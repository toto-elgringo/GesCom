using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace GesCom.DAL
{
    public class ConnexionBD
    {
        private SqlConnection maConnexion;
        private static ConnexionBD uneConnexionBD;
        private string chaineConnexion;

        // Constructeur privé (Singleton)
        private ConnexionBD()
        {
            // Chaîne de connexion vers SQL Server
            chaineConnexion = "Data Source=localhost;Initial Catalog=Gestion_Commerciale;Integrated Security=True;";
        }

        // Accesseur statique pour obtenir l'instance unique
        public static ConnexionBD GetConnexionBD()
        {
            if (uneConnexionBD == null)
            {
                uneConnexionBD = new ConnexionBD();
            }
            return uneConnexionBD;
        }

        // Getter de la chaîne de connexion
        public string GetchaineConnexion()
        {
            return chaineConnexion;
        }

        // Setter de la chaîne de connexion
        public void SetchaineConnexion(string ch)
        {
            chaineConnexion = ch;
        }

        // Méthode pour obtenir la connexion SQL
        public SqlConnection GetSqlConnexion()
        {
            if (maConnexion == null)
            {
                maConnexion = new SqlConnection();
            }
            maConnexion.ConnectionString = chaineConnexion;

            // Si la connexion est fermée, on l'ouvre
            if (maConnexion.State == System.Data.ConnectionState.Closed)
            {
                maConnexion.Open();
            }
            return maConnexion;
        }

        // Méthode pour fermer la connexion
        public void CloseConnexion()
        {
            if (this.maConnexion != null &&
                this.maConnexion.State != System.Data.ConnectionState.Closed)
            {
                this.maConnexion.Close();
            }
        }
    }
}
