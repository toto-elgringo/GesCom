using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GesCom.BO;
using GesCom.DAL;

namespace GesCom.BLL
{
    public class ProduitBLL
    {
        private static ProduitBLL unProduitBLL;
        private List<Produit> listProduits = new List<Produit>();

        public static ProduitBLL GetUnProduitBLL()
        {
            if (unProduitBLL == null)
            {
                unProduitBLL = new ProduitBLL();
            }
            return unProduitBLL;
        }

        public List<Produit> GetListeProduits()
        {
            listProduits = ProduitDAL.GetUnProduitDAL().GetListProduits();
            return listProduits;
        }

        public Produit GetProduitByCode(int code)
        {
            return ProduitDAL.GetUnProduitDAL().GetProduitByCode(code);
        }

        public void AjouterProduit(Produit produit)
        {
            if (string.IsNullOrWhiteSpace(produit.Libelle))
            {
                throw new ArgumentException("Le libellé du produit ne peut pas être vide.");
            }

            if (produit.Libelle.Length > 100)
            {
                throw new ArgumentException("Le libellé du produit ne peut pas dépasser 100 caractères.");
            }

            if (produit.Categorie == null)
            {
                throw new ArgumentException("La catégorie du produit ne peut pas être nulle.");
            }

            if (produit.Categorie.Code <= 0)
            {
                throw new ArgumentException("Le code de la catégorie doit être valide.");
            }

            if (produit.PrixVenteHT <= 0)
            {
                throw new ArgumentException("Le prix de vente HT doit être supérieur à 0.");
            }

            if (produit.PrixVenteHT > 999999.99f)
            {
                throw new ArgumentException("Le prix de vente HT ne peut pas dépasser 999999.99.");
            }

            // Vérification de l'unicité du libellé
            GetListeProduits();
            if (listProduits.Any(p => p.Libelle.Trim().ToLower() == produit.Libelle.Trim().ToLower()))
            {
                throw new InvalidOperationException("Un produit avec ce libellé existe déjà.");
            }

            // Si toutes les validations passent, on ajoute le produit
            ProduitDAL.GetUnProduitDAL().AddProduit(produit);
        }

        public void ModifierProduit(Produit produit)
        {
            if (produit.Code <= 0)
            {
                throw new ArgumentException("Le code du produit doit être valide.");
            }

            Produit produitExistant = GetProduitByCode(produit.Code);
            if (produitExistant == null)
            {
                throw new InvalidOperationException("Le produit n'existe pas.");
            }

            if (string.IsNullOrWhiteSpace(produit.Libelle))
            {
                throw new ArgumentException("Le libellé du produit ne peut pas être vide.");
            }

            if (produit.Libelle.Length > 100)
            {
                throw new ArgumentException("Le libellé du produit ne peut pas dépasser 100 caractères.");
            }

            if (produit.Categorie == null)
            {
                throw new ArgumentException("La catégorie du produit ne peut pas être nulle.");
            }

            if (produit.Categorie.Code <= 0)
            {
                throw new ArgumentException("Le code de la catégorie doit être valide.");
            }

            if (produit.PrixVenteHT <= 0)
            {
                throw new ArgumentException("Le prix de vente HT doit être supérieur à 0.");
            }

            if (produit.PrixVenteHT > 999999.99f)
            {
                throw new ArgumentException("Le prix de vente HT ne peut pas dépasser 999999.99.");
            }

            GetListeProduits();
            if (listProduits.Any(p => p.Code != produit.Code && p.Libelle.Trim().ToLower() == produit.Libelle.Trim().ToLower()))
            {
                throw new InvalidOperationException("Un autre produit avec ce libellé existe déjà.");
            }

            ProduitDAL.GetUnProduitDAL().UpdateProduit(produit);
        }

        public void SupprimerProduit(int code)
        {
            if (code <= 0)
            {
                throw new ArgumentException("Le code du produit doit être valide.");
            }

            // Vérification de l'existence du produit
            Produit produitExistant = GetProduitByCode(code);
            if (produitExistant == null)
            {
                throw new InvalidOperationException("Le produit n'existe pas.");
            }

            // Vérification qu'il n'est pas lié à un devis
            if (ProduitDAL.GetUnProduitDAL().IsProduitInDevis(code))
            {
                throw new InvalidOperationException("Impossible de supprimer ce produit car il est lié à un ou plusieurs devis.");
            }

            ProduitDAL.GetUnProduitDAL().DeleteProduit(code);
        }
    }
}