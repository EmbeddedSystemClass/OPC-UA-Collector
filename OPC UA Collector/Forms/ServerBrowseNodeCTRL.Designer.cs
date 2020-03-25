namespace ServerCollector.Forms
{
    partial class ServerBrowseNodeCTRL
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.ServerBrowseTreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // ServerBrowseTreeView
            // 
            this.ServerBrowseTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerBrowseTreeView.Location = new System.Drawing.Point(0, 0);
            this.ServerBrowseTreeView.Name = "ServerBrowseTreeView";
            this.ServerBrowseTreeView.Size = new System.Drawing.Size(484, 431);
            this.ServerBrowseTreeView.TabIndex = 0;
            // 
            // ServerBrowseNodeCTRL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ServerBrowseTreeView);
            this.Name = "ServerBrowseNodeCTRL";
            this.Size = new System.Drawing.Size(484, 431);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView ServerBrowseTreeView;
    }
}
