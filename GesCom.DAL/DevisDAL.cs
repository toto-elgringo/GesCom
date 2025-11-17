using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using GesCom.BO;

namespace GesCom.DAL
{
    public class DevisDAL
    {
        private static DevisDAL unDevisDAL;

        // récupération d'une instance de la classe
        public static DevisDAL GetUnDevisDAL()
        {
            if (unDevisDAL == null)
            {
                unDevisDAL = new DevisDAL();
            }
            return unDevisDAL;
        }

        // liste de tous les devis de la table devis dans la BDD
        public List<Devis> GetListDevis()
        {
            List<Devis> devisList = new List<Devis>();
            string query = @"SELECT D.code_devis, D.date_devis, D.tauxTVA, D.tauxRemiseGlobal,
                            C.code, C.nom, C.numRueFact, C.rueFact, C.villeFact, C.codePostFact,
                            C.numRueLivr, C.rueLivr, C.villeLivr, C.codePostLivr, C.numTel, C.numFax, C.mail,
                            S.code_statut, S.nom_statut
                            FROM DEVIS D
                            INNER JOIN CLIENTS C ON D.code_client = C.code
                            INNER JOIN STATUTS S ON D.code_statut = S.code_statut";

            using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand(query, connexion);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Client client = new Client(
                        reader.GetInt32(reader.GetOrdinal("code")),
                        reader.GetString(reader.GetOrdinal("nom")),
                        reader.GetInt32(reader.GetOrdinal("numRueFact")),
                        reader.GetString(reader.GetOrdinal("rueFact")),
                        reader.GetString(reader.GetOrdinal("villeFact")),
                        reader.GetInt32(reader.GetOrdinal("codePostFact")),
                        reader.GetInt32(reader.GetOrdinal("numRueLivr")),
                        reader.GetString(reader.GetOrdinal("rueLivr")),
                        reader.GetString(reader.GetOrdinal("villeLivr")),
                        reader.GetInt32(reader.GetOrdinal("codePostLivr")),
                        reader.GetInt32(reader.GetOrdinal("numTel")),
                        reader.GetInt32(reader.GetOrdinal("numFax")),
                        reader.GetString(reader.GetOrdinal("mail"))
                    );

                    Statut statut = new Statut();
                    statut.Code = reader.GetInt32(reader.GetOrdinal("code_statut"));
                    statut.Name = reader.GetString(reader.GetOrdinal("nom_statut"));

                    Devis devis = new Devis(
                        reader.GetInt32(reader.GetOrdinal("code_devis")),
                        reader.GetDateTime(reader.GetOrdinal("date_devis")),
                        (float)reader.GetDecimal(reader.GetOrdinal("tauxTVA")),
                        (float)reader.GetDecimal(reader.GetOrdinal("tauxRemiseGlobal")),
                        client,
                        statut
                    );

                    devis.Lignes = GetProduitsDevis(devis.Code);

                    devisList.Add(devis);
                }
                reader.Close();
            }

