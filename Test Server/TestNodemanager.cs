using System;
using System.Collections.Generic;
using Opc.Ua;
using Opc.Ua.Server;
using System.Threading;
namespace Test_Server
{
    public class TestNodeManager : CustomNodeManager2
    {
        #region Constructors
        /// <summary>
        /// Initializes the node manager.
        /// </summary>
        public TestNodeManager(IServerInternal server, ApplicationConfiguration configuration)
        :
            // base(server, configuration, Namespaces.Demo)
            base(server, configuration, "test.Server")
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
                BaseObjectState TestValues = new BaseObjectState(null);
                TestValues.NodeId = new NodeId(1000);
                TestValues.BrowseName = new QualifiedName("TestValues", NamespaceIndex);
                TestValues.DisplayName = TestValues.BrowseName.Name;
                TestValues.TypeDefinitionId = ObjectTypeIds.BaseObjectType;
                TestValues.AddReference(ReferenceTypeIds.Organizes, true, ObjectIds.ObjectsFolder);
                references.Add(new NodeStateReference(ReferenceTypeIds.Organizes, false, TestValues.NodeId));

                PropertyState random = new PropertyState(TestValues);
                random.NodeId = new NodeId(1001);
                random.BrowseName = new QualifiedName("RandomValue", NamespaceIndex);
                random.DisplayName = random.BrowseName.Name;
                random.TypeDefinitionId = VariableTypeIds.PropertyType;
                random.ReferenceTypeId = ReferenceTypeIds.HasProperty;
                random.DataType = DataTypeIds.Int32;
                random.ValueRank = ValueRanks.Scalar;
                ParameterizedThreadStart randomUpdate = new ParameterizedThreadStart(updateValue);
                Thread randomThread = new Thread(randomUpdate);
                randomThread.Start();
                TestValues.AddChild(random);

            }
        }
        public static void updateValue(object node_)
        {
            Random random = new Random();
            PropertyState node= (PropertyState) node_;
            while (true){
                Thread.Sleep(100);
                node.Value = random.Next(0, 100);
            }
        }
        /// <summary>
        /// Import NodeSets from xml
        /// </summary>
        /// <param name="path">String to path of XML</param>
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
       #region Private Fields
        BaseObjectState machines;
        BaseObjectTypeState ControllerObject;
        IReference[] externalRef;
        #endregion
    }
}
