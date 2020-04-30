using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Opc.Ua;
using Opc.Ua.Server;
using ServerCollector;
using ServerCollector.Forms.Elements;
namespace ServerCollector.Forms
{
    public partial class ServerBrowseNodeCTRL : UserControl
    {
        #region constructors
        public ServerBrowseNodeCTRL()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="server">the server who's Datamodel shall be shown</param>
        /// <param name="roots">the root Nodes where start displaying the Nodes</param>
        public ServerBrowseNodeCTRL(CollectorServer server,IList<BaseInstanceState> roots)
        {
            InitializeComponent();
            this.context=server.GetSystemContext();
            this.roots = roots;
            updateView();
        }
        #endregion

        #region public methods
        /// <summary>
        /// Initialize the TreeView with new start Values
        /// </summary>
        /// <param name="context">Systemcontext where the Nodes are definded</param>
        /// <param name="roots"></param>
        public void InitializeView(SystemContext context, IList<BaseInstanceState> roots)
        {
            // initialize private fields
            this.context = context;
            this.roots = roots;
            updateView();
        }
        /// <summary>
        /// updates the TreeView
        /// </summary>
        public void updateView()
        {
            this.ServerBrowseTreeView.Nodes.Clear();
            foreach (BaseInstanceState root in roots)
            {
                TreeViewNode rootnode = new TreeViewNode(root);
                this.ServerBrowseTreeView.Nodes.Add(rootnode);
                addChildrenIter(getChildren(root), rootnode);
            }
        }
        /// <summary>
        /// return the selected Node of the TreeView
        /// </summary>
        /// <returns>selected Node</returns>
        public BaseInstanceState getSelectedNode()
        {
            TreeViewNode nodeView = (TreeViewNode)this.ServerBrowseTreeView.SelectedNode;
            return nodeView.getNode();
        }
        #endregion

        #region private methods
        /// <summary>
        /// adds all children nodes of a specific parent TreeNode in the TreeView/node model recursive
        /// </summary>
        /// <param name="children">nodes to add as children of parent in the nodeview / TreeView</param>
        /// <param name="parent">parent node where to subordinate the children nodes</param>
        private void addChildrenIter(IList<BaseInstanceState> children,TreeViewNode parent)
        {
            foreach(BaseInstanceState child in children)
            {
                TreeViewNode childNode = new TreeViewNode(child);
                parent.Nodes.Add(childNode);
                IList<BaseInstanceState> grandchildren= getChildren(child);
                if (grandchildren != new List<BaseInstanceState>()) addChildrenIter(grandchildren, childNode);
            }
        }
        /// <summary>
        /// get all children of a specific node in a server context
        /// </summary>
        /// <param name="parent">node to get children of</param>
        /// <returns>List of children nodes from parent node</returns>
        private IList<BaseInstanceState> getChildren(BaseInstanceState parent)
        {
            IList<BaseInstanceState> children= new List<BaseInstanceState>();
            if (this.context == null) throw new Exception("ServerBrowseNodeCTRL: Systemcontext is null");

            parent.GetChildren(this.context, children);
            return children;
        }
        #endregion
        #region private members
        // system / server contex
        private SystemContext context;
        // root nodes where to start displaying the node hierachy
        private IList<BaseInstanceState> roots;
        #endregion
    }
}
