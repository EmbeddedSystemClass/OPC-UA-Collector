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
using Opc.Ua.Server;

namespace ServerCollector
{
    public partial class mainForm : Form
    {
        public mainForm(ApplicationInstance application)
        {
            InitializeComponent();

            m_application = application;
            m_server = application.Server as Opc.Ua.Server.StandardServer;
            m_configuration = application.ApplicationConfiguration;
            this.ServerDiagnosticsCTRL.Initialize(m_server,m_configuration);
        }
        #region private fields
        ApplicationInstance m_application;
        Opc.Ua.Server.StandardServer m_server;
        Opc.Ua.ApplicationConfiguration m_configuration;
        #endregion

    }
}
