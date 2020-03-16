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
        public ServiceResult addNamespace(ISystemContext context, MethodState method, IList<object> inputsArguments, IList<object> outputArguments)
        {
            Debug.WriteLine("called: " + method.DisplayName.Text + " ; addNamespace");
            if (inputsArguments[0].ToString() == null || inputsArguments[0].ToString() == "")
                return StatusCodes.BadArgumentsMissing;
            ushort index = SystemContext.NamespaceUris.GetIndexOrAppend(inputsArguments[0].ToString());
            context.SessionId.ToString();
            outputArguments[0] = index.ToString();
            return StatusCodes.Good;
            //context.SessionId;
        }

        public ServiceResult addObjectNode(ISystemContext context, MethodState method, IList<object> inputsArguments, IList<object> outputArguments)
        {

            Debug.WriteLine("called: " + method.DisplayName.Text + " ; addObjectNode");
            return StatusCodes.BadNotImplemented;
        }
        public ServiceResult authenticate(ISystemContext context, MethodState method, IList<object> inputsArguments, IList<object> outputArguments)
        {
            ClientOPC cl;
            string token = inputsArguments[0].ToString();
            if (!ServerCollector.Clients.token_Client.TryGetValue(token, out cl))
            {
                return StatusCodes.BadAggregateInvalidInputs;
            }
            cl.authenticate(token, context.SessionId);
            return StatusCodes.Good;
        }
        public ServiceResult getObjectRootNode(ISystemContext context, MethodState method, IList<object> inputsArguments, IList<object> outputArguments)
        {
            ClientOPC client = Clients.clients[0];
            //try to get client
            if (!Clients.session_client.TryGetValue(context.SessionId, out client))
            {
                //No Client for this session id
                return StatusCodes.BadSessionIdInvalid;
            }
            //test if client root node is alread set
            if (!client.isRootset || true)
            {
                addCollectorRootObject(client, "test");
            }
            //NodeState nodest = client.RootObject;
            //FileStream fs = new FileStream(context.SessionId.ToString() + ".xml",FileMode.Create);
            //XmlEncoder xml = new XmlEncoder(ServiceMessageContext.GlobalContext);
            //nodest.SaveAsXml(context,xml);
            //Debug.WriteLine(xml.ToString());

            Debug.WriteLine("called: " + method.DisplayName.Text + " ; getObjectRootNode");
            return StatusCodes.BadNotImplemented;
        }
        public ServiceResult registerServer(ISystemContext contex, MethodState method, IList<object> inputArguments, IList<object> outputarguments)
        {
            IEnumerator<object> inputs = inputArguments.GetEnumerator();
            inputs.MoveNext();
            string token = ClientToken.getClientToken(inputs.Current.ToString());
            ClientOPC client;
            if (Clients.token_Client.TryGetValue(token, out client))
            {
                outputarguments[0] = token;
                return StatusCodes.Good;
            }
            client = new ClientOPC(inputArguments[0], contex.SessionId);
            Clients.addClient(client);
            outputarguments[0] = client.token;
            addCollectorRootObject(client, inputs.MoveNext() ? inputs.Current.ToString() : contex.SessionId.ToString());
            return StatusCodes.Good;
        }
        #endregion
        #region private fields
        private NodeManagerCollector collectorNodeManager;
        #endregion
    }
}
