namespace Client
{
    partial class MainForm
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            //
            // initialize fields
            //
            this.connectServerCtrl1 = new Opc.Ua.Client.Controls.ConnectServerCtrl();
            // 
            // connectServerCtrl1
            // 
            this.connectServerCtrl1.Configuration = null;
            this.connectServerCtrl1.DisableDomainCheck = false;
            this.connectServerCtrl1.Location = new System.Drawing.Point(4, 27);
            this.connectServerCtrl1.MaximumSize = new System.Drawing.Size(2048, 23);
            this.connectServerCtrl1.MinimumSize = new System.Drawing.Size(500, 23);
            this.connectServerCtrl1.Name = "connectServerCtrl1";
            this.connectServerCtrl1.PreferredLocales = null;
            this.connectServerCtrl1.ServerStatusControl = null;
            this.connectServerCtrl1.ServerUrl = "";
            this.connectServerCtrl1.SessionName = null;
            this.connectServerCtrl1.Size = new System.Drawing.Size(943, 23);
            this.connectServerCtrl1.StatusStrip = null;
            this.connectServerCtrl1.StatusUpateTimeControl = null;
            this.connectServerCtrl1.TabIndex = 14;
            this.connectServerCtrl1.UserIdentity = null;
            this.connectServerCtrl1.UseSecurity = true;
            this.connectServerCtrl1.ReconnectStarting += new System.EventHandler(this.Server_ReconnectStarting);
            this.connectServerCtrl1.ReconnectComplete += new System.EventHandler(this.Server_ReconnectComplete);
            this.connectServerCtrl1.ConnectComplete += new System.EventHandler(this.Server_ConnectComplete);
            this.connectServerCtrl1.Load += new System.EventHandler(this.connectServerCtrl1_Load);
            //this.ConnectServerCtrl = new Opc.Ua.Client.Controls.ConnectServerCtrl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 28);
            this.panel1.TabIndex = 0;
            //this.panel1.Controls.Add(ConnectServerCtrl);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.Controls.Add(this.connectServerCtrl1);

        }
        #endregion
        

        private Opc.Ua.Client.Controls.ConnectServerCtrl connectServerCtrl1;
        private System.Windows.Forms.Panel panel1;
    }
}

