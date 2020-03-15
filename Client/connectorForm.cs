using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Opc.Ua.Configuration;
namespace Client
{
    public partial class connectorForm : Opc.Ua.Sample.Controls.ClientForm
    {
        public connectorForm()
        {
            InitializeComponent();
        }
        public connectorForm(ApplicationInstance application):base(application.ApplicationConfiguration.CreateMessageContext(),application,null,application.ApplicationConfiguration)
        {
            InitializeComponent();
        }
    }
}
