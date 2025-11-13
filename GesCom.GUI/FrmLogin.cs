using System;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using GesCom.BLL;

namespace GesCom.GUI
{
    public partial class FrmLogin : Form
    {
        private string loginPlaceholder = "Entrez votre login";
        private string passwordPlaceholder = "Entrez votre mot de passe";
        private bool isPasswordPlaceholder = true;
        private bool isLoginPlaceholder = true;

        public FrmLogin()
        {
            InitializeComponent();
            InitializePlaceholders();
        }

        private void InitializePlaceholders()
        {
            // Configuration initiale du placeholder pour le login
            txtLogin.Text = loginPlaceholder;
            txtLogin.ForeColor = Color.FromArgb(100, 100, 100);
            isLoginPlaceholder = true;

            // Configuration initiale du placeholder pour le mot de passe
            txtPassword.Text = passwordPlaceholder;
            txtPassword.ForeColor = Color.FromArgb(100, 100, 100);
            txtPassword.UseSystemPasswordChar = false;
            isPasswordPlaceholder = true;
        }

        private void txtLogin_Enter(object sender, EventArgs e)
        {
            if (isLoginPlaceholder)
            {
                txtLogin.Text = "";
                txtLogin.ForeColor = Color.FromArgb(33, 33, 33);
                isLoginPlaceholder = false;
            }
        }

        private void txtLogin_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                txtLogin.Text = loginPlaceholder;
                txtLogin.ForeColor = Color.FromArgb(100, 100, 100);
                isLoginPlaceholder = true;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (isPasswordPlaceholder)
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.FromArgb(33, 33, 33);
                txtPassword.UseSystemPasswordChar = true;
                isPasswordPlaceholder = false;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.Text = passwordPlaceholder;
                txtPassword.ForeColor = Color.FromArgb(100, 100, 100);
                isPasswordPlaceholder = true;
            }
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            // Validation des champs
            if (isLoginPlaceholder || string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                MessageBox.Show("Veuillez saisir votre identifiant.", "Erreur de saisie",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLogin.Focus();
                return;
            }

            if (isPasswordPlaceholder || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Veuillez saisir votre mot de passe.", "Erreur de saisie",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {
                ConnectionStringSettings chset = ConfigurationManager.ConnectionStrings["GestionCommerciale"];

                if (chset == null)
                {
                    MessageBox.Show("Erreur de configuration de la base de données.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                UserBLL.SetChaineConnexion(chset);

                UserBLL userBLL = UserBLL.GetUserBLL();
                bool isAuthenticated = userBLL.CheckConnexion(txtLogin.Text.Trim(), txtPassword.Text);

                if (isAuthenticated)
                {
                    MessageBox.Show("Connexion réussie ! Bienvenue dans GESCOM.", "Succès",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // TODO: Ouvrir le formulaire principal
                    // FormPrincipal formPrincipal = new FormPrincipal();
                    // formPrincipal.Show();
                    // this.Hide();
                }
                else
                {
                    MessageBox.Show("Identifiant ou mot de passe incorrect.", "Échec de connexion",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtPassword.UseSystemPasswordChar = false;
                    txtPassword.Text = passwordPlaceholder;
                    txtPassword.ForeColor = Color.FromArgb(100, 100, 100);
                    isPasswordPlaceholder = true;
                    txtLogin.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la connexion : {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnConnexion_Click(sender, e);
                e.Handled = true;
            }
        }

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void FormConnexion_Load(object sender, EventArgs e)
        {
            txtLogin.Focus();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}