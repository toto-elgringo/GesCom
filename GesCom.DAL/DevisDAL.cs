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
            string query = @"SELECT D.code_dev, D.date_dev, D.tauxTVA_dev, D.tauxRemiseGlobal_dev,
                            C.code_cli, C.nom_cli, C.numRueFact_cli, C.rueFact_cli, C.villeFact_cli, C.codePostFact_cli,
                            C.numRueLivr_cli, C.rueLivr_cli, C.villeLivr_cli, C.codePostLivr_cli, C.numTel_cli, C.numFax_cli, C.mail_cli,
                            S.code_sta, S.nom_sta
                            FROM Devis D
                            INNER JOIN Clients C ON D.code_cli = C.code_cli
                            INNER JOIN Statut S ON D.code_sta = S.code_sta";

            SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion();
            SqlCommand cmd = new SqlCommand(query, connexion);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Client client = new Client(
                    reader.GetInt32(reader.GetOrdinal("code_cli")),
                    reader.GetString(reader.GetOrdinal("nom_cli")),
                    reader.GetInt32(reader.GetOrdinal("numRueFact_cli")),
                    reader.GetString(reader.GetOrdinal("rueFact_cli")),
                    reader.GetString(reader.GetOrdinal("villeFact_cli")),
                    reader.GetInt32(reader.GetOrdinal("codePostFact_cli")),
                    reader.GetInt32(reader.GetOrdinal("numRueLivr_cli")),
                    reader.GetString(reader.GetOrdinal("rueLivr_cli")),
                    reader.GetString(reader.GetOrdinal("villeLivr_cli")),
                    reader.GetInt32(reader.GetOrdinal("codePostLivr_cli")),
                    reader.GetString(reader.GetOrdinal("numTel_cli")),
                    reader.GetString(reader.GetOrdinal("numFax_cli")),
                    reader.GetString(reader.GetOrdinal("mail_cli"))
                );

                Statut statut = new Statut(
                reader.GetInt32(reader.GetOrdinal("code_sta")),
                reader.GetString(reader.GetOrdinal("nom_sta"))
                );

                Devis devis = new Devis(
                    reader.GetInt32(reader.GetOrdinal("code_dev")),
                    reader.GetDateTime(reader.GetOrdinal("date_dev")),
                    (float)reader.GetDecimal(reader.GetOrdinal("tauxTVA_dev")),
                    (float)reader.GetDecimal(reader.GetOrdinal("tauxRemiseGlobal_dev")),
                    client,
                    statut
                );

                devisList.Add(devis);
            }
            reader.Close();

            // Récupérer les produits pour chaque devis après avoir fermé le reader
            foreach (Devis devis in devisList)
            {
                devis.Lignes = GetProduitsDevis(devis.Code);
            }

            return devisList;
        }

        // fonction de recherche d'informations d'un seul devis grâce à son code
        public Devis GetDevisByCode(int code)
        {
            Devis devis = null;
            string query = @"SELECT D.code_dev, D.date_dev, D.tauxTVA_dev, D.tauxRemiseGlobal_dev,
                            C.code_cli, C.nom_cli, C.numRueFact_cli, C.rueFact_cli, C.villeFact_cli, C.codePostFact_cli,
                            C.numRueLivr_cli, C.rueLivr_cli, C.villeLivr_cli, C.codePostLivr_cli, C.numTel_cli, C.numFax_cli, C.mail_cli,
                            S.code_sta, S.nom_sta
                            FROM Devis D
                            INNER JOIN Clients C ON D.code_cli = C.code_cli
                            INNER JOIN Statut S ON D.code_sta = S.code_sta
                            WHERE D.code_dev = @code";

            using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand(query, connexion);
                cmd.Parameters.AddWithValue("@code", code);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Client client = new Client(
                        reader.GetInt32(reader.GetOrdinal("code_cli")),
                        reader.GetString(reader.GetOrdinal("nom_cli")),
                        reader.GetInt32(reader.GetOrdinal("numRueFact_cli")),
                        reader.GetString(reader.GetOrdinal("rueFact_cli")),
                        reader.GetString(reader.GetOrdinal("villeFact_cli")),
                        reader.GetInt32(reader.GetOrdinal("codePostFact_cli")),
                        reader.GetInt32(reader.GetOrdinal("numRueLivr_cli")),
                        reader.GetString(reader.GetOrdinal("rueLivr_cli")),
                        reader.GetString(reader.GetOrdinal("villeLivr_cli")),
                        reader.GetInt32(reader.GetOrdinal("codePostLivr_cli")),
                        reader.GetString(reader.GetOrdinal("numTel_cli")),
                        reader.GetString(reader.GetOrdinal("numFax_cli")),
                        reader.GetString(reader.GetOrdinal("mail_cli"))
                    );

                    Statut statut = new Statut(
                    reader.GetInt32(reader.GetOrdinal("code_sta")),
                    reader.GetString(reader.GetOrdinal("nom_sta"))
                    );

                    devis = new Devis(
                        reader.GetInt32(reader.GetOrdinal("code_dev")),
                        reader.GetDateTime(reader.GetOrdinal("date_dev")),
                        (float)reader.GetDecimal(reader.GetOrdinal("tauxTVA_dev")),
                        (float)reader.GetDecimal(reader.GetOrdinal("tauxRemiseGlobal_dev")),
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
            string query = @"SELECT code_dev, code_prod, quantiteProduit, remiseProduit
                            FROM Contenir
                            WHERE code_dev = @codeDevis";

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
                        reader.GetInt32(reader.GetOrdinal("code_dev")),
                        reader.GetInt32(reader.GetOrdinal("code_prod")),
                        reader.GetInt32(reader.GetOrdinal("quantiteProduit")),
                        (float)reader.GetDecimal(reader.GetOrdinal("remiseProduit"))
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
            string query = @"INSERT INTO Devis (date_dev, tauxTVA_dev, tauxRemiseGlobal_dev,MontantHTHorsRemise_dev, code_cli, code_sta)
                            VALUES (@date, @tauxTVA, @tauxRemiseGlobal,@MontantHT, @codeClient, @codeStatut);
                            SELECT CAST(SCOPE_IDENTITY() AS INT);";

            try
            {
                using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
                {
                    SqlCommand cmd = new SqlCommand(query, connexion);
                    cmd.Parameters.AddWithValue("@date", devis.Date);
                    cmd.Parameters.AddWithValue("@tauxTVA", devis.TauxTVA);
                    cmd.Parameters.AddWithValue("@tauxRemiseGlobal", devis.TauxRemiseGlobal);
                    cmd.Parameters.AddWithValue("MontantHT", devis.MontantHTHorsRemiseGlobale);
                    cmd.Parameters.AddWithValue("@codeClient", devis.Client.Code);
                    cmd.Parameters.AddWithValue("@codeStatut", devis.Statut.Code);


                    object id = cmd.ExecuteScalar();
                    
                    devis.Code = Convert.ToInt32(id);
                    AddProduitsInDevis(devis);
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
            string query = @"UPDATE Devis SET date_dev = @date, tauxTVA_dev = @tauxTVA,
                            tauxRemiseGlobal_dev = @tauxRemiseGlobal, code_cli = @codeClient,
                            code_sta = @codeStatut
                            WHERE code_dev = @code";

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
                    string deleteProduitsQuery = "DELETE FROM Contenir WHERE code_dev = @code";
                    SqlCommand deleteProdCmd = new SqlCommand(deleteProduitsQuery, connexion);
                    deleteProdCmd.Parameters.AddWithValue("@code", code);
                    deleteProdCmd.ExecuteNonQuery();

                    // Puis suppression du devis
                    string deleteDevisQuery = "DELETE FROM Devis WHERE code_dev = @code";
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
                        string query = @"INSERT INTO Contenir (code_dev, code_prod, quantiteProduit, remiseProduit)
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
                    string deleteQuery = "DELETE FROM Contenir WHERE code_dev = @codeDevis";
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
                        string query = "DELETE FROM Contenir WHERE code_dev = @codeDevis AND code_prod = @codeProd";
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
