using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            string query = "SELECT P.Code, P.Libelle, P.PrixVenteHT, C.Code as CatCode, C.Libelle as CatLibelle " +
                          "FROM PRODUITS P " +
                          "INNER JOIN CATEGORIES C ON P.CodeCategorie = C.Code";

            using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand(query, connexion);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Categorie categorie = new Categorie(
                        reader.GetInt32(reader.GetOrdinal("CatCode")),
                        reader.GetString(reader.GetOrdinal("CatLibelle"))
                    );

                    Produit produit = new Produit(
                        reader.GetInt32(reader.GetOrdinal("Code")),
                        reader.GetString(reader.GetOrdinal("Libelle")),
                        categorie,
                        (float)reader.GetDecimal(reader.GetOrdinal("PrixVenteHT"))
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
            string query = "SELECT P.Code, P.Libelle, P.PrixVenteHT, C.Code as CatCode, C.Libelle as CatLibelle " +
                          "FROM PRODUITS P " +
                          "INNER JOIN CATEGORIES C ON P.CodeCategorie = C.Code " +
                          "WHERE P.Code = @Code";

            using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand(query, connexion);
                cmd.Parameters.AddWithValue("@Code", code);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Categorie categorie = new Categorie(
                        reader.GetInt32(reader.GetOrdinal("CatCode")),
                        reader.GetString(reader.GetOrdinal("CatLibelle"))
                    );

                    produit = new Produit(
                        reader.GetInt32(reader.GetOrdinal("Code")),
                        reader.GetString(reader.GetOrdinal("Libelle")),
                        categorie,
                        (float)reader.GetDecimal(reader.GetOrdinal("PrixVenteHT"))
                    );
                }
                reader.Close();
            }

            return produit;
        }

        public bool IsProduitInDevis(int codeProduit)
        {
            string query = "SELECT COUNT(*) FROM LIGNESDEVIS WHERE CodeProduit = @CodeProduit";

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
            string query = "INSERT INTO PRODUITS (Libelle, CodeCategorie, PrixVenteHT) " +
                          "VALUES (@Libelle, @CodeCategorie, @PrixVenteHT)";

            using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand(query, connexion);
                cmd.Parameters.AddWithValue("@Libelle", produit.Libelle);
                cmd.Parameters.AddWithValue("@CodeCategorie", produit.Categorie.Code);
                cmd.Parameters.AddWithValue("@PrixVenteHT", produit.PrixVenteHT);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateProduit(Produit produit)
        {
            string query = "UPDATE PRODUITS SET Libelle = @Libelle, CodeCategorie = @CodeCategorie, " +
                          "PrixVenteHT = @PrixVenteHT WHERE Code = @Code";

            using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand(query, connexion);
                cmd.Parameters.AddWithValue("@Code", produit.Code);
                cmd.Parameters.AddWithValue("@Libelle", produit.Libelle);
                cmd.Parameters.AddWithValue("@CodeCategorie", produit.Categorie.Code);
                cmd.Parameters.AddWithValue("@PrixVenteHT", produit.PrixVenteHT);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteProduit(int code)
        {
            string query = "DELETE FROM PRODUITS WHERE Code = @Code";

            using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand(query, connexion);
                cmd.Parameters.AddWithValue("@Code", code);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
