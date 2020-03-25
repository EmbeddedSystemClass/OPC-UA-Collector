
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Security.Cryptography.X509Certificates;
    using Opc.Ua;
    using Opc.Ua.Configuration;
    using Opc.Ua.Client.Controls;

    namespace Client
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                // Initialize the user interface.
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                ApplicationInstance.MessageDlg = new ApplicationMessageDlg();
                ApplicationInstance application = new ApplicationInstance();
                application.ApplicationType = ApplicationType.Server;
                application.ConfigSectionName = "ConnectorClient";

                ApplicationInstance applicationclient = new ApplicationInstance();
            applicationclient.ApplicationType = ApplicationType.Client;
            applicationclient.ConfigSectionName = "Client";
                try
                {
                    // process and command line arguments.
                    if (application.ProcessCommandLine())
                    {
                        return;
                    }
                // load the application configuration.
                application.LoadApplicationConfiguration(false).Wait();
                applicationclient.LoadApplicationConfiguration(false).Wait();

                // check the application certificate.
                application.CheckApplicationInstanceCertificate(false, 0).Wait();
                applicationclient.CheckApplicationInstanceCertificate(false, 0).Wait();
                //application.ApplicationConfiguration = getConfiguration();

                // run the application interactively.
                connectorForm form = new connectorForm(applicationclient);
                Application.Run(form);
                }
                catch (Exception e)
                {
                    ExceptionDlg.Show(application.ApplicationName, e);
                    return;
                }
            }
        public static ApplicationConfiguration getConfiguration()
        {
            ApplicationConfiguration config = new ApplicationConfiguration();
            config.ApplicationName = "Connector Client";
            config.ApplicationType = ApplicationType.Client;

            return config;
        }
        /*
        public void Call()
        {
            // build list of methods to call.
            CallMethodRequestCollection methodsToCall = new CallMethodRequestCollection();

            CallMethodRequest methodToCall = new CallMethodRequest();

            methodToCall.ObjectId = m_objectId;
            methodToCall.MethodId = m_methodId;

            foreach (DataRow row in m_dataset.Tables[0].Rows)
            {
                Argument argument = (Argument)row[0];
                Variant value = (Variant)row[4];
                argument.Value = value.Value;
                methodToCall.InputArguments.Add(value);
            }

            methodsToCall.Add(methodToCall);

            // call the method.
            CallMethodResultCollection results = null;
            DiagnosticInfoCollection diagnosticInfos = null;

            ResponseHeader responseHeader = m_session.Call(
                null,
                methodsToCall,
                out results,
                out diagnosticInfos);

            ClientBase.ValidateResponse(results, methodsToCall);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, methodsToCall);

            for (int ii = 0; ii < results.Count; ii++)
            {
                // display any input argument errors.
                if (results[ii].InputArgumentResults != null)
                {
                    for (int jj = 0; jj < results[ii].InputArgumentResults.Count; jj++)
                    {
                        if (StatusCode.IsBad(results[ii].InputArgumentResults[jj]))
                        {
                            DataRow row = m_dataset.Tables[0].Rows[jj];
                            row[5] = results[ii].InputArgumentResults[jj].ToString();
                            ResultCH.Visible = true;
                        }
                    }
                }

                // throw an exception on error.
                if (StatusCode.IsBad(results[ii].StatusCode))
                {
                    throw ServiceResultException.Create(results[ii].StatusCode, ii, diagnosticInfos, responseHeader.StringTable);
                }

                // display the output arguments
                ResultCH.Visible = false;
                NoArgumentsLB.Visible = m_outputArguments == null || m_outputArguments.Length == 0;
                NoArgumentsLB.Text = "Method invoked successfully.\r\nNo output arguments to display.";
                m_dataset.Tables[0].Rows.Clear();

                if (m_outputArguments != null)
                {
                    for (int jj = 0; jj < m_outputArguments.Length; jj++)
                    {
                        DataRow row = m_dataset.Tables[0].NewRow();

                        if (results[ii].OutputArguments.Count > jj)
                        {
                            UpdateRow(row, m_outputArguments[jj], results[ii].OutputArguments[jj], true);
                        }
                        else
                        {
                            UpdateRow(row, m_outputArguments[jj], Variant.Null, true);
                        }

                        m_dataset.Tables[0].Rows.Add(row);
                    }
                }
            }
        }*/
    }
    }
