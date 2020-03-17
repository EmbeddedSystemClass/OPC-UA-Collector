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
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            //item.
            //m_server.addNamespace("test");
        }
        #endregion
        #region private fields
        ApplicationInstance m_application;
        CollectorServer m_server;
        Opc.Ua.ApplicationConfiguration m_configuration;
        #endregion
        private async void connectToCollector_()
        {
            EndpointDescription endpointDescription = CoreClientUtils.SelectEndpoint(m_configuration.ServerConfiguration.BaseAddresses[0], false, 1000);

            EndpointConfiguration endpointConfiguration = EndpointConfiguration.Create(m_configuration);
            ConfiguredEndpoint endpoint = new ConfiguredEndpoint(null, endpointDescription, endpointConfiguration);
            m_server.sess
            m_server session = await Session.Create(
                m_configuration,
                endpoint,
                false,
                !DisableDomainCheck,
                (String.IsNullOrEmpty(SessionName)) ? m_configuration.ApplicationName : SessionName,
                60000,
                UserIdentity,
                PreferredLocales);

            // set up keep alive callback.
            m_session.KeepAlive += new KeepAliveEventHandler(Session_KeepAlive);

            // raise an event.
            DoConnectComplete(null);

            // return the new session.
            return m_session;
        }
        private void buttonNamespace_Click(object sender, EventArgs e)
        {
            ServerCollector.Forms.InputDialog input = new Forms.InputDialog("test");
            input.ShowDialog() ;
            m_server.addNamespace(input.getInputText());
        }

        private void buttonNamespaces_Click(object sender, EventArgs e)
        {
            m_server.addNamespaces(this.connectServerCtrl1.Session.NamespaceUris.ToArray());
        }
    }
}
