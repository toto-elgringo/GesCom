using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GesCom.GUI
{
    public partial class FormPrincipal : Form
    {
        private UserControlProduits ucProduits;
        private UserControlClients ucClients;
        private UserControlDevis ucDevis;

        public FormPrincipal()
        {
            InitializeComponent();
            InitializeUserControls();
            AfficherProduits(); // Afficher par défaut l'onglet Produits
        }

        private void InitializeUserControls()
        {
            // Initialiser le UserControl Produits
            ucProduits = new UserControlProduits();
            {
                Dock = DockStyle.Fill;
            };
        }

        private void btnProduits_Click(object sender, EventArgs e)
        {
            AfficherProduits();
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            // TODO: Implémenter plus tard
            MessageBox.Show("Module Clients - À venir", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDevis_Click(object sender, EventArgs e)
        {
            // TODO: Implémenter plus tard
            MessageBox.Show("Module Devis - À venir", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSynthese_Click(object sender, EventArgs e)
        {
            // TODO: Implémenter plus tard
            MessageBox.Show("Module Synthèse clients - À venir", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AfficherProduits()
        {
            // Réinitialiser les couleurs des boutons
            ResetButtonColors();

            // Mettre en évidence le bouton actif
            btnProduits.BackColor = Color.White;
            btnProduits.ForeColor = Color.FromArgb(24, 119, 242);

            // Afficher le UserControl
            panelContent.Controls.Clear();
            panelContent.Controls.Add(ucProduits);
        }

        private void ResetButtonColors()
        {
            Color defaultBack = Color.FromArgb(240, 240, 240);
            Color defaultFore = Color.FromArgb(60, 60, 60);

            btnProduits.BackColor = defaultBack;
            btnProduits.ForeColor = defaultFore;
            btnClients.BackColor = defaultBack;
            btnClients.ForeColor = defaultFore;
            btnDevis.BackColor = defaultBack;
            btnDevis.ForeColor = defaultFore;
            btnSynthese.BackColor = defaultBack;
            btnSynthese.ForeColor = defaultFore;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            // Configuration initiale
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Voulez-vous vraiment quitter l'application ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
