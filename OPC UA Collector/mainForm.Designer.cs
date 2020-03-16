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
            this.BrowseCTRL = new Opc.Ua.Client.Controls.BrowseNodeCtrl();
            this.connectServerCtrl1 = new Opc.Ua.Client.Controls.ConnectServerCtrl();
            this.browseTreeCtrlBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NodeInspector = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.PopupMenu = new System.Windows.Forms.ContextMenuStrip();
            this.addToCollector = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.serverDiagnosticsCtrlBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverFormBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverUtilsBindingSource)).BeginInit();
            this.ServerDiagnosticPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.browseTreeCtrlBindingSource)).BeginInit();
            this.NodeInspector.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.ServerDiagnosticPanel.Size = new System.Drawing.Size(1092, 502);
            this.ServerDiagnosticPanel.TabIndex = 0;
            // 
            // ServerDiagnosticsCTRL
            // 
            this.ServerDiagnosticsCTRL.Location = new System.Drawing.Point(0, 0);
            this.ServerDiagnosticsCTRL.Name = "ServerDiagnosticsCTRL";
            this.ServerDiagnosticsCTRL.Size = new System.Drawing.Size(340, 400);
            this.ServerDiagnosticsCTRL.TabIndex = 0;
            //
            // PopupMenuItems
            //
            this.addToCollector.Checked = true;
            this.addToCollector.CheckOnClick = true;
            this.addToCollector.CheckState = System.Windows.Forms.CheckState.Checked;
            this.addToCollector.Name = "CollectorAdd";
            this.addToCollector.Size = new System.Drawing.Size(161, 22);
            this.addToCollector.Text = "Add to Collector";
            this.addToCollector.CheckedChanged += new System.EventHandler(addToCollector_CheckedChanged);
            //
            // PopupMenu
            //
            this.PopupMenu.Name = "PopupMenu";
            this.PopupMenu.Size = new System.Drawing.Size(162,330);
            this.PopupMenu.Items.Add(this.addToCollector);
            // 
            // BrowseCTRL
            // 
            this.BrowseCTRL.AttributesListCollapsed = false;
            this.BrowseCTRL.AutoSize = true;
            this.BrowseCTRL.Cursor = System.Windows.Forms.Cursors.Default;
            this.BrowseCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowseCTRL.Location = new System.Drawing.Point(0, 0);
            this.BrowseCTRL.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BrowseCTRL.MinimumSize = new System.Drawing.Size(0, 100);
            this.BrowseCTRL.Name = "BrowseCTRL";
            this.BrowseCTRL.Size = new System.Drawing.Size(516, 449);
            this.BrowseCTRL.SplitterDistance = 387;
            this.BrowseCTRL.TabIndex = 6;
            this.BrowseCTRL.View = null;
            this.BrowseCTRL.BrowseCTRL.BrowseTV.ContextMenuStrip = this.PopupMenu;
            // 
            // connectServerCtrl1
            // 
            this.connectServerCtrl1.Configuration = null;
            this.connectServerCtrl1.DisableDomainCheck = false;
            this.connectServerCtrl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.connectServerCtrl1.Location = new System.Drawing.Point(0, 24);
            this.connectServerCtrl1.MaximumSize = new System.Drawing.Size(2048, 23);
            this.connectServerCtrl1.MinimumSize = new System.Drawing.Size(500, 23);
            this.connectServerCtrl1.Name = "connectServerCtrl1";
            this.connectServerCtrl1.PreferredLocales = null;
            this.connectServerCtrl1.ServerStatusControl = null;
            this.connectServerCtrl1.ServerUrl = "";
            this.connectServerCtrl1.SessionName = null;
            this.connectServerCtrl1.Size = new System.Drawing.Size(606, 23);
            this.connectServerCtrl1.StatusStrip = null;
            this.connectServerCtrl1.StatusUpateTimeControl = null;
            this.connectServerCtrl1.TabIndex = 14;
            this.connectServerCtrl1.UserIdentity = null;
            this.connectServerCtrl1.UseSecurity = true;
            this.connectServerCtrl1.ReconnectComplete += new System.EventHandler(this.Client_ReconnectComplete);
            this.connectServerCtrl1.ConnectComplete += new System.EventHandler(this.Client_ConnectComplete);
            // 
            // browseTreeCtrlBindingSource
            // 
            this.browseTreeCtrlBindingSource.DataSource = typeof(Opc.Ua.Client.Controls.BrowseTreeCtrl);
            // 
            // NodeInspector
            // 
            this.NodeInspector.Controls.Add(this.panel1);
            this.NodeInspector.Controls.Add(this.connectServerCtrl1);
            this.NodeInspector.Controls.Add(this.label1);
            this.NodeInspector.Dock = System.Windows.Forms.DockStyle.Right;
            this.NodeInspector.Location = new System.Drawing.Point(486, 0);
            this.NodeInspector.MinimumSize = new System.Drawing.Size(0, 300);
            this.NodeInspector.Name = "NodeInspector";
            this.NodeInspector.Size = new System.Drawing.Size(606, 502);
            this.NodeInspector.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BrowseCTRL);
            this.panel1.Location = new System.Drawing.Point(3, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(516, 449);
            this.panel1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(606, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Client Connector";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 502);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Opc.Ua.Client.Controls.ConnectServerCtrl connectServerCtrl1;
        private Opc.Ua.Client.Controls.BrowseNodeCtrl BrowseCTRL;
        private Opc.Ua.Server.Controls.ServerDiagnosticsCtrl ServerDiagnosticsCTRL;
        private System.Windows.Forms.ContextMenuStrip PopupMenu;
        private System.Windows.Forms.ToolStripMenuItem addToCollector;
        private System.Windows.Forms.BindingSource serverDiagnosticsCtrlBindingSource;
        private System.Windows.Forms.BindingSource serverFormBindingSource;
        private System.Windows.Forms.BindingSource serverUtilsBindingSource;
        private System.Windows.Forms.Panel ServerDiagnosticPanel;
        private System.Windows.Forms.BindingSource browseTreeCtrlBindingSource;
        private System.Windows.Forms.Panel NodeInspector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}