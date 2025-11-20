using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GesCom.BLL;
using GesCom.DAL;
using GesCom.BO;


namespace GesCom.GUI
{
    public partial class UserControlClients : UserControl
    {
        private List<Client> listeClients;
        private Client clientSelectionne;

        // cette variable sert à savoir si on est en mode création ou pas  
        private bool modeCreation = false;

        public UserControlClients()
        {
            InitializeComponent();
            ChargerClients();
        }

        private void UserControlClients_Load(object sender, EventArgs e)
        {
            ChargerClients();
            InitialiserEtatDetail();
        }

        private void ChargerClients()
        {
            listeClients = ClientBLL.GetUnClientBLL().GetListClients();
            dgvClients.DataSource = null;
            dgvClients.DataSource = listeClients;
            try
            {
                if (dgvClients.Columns.Count > 0)
                {
                    dgvClients.Columns["Nom"].HeaderText = "Nom";
                    

                    dgvClients.Columns["NumRueFact"].HeaderText = "Num Rue Fact";

                    dgvClients.Columns["RueFact"].HeaderText = "Rue Fact";
                  
                    dgvClients.Columns["VilleFact"].HeaderText = "Ville Fact";
                  
                    dgvClients.Columns["CodePostFact"].HeaderText = "CP Fact";

                    dgvClients.Columns["NumRueLivr"].HeaderText = "Num Rue Livr";

                    dgvClients.Columns["RueLivr"].HeaderText = "Rue Livr";

                    dgvClients.Columns["VilleLivr"].HeaderText = "Ville Livr";

                    dgvClients.Columns["CodePostLivr"].HeaderText = "CP Livr";

                    dgvClients.Columns["NumTel"].HeaderText = "Téléphone";

                    dgvClients.Columns["NumFax"].HeaderText = "Fax";

                    dgvClients.Columns["Mail"].HeaderText = "Email";

                }
            }
          
             catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des clients : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitialiserEtatDetail()
        {
            modeCreation = false;
            clientSelectionne = null;

            txtName.Text = "";
            txtNumRueFact.Text = "";
            txtRueFact.Text = "";
            txtVilleFact.Text = "";
            txtCpFact.Text = "";
            txtNumRueLivr.Text = "";
            txtRueLivr.Text = "";
            txtVilleLivr.Text = "";
            txtCpLivr.Text = "";
            txtTelephone.Text = "";
            txtFax.Text = "";
            txtEmail.Text = "";


            txtName.Enabled = false;
            txtNumRueFact.Enabled = false;
            txtRueFact.Enabled = false;
            txtVilleFact.Enabled = false;
            txtCpFact.Enabled = false;
            txtNumRueLivr.Enabled = false;
            txtRueLivr.Enabled = false;
            txtVilleLivr.Enabled = false;
            txtCpLivr.Enabled = false;
            txtTelephone.Enabled = false;
            txtFax.Enabled = false;
            txtEmail.Enabled = false;

            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
            btnNouveau.Enabled = true;
        }

        private void AfficherDetailClient()
        {
            txtName.Text = clientSelectionne.Nom;
            txtNumRueFact.Text = clientSelectionne.NumRueFact.ToString();
            txtRueFact.Text = clientSelectionne.RueFact;
            txtVilleFact.Text = clientSelectionne.VilleFact;
            txtCpFact.Text = clientSelectionne.CodePostFact.ToString();
            txtNumRueLivr.Text = clientSelectionne.NumRueLivr.ToString();
            txtRueLivr.Text = clientSelectionne.RueLivr;
            txtVilleLivr.Text = clientSelectionne.VilleLivr;
            txtCpLivr.Text = clientSelectionne.CodePostLivr.ToString();
            txtTelephone.Text = clientSelectionne.NumTel;
            txtFax.Text = clientSelectionne.NumFax;
            txtEmail.Text = clientSelectionne.Mail;

            txtName.Enabled = false;
            txtNumRueFact.Enabled = false;
            txtRueFact.Enabled = false;
            txtVilleFact.Enabled = false;
            txtCpFact.Enabled = false;
            txtNumRueLivr.Enabled = false;
            txtRueLivr.Enabled = false;
            txtVilleLivr.Enabled = false;
            txtCpLivr.Enabled = false;
            txtTelephone.Enabled = false;
            txtFax.Enabled = false;
            txtEmail.Enabled = false;

            btnModifier.Enabled = true;
            btnModifier.Visible = true;
            btnSupprimer.Enabled = true;
            btnSupprimer.Visible = true;
            btnNouveau.Enabled = true;
            btnNouveau.Visible = true;

            btnAjouter.Visible = false;
            btnAnnuler.Visible = false;
        }

        private void dgvClients_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClients.SelectedRows.Count > 0)
            {
                clientSelectionne = (Client)dgvClients.SelectedRows[0].DataBoundItem;
                AfficherDetailClient();
            }
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            modeCreation = true;
            clientSelectionne = null;

