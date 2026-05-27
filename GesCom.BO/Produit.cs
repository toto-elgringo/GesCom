using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GesCom.BO
{
    public class Produit
    {
        private int code;
        private string libelle;
        private Categorie categorie;
        private float prixVenteHT;
        private Provenance provenance;

        public Produit(int code, string libelle, Categorie categorie, float prixVenteHT)
        {
            this.code = code;
            this.libelle = libelle;
            this.categorie = categorie;
            this.prixVenteHT = prixVenteHT;
            this.provenance = null;
        }

        public Produit(int code, string libelle, Categorie categorie, float prixVenteHT, Provenance provenance)
        {
            this.code = code;
            this.libelle = libelle;
            this.categorie = categorie;
            this.prixVenteHT = prixVenteHT;
            this.provenance = provenance;
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

        public Provenance Provenance
        {
            get { return this.provenance; }
            set { this.provenance = value; }
        }

        public float PrixVenteFinal
        {
            get
            {
                if (this.provenance == null)
                {
                    return this.prixVenteHT;
                }
                return this.prixVenteHT * this.provenance.Coefficient;
            }
        }

        public override string ToString()
        {
            return libelle;
        }
    }
}
