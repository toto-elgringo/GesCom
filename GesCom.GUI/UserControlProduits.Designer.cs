namespace GesCom.GUI
{
    partial class UserControlProduits
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
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelDetail = new System.Windows.Forms.Panel();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.cmbCategorie = new System.Windows.Forms.ComboBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.txtPrix = new System.Windows.Forms.TextBox();
            this.txtLibelle = new System.Windows.Forms.TextBox();
            this.lblPrix = new System.Windows.Forms.Label();
            this.lblCategorie = new System.Windows.Forms.Label();
            this.lblLibelle = new System.Windows.Forms.Label();
            this.btnNouveau = new System.Windows.Forms.Button();
            this.panelRightHeader = new System.Windows.Forms.Panel();
            this.lblDetail = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panelLeft = new System.Windows.Forms.Panel();
            this.lblZeroProduit = new System.Windows.Forms.Label();
            this.dgvProduits = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblGestionProduits = new System.Windows.Forms.Label();
            this.panelRight.SuspendLayout();
            this.panelDetail.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelRightHeader.SuspendLayout();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduits)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.panelDetail);
            this.panelRight.Controls.Add(this.panelRightHeader);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(760, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(380, 550);
            this.panelRight.TabIndex = 0;
            // 
            // panelDetail
            // 
            this.panelDetail.Controls.Add(this.btnAnnuler);
            this.panelDetail.Controls.Add(this.btnAjouter);
            this.panelDetail.Controls.Add(this.cmbCategorie);
            this.panelDetail.Controls.Add(this.panelButtons);
            this.panelDetail.Controls.Add(this.txtPrix);
            this.panelDetail.Controls.Add(this.txtLibelle);
            this.panelDetail.Controls.Add(this.lblPrix);
            this.panelDetail.Controls.Add(this.lblCategorie);
            this.panelDetail.Controls.Add(this.lblLibelle);
            this.panelDetail.Controls.Add(this.btnNouveau);
            this.panelDetail.Location = new System.Drawing.Point(0, 60);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Size = new System.Drawing.Size(380, 490);
            this.panelDetail.TabIndex = 1;
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.Red;
            this.btnAnnuler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnnuler.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.ForeColor = System.Drawing.Color.White;
            this.btnAnnuler.Location = new System.Drawing.Point(195, 27);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(150, 45);
            this.btnAnnuler.TabIndex = 10;
            this.btnAnnuler.Text = "❌ Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Visible = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnAjouter
            // 
            this.btnAjouter.BackColor = System.Drawing.Color.LimeGreen;
            this.btnAjouter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjouter.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouter.ForeColor = System.Drawing.Color.White;
            this.btnAjouter.Location = new System.Drawing.Point(25, 27);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(150, 45);
            this.btnAjouter.TabIndex = 9;
            this.btnAjouter.Text = "✅ Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = false;
            this.btnAjouter.Visible = false;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // cmbCategorie
            // 
            this.cmbCategorie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategorie.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategorie.FormattingEnabled = true;
            this.cmbCategorie.Location = new System.Drawing.Point(25, 232);
            this.cmbCategorie.Name = "cmbCategorie";
            this.cmbCategorie.Size = new System.Drawing.Size(320, 25);
            this.cmbCategorie.TabIndex = 8;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnSupprimer);
            this.panelButtons.Controls.Add(this.btnModifier);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 406);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(380, 84);
            this.panelButtons.TabIndex = 7;
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.BackColor = System.Drawing.Color.Red;
            this.btnSupprimer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSupprimer.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnSupprimer.FlatAppearance.BorderSize = 0;
            this.btnSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupprimer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimer.ForeColor = System.Drawing.Color.White;
            this.btnSupprimer.Location = new System.Drawing.Point(190, 18);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(155, 45);
            this.btnSupprimer.TabIndex = 2;
            this.btnSupprimer.Text = "❌ Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = false;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifier.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifier.Location = new System.Drawing.Point(25, 18);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(155, 45);
            this.btnModifier.TabIndex = 1;
            this.btnModifier.Text = "✏️ Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // txtPrix
            // 
            this.txtPrix.Enabled = false;
            this.txtPrix.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrix.Location = new System.Drawing.Point(25, 301);
            this.txtPrix.Multiline = true;
            this.txtPrix.Name = "txtPrix";
            this.txtPrix.Size = new System.Drawing.Size(320, 41);
            this.txtPrix.TabIndex = 6;
            this.txtPrix.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPrix_KeyDown);
            // 
            // txtLibelle
            // 
            this.txtLibelle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLibelle.Enabled = false;
            this.txtLibelle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLibelle.Location = new System.Drawing.Point(25, 128);
            this.txtLibelle.Multiline = true;
            this.txtLibelle.Name = "txtLibelle";
            this.txtLibelle.Size = new System.Drawing.Size(320, 41);
            this.txtLibelle.TabIndex = 5;
            this.txtLibelle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLibelle_KeyPress);
            // 
            // lblPrix
            // 
            this.lblPrix.AutoSize = true;
            this.lblPrix.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrix.Location = new System.Drawing.Point(21, 278);
            this.lblPrix.Name = "lblPrix";
            this.lblPrix.Size = new System.Drawing.Size(100, 20);
            this.lblPrix.TabIndex = 4;
            this.lblPrix.Text = "Prix de vente";
            // 
            // lblCategorie
            // 
            this.lblCategorie.AutoSize = true;
            this.lblCategorie.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategorie.Location = new System.Drawing.Point(21, 197);
            this.lblCategorie.Name = "lblCategorie";
            this.lblCategorie.Size = new System.Drawing.Size(132, 20);
            this.lblCategorie.TabIndex = 3;
            this.lblCategorie.Text = "Catégorie Produit";
            // 
            // lblLibelle
            // 
            this.lblLibelle.AutoSize = true;
            this.lblLibelle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLibelle.Location = new System.Drawing.Point(21, 105);
            this.lblLibelle.Name = "lblLibelle";
            this.lblLibelle.Size = new System.Drawing.Size(110, 20);
            this.lblLibelle.TabIndex = 2;
            this.lblLibelle.Text = "Libellé Produit";
            // 
            // btnNouveau
            // 
            this.btnNouveau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnNouveau.FlatAppearance.BorderSize = 0;
            this.btnNouveau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNouveau.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNouveau.Location = new System.Drawing.Point(25, 27);
            this.btnNouveau.Name = "btnNouveau";
            this.btnNouveau.Size = new System.Drawing.Size(320, 45);
            this.btnNouveau.TabIndex = 0;
            this.btnNouveau.Text = "+ Nouveau";
            this.btnNouveau.UseVisualStyleBackColor = false;
            this.btnNouveau.Click += new System.EventHandler(this.btnNouveau_Click);
            // 
            // panelRightHeader
            // 
            this.panelRightHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelRightHeader.Controls.Add(this.lblDetail);
            this.panelRightHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRightHeader.Location = new System.Drawing.Point(0, 0);
            this.panelRightHeader.Name = "panelRightHeader";
            this.panelRightHeader.Size = new System.Drawing.Size(380, 60);
            this.panelRightHeader.TabIndex = 0;
            // 
            // lblDetail
            // 
            this.lblDetail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDetail.AutoSize = true;
            this.lblDetail.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetail.ForeColor = System.Drawing.Color.White;
            this.lblDetail.Location = new System.Drawing.Point(20, 30);
            this.lblDetail.Name = "lblDetail";
            this.lblDetail.Size = new System.Drawing.Size(63, 25);
            this.lblDetail.TabIndex = 0;
            this.lblDetail.Text = "Détail";
            this.lblDetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDetail.Click += new System.EventHandler(this.lblDetail_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.lblZeroProduit);
            this.panelLeft.Controls.Add(this.dgvProduits);
            this.panelLeft.Controls.Add(this.panel1);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(760, 550);
            this.panelLeft.TabIndex = 2;
            // 
            // lblZeroProduit
            // 
            this.lblZeroProduit.AutoSize = true;
            this.lblZeroProduit.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZeroProduit.Location = new System.Drawing.Point(50, 147);
            this.lblZeroProduit.Name = "lblZeroProduit";
            this.lblZeroProduit.Size = new System.Drawing.Size(310, 25);
            this.lblZeroProduit.TabIndex = 2;
            this.lblZeroProduit.Text = "Aucun produit n\'a été renseigné !";
            // 
            // dgvProduits
            // 
            this.dgvProduits.AllowUserToAddRows = false;
            this.dgvProduits.AllowUserToDeleteRows = false;
            this.dgvProduits.AllowUserToOrderColumns = true;
            this.dgvProduits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProduits.Location = new System.Drawing.Point(0, 60);
            this.dgvProduits.MultiSelect = false;
            this.dgvProduits.Name = "dgvProduits";
            this.dgvProduits.ReadOnly = true;
            this.dgvProduits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProduits.Size = new System.Drawing.Size(760, 490);
            this.dgvProduits.TabIndex = 1;
            this.dgvProduits.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dgvProduits.SelectionChanged += new System.EventHandler(this.dgvProduits_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.lblGestionProduits);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 60);
            this.panel1.TabIndex = 0;
            // 
            // lblGestionProduits
            // 
            this.lblGestionProduits.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblGestionProduits.AutoSize = true;
            this.lblGestionProduits.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGestionProduits.ForeColor = System.Drawing.Color.White;
            this.lblGestionProduits.Location = new System.Drawing.Point(45, 30);
            this.lblGestionProduits.Name = "lblGestionProduits";
            this.lblGestionProduits.Size = new System.Drawing.Size(196, 25);
            this.lblGestionProduits.TabIndex = 0;
            this.lblGestionProduits.Text = "Gestion des produits";
            // 
            // UserControlProduits
            // 
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelRight);
            this.Name = "UserControlProduits";
            this.Size = new System.Drawing.Size(1140, 550);
            this.Load += new System.EventHandler(this.UserControlProduits_Load);
            this.panelRight.ResumeLayout(false);
            this.panelDetail.ResumeLayout(false);
            this.panelDetail.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.panelRightHeader.ResumeLayout(false);
            this.panelRightHeader.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduits)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelRightHeader;
        private System.Windows.Forms.Label lblDetail;
        private System.Windows.Forms.Panel panelDetail;
        private System.Windows.Forms.Button btnNouveau;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Label lblCategorie;
        private System.Windows.Forms.Label lblLibelle;
        private System.Windows.Forms.TextBox txtLibelle;
        private System.Windows.Forms.Label lblPrix;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.TextBox txtPrix;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.ComboBox cmbCategorie;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvProduits;
        private System.Windows.Forms.Label lblGestionProduits;
        private System.Windows.Forms.Label lblZeroProduit;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Button btnAjouter;
    }
}
