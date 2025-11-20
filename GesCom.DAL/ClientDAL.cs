using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using GesCom.BO;

namespace GesCom.DAL
{
    public class ClientDAL
    {
        private static ClientDAL unClientDAL;

        // récupération d'une instance de la classe
        public static ClientDAL GetUnClientDAL()
        {
            if (unClientDAL == null)
            {
                unClientDAL = new ClientDAL();
            }
            return unClientDAL;
        }

        // liste de tous les clients de la table clients dans la BDD
        public List<Client> GetListClients()
        {
            List<Client> clients = new List<Client>();
            string query = "SELECT * FROM Clients";

            using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
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
                    clients.Add(client);
                }
                reader.Close();
            }

            return clients;
        }

        // fonction de recherche d'informations d'un seul client grâce à son code_client
        public Client GetClientByCode(int codeClient)
        {
            Client client = null;
            string query = "SELECT * FROM CLIENTS WHERE code_cli = @code";

            using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand(query, connexion);
                cmd.Parameters.AddWithValue("@code", codeClient);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    client = new Client(
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
                }
                reader.Close();
            }

            return client;
        }

        // fonction d'ajout d'un nouveau client dans la BDD
        public bool AddClient(Client client)
        {
            bool result = false;
            string query = @"INSERT INTO CLIENTS (nom_cli, numRueFact_cli, rueFact_cli, villeFact_cli, codePostFact_cli,
                            numRueLivr_cli, rueLivr_cli, villeLivr_cli, codePostLivr_cli, numTel_cli, numFax_cli, mail_cli)
                            VALUES (@nom, @numRueFact, @rueFact, @villeFact, @codePostFact,
                            @numRueLivr, @rueLivr, @villeLivr, @codePostLivr, @numTel, @numFax, @mail)";

            try
            {
                using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
                {
                    SqlCommand cmd = new SqlCommand(query, connexion);
                    cmd.Parameters.AddWithValue("@nom", client.Nom);
                    cmd.Parameters.AddWithValue("@numRueFact", client.NumRueFact);
                    cmd.Parameters.AddWithValue("@rueFact", client.RueFact);
                    cmd.Parameters.AddWithValue("@villeFact", client.VilleFact);
                    cmd.Parameters.AddWithValue("@codePostFact", client.CodePostFact);
                    cmd.Parameters.AddWithValue("@numRueLivr", client.NumRueLivr);
                    cmd.Parameters.AddWithValue("@rueLivr", client.RueLivr);
                    cmd.Parameters.AddWithValue("@villeLivr", client.VilleLivr);
                    cmd.Parameters.AddWithValue("@codePostLivr", client.CodePostLivr);
                    cmd.Parameters.AddWithValue("@numTel", client.NumTel);
                    cmd.Parameters.AddWithValue("@numFax", client.NumFax);
                    cmd.Parameters.AddWithValue("@mail", client.Mail);

                    // verification si la requete a fonctionne, 0 = ko, 1 = ok
                    int rowsAffected = cmd.ExecuteNonQuery();
                    result = (rowsAffected > 0);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'ajout du client : " + ex.Message);
            }

            return result;
        }

        // fonction de modification d'un client déjà existant
        public bool UpdateClient(Client client)
        {
            bool result = false;
            string query = @"UPDATE CLIENTS SET nom_cli = @nom, numRueFact_cli = @numRueFact, rueFact_cli = @rueFact,
                            villeFact_cli = @villeFact, codePostFact_cli = @codePostFact, numRueLivr_cli = @numRueLivr,
                            rueLivr_cli = @rueLivr, villeLivr_cli = @villeLivr, codePostLivr_cli = @codePostLivr,
                            numTel_cli = @numTel, numFax_cli = @numFax, mail_cli = @mail
                            WHERE code_cli = @code";

            try
            {
                using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
                {
                    SqlCommand cmd = new SqlCommand(query, connexion);
                    cmd.Parameters.AddWithValue("@code", client.Code);
                    cmd.Parameters.AddWithValue("@nom", client.Nom);
                    cmd.Parameters.AddWithValue("@numRueFact", client.NumRueFact);
                    cmd.Parameters.AddWithValue("@rueFact", client.RueFact);
                    cmd.Parameters.AddWithValue("@villeFact", client.VilleFact);
                    cmd.Parameters.AddWithValue("@codePostFact", client.CodePostFact);
                    cmd.Parameters.AddWithValue("@numRueLivr", client.NumRueLivr);
                    cmd.Parameters.AddWithValue("@rueLivr", client.RueLivr);
                    cmd.Parameters.AddWithValue("@villeLivr", client.VilleLivr);
                    cmd.Parameters.AddWithValue("@codePostLivr", client.CodePostLivr);
                    cmd.Parameters.AddWithValue("@numTel", client.NumTel);
                    cmd.Parameters.AddWithValue("@numFax", client.NumFax);
                    cmd.Parameters.AddWithValue("@mail", client.Mail);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    result = (rowsAffected > 0);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la modification du client : " + ex.Message);
            }

            return result;
        }

        // fonction de suppression d'un client seulement si il n'est pas lié à un devis
        public bool DeleteClient(int codeClient)
        {
            bool result = false;

            try
            {
                using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
                {
                    string deleteQuery = "DELETE FROM CLIENTS WHERE code_cli = @code";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, connexion);
                    deleteCmd.Parameters.AddWithValue("@code", codeClient);

                    int rowsAffected = deleteCmd.ExecuteNonQuery();
                    result = (rowsAffected > 0);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la suppression du client : " + ex.Message);
            }

            return result;
        }

        public bool IsCLientInDevis(int codeClient)
        {
            string query = "SELECT COUNT(*) FROM Devis WHERE code_cli = @CodeClient";

            using (SqlConnection connexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand(query, connexion);
                cmd.Parameters.AddWithValue("@CodeClient", codeClient);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }
}
