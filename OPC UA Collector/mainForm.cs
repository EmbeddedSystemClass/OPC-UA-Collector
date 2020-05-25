using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Opc.Ua.Configuration;
using Opc.Ua.Server;
using Opc.Ua.Client;
using Opc.Ua;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCollector
{
    public partial class mainForm : Form
    {
        public mainForm(ApplicationInstance application)
        {
            InitializeComponent();

            m_application = application;
            m_server = application.Server as CollectorServer;
            m_configuration = application.ApplicationConfiguration;
            this.ServerDiagnosticsCTRL.Initialize(m_server,m_configuration);
            this.connectServerCtrl1.Configuration = application.ApplicationConfiguration;
            List<BaseInstanceState> BrowseNodeCTRLRoots = new List<BaseInstanceState>();
            BrowseNodeCTRLRoots.Add(m_server.machineNode);
            //BrowseNodeCTRLRoots.Add(m_server.collectorNodeManager.ObjectRoot);
            this.serverBrowseNodeCTRL1.InitializeView(m_server.GetSystemContext(), BrowseNodeCTRLRoots);
        }
        
        #region GUI methods
        private void Client_ReconnectCompleted(object sender, EventArgs e)
        {
            Client_ConnectComplete(sender, e);
        }
        private void Client_ConnectComplete(object sender, EventArgs e)
        {
            this.isServerReg.Checked = false;

            try
            {
                Opc.Ua.Client.Controls.ConnectServerCtrl client = (Opc.Ua.Client.Controls.ConnectServerCtrl)sender;
                this.isServerReg.Checked=m_server.isClientRegistered(client.ServerUrl);
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
        private void buttonNamespace_Click(object sender, EventArgs e)
        {
            ServerCollector.Forms.InputDialog input = new Forms.InputDialog("Namespace to add:");
            input.ShowDialog() ;
            
            m_server.addNamespace(input.getInputText());
        }

        private void buttonNamespaces_Click(object sender, EventArgs e)
        {
            m_server.addNamespaces(this.connectServerCtrl1.Session.NamespaceUris.ToArray());
        }

        private void addToCollectorModel_Click(object sender, EventArgs e)
        {
            ServerCollector.Forms.NodeSelector nodeSelector = new Forms.NodeSelector(addSelectedNodeAsChild,this.m_server.GetSystemContext(),this.m_server.getMachineNode());
            nodeSelector.Show();
        }
        private void addSelectedNodeAsChild(BaseInstanceState parentNode)
        {

            ReferenceDescription selectedNode = this.BrowseCTRL.SelectedNode;
            if (selectedNode.NodeClass == NodeClass.Variable)
            {
                ReadValueId nodeToRead = new ReadValueId();
                nodeToRead.NodeId = (NodeId)selectedNode.NodeId;
                nodeToRead.AttributeId = Attributes.Value;
                nodeToRead.Handle = selectedNode;
                ReadValueIdCollection nodesToRead = new ReadValueIdCollection();
                nodesToRead.Add(nodeToRead);

                DataValueCollection results = null;
                DiagnosticInfoCollection diagnosticInfos = null;

                this.connectServerCtrl1.Session.Read(null, 0, TimestampsToReturn.Neither, nodesToRead, out results, out diagnosticInfos);
                ClientBase.ValidateResponse(results, nodesToRead);
                ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToRead);

                TypeInfo varInfo = TypeInfo.Construct(results[0].Value);

                BaseVariableState varNode = new BaseDataVariableState(parentNode);
                varNode.ValueRank = varInfo.ValueRank;
                varNode.WrappedValue = results[0].WrappedValue;
                varNode.NodeId = (NodeId)selectedNode.NodeId;
                varNode.BrowseName = new QualifiedName(selectedNode.DisplayName.Text,(ushort) m_server.getNamespaceIndex(this.connectServerCtrl1.Session.NamespaceUris.GetString(selectedNode.BrowseName.NamespaceIndex)));
                varNode.DisplayName = varNode.BrowseName.Name;
                m_server.addNode(varNode, parentNode.NodeId);
                m_server.addVariableConnection(varNode, selectedNode, this.connectServerCtrl1.ServerUrl);
            }
            else
            {
                BaseObjectState child = new BaseObjectState(parentNode);
                uint nodeid_ident;
                if (UInt32.TryParse(selectedNode.NodeId.Identifier.ToString(), out nodeid_ident)) child.NodeId = new NodeId(nodeid_ident);
                else child.NodeId = new NodeId(selectedNode.NodeId.Identifier.ToString());
                child.BrowseName = selectedNode.BrowseName;
                child.DisplayName = child.BrowseName.Name;
                this.m_server.addNode(child, parentNode.NodeId);
            }
        }

        private void updateView(object sender, PaintEventArgs e)
        {
            this.serverBrowseNodeCTRL1.updateView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // try to find opened Tab with same Adress

            // not opened - add new tab with Adress from ServerConnectorEndpoint


            //TabPage tabPage = new TabPage();
            //tabPage.Text = 
            //this.tabControl_Server.Controls.Add()
        }

        private void regServerButton_Click(object sender, EventArgs e)
        {
            if (m_server.isClientRegistered(connectServerCtrl1.ServerUrl))
            {
                MessageBox.Show("OPC UA Server already registered with identifier: \n" + connectServerCtrl1.ServerUrl.ToString());
                return;

            } 
            ServerCollector.Forms.InputDialog input = new Forms.InputDialog("Name of the Server with URL ("+connectServerCtrl1.ServerUrl+"):");
            
            input.ShowDialog();

            try
            {
                
                m_server.registerServer(input.getInputText(), connectServerCtrl1.ServerUrl, createSession(connectServerCtrl1.ServerUrl).Result);
                this.isServerReg.Checked = true;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async Task<Opc.Ua.Client.Session> createSession(string url)
        {
            // select the best endpoint.
            EndpointDescription endpointDescription = CoreClientUtils.SelectEndpoint(url, true, 5000);

            EndpointConfiguration endpointConfiguration = EndpointConfiguration.Create(m_configuration);
            ConfiguredEndpoint endpoint = new ConfiguredEndpoint(null, endpointDescription, endpointConfiguration);
            
            UserIdentity user = new UserIdentity();

            Opc.Ua.Client.Session session = await Opc.Ua.Client.Session.Create(
                m_configuration,
                endpoint,
                false,
                false,
                "Collector Server",
                60000,
                user,
                null);
            return session;
        }
    }
}
