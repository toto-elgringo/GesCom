using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesCom.BO
{
    public class Devis
    {
        private int code;
        private DateTime date;
        private float tauxTVA;
        private float tauxRemiseGlobal;
        private Client client;
        private Statut statut;
        private List<ContenirDevis> lignes;

        public Devis(int code, DateTime date, float tauxTVA, float tauxRemiseGlobal,
                     Client client, Statut statut)
        {
            this.code = code;
            this.date = date;
            this.tauxTVA = tauxTVA;
            this.tauxRemiseGlobal = tauxRemiseGlobal;
            this.client = client;
            this.statut = statut;
            this.lignes = new List<ContenirDevis>();
        }

        // Propriétés de base
        public int Code
        {
            get { return code; }
            set { code = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public float TauxTVA
        {
            get { return tauxTVA; }
            set { tauxTVA = value; }
        }

        public float TauxRemiseGlobal
        {
            get { return tauxRemiseGlobal; }
            set { tauxRemiseGlobal = value; }
        }

        public Client Client
        {
            get { return client; }
            set { client = value; }
        }

        public Statut Statut
        {
            get { return statut; }
            set { statut = value; }
        }

        public List<ContenirDevis> Lignes
        {
            get { return lignes; }
            set { lignes = value; }
        }

        // Propriétés calculées
        public float MontantHTHorsRemiseGlobale
        {
            get
            {
                float total = 0;
                foreach (ContenirDevis ligne in lignes)
                {
                    total += ligne.MontantHTAvecRemise;
                }
                return total;
            }
        }

        public float MontantRemiseGlobale
        {
            get { return MontantHTHorsRemiseGlobale * (tauxRemiseGlobal / 100); }
        }

        public float MontantHT
        {
            get { return MontantHTHorsRemiseGlobale - MontantRemiseGlobale; }
        }

        public float MontantTVA
        {
            get { return MontantHT * (tauxTVA / 100); }
        }

        public float MontantTTC
        {
            get { return MontantHT + MontantTVA; }
        }
    }
}