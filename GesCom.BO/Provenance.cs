using System;

namespace GesCom.BO
{
    public class Provenance
    {
        private int code;
        private string libelle;
        private float coefficient;

        public Provenance(int code, string libelle, float coefficient)
        {
            this.code = code;
            this.libelle = libelle;
            this.coefficient = coefficient;
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

        public float Coefficient
        {
            get { return this.coefficient; }
            set { this.coefficient = value; }
        }

        public override string ToString()
        {
            return this.libelle;
        }
    }
}
