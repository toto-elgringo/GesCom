using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesCom.BO
{
    public class TVA
    {
        private int idTva;
        private string nomPays;
        private float tauxTva;

        public TVA(int idTva, string nomPays, float tauxTva)
        {
            this.idTva = idTva;
            this.nomPays = nomPays;
            this.tauxTva = tauxTva;
        }

        public int IdTva
        {
            get { return idTva; }
            set { idTva = value; }
        }

        public string NomPays
        {
            get { return nomPays; }
            set { nomPays = value; }
        }

        public float TauxTva
        {
            get { return tauxTva; }
            set { tauxTva = value; }
        }

        public override string ToString()
        {
            return nomPays;
        }
    }
}
