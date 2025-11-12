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

            return unUserDal;
        }

        public List<User> GetListUsers()
        {
            List<User> users = new List<User>();
            string query = "SELECT * FROM USERS";

            using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand(query, connexion);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User(
                        reader.GetInt32(reader.GetOrdinal("id")),
                        reader.GetString(reader.GetOrdinal("username")),
                        reader.GetString(reader.GetOrdinal("password")
                        ));
                    users.Add(user);
                }
                reader.Close();
            }

            return users;
        }
    }
}
