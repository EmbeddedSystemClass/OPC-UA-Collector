﻿/* ========================================================================
 * Copyright (c) 2005-2016 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 * 
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 * 
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

using System;
using System.Collections.Generic;
using System.Xml;
using System.Threading;
using Opc.Ua;
using Opc.Ua.Server;
using System.IO;
using System.Reflection;
// Namespaces Zum Zugriff auf die SQLServer-Datenbank
using System.Data.SqlClient;
using System.Diagnostics;
using ServerCollector;
using ServerCollector.old;

namespace ServerCollector
{
    /// <summary>
    /// A node manager the diagnostic information exposed by the server.
    /// </summary>
    public class NodeManagerCollector : CustomNodeManager2
    {
        #region Constructors
        /// <summary>
        /// Initializes the node manager.
        /// </summary>
        public NodeManagerCollector(IServerInternal server, ApplicationConfiguration configuration)
        :
            // base(server, configuration, Namespaces.Demo)
            base(server, configuration, ServerCollector.Namespaces.Collector)
        {
            SystemContext.NodeIdFactory = this;

            //m_configuration = configuration.ParseExtension<DemoConfiguration>();
            //if (m_configuration == null)
            //{
            //    m_configuration = new DemoConfiguration();
            //}

        }
        #endregion

        #region INodeIdFactory Members
        /// <summary>
        /// Creates the NodeId for the specified node.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="node">The node.</param>
        /// <returns>The new NodeId.</returns>
        public override NodeId New(ISystemContext context, NodeState node)
        {
            // uint id = Utils.IncrementIdentifier(ref m_lastUsedId);
            // return new NodeId(id, m_namespaceIndex);

            return node.NodeId;
        }
        #endregion

        #region INodeManager Members
        /// <summary>
        /// Does any initialization required before the address space can be used.
        /// </summary>
        /// <remarks>
        /// The externalReferences is an out parameter that allows the node manager to link to nodes
        /// in other node managers. For example, the 'Objects' node is managed by the CoreNodeManager and
        /// should have a reference to the root folder node(s) exposed by this node manager.  
        /// </remarks>
        public override void CreateAddressSpace(IDictionary<NodeId, IList<IReference>> externalReferences)
        {
            
            lock (Lock)
            {
                // ensure the process object can be found via the server object. 
                IList<IReference> references = null;

                if (!externalReferences.TryGetValue(ObjectIds.ObjectsFolder, out references))
                {
                    externalReferences[ObjectIds.ObjectsFolder] = references = new List<IReference>();
                }

                try
                {
                    NodeStateCollection nodes = ImportXml(externalReferences, "../../References/ServerCollector.xml");
                    fillCollector(nodes);
                }
                catch (FileNotFoundException exc)
                {
                    Debug.WriteLine("can't opern file ! ", exc.Message);
                }

            }
        }
        
        /// <summary>
        /// Import NodeSets from xml
        /// </summary>
        /// <param name="path">String to path of XML</param>
        private NodeStateCollection ImportXml(IDictionary<NodeId, IList<IReference>> externalReferences, string resourcepath)
        {
            NodeState mnode = null;
            NodeStateCollection predefinedNodes = new NodeStateCollection();
            try
            {
                Stream stream = new FileStream(resourcepath, FileMode.Open);
                Opc.Ua.Export.UANodeSet nodeSet = Opc.Ua.Export.UANodeSet.Read(stream);

                foreach (string namespaceUri in nodeSet.NamespaceUris)
                {
                    SystemContext.NamespaceUris.GetIndexOrAppend(namespaceUri);
                }
                nodeSet.Import(SystemContext, predefinedNodes);

                for (int ii = 0; ii < predefinedNodes.Count; ii++)
                {
                    // die gefundenen Knoten in Hauptspeicher-Struktur laden
                    AddPredefinedNode(SystemContext, predefinedNodes[ii]);
                }

                // ensure the reverse refernces exist.
                AddReverseReferences(externalReferences);

            }
            catch (Exception fehler)
            {
                Console.WriteLine("Fehler in ImportXML: --> \n" +fehler.Message);
                throw;
            }
            return predefinedNodes;
        }
      
        protected override NodeHandle GetManagerHandle(ServerSystemContext context, NodeId nodeId, IDictionary<NodeId, NodeState> cache)
        {
            lock (Lock)
            {
                // quickly exclude nodes that are not in the namespace. 
                if (!IsNodeIdInNamespace(nodeId))
                {
                    return null;
                }

                NodeState node = null;

                if (!PredefinedNodes.TryGetValue(nodeId, out node))
                {
                    return null;
                }

                NodeHandle handle = new NodeHandle();

                handle.NodeId = nodeId;
                handle.Node = node;
                handle.Validated = true;

                return handle;
            }
        }

        /// <summary>
        /// Verifies that the specified node exists.
        /// </summary>
        protected override NodeState ValidateNode(
            ServerSystemContext context,
            NodeHandle handle,
            IDictionary<NodeId, NodeState> cache)
        {
            // not valid if no root.
            if (handle == null)
            {
                return null;
            }

            // check if previously validated.
            if (handle.Validated)
            {
                return handle.Node;
            }

            // TBD

            return null;
        }

        #endregion

        #region NodeManager
        // methods for Handling Nodes
        /// <summary>
        /// add a Node as a child node of a parent to node structure
        /// </summary>
        /// <param name="node">node to add</param>
        /// <param name="Parent">parent node of the node</param>
        public void addNode(BaseInstanceState node, BaseInstanceState Parent)
        {
            addNode(node, Parent.NodeId);
        } 
        public void addNode(BaseInstanceState node , NodeId parentId)
        {
            NodeState parent = Find(parentId);
            if (Find(node.NodeId) != null) { 
                node.NodeId = getFreeNodeId(node.NodeId.NamespaceIndex, node.NodeId.Identifier.GetType() ==typeof(int)?(uint)node.NodeId.Identifier:10000);
            }
            parent.AddChild(node);
            AddPredefinedNode(SystemContext, parent);
            parent.AddReference(ReferenceTypes.HasComponent, true, node.NodeId);
            IDictionary<NodeId, List<IReference>> refs = new Dictionary<NodeId, List<IReference>>();
            //IReference iref = parent.ref;
            //refs.Add(parent.NodeId, parent.GetReferences(SystemContext));
            //AddReferences();
        }
        public ushort addNamespace(string url)
        {
            return SystemContext.NamespaceUris.GetIndexOrAppend(url);
        }
        public List<ushort> addNamespaces(string[] urls)
        {
            List<ushort> indices = new List<ushort>();
            foreach(string url in urls)
            {
                indices.Add(addNamespace(url));
            }
            return indices;
        }
        
        #endregion

        // methods called by external clients via opc ua
        #region Collector opc ua methods
        public ServiceResult method_ControllerMethodStandard(ISystemContext context, MethodState method, IList<object> inputsArguments, IList<object> outputArguments)
        {
            //System.Windows.Forms.MessageBox.Show("test");

            return StatusCodes.BadNotImplemented;
        }
        public ServiceResult method_addNamespace(ISystemContext context, MethodState method, IList<object> inputsArguments, IList<object> outputArguments)
        {
            Debug.WriteLine("called: " + method.DisplayName.Text + " ; addNamespace");
            if (inputsArguments[0].ToString() == null || inputsArguments[0].ToString() == "")
                return StatusCodes.BadArgumentsMissing;
            List<string> urls = new List<string>();
            outputArguments[0] = addNamespace(inputsArguments[0].ToString()) ;
            return StatusCodes.Good;
        }

        public ServiceResult method_addObjectNode(ISystemContext context, MethodState method, IList<object> inputsArguments, IList<object> outputArguments)
        {

            Debug.WriteLine("called: " + method.DisplayName.Text + " ; addObjectNode");
            return StatusCodes.BadNotImplemented;
        }
        public ServiceResult method_authenticate(ISystemContext context, MethodState method, IList<object> inputsArguments, IList<object> outputArguments)
        {
            ClientOPC cl;
            string token = inputsArguments[0].ToString();
            if (!Clients.token_Client.TryGetValue(token, out cl))
            {
                return StatusCodes.BadAggregateInvalidInputs;
            }
            cl.authenticate(token, context.SessionId);
            return StatusCodes.Good;
        }
        public ServiceResult method_getObjectRootNode(ISystemContext context, MethodState method, IList<object> inputsArguments, IList<object> outputArguments)
        {
            throw new NotImplementedException();
            ClientOPC client = Clients.clients[0];
            //try to get client
            if (!Clients.session_client.TryGetValue(context.SessionId, out client))
            {
                //No Client for this session id
                return StatusCodes.BadSessionIdInvalid;
            }
            //test if client root node is alread set
            if (!client.isRootset||true)
            {
                //addCollectorRootObject(client,"test");
            }

            Debug.WriteLine("called: " + method.DisplayName.Text + " ; getObjectRootNode");
            return StatusCodes.BadNotImplemented;
        }
        public ServiceResult method_registerServer(ISystemContext contex, MethodState method, IList<object> inputArguments, IList<object> outputarguments)
        {
            throw new NotImplementedException();
            IEnumerator<object> inputs = inputArguments.GetEnumerator();
            inputs.MoveNext();
            string token=ClientToken.getClientToken(inputs.Current.ToString());
            ClientOPC client;
            if(Clients.token_Client.TryGetValue(token,out client))
            {
                outputarguments[0] = token;
                return StatusCodes.Good;
            }
            client = new ClientOPC(inputArguments[0], contex.SessionId);
            Clients.addClient(client);
            outputarguments[0] = client.token;
            //addCollectorRootObject(client,inputs.MoveNext()?inputs.Current.ToString():contex.SessionId.ToString());
            return StatusCodes.Good;
            
        }
        #endregion

        // small helpers for the main collector methods
        #region Collector helpers
        private void createMethod(NodeState parent, MethodState method, PropertyState inputs, PropertyState output, GenericMethodCalledEventHandler methodToBeCalled)
        {

            // a method to start the process.
            MethodState start = new MethodState(parent);

            start.NodeId = method.NodeId;
            start.BrowseName = method.BrowseName;
            start.DisplayName = method.BrowseName.Name;
            start.ReferenceTypeId = ReferenceTypeIds.HasComponent;
            start.UserExecutable = true;
            start.Executable = true;

            // add input arguments.
            start.InputArguments = new PropertyState<Argument[]>(start);
            start.InputArguments.NodeId = inputs.NodeId;
            start.InputArguments.BrowseName = BrowseNames.InputArguments;
            start.InputArguments.DisplayName = start.InputArguments.BrowseName.Name;
            start.InputArguments.TypeDefinitionId = VariableTypeIds.PropertyType;
            start.InputArguments.ReferenceTypeId = ReferenceTypeIds.HasProperty;
            start.InputArguments.DataType = DataTypeIds.Argument;
            start.InputArguments.ValueRank = ValueRanks.OneDimension;

            List<Argument> args = new List<Argument>();
            Argument arg;
            foreach (ExtensionObject ext in (ExtensionObject[])inputs.Value)
            {
                arg = (Argument)ext.Body;
                args.Add(arg);
            }
            start.InputArguments.Value = args.ToArray();

            // add output arguments.
            start.OutputArguments = new PropertyState<Argument[]>(start);
            start.OutputArguments.NodeId = output.NodeId;
            start.OutputArguments.BrowseName = BrowseNames.OutputArguments;
            start.OutputArguments.DisplayName = start.OutputArguments.BrowseName.Name;
            start.OutputArguments.TypeDefinitionId = VariableTypeIds.PropertyType;
            start.OutputArguments.ReferenceTypeId = ReferenceTypeIds.HasProperty;
            start.OutputArguments.DataType = DataTypeIds.Argument;
            start.OutputArguments.ValueRank = ValueRanks.OneDimension;

            args = new List<Argument>();
            foreach (ExtensionObject ext in (ExtensionObject[])inputs.Value)
            {
                arg = (Argument)ext.Body;
                args.Add(arg);
            }
            start.OutputArguments.Value = args.ToArray();

            parent.AddChild(start);
            AddPredefinedNode(SystemContext, parent);
            // save in dictionary. 
            //AddPredefinedNode(SystemContext, process);

            // set up method handlers. 
            start.OnCallMethod = new GenericMethodCalledEventHandler(methodToBeCalled);
        }
        private void fillCollector(NodeStateCollection nodes)
        {
            if (nodes.Equals(null))
            {
                createCollectorObject();
                return;
            }

            Dictionary<NodeId, NodeState> nodeDic = new Dictionary<NodeId, NodeState>();
            foreach (NodeState node in nodes)
            {
                nodeDic.Add(node.NodeId, node);
            }
            NodeState Controller = nodeDic[new NodeId((int)Collector.ObjectsIDs.ObjectController, NamespaceIndex)];

            //properties for addNamespace methodes

            Collector.ObjectsIDs[] methodsid = {
                Collector.ObjectsIDs.ObjectControlleraddNamespace,
                Collector.ObjectsIDs.ObjectControlleraddObjectNode,
                Collector.ObjectsIDs.ObjectControllergetObjectRootNode,
                Collector.ObjectsIDs.ObjectControllerauthenticate,
                Collector.ObjectsIDs.ObjectControllerregisterServer
            };
            foreach (Collector.ObjectsIDs n in methodsid)
            {
                GenericMethodCalledEventHandler m;
                MethodState addNamespaceMethod = (MethodState)nodeDic[new NodeId((ushort)n, NamespaceIndex)];
                NodeState input = nodeDic[new NodeId((ushort)(n + 1), NamespaceIndex)];
                NodeState output = nodeDic[new NodeId((ushort)(n + 2), NamespaceIndex)];
                switch (n)
                {
                    case Collector.ObjectsIDs.ObjectControlleraddNamespace:
                        m = method_addNamespace;
                        break;
                    case Collector.ObjectsIDs.ObjectControlleraddObjectNode:
                        m = method_addObjectNode;
                        break;
                    case Collector.ObjectsIDs.ObjectControllergetObjectRootNode:
                        m = method_getObjectRootNode;
                        break;
                    case Collector.ObjectsIDs.ObjectControllerauthenticate:
                        m = method_authenticate;
                        break;
                    case Collector.ObjectsIDs.ObjectControllerregisterServer:
                        m = method_registerServer;
                        break;
                    default:
                        m = method_ControllerMethodStandard;
                        break;
                }
                createMethod(Controller, addNamespaceMethod, (PropertyState)input, (PropertyState)output, m);
            }
            //machines Folder
            machines = (BaseObjectState)nodeDic[new NodeId((int)Collector.ObjectsIDs.FolderMachines, NamespaceIndex)];
        }
        private void createCollectorObject()
        {
            throw new NotImplementedException();
        }
        public BaseObjectState addChildRootNode(string name, BaseObjectState parentNode= null)
        {
            if (parentNode==null)
            {
                parentNode = machines;
            }
            /*BaseObjectState objRoot = new BaseObjectState(parentNode);
            objRoot.DisplayName = name;
            objRoot.BrowseName = new QualifiedName(name, 3);
            //objRoot.NodeId = getFreeNodeId(3,2000,1000);
            objRoot.NodeId = new NodeId(name, 3);
            objRoot.SymbolicName = name;
            objRoot.ReferenceTypeId = ReferenceTypes.Organizes;
            objRoot.TypeDefinitionId = ObjectTypeIds.BaseObjectType;
            objRoot.WriteMask = AttributeWriteMask.None;
            objRoot.UserWriteMask = AttributeWriteMask.None;
            objRoot.EventNotifier = EventNotifiers.None;*/

            FolderState objfolder = new FolderState(parentNode);

            objfolder.SymbolicName = name;
            objfolder.ReferenceTypeId = ReferenceTypes.Organizes;
            objfolder.TypeDefinitionId = ObjectTypeIds.FolderType;
            objfolder.NodeId = new NodeId(2003, NamespaceIndex);
            objfolder.BrowseName = new QualifiedName(name, NamespaceIndex);
            objfolder.DisplayName = new LocalizedText(name);
            objfolder.WriteMask = AttributeWriteMask.None;
            objfolder.UserWriteMask = AttributeWriteMask.None;
            objfolder.EventNotifier = EventNotifiers.None;
            if (parentNode != null)
            {
                parentNode.AddChild(objfolder);
            }
            AddPredefinedNode(SystemContext, machines);
            return objfolder;
        }
        public NodeId getFreeNodeId(ushort namespaceIndex,uint start=2000,uint step=1)
        {
            while (start < uint.MaxValue - 1)
            {
                if (Find(new NodeId(start))==null) return new NodeId(start,namespaceIndex);
                start += step;
            }
            throw new Exception("no available NodeId!");
        }
        #endregion

        #region Fields
        // Object root node (Folder)
        public BaseObjectState ObjectRoot { private set; get; }
        // machine node, where all machine data of other opc's are stored
        public BaseObjectState machines { private set; get; }
        IReference[] externalRef;
        #endregion
    }
}
