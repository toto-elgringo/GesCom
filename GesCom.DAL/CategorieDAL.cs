
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using GesCom.BO;

namespace GesCom.DAL
{
    public class CategorieDAL
    {
        private static CategorieDAL uneCategorieDAL;

        public static CategorieDAL GetUneCategorieDAL()
        {
            if (uneCategorieDAL == null)
            {
                uneCategorieDAL = new CategorieDAL();
            }
            return uneCategorieDAL;
        }

        public List<Categorie> GetListCategories()
        {
            List<Categorie> categories = new List<Categorie>();
            string query = "SELECT code_categ, nom_categ FROM Categorie ORDER BY nom_categ";

            using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand(query, connexion);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Categorie categorie = new Categorie(
                        reader.GetInt32(reader.GetOrdinal("code_categ")),
                        reader.GetString(reader.GetOrdinal("nom_categ"))
                    );
                    categories.Add(categorie);
                }
                reader.Close();
            }

            return categories;
        }

        public Categorie GetCategorieByCode(int code)
        {
            Categorie categorie = null;
            string query = "SELECT code_categ, nom_categ FROM Categorie WHERE code_categ = @Code";

            using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand(query, connexion);
                cmd.Parameters.AddWithValue("@Code", code);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    categorie = new Categorie(
                        reader.GetInt32(reader.GetOrdinal("code_categ")),
                        reader.GetString(reader.GetOrdinal("nom_categ"))
                    );
                }
                reader.Close();
            }

            return categorie;
        }
    }
}
