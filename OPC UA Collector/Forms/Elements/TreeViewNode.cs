using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opc.Ua;
namespace ServerCollector.Forms.Elements
{
    class TreeViewNode:System.Windows.Forms.TreeNode
    {
        public TreeViewNode(BaseInstanceState node)
        {
            this.Node = node;
            this.Name = Node.BrowseName.ToString();
            this.Text = Node.DisplayName.Text;
        }
        public BaseInstanceState getNode()
        {
            return Node;
        }
        #region private Members
        private BaseInstanceState Node; 
        #endregion
    }
}
