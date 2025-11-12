using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesCom.BO
{
    public class Categorie
    {
        private int code;
        private string nom;

        public Categorie(int code, string nom)
        {
            this.code = code;
            this.nom = nom;
        }

        public int Code
        {
            get { return this.code; }
            set { this.code = value; }
        }

        public string nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }
    }
}
