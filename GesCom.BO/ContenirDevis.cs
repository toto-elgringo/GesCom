using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesCom.BO
{
    public class ContenirDevis
    {
        private int codeDevis;
        private Produit produit;
        private int quantite;
        private float remise; 

        public ContenirDevis(int codeDevis, Produit produit, int quantite, float remise)
        {
            this.codeDevis = codeDevis;
            this.produit = produit;
            this.quantite = quantite;
            this.remise = remise;
        }

        public int CodeDevis
        {
            get { return codeDevis; }
            set { codeDevis = value; }
        }

        public Produit Produit
        {
            get { return produit; }
            set { produit = value; }
        }

        public int Quantite
        {
            get { return quantite; }
            set { quantite = value; }
        }

        public float Remise
        {
            get { return remise; }
            set { remise = value; }
        }

        // Propriétés calculées (
        public float PrixUnitaireHT
        {
            get { return produit.PrixVenteHT; }
        }

        public float MontantHTSansRemise
        {
            get { return produit.PrixVenteHT * quantite; }
        }

        public float MontantRemise
        {
            get { return MontantHTSansRemise * (remise / 100); }
        }

        public float MontantHTAvecRemise
        {
            get { return MontantHTSansRemise - MontantRemise; }
        }
    }
}
