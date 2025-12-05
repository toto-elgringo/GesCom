using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesCom.BO
{
    public class Statut
    {
        private int code;
        private string name;

        public Statut(int code, string name)
        {
            this.code = code;
            this.name = name;
        }

        public int Code
        {
            get { return this.code; }
            set { this.code = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public override string ToString()
        {
            return name;
        }
    }
}
