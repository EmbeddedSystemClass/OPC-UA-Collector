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
namespace ServerCollector.Forms
{
    public partial class ServerBrowseNodeCTRL : UserControl
    {
        public ServerBrowseNodeCTRL()
        {
            InitializeComponent();
        }
        public ServerBrowseNodeCTRL(CollectorServer server,BaseObjectState root)
        {
            InitializeComponent();
            this.context=server.GetSystemContext();
            this.root = root;
            InitializeView();
        }
        public void InitializeView(SystemContext context, BaseObjectState root)
        {
            // initialize private fields
            this.context = context;
            this.root = root;
            //set Root node
            string rootName = root.DisplayName.ToString();
            this.ServerBrowseTreeView.Nodes.Add(rootName);

            //SetAutoScrollMargin children nodes
            IList<BaseInstanceState> children = new List<BaseInstanceState>();
            root.GetChildren(context, children);
            
            foreach (BaseObjectState child in children)
            {
                this.ServerBrowseTreeView.Nodes[0].Nodes.Add(child.DisplayName.ToString());
            }
            this.ServerBrowseTreeView.ExpandAll();
            this.ServerBrowseTreeView.Update();
        }
        private void InitializeView()
        {
            this.InitializeView(this.context, this.root);
        }
        #region private members
        private SystemContext context;
        private BaseObjectState root;
        #endregion
    }
}
