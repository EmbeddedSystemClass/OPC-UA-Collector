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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ServerDiagnosticsCTRL = new Opc.Ua.Server.Controls.ServerDiagnosticsCtrl();
            this.NodeInspector = new System.Windows.Forms.Panel();
            this.buttonNamespace = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BrowseCTRL = new Opc.Ua.Client.Controls.BrowseNodeCtrl();
            this.BrowsCTRLServer = new Opc.Ua.Client.Controls.BrowseNodeCtrl();
            this.PopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToCollector = new System.Windows.Forms.ToolStripMenuItem();
            this.connectServerCtrl1 = new Opc.Ua.Client.Controls.ConnectServerCtrl();
            this.label1 = new System.Windows.Forms.Label();
            this.browseTreeCtrlBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonNamespaces = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.serverDiagnosticsCtrlBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverFormBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverUtilsBindingSource)).BeginInit();
            this.ServerDiagnosticPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.NodeInspector.SuspendLayout();
            this.panel1.SuspendLayout();
            this.PopupMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.browseTreeCtrlBindingSource)).BeginInit();
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
            this.ServerDiagnosticPanel.Controls.Add(this.tabControl1);
            this.ServerDiagnosticPanel.Controls.Add(this.ServerDiagnosticsCTRL);
            this.ServerDiagnosticPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerDiagnosticPanel.Location = new System.Drawing.Point(0, 0);
            this.ServerDiagnosticPanel.Name = "ServerDiagnosticPanel";
            this.ServerDiagnosticPanel.Size = new System.Drawing.Size(1137, 502);
            this.ServerDiagnosticPanel.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(346, 12);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(788, 487);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.NodeInspector);
            this.tabPage1.Location = new System.Drawing.Point(23, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(761, 479);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Connector";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(BrowsCTRLServer);
            this.tabPage2.Location = new System.Drawing.Point(23, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(761, 479);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Collector";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ServerDiagnosticsCTRL
            // 
            this.ServerDiagnosticsCTRL.Location = new System.Drawing.Point(0, 0);
            this.ServerDiagnosticsCTRL.Name = "ServerDiagnosticsCTRL";
            this.ServerDiagnosticsCTRL.Size = new System.Drawing.Size(340, 502);
            this.ServerDiagnosticsCTRL.TabIndex = 0;
            // 
            // NodeInspector
            // 
            this.NodeInspector.Controls.Add(this.buttonNamespaces);
            this.NodeInspector.Controls.Add(this.buttonNamespace);
            this.NodeInspector.Controls.Add(this.button1);
            this.NodeInspector.Controls.Add(this.panel1);
            this.NodeInspector.Controls.Add(this.connectServerCtrl1);
            this.NodeInspector.Controls.Add(this.label1);
            this.NodeInspector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NodeInspector.Location = new System.Drawing.Point(3, 3);
            this.NodeInspector.MinimumSize = new System.Drawing.Size(0, 300);
            this.NodeInspector.Name = "NodeInspector";
            this.NodeInspector.Size = new System.Drawing.Size(755, 473);
            this.NodeInspector.TabIndex = 1;
            // 
            // buttonNamespace
            // 
            this.buttonNamespace.Location = new System.Drawing.Point(600, 89);
            this.buttonNamespace.Name = "buttonNamespace";
            this.buttonNamespace.Size = new System.Drawing.Size(109, 23);
            this.buttonNamespace.TabIndex = 17;
            this.buttonNamespace.Text = "add Namespace";
            this.buttonNamespace.UseVisualStyleBackColor = true;
            this.buttonNamespace.Click += new System.EventHandler(this.buttonNamespace_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(600, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "add to Collector";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.BrowseCTRL);
            this.panel1.Location = new System.Drawing.Point(3, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(579, 449);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(597, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(104, 443);
            this.panel2.TabIndex = 16;
            // 
            // BrowseCTRL
            // 
            this.BrowseCTRL.AttributesListCollapsed = false;
            this.BrowseCTRL.AutoSize = true;
            this.BrowseCTRL.BrowseMenuStrip = this.PopupMenu;
            this.BrowseCTRL.Cursor = System.Windows.Forms.Cursors.Default;
            this.BrowseCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowseCTRL.Location = new System.Drawing.Point(0, 0);
            this.BrowseCTRL.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BrowseCTRL.MinimumSize = new System.Drawing.Size(0, 100);
            this.BrowseCTRL.Name = "BrowseCTRL";
            this.BrowseCTRL.Size = new System.Drawing.Size(579, 449);
            this.BrowseCTRL.SplitterDistance = 387;
            this.BrowseCTRL.TabIndex = 6;
            this.BrowseCTRL.View = null;
            //
            // BrowseCTRLServer
            //
            this.BrowsCTRLServer.AttributesListCollapsed = false;
            this.BrowsCTRLServer.AutoSize = true;
            this.BrowsCTRLServer.Cursor = System.Windows.Forms.Cursors.Default;
            this.BrowsCTRLServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowsCTRLServer.Location = new System.Drawing.Point(0, 0);
            this.BrowsCTRLServer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BrowsCTRLServer.MinimumSize = new System.Drawing.Size(0, 100);
            this.BrowsCTRLServer.Name = "BrowseCTRLServer";
            this.BrowsCTRLServer.Size = new System.Drawing.Size(579, 449);
            this.BrowsCTRLServer.SplitterDistance = 387;
            this.BrowsCTRLServer.TabIndex = 6;
            this.BrowsCTRLServer.View = null;
            // 
            // PopupMenu
            // 
            this.PopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToCollector});
            this.PopupMenu.Name = "PopupMenu";
            this.PopupMenu.Size = new System.Drawing.Size(162, 26);
            // 
            // addToCollector
            // 
            this.addToCollector.Checked = true;
            this.addToCollector.CheckOnClick = true;
            this.addToCollector.CheckState = System.Windows.Forms.CheckState.Checked;
            this.addToCollector.Name = "addToCollector";
            this.addToCollector.Size = new System.Drawing.Size(161, 22);
            this.addToCollector.Text = "Add to Collector";
            this.addToCollector.CheckedChanged += new System.EventHandler(this.addToCollector_CheckedChanged);
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
            this.connectServerCtrl1.Size = new System.Drawing.Size(755, 23);
            this.connectServerCtrl1.StatusStrip = null;
            this.connectServerCtrl1.StatusUpateTimeControl = null;
            this.connectServerCtrl1.TabIndex = 14;
            this.connectServerCtrl1.UserIdentity = null;
            this.connectServerCtrl1.UseSecurity = true;
            this.connectServerCtrl1.ConnectComplete += new System.EventHandler(this.Client_ConnectComplete);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(755, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Client Connector";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // browseTreeCtrlBindingSource
            // 
            this.browseTreeCtrlBindingSource.DataSource = typeof(Opc.Ua.Client.Controls.BrowseTreeCtrl);
            // 
            // buttonNamespaces
            // 
            this.buttonNamespaces.Location = new System.Drawing.Point(600, 119);
            this.buttonNamespaces.Name = "buttonNamespaces";
            this.buttonNamespaces.Size = new System.Drawing.Size(109, 23);
            this.buttonNamespaces.TabIndex = 18;
            this.buttonNamespaces.Text = "add Namespaces";
            this.buttonNamespaces.UseVisualStyleBackColor = true;
            this.buttonNamespaces.Click += new System.EventHandler(this.buttonNamespaces_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 502);
            this.Controls.Add(this.ServerDiagnosticPanel);
            this.Name = "mainForm";
            this.Text = "mainForm";
            ((System.ComponentModel.ISupportInitialize)(this.serverDiagnosticsCtrlBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverFormBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverUtilsBindingSource)).EndInit();
            this.ServerDiagnosticPanel.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.NodeInspector.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PopupMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.browseTreeCtrlBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Opc.Ua.Client.Controls.ConnectServerCtrl connectServerCtrl1;
        private Opc.Ua.Client.Controls.BrowseNodeCtrl BrowseCTRL;
        private Opc.Ua.Client.Controls.BrowseNodeCtrl BrowsCTRLServer;
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
        private System.Windows.Forms.Button buttonNamespace;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonNamespaces;
    }
}