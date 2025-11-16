using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesCom.BO
{
    public class Client
    {
        private int code;
        private string nom;
        private int numRueFact;
        private string rueFact;
        private string villeFact;
        private int codePostFact;
        private int numRueLivr;
        private string rueLivr;
        private string villeLivr;
        private int codePostLivr;
        private int numTel;
        private int numFax;
        private string mail;

        public Client(int code, string nom, int numRueFact, string rueFact, string villeFact, int codePostFact, int numRueLivr,
                        string rueLivr, string villeLivr, int codePostLivr, int numTel, int numFax, string mail) {

            this.code = code;
            this.nom = nom;
            this.numRueFact = numRueFact;
            this.rueFact = rueFact;
            this.villeFact = villeFact;
            this.codePostFact = codePostFact;
            this.numRueLivr = numRueLivr;
            this.rueLivr = rueLivr;
            this.villeLivr = villeLivr;
            this.codePostLivr = codePostLivr;
            this.numTel = numTel;
            this.numFax = numFax;
            this.mail = mail;
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

        public int NumRueFact
        {
            get { return numRueFact; }
            set { numRueFact = value; }
        }

        public string RueFact
        {
            get { return rueFact; }
            set { rueFact = value; }
        }

        public string VilleFact
        {
            get { return villeFact; }
            set { villeFact = value; }
        }

        public int CodePostFact
        {
            get { return codePostFact; }
            set { codePostFact = value; }
        }

        public int NumRueLivr
        {
            get { return numRueLivr; }
            set { numRueLivr = value; }
        }

        public string RueLivr
        {
            get { return rueLivr; }
            set { rueLivr = value; }
        }

        public string VilleLivr
        {
            get { return villeLivr; }
            set { villeLivr = value; }
        }

        public int CodePostLivr
        {
            get { return codePostLivr; }
            set { codePostLivr = value; }
        }

        public int NumTel
        {
            get { return numTel; }
            set { numTel = value; }
        }

        public int NumFax
        {
            get { return numFax; }
            set { numFax = value; }
        }

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
    }
}