            dgvClients.ClearSelection();

            txtName.Text = "";
            txtNumRueFact.Text = "";
            txtRueFact.Text = "";
            txtVilleFact.Text = "";
            txtCpFact.Text = "";
            txtNumRueLivr.Text = "";
            txtRueLivr.Text = "";
            txtVilleLivr.Text = "";
            txtCpLivr.Text = "";
            txtTelephone.Text = "";
            txtFax.Text = "";
            txtEmail.Text = "";

            txtName.Enabled = true;
            txtNumRueFact.Enabled = true;
            txtRueFact.Enabled = true;
            txtVilleFact.Enabled = true;
            txtCpFact.Enabled = true;
            txtNumRueLivr.Enabled = true;
            txtRueLivr.Enabled = true;
            txtVilleLivr.Enabled = true;
            txtCpLivr.Enabled = true;
            txtTelephone.Enabled = true;
            txtFax.Enabled = true;
            txtEmail.Enabled = true;

            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
            btnNouveau.Enabled = false;

            btnAjouter.Visible = true;
            btnAnnuler.Visible = true;
            btnNouveau.Visible = false;
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            modeCreation = false;
            btnAjouter.Visible = false;
            btnAnnuler.Visible = false;
            btnNouveau.Visible = true;
            btnModifier.Text = "✏️ Modifier";

            InitialiserEtatDetail();

