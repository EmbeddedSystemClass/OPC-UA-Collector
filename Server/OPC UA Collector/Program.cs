using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;

using Opc.Ua.Configuration;
using Opc.Ua;
using Opc.Ua.Server.Controls;

using System.Windows.Forms;

namespace OPCDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize the user interface.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //ApplicationInstance.MessageDlg = new ApplicationMessageDlg();
            ApplicationInstance application = new ApplicationInstance();
            application.ApplicationType = ApplicationType.Server;
            application.ConfigSectionName = "DemoServer";

            

            try
            {
                CollectorServer demo = new CollectorServer();
                

                
                // process and command line arguments.
                if (application.ProcessCommandLine())
                {
                    return;
                }

                // check if running as a service.
                if (!Environment.UserInteractive)
                {
                    application.StartAsService(demo);
                    return;
                }
                // load the application configuration.
                application.LoadApplicationConfiguration(false).Wait();

                // check the application certificate.
                application.CheckApplicationInstanceCertificate(false, 0).Wait();

                // start the server.
                application.Start(demo).Wait();

                // run the application interactively.
                Application.Run(new Opc.Ua.Server.Controls.ServerForm(application));
                //Console.ReadLine();
                
            }
            catch (Exception e)
            {
                //ExceptionDlg.Show(application.ApplicationName, e);
                Console.WriteLine(e.Message);
                return;
            }
        }
    }
}

