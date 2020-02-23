using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opc.Ua;
namespace ServerCollector.Collector
{
    public enum ObjectsIDs
    {
        ObjectController=1081,
        ObjectControlleraddNamespace=1132,
        ObjectControlleraddObjectNode=1135,
        ObjectControllergetObjectRootNode=1138,
        ObjectControllergetToken=1141,
        TypeServerCollector=1009,
        TypeServerCollectoraddNamespace = 1010,
        TypeServerCollectoradObjectNode =1015,
        TypeServerCollectorgetObjectRootNode = 1019,
        TypeServerCollectorgetToken =   1022

    }
}
