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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblGestionProduits = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.lblGestionProduits);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 60);
            this.panel1.TabIndex = 1;
            // 
            // lblGestionProduits
            // 
            this.lblGestionProduits.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblGestionProduits.AutoSize = true;
            this.lblGestionProduits.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGestionProduits.ForeColor = System.Drawing.Color.White;
            this.lblGestionProduits.Location = new System.Drawing.Point(45, 30);
            this.lblGestionProduits.Name = "lblGestionProduits";
            this.lblGestionProduits.Size = new System.Drawing.Size(301, 40);
            this.lblGestionProduits.TabIndex = 0;
            this.lblGestionProduits.Text = "Gestion des produits";
            this.lblGestionProduits.Click += new System.EventHandler(this.lblGestionProduits_Click);
            // 
            // UserControlDevis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "UserControlDevis";
            this.Size = new System.Drawing.Size(810, 490);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblGestionProduits;
    }
}
