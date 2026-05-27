using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using GesCom.BO;

namespace GesCom.DAL
{
    public class ProduitDAL
    {
        private static ProduitDAL unProduitDAL;

        public static ProduitDAL GetUnProduitDAL()
        {
            if (unProduitDAL == null)
            {
                unProduitDAL = new ProduitDAL();
            }
            return unProduitDAL;
        }

        public List<Produit> GetListProduits()
        {
            List<Produit> produits = new List<Produit>();
            string query = "SELECT P.code_prod, P.libelle_prod, P.prixHT_prod, P.id_prov, " +
                          "C.code_categ, C.nom_categ, " +
                          "PR.libelle_prov, PR.coefficient_prov " +
                          "FROM Produits P " +
                          "INNER JOIN Categorie C ON P.code_categ = C.code_categ " +
                          "LEFT JOIN Provenance PR ON P.id_prov = PR.id_prov " +
                          "ORDER BY C.code_categ";

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

                    Provenance provenance = null;
                    int ordIdProv = reader.GetOrdinal("id_prov");
                    if (!reader.IsDBNull(ordIdProv))
                    {
                        provenance = new Provenance(
                            reader.GetInt32(ordIdProv),
                            reader.GetString(reader.GetOrdinal("libelle_prov")),
                            (float)reader.GetDecimal(reader.GetOrdinal("coefficient_prov"))
                        );
                    }

                    Produit produit = new Produit(
                        reader.GetInt32(reader.GetOrdinal("code_prod")),
                        reader.GetString(reader.GetOrdinal("libelle_prod")),
                        categorie,
                        (float)reader.GetDecimal(reader.GetOrdinal("prixHT_prod")),
                        provenance
                    );
                    produits.Add(produit);
                }
                reader.Close();
            }

            return produits;
        }

        public Produit GetProduitByCode(int code)
        {
            Produit produit = null;
            string query = "SELECT P.code_prod, P.libelle_prod, P.prixHT_prod, P.id_prov, " +
                          "C.code_categ, C.nom_categ, " +
                          "PR.libelle_prov, PR.coefficient_prov " +
                          "FROM Produits P " +
                          "INNER JOIN Categorie C ON P.code_categ = C.code_categ " +
                          "LEFT JOIN Provenance PR ON P.id_prov = PR.id_prov " +
                          "WHERE P.code_prod = @Code";

            using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand(query, connexion);
                cmd.Parameters.AddWithValue("@Code", code);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Categorie categorie = new Categorie(
                        reader.GetInt32(reader.GetOrdinal("code_categ")),
                        reader.GetString(reader.GetOrdinal("nom_categ"))
                    );

                    Provenance provenance = null;
                    int ordIdProv = reader.GetOrdinal("id_prov");
                    if (!reader.IsDBNull(ordIdProv))
                    {
                        provenance = new Provenance(
                            reader.GetInt32(ordIdProv),
                            reader.GetString(reader.GetOrdinal("libelle_prov")),
                            (float)reader.GetDecimal(reader.GetOrdinal("coefficient_prov"))
                        );
                    }

                    produit = new Produit(
                        reader.GetInt32(reader.GetOrdinal("code_prod")),
                        reader.GetString(reader.GetOrdinal("libelle_prod")),
                        categorie,
                        (float)reader.GetDecimal(reader.GetOrdinal("prixHT_prod")),
                        provenance
                    );
                }
                reader.Close();
            }

            return produit;
        }

        public bool IsProduitInDevis(int codeProduit)
        {
            string query = "SELECT COUNT(*) FROM Contenir WHERE code_prod = @CodeProduit";

            using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand(query, connexion);
                cmd.Parameters.AddWithValue("@CodeProduit", codeProduit);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public void AddProduit(Produit produit)
        {
            string query = "INSERT INTO Produits (libelle_prod, code_categ, prixHT_prod, id_prov) " +
                          "VALUES (@Libelle, @CodeCategorie, @PrixHT, @CodeProvenance)";

            using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand(query, connexion);
                cmd.Parameters.AddWithValue("@Libelle", produit.Libelle);
                cmd.Parameters.AddWithValue("@CodeCategorie", produit.Categorie.Code);
                cmd.Parameters.AddWithValue("@PrixHT", produit.PrixVenteHT);
                if (produit.Provenance == null)
                {
                    cmd.Parameters.AddWithValue("@CodeProvenance", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@CodeProvenance", produit.Provenance.Code);
                }
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateProduit(Produit produit)
        {
            string query = "UPDATE Produits SET libelle_prod = @Libelle, " +
                          "code_categ = @CodeCategorie, prixHT_prod = @PrixHT, " +
                          "id_prov = @CodeProvenance " +
                          "WHERE code_prod = @Code";

            using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand(query, connexion);
                cmd.Parameters.AddWithValue("@Code", produit.Code);
                cmd.Parameters.AddWithValue("@Libelle", produit.Libelle);
                cmd.Parameters.AddWithValue("@CodeCategorie", produit.Categorie.Code);
                cmd.Parameters.AddWithValue("@PrixHT", produit.PrixVenteHT);
                if (produit.Provenance == null)
                {
                    cmd.Parameters.AddWithValue("@CodeProvenance", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@CodeProvenance", produit.Provenance.Code);
                }
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteProduit(int code)
        {
            string query = "DELETE FROM Produits WHERE code_prod = @Code";

            using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand(query, connexion);
                cmd.Parameters.AddWithValue("@Code", code);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
