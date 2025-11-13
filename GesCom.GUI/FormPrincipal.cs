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

        private void btnClients_Click(object sender, EventArgs e)
        {
            // A FAIRE POUR LE 20/11
            MessageBox.Show("Module Clients - À venir", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void AfficherProduits()
        { 
            panelContent.Controls.Clear();
            panelContent.Controls.Add(ucProduits);
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            
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
