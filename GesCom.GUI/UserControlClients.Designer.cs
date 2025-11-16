namespace GesCom.GUI
{
    partial class UserControlClients
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
            this.userControlDevis1 = new GesCom.GUI.UserControlDevis();
            this.SuspendLayout();
            // 
            // userControlDevis1
            // 
            this.userControlDevis1.Location = new System.Drawing.Point(98, 79);
            this.userControlDevis1.Name = "userControlDevis1";
            this.userControlDevis1.Size = new System.Drawing.Size(203, 150);
            this.userControlDevis1.TabIndex = 0;
            // 
            // UserControlClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.userControlDevis1);
            this.Name = "UserControlClients";
            this.Size = new System.Drawing.Size(760, 490);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControlDevis userControlDevis1;
    }
}
