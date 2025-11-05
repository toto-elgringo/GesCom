using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using GesCom.BO;


namespace GesCom.DAL
{
    public class UserDAL
    {

        private static UserDAL unUserDal;
        
        public static UserDAL GetUnUserDAL()
        {
            if(unUserDal == null)
            {
                unUserDal = new UserDAL();
            }

            return unUserDal
        }

        public List<Users> GetListUsers()
        {
            List<Users> users = new List<Users>();
            string query = "SELECT * FROM USERS";

            using (SqlConnection connexion = ConnexionDB.GetConnexionDB().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand(query, connexion);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User(
                        reader.GetInt32(),
                        reader.GetString(),
                        reader.GetString()
                        );
                    users.Add(user);
                }
                reader.Close();
            }

            return users;
        }
    }
}
