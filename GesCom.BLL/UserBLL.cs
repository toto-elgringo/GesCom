using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Configuration;
using System.Threading.Tasks;
using GesCom.BO;
using GesCom.DAL;
using BCrypt.Net;

namespace GesCom.BLL
{
    public class UserBLL
    {
        private static UserBLL unUserBLL;
        private List<User> listUsers = new List<User>();

        public static UserBLL GetUserBLL()
        {
            if (unUserBLL == null)
            {
                unUserBLL = new UserBLL();
            }
            return unUserBLL;
        }

        public static void SetChaineConnexion(ConnectionStringSettings chset)
        {
            string chaine = chset.ConnectionString;
            ConnexionBD.GetConnexionBD().SetchaineConnexion(chaine);
        }

        public List<User> GetListeUtilisateurs()
        {
            listUsers = UserDAL.GetUnUserDAL().GetListUsers();
            return listUsers;
        }

        public bool CheckConnexion(string login, string password)
        {
            GetListeUtilisateurs();

            foreach (User user in listUsers)
            {
                if (user.Login == login && BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
