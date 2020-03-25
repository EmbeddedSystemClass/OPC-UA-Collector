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
        public ServerBrowseNodeCTRL(CollectorServer server,IList<BaseInstanceState> roots)
        {
            InitializeComponent();
            this.context=server.GetSystemContext();
            this.roots = roots;
            updateView();
        }
        #endregion
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
        private void addChildrenIter(IList<BaseInstanceState> children,TreeViewNode parent)
        {
            foreach(BaseObjectState child in children)
            {
                TreeViewNode childNode = new TreeViewNode(child);
                parent.Nodes.Add(childNode);
                IList<BaseInstanceState> grandchildren= getChildren(child);
                if (grandchildren != new List<BaseInstanceState>()) addChildrenIter(grandchildren, childNode);
            }
        }
        private IList<BaseInstanceState> getChildren(BaseInstanceState parent)
        {
            IList<BaseInstanceState> children= new List<BaseInstanceState>();
            if (this.context == null) throw new Exception("ServerBrowseNodeCTRL: Systemcontext is null");

            parent.GetChildren(this.context, children);
            return children;
        }
        public BaseInstanceState getSelectedNode()
        {
            TreeViewNode nodeView = (TreeViewNode)this.ServerBrowseTreeView.SelectedNode;
            return nodeView.getNode();
        }
        #region private members
        private SystemContext context;
        private IList<BaseInstanceState> roots;
        #endregion
    }
}