            if (dgvClients.SelectedRows.Count > 0)
            {
                clientSelectionne = (Client)dgvClients.SelectedRows[0].DataBoundItem;
                AfficherDetailClient();
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (clientSelectionne == null)
            {
                MessageBox.Show("Veuillez sélectionner un client.", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnNouveau.Visible = false;
            btnAnnuler.Visible = true;

            if (!txtName.Enabled)
            {
                txtName.Enabled = true;
                txtNumRueFact.Enabled = true;
                txtRueFact.Enabled = true;
                txtVilleFact.Enabled = true;
                txtCpFact.Enabled = true;
                txtNumRueLivr.Enabled = true;
                txtRueLivr.Enabled = true;
                txtVilleLivr.Enabled = true;
                txtCpLivr.Enabled = true;
                txtTelephone.Enabled = true;
                txtFax.Enabled = true;
                txtEmail.Enabled = true;
                btnModifier.Text = "💾 Enregistrer";
                btnSupprimer.Enabled = false;
                btnNouveau.Enabled = false;
                btnAjouter.Visible = false;
                txtName.Focus();
            }
            else
            {
                EnregistrerModificationClient();
                btnModifier.Text = "✏️ Modifier";
            }
        }

        private void EnregistrerModificationClient()
        {
            if (!ValiderChamps())
            {
                return;
            }

            try
            {

                clientSelectionne.Nom = txtName.Text.Trim();
                clientSelectionne.NumRueFact = int.Parse(txtNumRueFact.Text);
                clientSelectionne.RueFact = txtRueFact.Text.Trim();
                clientSelectionne.VilleFact = txtVilleFact.Text.Trim();
                clientSelectionne.CodePostFact = int.Parse(txtCpFact.Text);
                clientSelectionne.NumRueLivr = int.Parse(txtNumRueLivr.Text);
                clientSelectionne.RueLivr = txtRueLivr.Text.Trim();
                clientSelectionne.VilleLivr = txtVilleLivr.Text.Trim();
                clientSelectionne.CodePostLivr = int.Parse(txtCpLivr.Text);
                clientSelectionne.NumTel = txtTelephone.Text.Trim();
                clientSelectionne.NumFax = txtFax.Text.Trim();
                clientSelectionne.Mail = txtEmail.Text.Trim();


                ClientBLL.GetUnClientBLL().UpdateClient(clientSelectionne);

                MessageBox.Show("Client modifié avec succès !", "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // rechargement de la page une fois le produit bien modifié 

                ChargerClients();

                foreach (DataGridViewRow row in dgvClients.Rows)
                {
                    if (((Client)row.DataBoundItem).Code == clientSelectionne.Code)
                    {
                        row.Selected = true;
                        break;
                    }
                }


                txtName.Enabled = false;
                txtNumRueFact.Enabled = false;
                txtRueFact.Enabled = false;
                txtVilleFact.Enabled = false;
                txtCpFact.Enabled = false;
                txtNumRueLivr.Enabled = false;
                txtRueLivr.Enabled = false;
                txtVilleLivr.Enabled = false;
                txtCpLivr.Enabled = false;
                txtTelephone.Enabled = false;
                txtFax.Enabled = false;
                txtEmail.Enabled = false;
                btnModifier.Text = "✏️ Modifier";
                btnSupprimer.Enabled = true;
                btnSupprimer.Visible = true;
                btnNouveau.Enabled = true;
                btnNouveau.Visible = true;
                btnAnnuler.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la modification : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Le client séléctionné à la base est supprimé apres une confirmation via un mesageBox

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (clientSelectionne == null)
            {
                MessageBox.Show("Veuillez sélectionner un client.", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ClientBLL.GetUnClientBLL().isClientInDevis(clientSelectionne.Code))
            {
                MessageBox.Show("Le client ne peut pas être supprimé, il appartient a 1 ou plusieurs devis ", "Attention",
                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Êtes-vous sûr de vouloir supprimer le client '{clientSelectionne.Nom}' ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    ClientBLL.GetUnClientBLL().SupprimerClient(clientSelectionne.Code);

                    MessageBox.Show("Client supprimé avec succès !", "Succès",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // rechargement de la page une fois le client bien supprimé avec les champs du formulaires vidés

                    ChargerClients();
                    InitialiserEtatDetail();
                    btnNouveau.Visible = true;
                    btnAjouter.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la suppression du client : {ex.Message}",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            EnregistrerNouveauClient();
            btnNouveau.Visible = true;
            btnSupprimer.Visible = true;
            btnModifier.Visible = true;
            btnAjouter.Visible = false;
            btnAnnuler.Visible = false;
        }

        private void EnregistrerNouveauClient()
        {
            if (!ValiderChamps())
            {
                return;
            }

            // vérification de l'existance d'un client lors de l'ajout ou de la modification d'un produit

            bool clientExistant = false;
            foreach (Client client in ClientBLL.GetUnClientBLL().GetListClients())
            {
                if (client.Nom == txtName.Text)
                {
                    clientExistant = true;
                }
            }

            if (clientExistant)
            {
                errorProvider1.SetError(txtName, "Ce client existe déjà");
                return;
            }
            else
            {
                errorProvider1.SetError(txtName, "");
            }

            try
            {
                // On créer le nouveau client

                Client NouveauClient = new Client(
                    0,
                    txtName.Text.Trim(),
                    int.Parse(txtNumRueFact.Text),
                    txtRueFact.Text.Trim(),
                    txtVilleFact.Text.Trim(),
                    int.Parse(txtCpFact.Text),
                    int.Parse(txtNumRueLivr.Text),
                    txtRueLivr.Text.Trim(),
                    txtVilleLivr.Text.Trim(),
                    int.Parse(txtCpLivr.Text),
                    txtTelephone.Text.Trim(),
                    txtFax.Text.Trim(),
                    txtEmail.Text.Trim()
                    );

                ClientBLL.GetUnClientBLL().AjouterClient(NouveauClient);

                MessageBox.Show("Client ajouté avec succès !", "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // rechargement de la page avec le nouveau produit 

                ChargerClients();
                InitialiserEtatDetail();
                btnNouveau.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout du client: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Fonctions de validation des champs dans le formulaire

        private bool ValiderChamps()
        {
            // vérification des champs pour vérifier si ils sont remplis 

            //Nom 
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider1.SetError(txtName, "Le nom du client est requis");
               return false;
            }
            else errorProvider1.SetError(txtName, "");

            // Num Rue Fact
            if (string.IsNullOrWhiteSpace(txtNumRueFact.Text))
            {
                errorProvider1.SetError(txtNumRueFact, "Numéro de rue facturation requis");
                return false;
            }
            else errorProvider1.SetError(txtNumRueFact, "");

            // Ville Fact
            if (string.IsNullOrWhiteSpace(txtVilleFact.Text))
            {
                errorProvider1.SetError(txtVilleFact, "Ville facturation requise");
                return false;
            }
            else errorProvider1.SetError(txtVilleFact, "");

            // CP Fact
            if (string.IsNullOrWhiteSpace(txtCpFact.Text))
            {
                errorProvider1.SetError(txtCpFact, "Code postal facturation requis");
                return  false;
            }
            else errorProvider1.SetError(txtCpFact, "");

            // Num Rue Livr
            if (string.IsNullOrWhiteSpace(txtNumRueLivr.Text))
            {
                errorProvider1.SetError(txtNumRueLivr, "Numéro de rue livraison requis");
                return false;
            }
            else errorProvider1.SetError(txtNumRueLivr, "");

            // Ville Livr
            if (string.IsNullOrWhiteSpace(txtVilleLivr.Text))
            {
                errorProvider1.SetError(txtVilleLivr, "Ville livraison requise");
                return false;
            }
            else errorProvider1.SetError(txtVilleLivr, "");

            // CP Livr
            if (string.IsNullOrWhiteSpace(txtCpLivr.Text))
            {
                errorProvider1.SetError(txtCpLivr, "Code postal livraison requis");
                return false;
            }
            else errorProvider1.SetError(txtCpLivr, "");

            // Téléphone
            if (string.IsNullOrWhiteSpace(txtTelephone.Text))
            {
                errorProvider1.SetError(txtTelephone, "Téléphone requis");
               return false;
            }
            else errorProvider1.SetError(txtTelephone, "");

            // Fax
            if (string.IsNullOrWhiteSpace(txtFax.Text))
            {
                errorProvider1.SetError(txtFax, "Fax requis");
                return false;
            }
            else errorProvider1.SetError(txtFax, "");

            // Email
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Email requis");
                return false;
            }
            else errorProvider1.SetError(txtEmail, "");

            // vérification du type des champs int  

            float nombre;
            if (!float.TryParse(txtNumRueFact.Text, out nombre))
            {
                errorProvider1.SetError(txtNumRueFact, "Le numéro de rue est incorrect");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtNumRueFact, "");
            }

            if(!float.TryParse(txtNumRueLivr.Text, out nombre))
            {
                errorProvider1.SetError(txtNumRueLivr, "Le numéro de rue est incorrect");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtNumRueLivr, "");
            }

            if (!float.TryParse(txtCpFact.Text, out nombre))
            {
                errorProvider1.SetError(txtCpFact, "Le code postal est incorrect");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtCpFact, "");
            }

            if (!float.TryParse(txtCpLivr.Text, out nombre))
            {
                errorProvider1.SetError(txtCpLivr, "Le code postal est incorrect");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtCpLivr, "");
            }


            if (!Regex.IsMatch(txtEmail.Text, @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$"))
            {
                errorProvider1.SetError(txtEmail, "Email invalide");
                return  false;
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }

            return true;
        }
    }
}
