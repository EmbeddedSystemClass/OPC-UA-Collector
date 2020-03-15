using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Opc.Ua.Configuration;
using Opc.Ua.Server;
using Opc.Ua.Client;
namespace ServerCollector
{
    public partial class mainForm : Form
    {
        public mainForm(ApplicationInstance application, ApplicationInstance client=null)
        {
            InitializeComponent();

            m_application = application;
            m_server = application.Server as Opc.Ua.Server.StandardServer;
            m_configuration = application.ApplicationConfiguration;
            this.ServerDiagnosticsCTRL.Initialize(m_server,m_configuration);
            this.connectServerCtrl1.Configuration = client.ApplicationConfiguration;
        }
        #region private fields
        ApplicationInstance m_application;
        Opc.Ua.Server.StandardServer m_server;
        Opc.Ua.ApplicationConfiguration m_configuration;
        #endregion
        #region methods
        private void Server_ConnectComplete(object sender, EventArgs e)
        {
            Opc.Ua.Client.Controls.ConnectServerCtrl client = (Opc.Ua.Client.Controls.ConnectServerCtrl)sender;
            
            BrowseCTRL.ChangeSession(client.Session);
            BrowseCTRL.Update();
        }
        #endregion
    }
}
