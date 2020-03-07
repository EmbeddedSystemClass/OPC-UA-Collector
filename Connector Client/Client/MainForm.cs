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
using Opc.Ua.Client;
using Opc.Ua.Client.Controls;
using Opc.Ua.Client;

namespace Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        public MainForm(ApplicationConfiguration configuration)
        {
            InitializeComponent();
            this.connectServerCtrl1.Configuration = configuration;
            this.Text = "Connector-Client";
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
