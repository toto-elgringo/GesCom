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
            ProduitDAL.GetUnProduitDAL().AddProduit(produit);
        }

        public void ModifierProduit(Produit produit)
        {
            

            GetListeProduits();
            if (listProduits.Any(p => p.Code != produit.Code && p.Libelle.Trim().ToLower() == produit.Libelle.Trim().ToLower()))
            {
                throw new InvalidOperationException("Un autre produit avec ce libellé existe déjà.");
            }

            ProduitDAL.GetUnProduitDAL().UpdateProduit(produit);
        }

        public void SupprimerProduit(int code)
        {
            ProduitDAL.GetUnProduitDAL().DeleteProduit(code);
        }
    }
}