using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesCom.BO
{
    public class User
    {
        private int id;
        private string login;
        private string password;

        public User(int id, string login, string password)
        {
            this.id = id;
            this.login = login;
            this.password = password;
        }

        public int id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string login
        {
            get { return this.login; }
            set { this.login = value; }
        }

        public string password
        {
            get { return this.password; }
            set { this.password = value; }
        }
    }
}
