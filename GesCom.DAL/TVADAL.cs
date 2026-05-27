using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using GesCom.BO;

namespace GesCom.DAL
{
    public class TVADAL
    {
        private static TVADAL unTVADAL;

        public static TVADAL GetUnTVADAL()
        {
            if (unTVADAL == null)
            {
                unTVADAL = new TVADAL();
            }
            return unTVADAL;
        }

        public List<TVA> GetListTVA()
        {
            List<TVA> listeTVA = new List<TVA>();
            string query = "SELECT * FROM TVA";

            using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand(query, connexion);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TVA tva = new TVA(
                        reader.GetInt32(reader.GetOrdinal("code_tva")),
                        reader.GetString(reader.GetOrdinal("pays")),
                        (float)reader.GetDecimal(reader.GetOrdinal("taux"))
                    );
                    listeTVA.Add(tva);
                }
                reader.Close();
            }

            return listeTVA;
        }

        public TVA GetTVAById(int idTva)
        {
            TVA tva = null;
            string query = "SELECT * FROM TVA WHERE code_tva = @id";

            using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand(query, connexion);
                cmd.Parameters.AddWithValue("@id", idTva);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    tva = new TVA(
                        reader.GetInt32(reader.GetOrdinal("code_tva")),
                        reader.GetString(reader.GetOrdinal("pays")),
                        (float)reader.GetDecimal(reader.GetOrdinal("taux"))
                    );
                }
                reader.Close();
            }

            return tva;
        }
    }
}
