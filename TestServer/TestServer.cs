using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Opc.Ua.Server;
using Opc.Ua;
namespace TestServer
{
    public partial class TestServer:StandardServer
    {
        public TestServer()
        {
            int i = 0;
        }
        protected override MasterNodeManager CreateMasterNodeManager(IServerInternal server, ApplicationConfiguration configuration)
        {
            return base.CreateMasterNodeManager(server, configuration);
        }
        protected override ServerProperties LoadServerProperties()
        {
            return base.LoadServerProperties();
        }

    }
}
