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
        public delegate void nodeSelected(BaseObjectState selectedNode);
        public nodeSelected onSelected;
        public NodeSelector(nodeSelected method)
        {
            onSelected = method;
            InitializeComponent();
        }
        #region methods
        #endregion
    }
}
