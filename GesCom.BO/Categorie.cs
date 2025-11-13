using System;

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
            get { return code; }
            set { code = value; }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public override string ToString()
        {
            return nom;
        }
    }
}
