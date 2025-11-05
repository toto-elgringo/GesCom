using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GesCom.DAL;
using System.Data.SqlClient;

namespace GesCom.GUI
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Test de connexion à la base de données
            try
            {
                ConnexionBD connexion = ConnexionBD.GetConnexionBD();
                SqlConnection sqlConn = connexion.GetSqlConnexion();
                MessageBox.Show("Connexion à la base de données réussie !",
                                "Test de connexion",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                connexion.CloseConnexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de connexion à la base de données :\n\n" + ex.Message,
                                "Erreur de connexion",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return; // Arrête l'application si la connexion échoue
            }

            Application.Run(new FrmLogin());
        }
    }
}
