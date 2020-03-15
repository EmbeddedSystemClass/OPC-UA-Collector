using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Opc.Ua.Configuration;
using Opc.Ua;
using Opc.Ua.Server.Controls;

namespace TestServer
{
    static class Program
    {
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //ApplicationInstance.MessageDlg = new ApplicationMessageDlg();
            ApplicationInstance application = new ApplicationInstance();
            application.ApplicationType = ApplicationType.Server;
            application.ConfigSectionName = "TestServer";

            try
            {
                TestServer test = new TestServer();
                if (!Environment.UserInteractive)
                {
                    application.StartAsService(test);
                    return;
                }
                // load the application configuration.
                application.LoadApplicationConfiguration(false).Wait();
                //application.ApplicationConfiguration = getConfiguration();


                // check the application certificate.
                application.CheckApplicationInstanceCertificate(false, 0).Wait();

                // start the server.
                application.Start(test).Wait();

                // run the application interactively.
                //Application.Run(new Opc.Ua.Server.Controls.ServerForm(application));
                Application.Run(new mainForm(application));
                //Console.ReadLine();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
