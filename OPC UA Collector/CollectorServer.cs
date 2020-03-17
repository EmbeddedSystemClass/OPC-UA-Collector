﻿using System;
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
        public ushort addNamespace(string url)
        {
            return collectorNodeManager.addNamespace(url);
        }
        public ushort[] addNamespaces(string[] urls)
        {
            return collectorNodeManager.addNamespaces(urls).ToArray();
        }
        #endregion
        #region private fields
        private NodeManagerCollector collectorNodeManager;
        #endregion
    }
}
