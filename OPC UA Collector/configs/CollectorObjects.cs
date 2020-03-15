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
        ObjectController=1042,
        ObjectControlleraddNamespace=1052,
        ObjectControlleraddObjectNode=1055,
        ObjectControllergetObjectRootNode=1061,
        ObjectControllerauthenticate=1058,
        ObjectControllerregisterServer=1064,
        TypeServerCollector=1009,
        TypeServerCollectoraddNamespace = 1010,
        TypeServerCollectorregisterServer = 1013,
        TypeServerCollectoradObjectNode =1015,
        TypeServerCollectorgetObjectRootNode = 1019,
        TypeServerCollectorauthenticate =   1049,
        TypeControllerObjectRoot = 1025,
        FolderMachines = 1068

    }
}
