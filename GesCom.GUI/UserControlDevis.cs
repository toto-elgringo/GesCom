using GesCom.BLL;
using GesCom.BO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace GesCom.GUI
{
    public partial class UserControlDevis : UserControl
    {
        private List<Devis> listeDevis;
        private Devis devisSelectionne;
        private bool modeCreation = false;

        public UserControlDevis()
        {
            InitializeComponent();
        }

        private void UserControlDevis_Load(object sender, EventArgs e)
        {
            ChargerDevis();
            ChargerClients();
            ChargerStatuts();
            ChargerProduitsAjout();
            InitialiserEtatDetail();
        }

        #region Chargement des données

        private void ChargerDevis()
        {
            try
            {
                listeDevis = DevisBLL.GetUnDevisBLL().GetListDevis();
                dgvDevis.DataSource = null;
                dgvDevis.DataSource = listeDevis;

                if (dgvDevis.Columns.Count > 0)
                {
                    ConfigurerColonneDevis("Code", "Code", 20);
                    ConfigurerColonneDevis("Date", "Date", 20);
                    ConfigurerColonneDevis("Client", "Client", 40);
                    ConfigurerColonneDevis("Statut", "Statut", 40);
                    ConfigurerColonneDevis("MontantTTC", "Montant TTC", 40, "N2");

                    // Masquer colonnes inutiles
                    MasquerColonneDevis("TauxTVA");
                    MasquerColonneDevis("TauxRemiseGlobal");
                    MasquerColonneDevis("Lignes");
                    MasquerColonneDevis("MontantHTHorsRemiseGlobale");
                    MasquerColonneDevis("MontantRemiseGlobale");
                    MasquerColonneDevis("MontantHT");
                    MasquerColonneDevis("MontantTVA");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des devis : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurerColonneDevis(string nom, string titre, int largeur, string format = null)
        {
            if (dgvDevis.Columns.Contains(nom))
            {
                dgvDevis.Columns[nom].HeaderText = titre;
                dgvDevis.Columns[nom].Width = largeur;
                if (!string.IsNullOrEmpty(format))
                {
                    dgvDevis.Columns[nom].DefaultCellStyle.Format = format;
                }
            }
        }

        private void MasquerColonneDevis(string nom)
        {
            if (dgvDevis.Columns.Contains(nom))
            {
                dgvDevis.Columns[nom].Visible = false;
            }
        }

        private void ChargerClients()
        {
            try
            {
                List<Client> clients = ClientBLL.GetUnClientBLL().GetListClients();
                cmbClient.DataSource = clients;
                cmbClient.DisplayMember = "Nom";
                cmbClient.ValueMember = "Code";
                cmbClient.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des clients : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChargerStatuts()
        {
            try
            {
                List<Statut> statuts = StatutBLL.GetUnStatutBLL().GetListeStatuts();
                cmbStatut.DataSource = statuts;
                cmbStatut.DisplayMember = "Name";
                cmbStatut.ValueMember = "Code";
                cmbStatut.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des statuts : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChargerProduitsAjout()
        {
            try
            {
                List<Produit> produits = ProduitBLL.GetUnProduitBLL().GetListeProduits();

                if (devisSelectionne?.Lignes != null && devisSelectionne.Lignes.Count > 0)
                {
                    // Récupérer les codes produits déjà présents dans le devis
                    var codesDejaAjoutes = devisSelectionne.Lignes
                                            .Select(l => l.Produit.Code)
                                            .ToList();

                    // Exclure ces produits de la liste
                    produits = produits
                                .Where(p => !codesDejaAjoutes.Contains(p.Code))
                                .ToList();
                }

                cmbProduitAjout.DataSource = produits;
                cmbProduitAjout.DisplayMember = "Libelle";
                cmbProduitAjout.ValueMember = "Code";
                cmbProduitAjout.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des produits : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Gestion de l'état du formulaire

        private void InitialiserEtatDetail()
        {
            modeCreation = false;
            devisSelectionne = null;

            dtpDate.Value = DateTime.Now;
            cmbClient.SelectedIndex = -1;
            cmbStatut.SelectedIndex = -1;
            numRemiseGlobale.Value = 0;

            dgvLignes.DataSource = null;
            ReinitialiserAjoutProduit();
            CalculerTotaux();

            DesactiverChamps();

            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
            btnNouveau.Enabled = true;
            btnSupprimerLigne.Enabled = false;
        }

        private void DesactiverChamps()
        {
            dtpDate.Enabled = false;
            cmbClient.Enabled = false;
            cmbStatut.Enabled = false;
            grpAjoutProduit.Enabled = false;
            
        }

        private void ActiverChamps()
        {
            dtpDate.Enabled = true;
            cmbClient.Enabled = true;
            cmbStatut.Enabled = true;
            grpAjoutProduit.Enabled = true;
        }

        private void AfficherDetailDevis()
        {
            if (devisSelectionne != null)
            {
                // Charger le devis complet avec les lignes
                Devis devisComplet = DevisBLL.GetUnDevisBLL().GetDevisByCode(devisSelectionne.Code);
                devisSelectionne = devisComplet;

                dtpDate.Value = devisSelectionne.Date;
                cmbClient.SelectedValue = devisSelectionne.Client.Code;
                cmbStatut.SelectedValue = devisSelectionne.Statut.Code;
                numRemiseGlobale.Value = (decimal)devisSelectionne.TauxRemiseGlobal;


                ChargerLignesDevis();
                CalculerTotaux();

                DesactiverChamps();

                btnModifier.Enabled = true;
                btnSupprimer.Enabled = true;

                btnAjouter.Visible = false;
                btnAnnuler.Visible = false;
            }
        }

        private void ChargerLignesDevis()
        {
            dgvLignes.DataSource = null;

            if (devisSelectionne != null && devisSelectionne.Lignes.Count > 0)
            {
                dgvLignes.DataSource = devisSelectionne.Lignes.ToList();

                if (dgvLignes.Columns.Count > 0)
                {
                    if (dgvLignes.Columns.Contains("CodeDevis"))
                        dgvLignes.Columns["CodeDevis"].Visible = false;

                    ConfigurerColonneLigne("Produit", "Produit", 150);
                    ConfigurerColonneLigne("Quantite", "Qté", 60);
                    ConfigurerColonneLigne("PrixUnitaireHT", "Prix U", 80, "N2");
                    ConfigurerColonneLigne("Remise", "Remise %", 70);
                    ConfigurerColonneLigne("MontantHTAvecRemise", "Total HT", 100, "N2");

                    MasquerColonneLigne("MontantHTSansRemise");
                    MasquerColonneLigne("MontantRemise");
                }
            }
        }

        private void ConfigurerColonneLigne(string nom, string titre, int largeur, string format = null)
        {
            if (dgvLignes.Columns.Contains(nom))
            {
                dgvLignes.Columns[nom].HeaderText = titre;
                dgvLignes.Columns[nom].Width = largeur;
                dgvLignes.Columns[nom].ReadOnly = true;

                if (!string.IsNullOrEmpty(format))
                {
                    dgvLignes.Columns[nom].DefaultCellStyle.Format = format;
                }
            }
        }

        private void MasquerColonneLigne(string nom)
        {
            if (dgvLignes.Columns.Contains(nom))
            {
                dgvLignes.Columns[nom].Visible = false;
            }
        }

        #endregion

        #region Événements de sélection

        private void dgvDevis_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDevis.SelectedRows.Count > 0 && !modeCreation)
            {
                devisSelectionne = (Devis)dgvDevis.SelectedRows[0].DataBoundItem;
                AfficherDetailDevis();
            }
        }

        private void dgvLignes_SelectionChanged(object sender, EventArgs e)
        {
            // Activer le bouton supprimer si une ligne est sélectionnée et qu'on est en mode édition
            if (dgvLignes.SelectedRows.Count > 0 && grpAjoutProduit.Enabled)
            {
                btnSupprimerLigne.Enabled = true;
            }
            else
            {
                btnSupprimerLigne.Enabled = false;
            }
        }

        #endregion

        #region Boutons principaux

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            modeCreation = true;
            devisSelectionne = new Devis(0, DateTime.Now, 20.0f, 0.0f, null, null);
            devisSelectionne.Lignes = new List<ContenirDevis>();

            dgvDevis.ClearSelection();

            dtpDate.Value = DateTime.Now;
            cmbClient.SelectedIndex = -1;
            numRemiseGlobale.Value = 0;

            // Sélectionner "En attente" par défaut
            foreach (Statut s in cmbStatut.Items)
            {
                if (s.Name == "En attente")
                {
                    cmbStatut.SelectedItem = s;
                    break;
                }
            }

            dgvLignes.DataSource = null;
            ReinitialiserAjoutProduit();
            CalculerTotaux();

            ActiverChamps();

            btnModifier.Visible = false;
            btnSupprimer.Visible = false;
            btnNouveau.Visible = false;
            btnAjouter.Visible = true;
            btnAnnuler.Visible = true;
            btnSupprimerLigne.Enabled = true;
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            modeCreation = false;
            btnAjouter.Visible = false;
            btnAnnuler.Visible = false;
            btnNouveau.Visible = true;
            btnModifier.Visible = true;
            btnSupprimer.Visible = true;
            btnModifier.Text = "✏️ Modifier";

            InitialiserEtatDetail();

            if (dgvDevis.SelectedRows.Count > 0)
            {
                devisSelectionne = (Devis)dgvDevis.SelectedRows[0].DataBoundItem;
                AfficherDetailDevis();
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (devisSelectionne == null)
            {
                MessageBox.Show("Veuillez sélectionner un devis.", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnNouveau.Visible = false;
            btnAnnuler.Visible = true;

            if (!dtpDate.Enabled) // Mode consultation
            {
                ActiverChamps();
                btnModifier.Text = "💾 Enregistrer";
                btnSupprimer.Enabled = false;
                btnSupprimerLigne.Enabled = true;
                btnNouveau.Enabled = false;
                dtpDate.Focus();
            }
            else // Mode édition - Enregistrer
            {
                EnregistrerDevis();
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (devisSelectionne == null)
            {
                MessageBox.Show("Veuillez sélectionner un devis.", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Êtes-vous sûr de vouloir supprimer le devis n°{devisSelectionne.Code} ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DevisBLL.GetUnDevisBLL().SupprimerDevis(devisSelectionne.Code);

                    MessageBox.Show("Devis supprimé avec succès !", "Succès",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ChargerDevis();
                    InitialiserEtatDetail();
                    btnNouveau.Visible = true;
                    btnAjouter.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la suppression : {ex.Message}",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (ValiderChamps())
            {
                EnregistrerDevis();
                btnNouveau.Visible = true;
                btnSupprimer.Visible = true;
                btnModifier.Visible = true;
                btnAjouter.Visible = false;
                btnAnnuler.Visible = false;
            }
        }

        #endregion

        #region Gestion des lignes de produits

        private void cmbProduitAjout_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculerApercuLigne();
        }

        private void txtQuantiteAjout_TextChanged(object sender, EventArgs e)
        {
            CalculerApercuLigne();
        }

        private void txtRemiseAjout_TextChanged(object sender, EventArgs e)
        {
            CalculerApercuLigne();
        }

        private void txtQuantiteAjout_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtRemiseAjout_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            if (e.KeyChar == ',' && txtRemiseAjout.Text.Contains(","))
            {
                e.Handled = true;
            }
        }

        private void CalculerApercuLigne()
        {
            if (cmbProduitAjout.SelectedItem != null)
            {
                Produit produit = (Produit)cmbProduitAjout.SelectedItem;

                int quantite = 1;
                int.TryParse(txtQuantiteAjout.Text, out quantite);

                float remise = 0;
                float.TryParse(txtRemiseAjout.Text, out remise);

                float montantHT = produit.PrixVenteHT * quantite;
                float montantRemise = montantHT * (remise / 100);
                float montantFinal = montantHT - montantRemise;

                lblPrixUnitaireLigne.Text = $"Prix unitaire HT : {produit.PrixVenteHT:N2} €";
                lblSousTotalLigne.Text = $"Sous-total : {montantHT:N2} €";
                lblRemiseLigne.Text = $"Remise ({remise}%) : -{montantRemise:N2} €";
                lblTotalLigne .Text = $"Total ligne : {montantFinal:N2} €";
            }
            else
            {
                ReinitialiserAjoutProduit();
            }
        }

        private void ReinitialiserAjoutProduit()
        {
            cmbProduitAjout.SelectedIndex = -1;
            txtQuantiteAjout.Text = "1";
            txtRemiseAjout.Text = "0";
            lblPrixUnitaireLigne.Text = "Prix unitaire HT : 0.00 €";
            lblSousTotalLigne.Text = "Sous-total : 0.00 €";
            lblRemiseLigne.Text = "Remise (0%) : 0.00 €";
            lblTotalLigne.Text = "Total ligne : 0.00 €";
        }

        private void btnAjouterLigne_Click(object sender, EventArgs e)
        {
            if (!ValiderAjoutLigne())
            {
                return;
            }

            try
            {
                Produit produit = (Produit)cmbProduitAjout.SelectedItem;
                int quantite = int.Parse(txtQuantiteAjout.Text);
                float remise = float.Parse(txtRemiseAjout.Text);

                ContenirDevis nouvelleLigne = new ContenirDevis(0, produit, quantite, remise);

                if (devisSelectionne.Lignes == null)
                {
                    devisSelectionne.Lignes = new List<ContenirDevis>();
                }

                devisSelectionne.Lignes.Add(nouvelleLigne);
                ChargerLignesDevis();
                CalculerTotaux();
                ReinitialiserAjoutProduit();

                MessageBox.Show("Produit ajouté au devis !", "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimerLigne_Click(object sender, EventArgs e)
        {
            if (dgvLignes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une ligne à supprimer.", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Supprimer ce produit du devis ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int index = dgvLignes.SelectedRows[0].Index;
                devisSelectionne.Lignes.RemoveAt(index);
                ChargerLignesDevis();
                CalculerTotaux();
                btnModifier.Visible = true;
                btnSupprimer.Visible = true;
                btnAnnuler.Visible = false;    

                MessageBox.Show("Produit supprimé du devis !", "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ValiderAjoutLigne()
        {
            if (cmbProduitAjout.SelectedIndex == -1)
            {
                errorProvider1.SetError(cmbProduitAjout, "Veuillez choisir un produit");
                cmbProduitAjout.Focus();
                return false;
            }
            else
            {
                errorProvider1.SetError(cmbProduitAjout, "");
            }

            if (!int.TryParse(txtQuantiteAjout.Text, out int quantite) || quantite <= 0)
            {
                errorProvider1.SetError(txtQuantiteAjout, "Veuillez choisir une quantité correcte");
                txtQuantiteAjout.Focus();
                return false;
            }
            else
            {
                errorProvider1.SetError(txtQuantiteAjout, "");
            }

            if (!float.TryParse(txtRemiseAjout.Text, out float remise) || remise < 0 || remise > 100)
            {
                errorProvider1.SetError(txtRemiseAjout, "La remise doit être comprise entre 0 et 100%");
                txtRemiseAjout.Focus();
                return false;
            }
            else
            {
                errorProvider1.SetError(txtRemiseAjout, "");
            }

            foreach (ContenirDevis ligne in devisSelectionne.Lignes)
            {
                if (
                    ((Produit)cmbProduitAjout.SelectedItem).Libelle == ligne.Produit.Libelle
                )
                {
                    MessageBox.Show("Ce produit a déjà été ajoutée", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }


            return true;
        }

        #endregion

        #region Calculs et totaux

        private void CalculerTotaux()
        {
            
            if (devisSelectionne != null && devisSelectionne.Lignes != null)
            {
                devisSelectionne.TauxRemiseGlobal = (float)numRemiseGlobale.Value;
                lblMontantHTSansRemise.Text = "Montant HT Sans Remise : " + devisSelectionne.MontantHTHorsRemiseGlobale.ToString("N2") + " €";
                lblMontantHTAvecRemise.Text = "Montant HT Avec Remise : " + devisSelectionne.MontantHT.ToString("N2") + " €";
                lblMontantTVA.Text = "Montant TVA : " + devisSelectionne.MontantTVA.ToString("N2") + " €";
                lblMontantTTC.Text = "Montant TTC : " +  devisSelectionne.MontantTTC.ToString("N2") + " €";
            }
            else
            {
                lblMontantHTSansRemise.Text = "Montant HT Sans Remise : 0.00 €";
                lblMontantHTAvecRemise.Text = "Montant HT Avec Remise : 0.00 €";
                lblMontantTVA.Text = "Montant TVA : 0.00 €";
                lblMontantTTC.Text = "Montant TTC : 0.00 €";
            }
        }

        #endregion

        #region Enregistrement

        private void EnregistrerDevis()
        {
            if (!ValiderChamps())
            {
                return;
            }

            try
            {
                devisSelectionne.Date = dtpDate.Value;
                devisSelectionne.Client = (Client)cmbClient.SelectedItem;
                devisSelectionne.Statut = (Statut)cmbStatut.SelectedItem;
                devisSelectionne.TauxRemiseGlobal = (float)numRemiseGlobale.Value;

                if (modeCreation)
                {
                    DevisBLL.GetUnDevisBLL().AjouterDevis(devisSelectionne);
                    MessageBox.Show($"Devis créé avec succès !", "Succès",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    modeCreation = false;
                }
                else
                {
                    DevisBLL.GetUnDevisBLL().UpdateDevis(devisSelectionne);
                    MessageBox.Show("Devis modifié avec succès !", "Succès",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ChargerDevis();
                DesactiverChamps();
                btnModifier.Text = "✏️ Modifier";
                btnSupprimer.Enabled = true;
                btnNouveau.Enabled = true;
                btnNouveau.Visible = true;
                btnSupprimerLigne.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'enregistrement : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValiderChamps()
        {
            if (cmbClient.SelectedIndex == -1)
            {
                errorProvider1.SetError(cmbClient, "Veuillez choisir le client du devis");
                cmbClient.Focus();
                return false;
            }
            else
            {
                errorProvider1.SetError(cmbClient, "");
            }

            if (cmbStatut.SelectedIndex == -1)
            {
                errorProvider1.SetError(cmbStatut, "Veuillez choisir le statut du devis");
                cmbStatut.Focus();
                return false;
            }
            else
            {
                errorProvider1.SetError(cmbStatut, "");
            }

            if (devisSelectionne.Lignes == null || devisSelectionne.Lignes.Count == 0)
            {
                errorProvider1.SetError(cmbProduitAjout, "Veuillez ajouter 1 produit au devis");
                return false;
            }
            else
            {
                errorProvider1.SetError(cmbProduitAjout, "");
            }

                return true;
        }

        #endregion

        private void lblMontantTVA_Click(object sender, EventArgs e)
        {

        }
    }
}