using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GesCom.BLL;
using GesCom.BO;

namespace GesCom.GUI
{
    public partial class UserControlProduits : UserControl
    {
        private List<Produit> listeProduits;
        private List<Categorie> listeCategories;
        private Produit produitSelectionne;
        private bool modeCreation = false;

        public UserControlProduits()
        {
            InitializeComponent();
        }

        private void UserControlProduits_Load(object sender, EventArgs e)
        {
            ChargerCategories();
            ChargerProduits();
            InitialiserEtatDetail();
        }

        private void ChargerCategories()
        {
            try
            {
                listeCategories = CategorieBLL.GetUneCategorieBLL().GetListeCategories();
                cmbCategorie.DataSource = null;
                cmbCategorie.DataSource = listeCategories;
                cmbCategorie.DisplayMember = "Nom";
                cmbCategorie.ValueMember = "Code";
                cmbCategorie.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des catégories : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChargerProduits()
        {
            try
            {
                listeProduits = ProduitBLL.GetUnProduitBLL().GetListeProduits();

                dgvProduits.DataSource = null;
                dgvProduits.DataSource = listeProduits;

                // Configuration des colonnes
                if (dgvProduits.Columns.Count > 0)
                {
                    dgvProduits.Columns["Code"].HeaderText = "Code";
                    dgvProduits.Columns["Code"].Width = 80;

                    dgvProduits.Columns["Libelle"].HeaderText = "Libellé";
                    dgvProduits.Columns["Libelle"].Width = 250;

                    dgvProduits.Columns["Categorie"].HeaderText = "Catégorie";
                    dgvProduits.Columns["Categorie"].Width = 150;

                    dgvProduits.Columns["PrixVenteHT"].HeaderText = "Prix de vente";
                    dgvProduits.Columns["PrixVenteHT"].Width = 120;
                    dgvProduits.Columns["PrixVenteHT"].DefaultCellStyle.Format = "N2";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des produits : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitialiserEtatDetail()
        {
            modeCreation = false;
            produitSelectionne = null;

            txtLibelle.Text = "";
            txtPrix.Text = "";
            cmbCategorie.SelectedIndex = -1;

            txtLibelle.Enabled = false;
            txtPrix.Enabled = false;
            cmbCategorie.Enabled = false;

            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
        }

        private void dgvProduits_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProduits.SelectedRows.Count > 0 && !modeCreation)
            {
                produitSelectionne = (Produit)dgvProduits.SelectedRows[0].DataBoundItem;
                AfficherDetailProduit();
            }
        }

        private void AfficherDetailProduit()
        {
            if (produitSelectionne != null)
            {
                txtLibelle.Text = produitSelectionne.Libelle;
                txtPrix.Text = produitSelectionne.PrixVenteHT.ToString("F2");
                cmbCategorie.SelectedValue = produitSelectionne.Categorie.Code;

                txtLibelle.Enabled = false;
                txtPrix.Enabled = false;
                cmbCategorie.Enabled = false;

                btnModifier.Enabled = true;
                btnSupprimer.Enabled = true;
            }
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            modeCreation = true;
            produitSelectionne = null;

            dgvProduits.ClearSelection();

            txtLibelle.Text = "";
            txtPrix.Text = "";
            cmbCategorie.SelectedIndex = -1;

            txtLibelle.Enabled = true;
            txtPrix.Enabled = true;
            cmbCategorie.Enabled = true;

            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
            btnNouveau.Enabled = false;

            txtLibelle.Focus();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (produitSelectionne == null)
            {
                MessageBox.Show("Veuillez sélectionner un produit.", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!txtLibelle.Enabled) // Mode consultation
            {
                // Activer le mode édition
                txtLibelle.Enabled = true;
                txtPrix.Enabled = true;
                cmbCategorie.Enabled = true;
                btnModifier.Text = "💾 Enregistrer";
                btnSupprimer.Enabled = false;
                btnNouveau.Enabled = false;
                txtLibelle.Focus();
            }
            else // Mode édition - Enregistrer
            {
                EnregistrerModificationProduit();
            }
        }

        private void EnregistrerModificationProduit()
        {
            if (!ValiderChamps())
            {
                return;
            }

            try
            {
                produitSelectionne.Libelle = txtLibelle.Text.Trim();
                produitSelectionne.PrixVenteHT = float.Parse(txtPrix.Text);
                produitSelectionne.Categorie = (Categorie)cmbCategorie.SelectedItem;

                ProduitBLL.GetUnProduitBLL().ModifierProduit(produitSelectionne);

                MessageBox.Show("Produit modifié avec succès !", "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ChargerProduits();

                // Réafficher le produit modifié
                foreach (DataGridViewRow row in dgvProduits.Rows)
                {
                    if (((Produit)row.DataBoundItem).Code == produitSelectionne.Code)
                    {
                        row.Selected = true;
                        break;
                    }
                }

                txtLibelle.Enabled = false;
                txtPrix.Enabled = false;
                cmbCategorie.Enabled = false;
                btnModifier.Text = "✏️ Modifier";
                btnSupprimer.Enabled = true;
                btnNouveau.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la modification : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (produitSelectionne == null)
            {
                MessageBox.Show("Veuillez sélectionner un produit.", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Êtes-vous sûr de vouloir supprimer le produit '{produitSelectionne.Libelle}' ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    ProduitBLL.GetUnProduitBLL().SupprimerProduit(produitSelectionne.Code);

                    MessageBox.Show("Produit supprimé avec succès !", "Succès",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ChargerProduits();
                    InitialiserEtatDetail();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la suppression : {ex.Message}",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtLibelle_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLibelle.Text) && (txtLibelle.Enabled))
            {
                MessageBox.Show("Le libellé ne peut pas être vide.", "Erreur de saisie",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLibelle.Focus();
            }
        }

        private void txtPrix_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Autoriser uniquement les chiffres, la virgule, le point et les touches de contrôle
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Remplacer le point par une virgule
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            // Autoriser une seule virgule
            if (e.KeyChar == ',' && txtPrix.Text.Contains(","))
            {
                e.Handled = true;
            }
        }

        private void txtLibelle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && modeCreation)
            {
                EnregistrerNouveauProduit();
                e.Handled = true;
            }
        }

        private void txtPrix_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (modeCreation)
                {
                    EnregistrerNouveauProduit();
                }
                else if (txtPrix.Enabled && produitSelectionne != null)
                {
                    EnregistrerModificationProduit();
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void EnregistrerNouveauProduit()
        {
            if (!ValiderChamps())
            {
                return;
            }

            try
            {
                Categorie categorieSelectionnee = (Categorie)cmbCategorie.SelectedItem;

                Produit nouveauProduit = new Produit(
                    0, // Le code sera généré par la base de données
                    txtLibelle.Text.Trim(),
                    categorieSelectionnee,
                    float.Parse(txtPrix.Text)
                );

                ProduitBLL.GetUnProduitBLL().AjouterProduit(nouveauProduit);

                MessageBox.Show("Produit ajouté avec succès !", "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ChargerProduits();
                InitialiserEtatDetail();
                btnNouveau.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValiderChamps()
        {
            if (string.IsNullOrWhiteSpace(txtLibelle.Text))
            {
                MessageBox.Show("Veuillez saisir un libellé.", "Erreur de saisie",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLibelle.Focus();
                return false;
            }

            if (txtLibelle.Text.Trim().Length > 100)
            {
                MessageBox.Show("Le libellé ne peut pas dépasser 100 caractères.", "Erreur de saisie",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLibelle.Focus();
                return false;
            }

            if (cmbCategorie.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez sélectionner une catégorie.", "Erreur de saisie",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategorie.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPrix.Text))
            {
                MessageBox.Show("Veuillez saisir un prix de vente.", "Erreur de saisie",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrix.Focus();
                return false;
            }

            float prix;
            if (!float.TryParse(txtPrix.Text, out prix))
            {
                MessageBox.Show("Le prix de vente doit être un nombre valide.", "Erreur de saisie",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrix.Focus();
                return false;
            }

            if (prix <= 0)
            {
                MessageBox.Show("Le prix de vente doit être supérieur à 0.", "Erreur de saisie",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrix.Focus();
                return false;
            }

            return true;
        }

        private void lblGestionProduits_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UserControlProduits_Load_1(object sender, EventArgs e)
        {

        }

        private void lblDetail_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
