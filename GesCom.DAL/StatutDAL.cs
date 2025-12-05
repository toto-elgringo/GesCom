
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using GesCom.BO;

namespace GesCom.DAL
{
    public class StatutDAL
    {
        private static StatutDAL unStatutDAL;

        public static StatutDAL GetUnStatutDAL()
        {
            if (unStatutDAL == null)
            {
                unStatutDAL = new StatutDAL();
            }
            return unStatutDAL;
        }

        public List<Statut> GetListStatut()
        {
            List<Statut> statuts = new List<Statut>();
            string query = "SELECT code_sta, nom_sta FROM Statut ORDER BY nom_sta";

            using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand(query, connexion);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Statut statut = new Statut(
                        reader.GetInt32(reader.GetOrdinal("code_sta")),
                        reader.GetString(reader.GetOrdinal("nom_sta"))
                    );
                    statuts.Add(statut);
                }
                reader.Close();
            }

            return statuts;
        }

        public Statut GetStatutByCode(int code)
        {
            Statut statut = null;
            string query = "SELECT code_sta, nom_sta FROM Statut WHERE code_sta = @Code";

            using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand(query, connexion);
                cmd.Parameters.AddWithValue("@Code", code);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    statut = new Statut(
                        reader.GetInt32(reader.GetOrdinal("code_sta")),
                        reader.GetString(reader.GetOrdinal("nom_sta"))
                    );
                }
                reader.Close();
            }

            return statut;
        }
    }
}

