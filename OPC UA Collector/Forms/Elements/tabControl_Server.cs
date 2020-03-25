using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opc.Ua.Client;
namespace ServerCollector.Forms.Elements
{
    class tabControl_Server:System.Windows.Forms.TabPage
    {
        public tabControl_Server(Session session):base()
        {
            this.session = session;
            InitializeComponents();
        }
        public void InitializeComponents()
        {
            // initialize 
            this.panel_server = new System.Windows.Forms.Panel();
            this.panel_ServerProperties = new System.Windows.Forms.Panel();
            this.panel_ServerActions = new System.Windows.Forms.Panel();
            this.label_serverName = new System.Windows.Forms.Label();
            // 
            // tabPage3
            // 
            this.Controls.Add(this.panel_ServerProperties);
            this.Controls.Add(this.panel_server);
            this.Location = new System.Drawing.Point(23, 4);
            this.Name = "tabPage3";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(761, 479);
            this.TabIndex = 2;
            this.Text = "tabPage3";
            this.UseVisualStyleBackColor = true;
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
            // label_serverName
            // 
            this.label_serverName.AutoSize = true;
            this.label_serverName.Location = new System.Drawing.Point(-3, 0);
            this.label_serverName.Name = "label_serverName";
            this.label_serverName.Size = new System.Drawing.Size(69, 13);
            this.label_serverName.TabIndex = 0;
            this.label_serverName.Text = "ServerName:";
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
            // panel_serverBrowseCTRL
            // 
            this.panel_serverBrowseCTRL.Location = new System.Drawing.Point(3, 49);
            this.panel_serverBrowseCTRL.Name = "panel_serverBrowseCTRL";
            this.panel_serverBrowseCTRL.Size = new System.Drawing.Size(543, 421);
            this.panel_serverBrowseCTRL.TabIndex = 1;
        }
        #region private Members
        private Session session;
        #endregion
        #region Forms
        private System.Windows.Forms.Panel panel_serverBrowseCTRL;
        private System.Windows.Forms.Panel panel_server;
        private System.Windows.Forms.Label label_serverName;
        private System.Windows.Forms.Panel panel_ServerProperties;
        private System.Windows.Forms.Panel panel_ServerActions;
        #endregion
    }
}
