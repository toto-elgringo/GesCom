namespace GesCom.GUI
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnDevis = new System.Windows.Forms.Button();
            this.btnClients = new System.Windows.Forms.Button();
            this.btnProduits = new System.Windows.Forms.Button();
            this.btnSynthese = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnDevis);
            this.panelTop.Controls.Add(this.btnClients);
            this.panelTop.Controls.Add(this.btnProduits);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(10, 10, 10, 5);
            this.panelTop.Size = new System.Drawing.Size(1184, 100);
            this.panelTop.TabIndex = 0;
            // 
            // btnDevis
            // 
            this.btnDevis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDevis.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDevis.Location = new System.Drawing.Point(510, 10);
            this.btnDevis.Name = "btnDevis";
            this.btnDevis.Size = new System.Drawing.Size(240, 40);
            this.btnDevis.TabIndex = 2;
            this.btnDevis.Text = "Devis";
            this.btnDevis.UseVisualStyleBackColor = true;
            this.btnDevis.Click += new System.EventHandler(this.btnDevis_Click);
            // 
            // btnClients
            // 
            this.btnClients.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClients.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClients.Location = new System.Drawing.Point(260, 10);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(240, 40);
            this.btnClients.TabIndex = 1;
            this.btnClients.Text = "Clients";
            this.btnClients.UseVisualStyleBackColor = true;
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);
            // 
            // btnProduits
            // 
            this.btnProduits.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProduits.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduits.Location = new System.Drawing.Point(10, 10);
            this.btnProduits.Name = "btnProduits";
            this.btnProduits.Size = new System.Drawing.Size(240, 40);
            this.btnProduits.TabIndex = 0;
            this.btnProduits.Text = "Produits";
            this.btnProduits.UseVisualStyleBackColor = true;
            this.btnProduits.Click += new System.EventHandler(this.btnProduits_Click);
            // 
            // btnSynthese
            // 
            this.btnSynthese.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSynthese.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSynthese.Location = new System.Drawing.Point(760, 10);
            this.btnSynthese.Name = "btnSynthese";
            this.btnSynthese.Size = new System.Drawing.Size(240, 40);
            this.btnSynthese.TabIndex = 1;
            this.btnSynthese.Text = "Synthèse Clients";
            this.btnSynthese.UseVisualStyleBackColor = true;
            this.btnSynthese.Click += new System.EventHandler(this.btnSynthese_Click);
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 100);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1184, 561);
            this.panelContent.TabIndex = 2;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.btnSynthese);
            this.Controls.Add(this.panelTop);
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuPrincipal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnProduits;
        private System.Windows.Forms.Button btnDevis;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnSynthese;
        private System.Windows.Forms.Panel panelContent;
    }
}