            return devisList;
        }

        // fonction de recherche d'informations d'un seul devis grâce à son code
        public Devis GetDevisByCode(int code)
        {
            Devis devis = null;
            string query = @"SELECT D.code_devis, D.date_devis, D.tauxTVA, D.tauxRemiseGlobal,
                            C.code, C.nom, C.numRueFact, C.rueFact, C.villeFact, C.codePostFact,
                            C.numRueLivr, C.rueLivr, C.villeLivr, C.codePostLivr, C.numTel, C.numFax, C.mail,
                            S.code_statut, S.nom_statut
                            FROM DEVIS D
                            INNER JOIN CLIENTS C ON D.code_client = C.code
                            INNER JOIN STATUTS S ON D.code_statut = S.code_statut
                            WHERE D.code_devis = @code";

            using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand(query, connexion);
                cmd.Parameters.AddWithValue("@code", code);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Client client = new Client(
                        reader.GetInt32(reader.GetOrdinal("code")),
                        reader.GetString(reader.GetOrdinal("nom")),
                        reader.GetInt32(reader.GetOrdinal("numRueFact")),
                        reader.GetString(reader.GetOrdinal("rueFact")),
                        reader.GetString(reader.GetOrdinal("villeFact")),
                        reader.GetInt32(reader.GetOrdinal("codePostFact")),
                        reader.GetInt32(reader.GetOrdinal("numRueLivr")),
                        reader.GetString(reader.GetOrdinal("rueLivr")),
                        reader.GetString(reader.GetOrdinal("villeLivr")),
                        reader.GetInt32(reader.GetOrdinal("codePostLivr")),
                        reader.GetInt32(reader.GetOrdinal("numTel")),
                        reader.GetInt32(reader.GetOrdinal("numFax")),
                        reader.GetString(reader.GetOrdinal("mail"))
                    );

                    Statut statut = new Statut();
                    statut.Code = reader.GetInt32(reader.GetOrdinal("code_statut"));
                    statut.Name = reader.GetString(reader.GetOrdinal("nom_statut"));

                    devis = new Devis(
                        reader.GetInt32(reader.GetOrdinal("code_devis")),
                        reader.GetDateTime(reader.GetOrdinal("date_devis")),
                        (float)reader.GetDecimal(reader.GetOrdinal("tauxTVA")),
                        (float)reader.GetDecimal(reader.GetOrdinal("tauxRemiseGlobal")),
                        client,
                        statut
                    );

                    reader.Close();

                    devis.Lignes = GetProduitsDevis(devis.Code);
                }
                else
                {
                    reader.Close();
                }
            }

            return devis;
        }

        // fonction privée pour récupérer les produits d'un devis
        private List<ContenirDevis> GetProduitsDevis(int codeDevis)
        {
            List<ContenirDevis> lignes = new List<ContenirDevis>();
            string query = @"SELECT code_devis, code_prod, quantite, remise
                            FROM CONTENIR
                            WHERE code_devis = @codeDevis";

            // Liste temporaire pour stocker les données avant de créer les objets ContenirDevis
            List<Tuple<int, int, int, float>> tempData = new List<Tuple<int, int, int, float>>();

            using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand(query, connexion);
                cmd.Parameters.AddWithValue("@codeDevis", codeDevis);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    tempData.Add(new Tuple<int, int, int, float>(
                        reader.GetInt32(reader.GetOrdinal("code_devis")),
                        reader.GetInt32(reader.GetOrdinal("code_prod")),
                        reader.GetInt32(reader.GetOrdinal("quantite")),
                        (float)reader.GetDecimal(reader.GetOrdinal("remise"))
                    ));
                }
                reader.Close();
            }

            // Maintenant on récupère les produits et on crée les objets ContenirDevis
            foreach (var data in tempData)
            {
                Produit produit = ProduitDAL.GetUnProduitDAL().GetProduitByCode(data.Item2);
                ContenirDevis ligne = new ContenirDevis(
                    data.Item1, // code_devis
                    produit,
                    data.Item3, // quantite
                    data.Item4  // remise
                );
                lignes.Add(ligne);
            }

            return lignes;
        }

        // fonction d'ajout d'un nouveau devis dans la BDD
        public bool AddDevis(Devis devis)
        {
            bool result = false;
            string query = @"INSERT INTO DEVIS (code_devis, date_devis, tauxTVA, tauxRemiseGlobal, code_client, code_statut)
                            VALUES (@code, @date, @tauxTVA, @tauxRemiseGlobal, @codeClient, @codeStatut)";

            try
            {
                using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
                {
                    SqlCommand cmd = new SqlCommand(query, connexion);
                    cmd.Parameters.AddWithValue("@code", devis.Code);
                    cmd.Parameters.AddWithValue("@date", devis.Date);
                    cmd.Parameters.AddWithValue("@tauxTVA", devis.TauxTVA);
                    cmd.Parameters.AddWithValue("@tauxRemiseGlobal", devis.TauxRemiseGlobal);
                    cmd.Parameters.AddWithValue("@codeClient", devis.Client.Code);
                    cmd.Parameters.AddWithValue("@codeStatut", devis.Statut.Code);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    result = (rowsAffected > 0);

                    if (result)
                    {
                        AddProduitsInDevis(devis);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'ajout du devis : " + ex.Message);
            }

            return result;
        }

        // fonction de modification d'un devis déjà existant
        public bool UpdateDevis(Devis devis)
        {
            bool result = false;
            string query = @"UPDATE DEVIS SET date_devis = @date, tauxTVA = @tauxTVA,
                            tauxRemiseGlobal = @tauxRemiseGlobal, code_client = @codeClient,
                            code_statut = @codeStatut
                            WHERE code_devis = @code";

            try
            {
                using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
                {
                    SqlCommand cmd = new SqlCommand(query, connexion);
                    cmd.Parameters.AddWithValue("@code", devis.Code);
                    cmd.Parameters.AddWithValue("@date", devis.Date);
                    cmd.Parameters.AddWithValue("@tauxTVA", devis.TauxTVA);
                    cmd.Parameters.AddWithValue("@tauxRemiseGlobal", devis.TauxRemiseGlobal);
                    cmd.Parameters.AddWithValue("@codeClient", devis.Client.Code);
                    cmd.Parameters.AddWithValue("@codeStatut", devis.Statut.Code);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    result = (rowsAffected > 0);

                    if (result)
                    {
                        UpdateProduitsInDevis(devis);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la modification du devis : " + ex.Message);
            }

            return result;
        }

        // fonction de suppression d'un devis
        public bool DeleteDevis(int code)
        {
            bool result = false;

            try
            {
                using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
                {
                    // Suppression d'abord des produits liés au devis
                    string deleteProduitsQuery = "DELETE FROM CONTENIR WHERE code_devis = @code";
                    SqlCommand deleteProdCmd = new SqlCommand(deleteProduitsQuery, connexion);
                    deleteProdCmd.Parameters.AddWithValue("@code", code);
                    deleteProdCmd.ExecuteNonQuery();

                    // Puis suppression du devis
                    string deleteDevisQuery = "DELETE FROM DEVIS WHERE code_devis = @code";
                    SqlCommand deleteDevisCmd = new SqlCommand(deleteDevisQuery, connexion);
                    deleteDevisCmd.Parameters.AddWithValue("@code", code);

                    int rowsAffected = deleteDevisCmd.ExecuteNonQuery();
                    result = (rowsAffected > 0);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la suppression du devis : " + ex.Message);
            }

            return result;
        }

        // ajout des infos de la liste du Devis passé en paramètre dans la table contenir
        public void AddProduitsInDevis(Devis devis)
        {
            try
            {
                using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
                {
                    foreach (ContenirDevis ligne in devis.Lignes)
                    {
                        string query = @"INSERT INTO CONTENIR (code_devis, code_prod, quantite, remise)
                                        VALUES (@codeDevis, @codeProd, @quantite, @remise)";

                        SqlCommand cmd = new SqlCommand(query, connexion);
                        cmd.Parameters.AddWithValue("@codeDevis", devis.Code);
                        cmd.Parameters.AddWithValue("@codeProd", ligne.Produit.Code);
                        cmd.Parameters.AddWithValue("@quantite", ligne.Quantite);
                        cmd.Parameters.AddWithValue("@remise", ligne.Remise);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'ajout des produits au devis : " + ex.Message);
            }
        }

        // suppression puis rajout des lignes du devis dans la table contenir
        public void UpdateProduitsInDevis(Devis devis)
        {
            try
            {
                using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
                {
                    // Suppression d'abord de toutes les lignes du devis
                    string deleteQuery = "DELETE FROM CONTENIR WHERE code_devis = @codeDevis";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, connexion);
                    deleteCmd.Parameters.AddWithValue("@codeDevis", devis.Code);
                    deleteCmd.ExecuteNonQuery();
                }

                // Puis ajout des nouvelles lignes
                AddProduitsInDevis(devis);
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la mise à jour des produits du devis : " + ex.Message);
            }
        }

        // suppression des lignes de la table contenir pour un devis donné
        public void DeleteProduitsInDevis(Devis devis)
        {
            try
            {
                using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
                {
                    foreach (ContenirDevis ligne in devis.Lignes)
                    {
                        string query = "DELETE FROM CONTENIR WHERE code_devis = @codeDevis AND code_prod = @codeProd";
                        SqlCommand cmd = new SqlCommand(query, connexion);
                        cmd.Parameters.AddWithValue("@codeDevis", devis.Code);
                        cmd.Parameters.AddWithValue("@codeProd", ligne.Produit.Code);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la suppression des produits du devis : " + ex.Message);
            }
        }
    }
}
