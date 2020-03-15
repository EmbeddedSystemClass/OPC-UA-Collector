using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using Opc.Ua.Configuration;
using Opc.Ua;
using Opc.Ua.Server.Controls;

using System.Windows.Forms;

namespace ServerCollector
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Initialize the user interface.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //ApplicationInstance.MessageDlg = new ApplicationMessageDlg();
            ApplicationInstance application = new ApplicationInstance(getConfiguration());
            application.ApplicationType = ApplicationType.Server;
            application.ConfigSectionName = "CollectorServer";

            

            try
            {
                CollectorServer server = new CollectorServer();
                

                
                // process and command line arguments.
                if (application.ProcessCommandLine())
                {
                    return;
                }

                // check if running as a service.
                if (!Environment.UserInteractive)
                {
                    application.StartAsService(server);
                    return;
                }
                // load the application configuration.
                application.LoadApplicationConfiguration(false).Wait();
                //application.ApplicationConfiguration = getConfiguration();
                

                // check the application certificate.
                application.CheckApplicationInstanceCertificate(false, 0).Wait();

                // start the server.
                application.Start(server).Wait();

                // run the application interactively.
                //Application.Run(new Opc.Ua.Server.Controls.ServerForm(application));
                Application.Run(new mainForm(application));
                //Console.ReadLine();
                
            }
            catch (Exception e)
            {
                ExceptionDlg.Show(application.ApplicationName, e);
                Console.WriteLine(e.Message);
                return;
            }
        }
        public static ApplicationConfiguration getConfiguration()
        {
            ApplicationConfiguration config = new ApplicationConfiguration();
            config.ApplicationName = "Collector Server";
            //config.ApplicationType = null;
            config.ApplicationUri = @"urn:localhost:UA:InformationModelServer";
            //config.CertificateValidator = null;
            //config.ClientConfiguration = null;
            //config.DisableHiResClock = null;
            //config.DiscoveryServerConfiguration = null;
            #region Extensions
            List<XmlElement> config_extensions = new List<XmlElement>();
            
            #endregion
            config.Extensions = new XmlElementCollection();
            //config.MessageContext = null;
            config.ProductUri = @"http://opcfoundation.org/UA/InformationModelServer";
            //config.Properties = null;
            //config.PropertiesLock = null;
            #region Security Configuration
            SecurityConfiguration config_security = new SecurityConfiguration();
            CertificateIdentifier config_security_certificate = new CertificateIdentifier();
            config_security_certificate.StoreType = "Directory";
            config_security_certificate.StorePath = @"%CommonApplicationData%\OPC Foundation\pki\own";
            config_security_certificate.SubjectName = @"CN = Demo Server, C = US, S = Arizona, O = OPC Foundation, DC = localhost";
            config_security.ApplicationCertificate = config_security_certificate;
            CertificateTrustList config_trustedIssuer = new CertificateTrustList();
            config_trustedIssuer.StoreType = "Directory";
            config_trustedIssuer.StorePath= @"%CommonApplicationData%\OPC Foundation\pki\issuer";
            config_security.TrustedIssuerCertificates = config_trustedIssuer;
            CertificateTrustList config_security_trustedPeer = new CertificateTrustList();
            config_security_trustedPeer.StoreType = "Directory";
            config_security_trustedPeer.StorePath = @"%CommonApplicationData%\OPC Foundation\pki\trusted";
            config_security.TrustedPeerCertificates = config_security_trustedPeer;
            CertificateStoreIdentifier config_security_rejected = new CertificateStoreIdentifier();
            config_security_rejected.StoreType = "Directory";
            config_security_rejected.StorePath = @"%CommonApplicationData%\OPC Foundation\pki\rejected";
            config_security.RejectedCertificateStore = config_security_rejected;
            #endregion
            config.SecurityConfiguration = config_security;
            //config_security.ApplicationCertificate = null;
            #region ServerConfiguration
            ServerConfiguration config_server = new ServerConfiguration();
            List<string> config_server_baseAdress = new List<string>();
            config_server_baseAdress.Add(@"https://localhost:51212/CollectorServer");
            config_server_baseAdress.Add(@"opc.tcp://localhost:51210/CollectorServer");
            config_server.BaseAddresses = new StringCollection(config_server_baseAdress);
            List<ServerSecurityPolicy> config_server_policies = new List<ServerSecurityPolicy>();
            ServerSecurityPolicy tmp_pol1 = new ServerSecurityPolicy();
            tmp_pol1.SecurityMode = MessageSecurityMode.SignAndEncrypt;
            tmp_pol1.SecurityPolicyUri = @"http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256";
            config_server_policies.Add(tmp_pol1);
            ServerSecurityPolicy tmp_pol2 = new ServerSecurityPolicy();
            tmp_pol2.SecurityMode = MessageSecurityMode.None;
            tmp_pol2.SecurityPolicyUri = @"http://opcfoundation.org/UA/SecurityPolicy#None";
            config_server_policies.Add(tmp_pol2);
            ServerSecurityPolicy tmp_pol3 = new ServerSecurityPolicy();
            tmp_pol3.SecurityMode = MessageSecurityMode.Sign;
            tmp_pol3.SecurityPolicyUri = @"";
            config_server_policies.Add(tmp_pol3);
            ServerSecurityPolicy tmp_pol4 = new ServerSecurityPolicy();
            tmp_pol4.SecurityMode = MessageSecurityMode.SignAndEncrypt;
            tmp_pol4.SecurityPolicyUri = @"";
            ServerSecurityPolicyCollection config_server_policy = new ServerSecurityPolicyCollection(config_server_policies);
            config_server.SecurityPolicies = config_server_policy;
            List<UserTokenPolicy> config_server_userTokenPolicies = new List<UserTokenPolicy>();
            config_server_userTokenPolicies.Add(new UserTokenPolicy(UserTokenType.Anonymous));
            config_server_userTokenPolicies.Add(new UserTokenPolicy(UserTokenType.UserName));
            config_server_userTokenPolicies.Add(new UserTokenPolicy(UserTokenType.Certificate));
            config_server.UserTokenPolicies = new UserTokenPolicyCollection(config_server_userTokenPolicies);
            config_server.DiagnosticsEnabled = false;
            config_server.MaxSessionCount = 100;
            config_server.MinSessionTimeout = 10000;
            config_server.MaxSessionTimeout = 3600000;
            config_server.MaxBrowseContinuationPoints = 10;
            config_server.MaxQueryContinuationPoints = 10;
            config_server.MaxHistoryContinuationPoints = 100;
            config_server.MaxRequestAge = 600000;
            config_server.MinPublishingInterval = 100;
            config_server.MaxPublishingInterval = 3600000;
            config_server.PublishingResolution = 50;
            config_server.MaxSubscriptionLifetime = 3600000;
            config_server.MaxMessageQueueSize = 10;
            config_server.MaxNotificationQueueSize = 100;
            config_server.MaxNotificationsPerPublish = 1000;
            config_server.MinMetadataSamplingInterval = 1000;
            List<SamplingRateGroup> config_server_samplingRateGroups= new List<SamplingRateGroup>();
            config_server_samplingRateGroups.Add(new SamplingRateGroup(5, 5, 20));
            config_server_samplingRateGroups.Add(new SamplingRateGroup(100,100,4));
            config_server_samplingRateGroups.Add(new SamplingRateGroup(500,250,2));
            config_server_samplingRateGroups.Add(new SamplingRateGroup(1000,500,20));
            config_server.AvailableSamplingRates = new SamplingRateGroupCollection(config_server_samplingRateGroups);
            config_server.MaxRegistrationInterval = 30000;
            #endregion
            config.ServerConfiguration = config_server;
            //config.SourceFilePath = null;
            #region TraceConfiguration
            TraceConfiguration config_traceConfiguration = new TraceConfiguration();
            config_traceConfiguration.OutputFilePath = @"Logs\Quickstarts.BoilerServer.log.txt";
            config_traceConfiguration.DeleteOnLoad = true;
            config_traceConfiguration.TraceMasks = 515;
            #endregion
            config.TraceConfiguration = config_traceConfiguration;
            config.TransportConfigurations = new TransportConfigurationCollection();
            #region TransportQuotas
            TransportQuotas config_transportQuotas = new TransportQuotas();
            config_transportQuotas.OperationTimeout = 600000;
            config_transportQuotas.MaxStringLength = 1048576;
            config_transportQuotas.MaxByteStringLength = 1048576;
            config_transportQuotas.MaxArrayLength = 65535;
            config_transportQuotas.ChannelLifetime = 300000;
            config_transportQuotas.SecurityTokenLifetime = 3600000;
            #endregion
            config.TransportQuotas = config_transportQuotas;
            return config;
        }
    }
}

