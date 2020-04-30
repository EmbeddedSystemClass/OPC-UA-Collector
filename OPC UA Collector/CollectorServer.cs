using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Opc.Ua;
using Opc.Ua.Configuration;
using Opc.Ua.Server;

namespace ServerCollector
{
    
    public class CollectorServer : StandardServer
     {
        
        #region Overridden Methods
            /// <summary>
            /// Creates the node managers for the server.
            /// </summary>
            /// <remarks>
            /// This method allows the sub-class create any additional node managers which it uses. The SDK
            /// always creates a CoreNodeManager which handles the built-in nodes defined by the specification.
            /// Any additional NodeManagers are expected to handle application specific nodes.
            /// </remarks>
            protected override MasterNodeManager CreateMasterNodeManager(IServerInternal server, ApplicationConfiguration configuration)
            {
                Utils.Trace("Creating the Node Managers.");
            
                List<INodeManager> nodeManagers = new List<INodeManager>();

                collectorNodeManager = new NodeManagerCollector(server, configuration);
                // create the custom node managers.
                nodeManagers.Add(collectorNodeManager);
            
            // create master node manager.
            return new MasterNodeManager(server, configuration, null, nodeManagers.ToArray());
            }
        /// <summary>
        /// Loads the non-configurable properties for the application.
        /// </summary>
        /// <remarks>
        /// These properties are exposed by the server but cannot be changed by administrators.
        /// </remarks>
        protected override ServerProperties LoadServerProperties()
        { 
            ServerProperties properties = new ServerProperties();

            properties.ManufacturerName = "Dermo Manufacturer";
            // properties.ProductName = "Quickstart InformationModel Server";
            // properties.ProductUri = "http://opcfoundation.org/Quickstart/InformationModelServer/v1.0";
            properties.ProductName = "Demo Server";
            // properties.ProductUri = "http://demo.demo/Demo";
            properties.ProductUri = "http://opcfoundation.org/Quickstart/MethodsServer/v1.0";
            properties.SoftwareVersion = Utils.GetAssemblySoftwareVersion();
            properties.BuildNumber = Utils.GetAssemblyBuildNumber();
            properties.BuildDate = Utils.GetAssemblyTimestamp();

            // TBD - All applications have software certificates that need to added to the properties.

            return properties;
        }
        
        #endregion
        #region Controller Methods
        // methods of the Collector Server, special actions
        /// <summary>
        /// add a url to Namespaces and return the id
        /// </summary>
        /// <param name="url">url to add to Namespaces of the Server</param>
        /// <returns>Namespaceindex</returns>
        public ushort addNamespace(string url)
        {
            return collectorNodeManager.addNamespace(url);
        }
        /// <summary>
        /// add multiple url's to Namespaces of the server
        /// </summary>
        /// <param name="urls">url's to add to Naespace</param>
        /// <returns>List of Namespaceindexes of the added url's</returns>
        public ushort[] addNamespaces(string[] urls)
        {
            return collectorNodeManager.addNamespaces(urls).ToArray();
        }
        /// <summary>
        /// sipmply return the systemcontext of the server
        /// </summary>
        /// <returns>systemcontext of the server</returns>
        public void addNode(BaseInstanceState node, NodeId parentId)
        {
            this.collectorNodeManager.addNode(node, parentId);
        }
        public NamespaceTable getNamespaces()
        {
            return collectorNodeManager.SystemContext.NamespaceUris;
        }
        public int getNamespaceIndex(string namespaceUri)
        {
            return collectorNodeManager.SystemContext.NamespaceUris.GetIndex(namespaceUri);
        }
        public void registerServer(string Name, object identifier, Opc.Ua.Client.Session client_session)
        {
            if (child_server.ContainsKey(identifier)) throw new Exception("Child Server with identifier already exist");
            Client.Client client = new Client.Client(Name, identifier, client_session);
            child_server.Add(identifier,client);
            collectorNodeManager.addChildRootNode(Name,machineNode);
        }
        public void addVariableConnection(BaseVariableState collectorNode,ReferenceDescription item, object clientIdentifier)
        {
            child_server[clientIdentifier].addConnection(collectorNode, item);
        }
        public bool isClientRegistered(object identifier)
        {
            return child_server.ContainsKey(identifier);
        }
        public SystemContext GetSystemContext()
        {
            return collectorNodeManager.SystemContext;
        }
        /// <summary>
        /// simply return the machine node of the server
        /// </summary>
        /// <returns>machine node of server</returns>
        public BaseObjectState getMachineNode()
        {
            return collectorNodeManager.machines;
        }
        #endregion
        #region private fields
        public BaseObjectState machineNode { 
            get
            {
                return this.collectorNodeManager.machines;
            }
        }
        private NodeManagerCollector collectorNodeManager;
        private Dictionary<object, Client.Client> child_server= new Dictionary<object, Client.Client>();
        #endregion
    }
}
