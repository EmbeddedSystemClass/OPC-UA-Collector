using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Opc.Ua.Configuration;
using Opc.Ua.Server;
using Opc.Ua.Client;
using Opc.Ua;
namespace ServerCollector
{
    public partial class mainForm : Form
    {
        public mainForm(ApplicationInstance application, ApplicationInstance client=null)
        {
            InitializeComponent();

            m_application = application;
            m_server = application.Server as CollectorServer;
            m_configuration = application.ApplicationConfiguration;
            this.ServerDiagnosticsCTRL.Initialize(m_server,m_configuration);
            this.connectServerCtrl1.Configuration = client.ApplicationConfiguration;
        }
        #region private fields
        ApplicationInstance m_application;
        CollectorServer m_server;
        Opc.Ua.ApplicationConfiguration m_configuration;
        #endregion
        #region GUI methods
        private void Client_ReconnectCompleted(object sender, EventArgs e)
        {
            Client_ConnectComplete(sender, e);
        }
        private void Client_ConnectComplete(object sender, EventArgs e)
        {
            try
            {
                Opc.Ua.Client.Controls.ConnectServerCtrl client = (Opc.Ua.Client.Controls.ConnectServerCtrl)sender;
                if (client.Session == null)
                {
                    return;
                }
                BrowseCTRL.Initialize(client.Session, ObjectIds.ObjectsFolder, ReferenceTypeIds.Organizes, ReferenceTypeIds.Aggregates);
                BrowseCTRL.ChangeSession(client.Session);
                BrowseCTRL.Update();
            }
            catch(Exception E)
            {
                Debug.WriteLine(E.Message);
            }
        }
        private void addToCollector_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
