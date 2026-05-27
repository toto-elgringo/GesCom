using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using GesCom.BO;

namespace GesCom.DAL
{
    public class ProvenanceDAL
    {
        private static ProvenanceDAL uneProvenanceDAL;

        public static ProvenanceDAL GetUneProvenanceDAL()
        {
            if (uneProvenanceDAL == null)
            {
                uneProvenanceDAL = new ProvenanceDAL();
            }
            return uneProvenanceDAL;
        }

        public List<Provenance> GetListProvenances()
        {
            List<Provenance> provenances = new List<Provenance>();
            string query = "SELECT id_prov, libelle_prov, coefficient_prov FROM Provenance ORDER BY libelle_prov";

            using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand(query, connexion);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Provenance provenance = new Provenance(
                        reader.GetInt32(reader.GetOrdinal("id_prov")),
                        reader.GetString(reader.GetOrdinal("libelle_prov")),
                        (float)reader.GetDecimal(reader.GetOrdinal("coefficient_prov"))
                    );
                    provenances.Add(provenance);
                }
                reader.Close();
            }

            return provenances;
        }

        public Provenance GetProvenanceByCode(int code)
        {
            Provenance provenance = null;
            string query = "SELECT id_prov, libelle_prov, coefficient_prov FROM Provenance WHERE id_prov = @Code";

            using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand(query, connexion);
                cmd.Parameters.AddWithValue("@Code", code);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    provenance = new Provenance(
                        reader.GetInt32(reader.GetOrdinal("id_prov")),
                        reader.GetString(reader.GetOrdinal("libelle_prov")),
                        (float)reader.GetDecimal(reader.GetOrdinal("coefficient_prov"))
                    );
                }
                reader.Close();
            }

            return provenance;
        }
    }
}
