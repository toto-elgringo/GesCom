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
            AfficherProduits(); 
        }

        private void InitializeUserControls()
        {
            ucProduits = new UserControlProduits();
            {
                Dock = DockStyle.Fill;
            };
        }

        private void btnProduits_Click(object sender, EventArgs e)
        {
            AfficherProduits();
        }

        // fonction pour accéder aux différentes gestions depuis le formulaire principal 

        private void btnClients_Click(object sender, EventArgs e)
        {

            AfficherClients();
        }

        private void btnDevis_Click(object sender, EventArgs e)
        {
            // A FAIRE POUR LE 27/11
            MessageBox.Show("Module Devis - À venir", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSynthese_Click(object sender, EventArgs e)
        {
            // A FAIRE POUR LE 3/12
            MessageBox.Show("Module Synthèse clients - À venir", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Affichage du userControlProduits 

        private void AfficherProduits()
        { 
            panelContent.Controls.Clear();
            panelContent.Controls.Add(ucProduits);
        }

        private void AfficherClients()
        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(ucClients);
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            
        }

        //fonction pour confirmer que l'utilisateur est sur de vouloir quitter le projet 

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
