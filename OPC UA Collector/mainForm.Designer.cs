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
            this.tabControl_Server = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.NodeInspector = new System.Windows.Forms.Panel();
            this.isServerReg = new System.Windows.Forms.CheckBox();
            this.regServerButton = new System.Windows.Forms.Button();
            this.connectNode = new System.Windows.Forms.Button();
            this.buttonNamespaces = new System.Windows.Forms.Button();
            this.buttonNamespace = new System.Windows.Forms.Button();
            this.addToCollectorModel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BrowseCTRL = new Opc.Ua.Client.Controls.BrowseNodeCtrl();
            this.PopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToCollector = new System.Windows.Forms.ToolStripMenuItem();
            this.connectServerCtrl1 = new Opc.Ua.Client.Controls.ConnectServerCtrl();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.serverBrowseNodeCTRL1 = new ServerCollector.Forms.ServerBrowseNodeCTRL();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ServerDiagnosticsCTRL = new Opc.Ua.Server.Controls.ServerDiagnosticsCtrl();
            this.browseTreeCtrlBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel_server = new System.Windows.Forms.Panel();
            this.label_serverName = new System.Windows.Forms.Label();
            this.panel_ServerProperties = new System.Windows.Forms.Panel();
            this.panel_ServerActions = new System.Windows.Forms.Panel();
            this.panel_serverBrowseCTRL = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.serverDiagnosticsCtrlBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverFormBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverUtilsBindingSource)).BeginInit();
            this.ServerDiagnosticPanel.SuspendLayout();
            this.tabControl_Server.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.NodeInspector.SuspendLayout();
            this.panel1.SuspendLayout();
            this.PopupMenu.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.browseTreeCtrlBindingSource)).BeginInit();
            this.panel_server.SuspendLayout();
            this.panel_ServerProperties.SuspendLayout();
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
            this.ServerDiagnosticPanel.Controls.Add(this.tabControl_Server);
            this.ServerDiagnosticPanel.Controls.Add(this.ServerDiagnosticsCTRL);
            this.ServerDiagnosticPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerDiagnosticPanel.Location = new System.Drawing.Point(0, 0);
            this.ServerDiagnosticPanel.Name = "ServerDiagnosticPanel";
            this.ServerDiagnosticPanel.Size = new System.Drawing.Size(1137, 502);
            this.ServerDiagnosticPanel.TabIndex = 0;
            // 
            // tabControl_Server
            // 
            this.tabControl_Server.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl_Server.Controls.Add(this.tabPage1);
            this.tabControl_Server.Controls.Add(this.tabPage2);
            this.tabControl_Server.Controls.Add(this.tabPage3);
            this.tabControl_Server.Location = new System.Drawing.Point(346, 12);
            this.tabControl_Server.Multiline = true;
            this.tabControl_Server.Name = "tabControl_Server";
            this.tabControl_Server.SelectedIndex = 0;
            this.tabControl_Server.Size = new System.Drawing.Size(788, 487);
            this.tabControl_Server.TabIndex = 2;
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
            // NodeInspector
            // 
            this.NodeInspector.Controls.Add(this.button1);
            this.NodeInspector.Controls.Add(this.isServerReg);
            this.NodeInspector.Controls.Add(this.regServerButton);
            this.NodeInspector.Controls.Add(this.connectNode);
            this.NodeInspector.Controls.Add(this.buttonNamespaces);
            this.NodeInspector.Controls.Add(this.buttonNamespace);
            this.NodeInspector.Controls.Add(this.addToCollectorModel);
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
            // isServerReg
            // 
            this.isServerReg.AutoSize = true;
            this.isServerReg.Enabled = false;
            this.isServerReg.Location = new System.Drawing.Point(604, 53);
            this.isServerReg.Name = "isServerReg";
            this.isServerReg.Size = new System.Drawing.Size(106, 17);
            this.isServerReg.TabIndex = 20;
            this.isServerReg.Text = "Server registered";
            this.isServerReg.UseVisualStyleBackColor = true;
            // 
            // regServerButton
            // 
            this.regServerButton.Location = new System.Drawing.Point(604, 96);
            this.regServerButton.Name = "regServerButton";
            this.regServerButton.Size = new System.Drawing.Size(109, 23);
            this.regServerButton.TabIndex = 19;
            this.regServerButton.Text = "register Server";
            this.regServerButton.UseVisualStyleBackColor = true;
            // 
            // connectNode
            // 
            this.connectNode.Location = new System.Drawing.Point(603, 186);
            this.connectNode.Name = "connectNode";
            this.connectNode.Size = new System.Drawing.Size(109, 23);
            this.connectNode.TabIndex = 18;
            this.connectNode.Text = "add and connect";
            this.connectNode.UseVisualStyleBackColor = true;
            // 
            // buttonNamespaces
            // 
            this.buttonNamespaces.Location = new System.Drawing.Point(603, 215);
            this.buttonNamespaces.Name = "buttonNamespaces";
            this.buttonNamespaces.Size = new System.Drawing.Size(109, 23);
            this.buttonNamespaces.TabIndex = 18;
            this.buttonNamespaces.Text = "add Namespaces";
            this.buttonNamespaces.UseVisualStyleBackColor = true;
            this.buttonNamespaces.Click += new System.EventHandler(this.buttonNamespaces_Click);
            // 
            // buttonNamespace
            // 
            this.buttonNamespace.Location = new System.Drawing.Point(603, 244);
            this.buttonNamespace.Name = "buttonNamespace";
            this.buttonNamespace.Size = new System.Drawing.Size(109, 23);
            this.buttonNamespace.TabIndex = 17;
            this.buttonNamespace.Text = "add Namespace";
            this.buttonNamespace.UseVisualStyleBackColor = true;
            this.buttonNamespace.Click += new System.EventHandler(this.buttonNamespace_Click);
            // 
            // addToCollectorModel
            // 
            this.addToCollectorModel.Location = new System.Drawing.Point(603, 155);
            this.addToCollectorModel.Name = "addToCollectorModel";
            this.addToCollectorModel.Size = new System.Drawing.Size(109, 23);
            this.addToCollectorModel.TabIndex = 16;
            this.addToCollectorModel.Text = "add to Collector";
            this.addToCollectorModel.UseVisualStyleBackColor = true;
            this.addToCollectorModel.Click += new System.EventHandler(this.addToCollectorModel_Click);
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
            // PopupMenu
            // 
            this.PopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToCollector});
            this.PopupMenu.Name = "PopupMenu";
            this.PopupMenu.Size = new System.Drawing.Size(162, 26);
            // 
            // addToCollector
            // 
            this.addToCollector.CheckOnClick = true;
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.serverBrowseNodeCTRL1);
            this.tabPage2.Location = new System.Drawing.Point(23, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(761, 479);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Collector";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Paint += new System.Windows.Forms.PaintEventHandler(this.connectToCollector);
            // 
            // serverBrowseNodeCTRL1
            // 
            this.serverBrowseNodeCTRL1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serverBrowseNodeCTRL1.Location = new System.Drawing.Point(3, 3);
            this.serverBrowseNodeCTRL1.Name = "serverBrowseNodeCTRL1";
            this.serverBrowseNodeCTRL1.Size = new System.Drawing.Size(755, 473);
            this.serverBrowseNodeCTRL1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel_ServerProperties);
            this.tabPage3.Controls.Add(this.panel_server);
            this.tabPage3.Location = new System.Drawing.Point(23, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(761, 479);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ServerDiagnosticsCTRL
            // 
            this.ServerDiagnosticsCTRL.Location = new System.Drawing.Point(0, 0);
            this.ServerDiagnosticsCTRL.Name = "ServerDiagnosticsCTRL";
            this.ServerDiagnosticsCTRL.Size = new System.Drawing.Size(340, 502);
            this.ServerDiagnosticsCTRL.TabIndex = 0;
            // 
            // browseTreeCtrlBindingSource
            // 
            this.browseTreeCtrlBindingSource.DataSource = typeof(Opc.Ua.Client.Controls.BrowseTreeCtrl);
            // 
            // panel_server
            // 
            this.panel_server.Controls.Add(this.panel_serverBrowseCTRL);
            this.panel_server.Controls.Add(this.panel_ServerActions);
            this.panel_server.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_server.Location = new System.Drawing.Point(3, 3);
            this.panel_server.Name = "panel_server";
            this.panel_server.Size = new System.Drawing.Size(755, 473);
            this.panel_server.TabIndex = 0;
            // 
            // label_serverName
            // 
            this.label_serverName.AutoSize = true;
            this.label_serverName.Location = new System.Drawing.Point(-3, 0);
            this.label_serverName.Name = "label_serverName";
            this.label_serverName.Size = new System.Drawing.Size(69, 13);
            this.label_serverName.TabIndex = 0;
            this.label_serverName.Text = "ServerName:";
            // 
            // panel_ServerProperties
            // 
            this.panel_ServerProperties.Controls.Add(this.label_serverName);
            this.panel_ServerProperties.Location = new System.Drawing.Point(3, 3);
            this.panel_ServerProperties.Name = "panel_ServerProperties";
            this.panel_ServerProperties.Size = new System.Drawing.Size(755, 43);
            this.panel_ServerProperties.TabIndex = 1;
            // 
            // panel_ServerActions
            // 
            this.panel_ServerActions.Location = new System.Drawing.Point(552, 49);
            this.panel_ServerActions.Name = "panel_ServerActions";
            this.panel_ServerActions.Size = new System.Drawing.Size(200, 421);
            this.panel_ServerActions.TabIndex = 0;
            // 
            // panel_serverBrowseCTRL
            // 
            this.panel_serverBrowseCTRL.Location = new System.Drawing.Point(3, 49);
            this.panel_serverBrowseCTRL.Name = "panel_serverBrowseCTRL";
            this.panel_serverBrowseCTRL.Size = new System.Drawing.Size(543, 421);
            this.panel_serverBrowseCTRL.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(603, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "open in Tab";
            this.button1.UseVisualStyleBackColor = true;
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
            this.tabControl_Server.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.NodeInspector.ResumeLayout(false);
            this.NodeInspector.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PopupMenu.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.browseTreeCtrlBindingSource)).EndInit();
            this.panel_server.ResumeLayout(false);
            this.panel_ServerProperties.ResumeLayout(false);
            this.panel_ServerProperties.PerformLayout();
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
        private System.Windows.Forms.Button buttonNamespace;
        private System.Windows.Forms.Button addToCollectorModel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl_Server;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buttonNamespaces;
        private System.Windows.Forms.Button connectNode;
        private System.Windows.Forms.TabPage tabPage2;
        private Forms.ServerBrowseNodeCTRL serverBrowseNodeCTRL1;
        private System.Windows.Forms.CheckBox isServerReg;
        private System.Windows.Forms.Button regServerButton;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel_ServerProperties;
        private System.Windows.Forms.Label label_serverName;
        private System.Windows.Forms.Panel panel_server;
        private System.Windows.Forms.Panel panel_serverBrowseCTRL;
        private System.Windows.Forms.Panel panel_ServerActions;
        private System.Windows.Forms.Button button1;
    }
}