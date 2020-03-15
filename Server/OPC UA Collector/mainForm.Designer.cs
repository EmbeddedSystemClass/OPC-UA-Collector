namespace ServerCollector
{
    partial class mainForm
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
            this.components = new System.ComponentModel.Container();
            this.serverDiagnosticsCtrlBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.serverFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.serverUtilsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ServerDiagnosticPanel = new System.Windows.Forms.Panel();
            this.ServerDiagnosticsCTRL = new Opc.Ua.Server.Controls.ServerDiagnosticsCtrl();
            this.BrowseCTRL = new Opc.Ua.Client.Controls.BrowseTreeCtrl();
            this.browseTreeCtrlBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NodeInspector = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.serverDiagnosticsCtrlBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverFormBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverUtilsBindingSource)).BeginInit();
            this.ServerDiagnosticPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.browseTreeCtrlBindingSource)).BeginInit();
            this.NodeInspector.SuspendLayout();
            this.SuspendLayout();
            // 
            // serverDiagnosticsCtrlBindingSource
            // 
            this.serverDiagnosticsCtrlBindingSource.DataSource = typeof(Opc.Ua.Server.Controls.ServerDiagnosticsCtrl);
            // 
            // serverFormBindingSource
            // 
            this.serverFormBindingSource.DataSource = typeof(Opc.Ua.Server.Controls.ServerForm);
            // 
            // serverUtilsBindingSource
            // 
            this.serverUtilsBindingSource.DataSource = typeof(Opc.Ua.Server.Controls.ServerUtils);
            // 
            // ServerDiagnosticPanel
            // 
            this.ServerDiagnosticPanel.Controls.Add(this.ServerDiagnosticsCTRL);
            this.ServerDiagnosticPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerDiagnosticPanel.Location = new System.Drawing.Point(0, 0);
            this.ServerDiagnosticPanel.Name = "ServerDiagnosticPanel";
            this.ServerDiagnosticPanel.Size = new System.Drawing.Size(931, 502);
            this.ServerDiagnosticPanel.TabIndex = 0;
            // 
            // ServerDiagnosticsCTRL
            // 
            this.ServerDiagnosticsCTRL.Location = new System.Drawing.Point(0, 0);
            this.ServerDiagnosticsCTRL.Name = "ServerDiagnosticsCTRL";
            this.ServerDiagnosticsCTRL.Size = new System.Drawing.Size(340, 400);
            this.ServerDiagnosticsCTRL.TabIndex = 0;
            // 
            // BrowseCTRL
            // 
            this.BrowseCTRL.AttributesCTRL = null;
            this.BrowseCTRL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BrowseCTRL.EnableDragging = false;
            this.BrowseCTRL.Location = new System.Drawing.Point(0, 131);
            this.BrowseCTRL.MinimumSize = new System.Drawing.Size(325, 216);
            this.BrowseCTRL.Name = "BrowseCTRL";
            this.BrowseCTRL.ReferencesCTRL = null;
            this.BrowseCTRL.Size = new System.Drawing.Size(447, 371);
            this.BrowseCTRL.TabIndex = 0;
            // 
            // browseTreeCtrlBindingSource
            // 
            this.browseTreeCtrlBindingSource.DataSource = typeof(Opc.Ua.Client.Controls.BrowseTreeCtrl);
            // 
            // NodeInspector
            // 
            this.NodeInspector.Controls.Add(this.label1);
            this.NodeInspector.Controls.Add(this.BrowseCTRL);
            this.NodeInspector.Dock = System.Windows.Forms.DockStyle.Right;
            this.NodeInspector.Location = new System.Drawing.Point(484, 0);
            this.NodeInspector.Name = "NodeInspector";
            this.NodeInspector.Size = new System.Drawing.Size(447, 502);
            this.NodeInspector.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(447, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Client Connector";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 502);
            this.Controls.Add(this.NodeInspector);
            this.Controls.Add(this.ServerDiagnosticPanel);
            this.Name = "mainForm";
            this.Text = "mainForm";
            ((System.ComponentModel.ISupportInitialize)(this.serverDiagnosticsCtrlBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverFormBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverUtilsBindingSource)).EndInit();
            this.ServerDiagnosticPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.browseTreeCtrlBindingSource)).EndInit();
            this.NodeInspector.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Opc.Ua.Client.Controls.BrowseTreeCtrl BrowseCTRL;
        private Opc.Ua.Server.Controls.ServerDiagnosticsCtrl ServerDiagnosticsCTRL;
        private System.Windows.Forms.BindingSource serverDiagnosticsCtrlBindingSource;
        private System.Windows.Forms.BindingSource serverFormBindingSource;
        private System.Windows.Forms.BindingSource serverUtilsBindingSource;
        private System.Windows.Forms.Panel ServerDiagnosticPanel;
        private System.Windows.Forms.BindingSource browseTreeCtrlBindingSource;
        private System.Windows.Forms.Panel NodeInspector;
        private System.Windows.Forms.Label label1;
    }
}