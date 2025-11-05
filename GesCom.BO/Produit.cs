using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesCom.BO
{
    public class Produit
    {
        private int code;
        private string libelle;
        private Categorie categorie;
        private float prixVenteHT;

        public Produit(int code, string libelle, Categorie categorie, float prixVenteHT)
        {
            this.code = code;
            this.libelle = libelle;
            this.categorie = categorie;
            this.prixVenteHT = prixVenteHT;
        }

        public int Code
        {
            get { return this.code; }
            set { this.code = value; }
        }

        public string Libelle
        {
            get { return this.libelle; }
            set { this.libelle = value; }
        }

        public Categorie Categorie
        {
            get { return this.categorie; }
            set { this.categorie = value; }
        }

        public float PrixVenteHT
        {
            get { return this.prixVenteHT; }
            set { this.prixVenteHT = value; }
        }
    }
}
