using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Opc.Ua;
namespace ServerCollector.Forms
{
    public partial class NodeSelector : Form
    {
        public delegate void nodeSelected(BaseInstanceState selectedNode);
        public nodeSelected onSelected;
        public NodeSelector(nodeSelected method,SystemContext context,BaseInstanceState root)
        {
            this.context = context;
            this.onSelected = method;
            this.rootNode = root;
            InitializeComponent();
            this.serverBrowseNodeCTRL1.InitializeView(this.context,new BaseInstanceState[] { this.rootNode });
        }
        #region methods
        /// <summary>
        /// called by pressing the selection button, invoke the action onSelected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selected_click(object sender , EventArgs e)
        {
            callOnSelected(this.serverBrowseNodeCTRL1.getSelectedNode());
        }
        /// <summary>
        /// call onSelected methods
        /// </summary>
        /// <param name="node">BaseInstanceState of the node where action will be performed on</param>
        private void callOnSelected(BaseInstanceState node)
        {
            onSelected(node);
        }
        #endregion
        #region private Members
        //RootNode where to start displaying the Nodes in the NodeView
        private BaseInstanceState rootNode;
        // in which context (environment)
        private SystemContext context;
        #endregion
    }
}
