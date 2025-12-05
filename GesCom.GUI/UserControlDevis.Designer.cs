namespace GesCom.GUI
{
    partial class UserControlDevis
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelleft = new System.Windows.Forms.Panel();
            this.dgvDevis = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblGestionsDevis = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grpAjoutProduit = new System.Windows.Forms.GroupBox();
            this.lblSousTotalLigne = new System.Windows.Forms.Label();
            this.lblPrixUnitaireLigne = new System.Windows.Forms.Label();
            this.btnAjouterLigne = new System.Windows.Forms.Button();
            this.lblRemiseAjout = new System.Windows.Forms.Label();
            this.lblQuantiteAjout = new System.Windows.Forms.Label();
            this.cmbProduitAjout = new System.Windows.Forms.ComboBox();
            this.lblAjoutProduit = new System.Windows.Forms.Label();
            this.dgvLignes = new System.Windows.Forms.DataGridView();
            this.lblProduits = new System.Windows.Forms.Label();
            this.cmbStatut = new System.Windows.Forms.ComboBox();
            this.lblStatut = new System.Windows.Forms.Label();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.lblClient = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnNouveau = new System.Windows.Forms.Button();
            this.panelRightHeader = new System.Windows.Forms.Panel();
            this.lblDetail = new System.Windows.Forms.Label();
            this.lblRemiseLigne = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalLigne = new System.Windows.Forms.Label();
            this.btnSupprimerLigne = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.lblMontantHTSansRemise = new System.Windows.Forms.Label();
            this.lblMontantTTC = new System.Windows.Forms.Label();
            this.lblMontantHTAvecRemise = new System.Windows.Forms.Label();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtQuantiteAjout = new System.Windows.Forms.NumericUpDown();
            this.txtRemiseAjout = new System.Windows.Forms.NumericUpDown();
            this.lblRemiseGlobale = new System.Windows.Forms.Label();
            this.numRemiseGlobale = new System.Windows.Forms.NumericUpDown();
            this.lblMontantTVA = new System.Windows.Forms.Label();
            this.panelleft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevis)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.grpAjoutProduit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLignes)).BeginInit();
            this.panelRightHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantiteAjout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemiseAjout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRemiseGlobale)).BeginInit();
            this.SuspendLayout();
            // 
            // panelleft
            // 
            this.panelleft.Controls.Add(this.dgvDevis);
            this.panelleft.Controls.Add(this.panel1);
            this.panelleft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelleft.Location = new System.Drawing.Point(0, 0);
            this.panelleft.Name = "panelleft";
            this.panelleft.Size = new System.Drawing.Size(1100, 950);
            this.panelleft.TabIndex = 0;
            // 
            // dgvDevis
            // 
            this.dgvDevis.AllowUserToAddRows = false;
            this.dgvDevis.AllowUserToDeleteRows = false;
            this.dgvDevis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDevis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDevis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDevis.Location = new System.Drawing.Point(0, 60);
            this.dgvDevis.MultiSelect = false;
            this.dgvDevis.Name = "dgvDevis";
            this.dgvDevis.RowHeadersVisible = false;
            this.dgvDevis.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDevis.Size = new System.Drawing.Size(1100, 890);
            this.dgvDevis.TabIndex = 1;
            this.dgvDevis.SelectionChanged += new System.EventHandler(this.dgvDevis_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel1.Controls.Add(this.lblGestionsDevis);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 60);
            this.panel1.TabIndex = 0;
            // 
            // lblGestionsDevis
            // 
            this.lblGestionsDevis.AutoSize = true;
            this.lblGestionsDevis.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGestionsDevis.ForeColor = System.Drawing.SystemColors.Control;
            this.lblGestionsDevis.Location = new System.Drawing.Point(47, 24);
            this.lblGestionsDevis.Name = "lblGestionsDevis";
            this.lblGestionsDevis.Size = new System.Drawing.Size(143, 23);
            this.lblGestionsDevis.TabIndex = 0;
            this.lblGestionsDevis.Text = "Gestion des devis";
            this.lblGestionsDevis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panelRightHeader);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(450, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(650, 950);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.numRemiseGlobale);
            this.panel3.Controls.Add(this.lblRemiseGlobale);
            this.panel3.Controls.Add(this.btnAnnuler);
            this.panel3.Controls.Add(this.btnAjouter);
            this.panel3.Controls.Add(this.lblMontantHTAvecRemise);
            this.panel3.Controls.Add(this.lblMontantTTC);
            this.panel3.Controls.Add(this.lblMontantTVA);
            this.panel3.Controls.Add(this.lblMontantHTSansRemise);
            this.panel3.Controls.Add(this.btnSupprimer);
            this.panel3.Controls.Add(this.btnModifier);
            this.panel3.Controls.Add(this.btnSupprimerLigne);
            this.panel3.Controls.Add(this.grpAjoutProduit);
            this.panel3.Controls.Add(this.dgvLignes);
            this.panel3.Controls.Add(this.lblProduits);
            this.panel3.Controls.Add(this.cmbStatut);
            this.panel3.Controls.Add(this.lblStatut);
            this.panel3.Controls.Add(this.cmbClient);
            this.panel3.Controls.Add(this.lblClient);
            this.panel3.Controls.Add(this.dtpDate);
            this.panel3.Controls.Add(this.lblDate);
            this.panel3.Controls.Add(this.btnNouveau);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(650, 890);
            this.panel3.TabIndex = 1;
            // 
            // grpAjoutProduit
            // 
            this.grpAjoutProduit.Controls.Add(this.txtRemiseAjout);
            this.grpAjoutProduit.Controls.Add(this.txtQuantiteAjout);
            this.grpAjoutProduit.Controls.Add(this.lblTotalLigne);
            this.grpAjoutProduit.Controls.Add(this.label2);
            this.grpAjoutProduit.Controls.Add(this.lblRemiseLigne);
            this.grpAjoutProduit.Controls.Add(this.lblSousTotalLigne);
            this.grpAjoutProduit.Controls.Add(this.lblPrixUnitaireLigne);
            this.grpAjoutProduit.Controls.Add(this.btnAjouterLigne);
            this.grpAjoutProduit.Controls.Add(this.lblRemiseAjout);
            this.grpAjoutProduit.Controls.Add(this.lblQuantiteAjout);
            this.grpAjoutProduit.Controls.Add(this.cmbProduitAjout);
            this.grpAjoutProduit.Controls.Add(this.lblAjoutProduit);
            this.grpAjoutProduit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAjoutProduit.Location = new System.Drawing.Point(15, 470);
            this.grpAjoutProduit.Name = "grpAjoutProduit";
            this.grpAjoutProduit.Size = new System.Drawing.Size(610, 180);
            this.grpAjoutProduit.TabIndex = 10;
            this.grpAjoutProduit.TabStop = false;
            this.grpAjoutProduit.Text = "Ajouter un produit";
            // 
            // lblSousTotalLigne
            // 
            this.lblSousTotalLigne.AutoSize = true;
            this.lblSousTotalLigne.Location = new System.Drawing.Point(15, 131);
            this.lblSousTotalLigne.Name = "lblSousTotalLigne";
            this.lblSousTotalLigne.Size = new System.Drawing.Size(107, 15);
            this.lblSousTotalLigne.TabIndex = 8;
            this.lblSousTotalLigne.Text = "Sous-total : 0.00 €";
            // 
            // lblPrixUnitaireLigne
            // 
            this.lblPrixUnitaireLigne.AutoSize = true;
            this.lblPrixUnitaireLigne.Location = new System.Drawing.Point(15, 100);
            this.lblPrixUnitaireLigne.Name = "lblPrixUnitaireLigne";
            this.lblPrixUnitaireLigne.Size = new System.Drawing.Size(137, 15);
            this.lblPrixUnitaireLigne.TabIndex = 7;
            this.lblPrixUnitaireLigne.Text = "Prix unitaire HT : 0.00 €";
            // 
            // btnAjouterLigne
            // 
            this.btnAjouterLigne.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAjouterLigne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjouterLigne.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouterLigne.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAjouterLigne.Location = new System.Drawing.Point(475, 50);
            this.btnAjouterLigne.Name = "btnAjouterLigne";
            this.btnAjouterLigne.Size = new System.Drawing.Size(120, 40);
            this.btnAjouterLigne.TabIndex = 6;
            this.btnAjouterLigne.Text = "+ Ajouter";
            this.btnAjouterLigne.UseVisualStyleBackColor = false;
            this.btnAjouterLigne.Click += new System.EventHandler(this.btnAjouterLigne_Click);
            // 
            // lblRemiseAjout
            // 
            this.lblRemiseAjout.AutoSize = true;
            this.lblRemiseAjout.Location = new System.Drawing.Point(375, 30);
            this.lblRemiseAjout.Name = "lblRemiseAjout";
            this.lblRemiseAjout.Size = new System.Drawing.Size(78, 15);
            this.lblRemiseAjout.TabIndex = 4;
            this.lblRemiseAjout.Text = "Remise en %";
            // 
            // lblQuantiteAjout
            // 
            this.lblQuantiteAjout.AutoSize = true;
            this.lblQuantiteAjout.Location = new System.Drawing.Point(280, 30);
            this.lblQuantiteAjout.Name = "lblQuantiteAjout";
            this.lblQuantiteAjout.Size = new System.Drawing.Size(56, 15);
            this.lblQuantiteAjout.TabIndex = 2;
            this.lblQuantiteAjout.Text = "Quantité";
            // 
            // cmbProduitAjout
            // 
            this.cmbProduitAjout.FormattingEnabled = true;
            this.cmbProduitAjout.Location = new System.Drawing.Point(15, 55);
            this.cmbProduitAjout.Name = "cmbProduitAjout";
            this.cmbProduitAjout.Size = new System.Drawing.Size(250, 23);
            this.cmbProduitAjout.TabIndex = 1;
            this.cmbProduitAjout.SelectedIndexChanged += new System.EventHandler(this.cmbProduitAjout_SelectedIndexChanged);
            // 
            // lblAjoutProduit
            // 
            this.lblAjoutProduit.AutoSize = true;
            this.lblAjoutProduit.Location = new System.Drawing.Point(15, 30);
            this.lblAjoutProduit.Name = "lblAjoutProduit";
            this.lblAjoutProduit.Size = new System.Drawing.Size(48, 15);
            this.lblAjoutProduit.TabIndex = 0;
            this.lblAjoutProduit.Text = "Produit";
            // 
            // dgvLignes
            // 
            this.dgvLignes.AllowUserToAddRows = false;
            this.dgvLignes.AllowUserToDeleteRows = false;
            this.dgvLignes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLignes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvLignes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLignes.Location = new System.Drawing.Point(15, 260);
            this.dgvLignes.Name = "dgvLignes";
            this.dgvLignes.RowHeadersVisible = false;
            this.dgvLignes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLignes.Size = new System.Drawing.Size(610, 200);
            this.dgvLignes.TabIndex = 9;
            // 
            // lblProduits
            // 
            this.lblProduits.AutoSize = true;
            this.lblProduits.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduits.Location = new System.Drawing.Point(15, 230);
            this.lblProduits.Name = "lblProduits";
            this.lblProduits.Size = new System.Drawing.Size(116, 17);
            this.lblProduits.TabIndex = 8;
            this.lblProduits.Text = "Produits du devis";
            // 
            // cmbStatut
            // 
            this.cmbStatut.FormattingEnabled = true;
            this.cmbStatut.Location = new System.Drawing.Point(320, 180);
            this.cmbStatut.Name = "cmbStatut";
            this.cmbStatut.Size = new System.Drawing.Size(305, 21);
            this.cmbStatut.TabIndex = 7;
            // 
            // lblStatut
            // 
            this.lblStatut.AutoSize = true;
            this.lblStatut.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatut.Location = new System.Drawing.Point(320, 155);
            this.lblStatut.Name = "lblStatut";
            this.lblStatut.Size = new System.Drawing.Size(45, 17);
            this.lblStatut.TabIndex = 6;
            this.lblStatut.Text = "Statut";
            // 
            // cmbClient
            // 
            this.cmbClient.FormattingEnabled = true;
            this.cmbClient.Location = new System.Drawing.Point(15, 180);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(290, 21);
            this.cmbClient.TabIndex = 5;
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClient.Location = new System.Drawing.Point(15, 155);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(44, 17);
            this.lblClient.TabIndex = 4;
            this.lblClient.Text = "Client";
            // 
            // dtpDate
            // 
            this.dtpDate.Enabled = false;
            this.dtpDate.Location = new System.Drawing.Point(15, 110);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(610, 20);
            this.dtpDate.TabIndex = 3;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(15, 85);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(37, 17);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Date";
            // 
            // btnNouveau
            // 
            this.btnNouveau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnNouveau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNouveau.FlatAppearance.BorderSize = 0;
            this.btnNouveau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNouveau.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNouveau.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnNouveau.Location = new System.Drawing.Point(15, 20);
            this.btnNouveau.Name = "btnNouveau";
            this.btnNouveau.Size = new System.Drawing.Size(610, 45);
            this.btnNouveau.TabIndex = 1;
            this.btnNouveau.Text = "+ Nouveau";
            this.btnNouveau.UseVisualStyleBackColor = false;
            this.btnNouveau.Click += new System.EventHandler(this.btnNouveau_Click);
            // 
            // panelRightHeader
            // 
            this.panelRightHeader.BackColor = System.Drawing.Color.DimGray;
            this.panelRightHeader.Controls.Add(this.lblDetail);
            this.panelRightHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRightHeader.Location = new System.Drawing.Point(0, 0);
            this.panelRightHeader.Name = "panelRightHeader";
            this.panelRightHeader.Size = new System.Drawing.Size(650, 60);
            this.panelRightHeader.TabIndex = 0;
            // 
            // lblDetail
            // 
            this.lblDetail.AutoSize = true;
            this.lblDetail.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetail.Location = new System.Drawing.Point(76, 24);
            this.lblDetail.Name = "lblDetail";
            this.lblDetail.Size = new System.Drawing.Size(54, 23);
            this.lblDetail.TabIndex = 0;
            this.lblDetail.Text = "Détail";
            // 
            // lblRemiseLigne
            // 
            this.lblRemiseLigne.AutoSize = true;
            this.lblRemiseLigne.Location = new System.Drawing.Point(183, 100);
            this.lblRemiseLigne.Name = "lblRemiseLigne";
            this.lblRemiseLigne.Size = new System.Drawing.Size(91, 15);
            this.lblRemiseLigne.TabIndex = 9;
            this.lblRemiseLigne.Text = "Remise : 0.00 €";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = " ";
            // 
            // lblTotalLigne
            // 
            this.lblTotalLigne.AutoSize = true;
            this.lblTotalLigne.Location = new System.Drawing.Point(183, 131);
            this.lblTotalLigne.Name = "lblTotalLigne";
            this.lblTotalLigne.Size = new System.Drawing.Size(77, 15);
            this.lblTotalLigne.TabIndex = 11;
            this.lblTotalLigne.Text = "Total : 0.00 €";
            // 
            // btnSupprimerLigne
            // 
            this.btnSupprimerLigne.BackColor = System.Drawing.Color.Red;
            this.btnSupprimerLigne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupprimerLigne.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimerLigne.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSupprimerLigne.Location = new System.Drawing.Point(15, 656);
            this.btnSupprimerLigne.Name = "btnSupprimerLigne";
            this.btnSupprimerLigne.Size = new System.Drawing.Size(200, 35);
            this.btnSupprimerLigne.TabIndex = 11;
            this.btnSupprimerLigne.Text = "- Supprimer produit ";
            this.btnSupprimerLigne.UseVisualStyleBackColor = false;
            this.btnSupprimerLigne.Click += new System.EventHandler(this.btnSupprimerLigne_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnModifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifier.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifier.ForeColor = System.Drawing.SystemColors.Control;
            this.btnModifier.Location = new System.Drawing.Point(15, 825);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(295, 50);
            this.btnModifier.TabIndex = 12;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = false;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.BackColor = System.Drawing.Color.Red;
            this.btnSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupprimer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimer.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSupprimer.Location = new System.Drawing.Point(330, 825);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(295, 50);
            this.btnSupprimer.TabIndex = 15;
            this.btnSupprimer.Text = "Supprimer ";
            this.btnSupprimer.UseVisualStyleBackColor = false;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // lblMontantHTSansRemise
            // 
            this.lblMontantHTSansRemise.AutoSize = true;
            this.lblMontantHTSansRemise.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontantHTSansRemise.Location = new System.Drawing.Point(12, 762);
            this.lblMontantHTSansRemise.Name = "lblMontantHTSansRemise";
            this.lblMontantHTSansRemise.Size = new System.Drawing.Size(211, 17);
            this.lblMontantHTSansRemise.TabIndex = 16;
            this.lblMontantHTSansRemise.Text = "Montant HT sans remise  : 0.00€ ";
            // 
            // lblMontantTTC
            // 
            this.lblMontantTTC.AutoSize = true;
            this.lblMontantTTC.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontantTTC.Location = new System.Drawing.Point(15, 728);
            this.lblMontantTTC.Name = "lblMontantTTC";
            this.lblMontantTTC.Size = new System.Drawing.Size(141, 17);
            this.lblMontantTTC.TabIndex = 18;
            this.lblMontantTTC.Text = "Montant TTC  : 0.00€ ";
            // 
            // lblMontantHTAvecRemise
            // 
            this.lblMontantHTAvecRemise.AutoSize = true;
            this.lblMontantHTAvecRemise.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontantHTAvecRemise.Location = new System.Drawing.Point(12, 792);
            this.lblMontantHTAvecRemise.Name = "lblMontantHTAvecRemise";
            this.lblMontantHTAvecRemise.Size = new System.Drawing.Size(211, 17);
            this.lblMontantHTAvecRemise.TabIndex = 19;
            this.lblMontantHTAvecRemise.Text = "Montant HT avec remise  : 0.00€ ";
            // 
            // btnAjouter
            // 
            this.btnAjouter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAjouter.FlatAppearance.BorderSize = 0;
            this.btnAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjouter.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouter.ForeColor = System.Drawing.Color.White;
            this.btnAjouter.Location = new System.Drawing.Point(15, 825);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(295, 50);
            this.btnAjouter.TabIndex = 29;
            this.btnAjouter.Text = "Ajouter ";
            this.btnAjouter.UseVisualStyleBackColor = false;
            this.btnAjouter.Visible = false;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.Red;
            this.btnAnnuler.FlatAppearance.BorderSize = 0;
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.btnAnnuler.ForeColor = System.Drawing.Color.White;
            this.btnAnnuler.Location = new System.Drawing.Point(330, 825);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(295, 50);
            this.btnAnnuler.TabIndex = 30;
            this.btnAnnuler.Text = "Annuler ";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Visible = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtQuantiteAjout
            // 
            this.txtQuantiteAjout.Location = new System.Drawing.Point(283, 56);
            this.txtQuantiteAjout.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtQuantiteAjout.Name = "txtQuantiteAjout";
            this.txtQuantiteAjout.Size = new System.Drawing.Size(86, 23);
            this.txtQuantiteAjout.TabIndex = 12;
            // 
            // txtRemiseAjout
            // 
            this.txtRemiseAjout.Location = new System.Drawing.Point(378, 55);
            this.txtRemiseAjout.Name = "txtRemiseAjout";
            this.txtRemiseAjout.Size = new System.Drawing.Size(91, 23);
            this.txtRemiseAjout.TabIndex = 13;
            // 
            // lblRemiseGlobale
            // 
            this.lblRemiseGlobale.AutoSize = true;
            this.lblRemiseGlobale.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemiseGlobale.Location = new System.Drawing.Point(270, 671);
            this.lblRemiseGlobale.Name = "lblRemiseGlobale";
            this.lblRemiseGlobale.Size = new System.Drawing.Size(119, 20);
            this.lblRemiseGlobale.TabIndex = 31;
            this.lblRemiseGlobale.Text = "Remise globale ";
            // 
            // numRemiseGlobale
            // 
            this.numRemiseGlobale.Location = new System.Drawing.Point(274, 700);
            this.numRemiseGlobale.Name = "numRemiseGlobale";
            this.numRemiseGlobale.Size = new System.Drawing.Size(120, 20);
            this.numRemiseGlobale.TabIndex = 32;
            // 
            // lblMontantTVA
            // 
            this.lblMontantTVA.AutoSize = true;
            this.lblMontantTVA.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontantTVA.Location = new System.Drawing.Point(15, 699);
            this.lblMontantTVA.Name = "lblMontantTVA";
            this.lblMontantTVA.Size = new System.Drawing.Size(102, 17);
            this.lblMontantTVA.TabIndex = 17;
            this.lblMontantTVA.Text = "Montant TVA   ";
            this.lblMontantTVA.Click += new System.EventHandler(this.lblMontantTVA_Click);
            // 
            // UserControlDevis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelleft);
            this.Name = "UserControlDevis";
            this.Size = new System.Drawing.Size(1100, 950);
            this.Load += new System.EventHandler(this.UserControlDevis_Load);
            this.panelleft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevis)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.grpAjoutProduit.ResumeLayout(false);
            this.grpAjoutProduit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLignes)).EndInit();
            this.panelRightHeader.ResumeLayout(false);
            this.panelRightHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantiteAjout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemiseAjout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRemiseGlobale)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelleft;
        private System.Windows.Forms.DataGridView dgvDevis;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblGestionsDevis;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelRightHeader;
        private System.Windows.Forms.Label lblDetail;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnNouveau;
        private System.Windows.Forms.Label lblProduits;
        private System.Windows.Forms.ComboBox cmbStatut;
        private System.Windows.Forms.Label lblStatut;
        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.GroupBox grpAjoutProduit;
        private System.Windows.Forms.Label lblAjoutProduit;
        private System.Windows.Forms.DataGridView dgvLignes;
        private System.Windows.Forms.Label lblQuantiteAjout;
        private System.Windows.Forms.ComboBox cmbProduitAjout;
        private System.Windows.Forms.Label lblRemiseAjout;
        private System.Windows.Forms.Button btnAjouterLigne;
        private System.Windows.Forms.Label lblSousTotalLigne;
        private System.Windows.Forms.Label lblPrixUnitaireLigne;
        private System.Windows.Forms.Label lblRemiseLigne;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalLigne;
        private System.Windows.Forms.Button btnSupprimerLigne;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Label lblMontantHTAvecRemise;
        private System.Windows.Forms.Label lblMontantTTC;
        private System.Windows.Forms.Label lblMontantHTSansRemise;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.NumericUpDown txtRemiseAjout;
        private System.Windows.Forms.NumericUpDown txtQuantiteAjout;
        private System.Windows.Forms.NumericUpDown numRemiseGlobale;
        private System.Windows.Forms.Label lblRemiseGlobale;
        private System.Windows.Forms.Label lblMontantTVA;
    }
}
