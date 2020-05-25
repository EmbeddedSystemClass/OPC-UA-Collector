
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opc.Ua.Client;
using Opc.Ua;
using System.Security.Cryptography;
using System.Diagnostics;
namespace ServerCollector.Client
{
    public class Clients
    {

    }
    public class Client
    {
        #region Members
        string name;
        object identifier;
        NodeId rootNode;
        Session session;
        Dictionary<MonitoredItem, BaseVariableState> connectedVariables;
        #endregion

        public Client(string Name, object Identifier, Session session)
        {
            connectedVariables = new Dictionary<MonitoredItem, BaseVariableState>();
            this.name = Name;
            this.identifier = Identifier;
            this.session = session;
            
            // setting up the subscription
            Subscription subscription = new Subscription();
            subscription.PublishingEnabled = true;
            subscription.PublishingInterval = 1000;
            subscription.Priority = 1;
            subscription.KeepAliveCount = 10;
            subscription.LifetimeCount = 20;
            subscription.MaxNotificationsPerPublish = 1000;
            session.AddSubscription(subscription);
            subscription.Create();
        }
        public void addConnection(BaseVariableState collectorNode, ReferenceDescription clientNode)
        {
            // test if clientNode is Variable
            if (clientNode.NodeClass== NodeClass.Variable )//&& collectorNode.GetType()==typeof(VariableNode))
            {
                MonitoredItem monitoredItem = new MonitoredItem();
                monitoredItem.StartNodeId = ExpandedNodeId.ToNodeId(clientNode.NodeId,session.NamespaceUris);
                monitoredItem.AttributeId = Attributes.Value;
                monitoredItem.Notification += new MonitoredItemNotificationEventHandler(connectVariable);
                Debug.Print("Client.cs: not fully implemented new session, just easily created");
                Subscription sub = new Subscription();
                sub.PublishingEnabled = true;
                sub.PublishingInterval = 1000;
                sub.Priority = 1;
                sub.KeepAliveCount = 10;
                sub.LifetimeCount = 20;
                sub.MaxNotificationsPerPublish = 1000;

                sub.AddItem(monitoredItem);
                session.AddSubscription(sub);
                sub.Create();
                connectedVariables.Add(monitoredItem, collectorNode);

            }
        }
        private void connectVariable(Opc.Ua.Client. MonitoredItem item, Opc.Ua.Client.MonitoredItemNotificationEventArgs e)
        {
            BaseVariableState varNode;
            if(connectedVariables.TryGetValue(item,out varNode))
            {
                MonitoredItemNotification datachange = e.NotificationValue as MonitoredItemNotification;
                if (datachange == null) return;
                varNode.Value = datachange.Value.WrappedValue;
            }
            else
            {
                throw new Exception("monitored item is not connected to a Node in Collector Nodes");
            }
        }
    }
}
namespace ServerCollector.old
{
    static class Clients
    {
        public static Dictionary<NodeId, ClientOPC> session_client = new Dictionary<NodeId, ClientOPC>();
        private static List<ClientOPC> clients_;
        public static Dictionary<string, ClientOPC> token_Client { 
            private set { } 
            get {
                if (token_client_ == null)
                {
                    token_client_ = new Dictionary<string, ClientOPC>();
                }
                return token_client_;
            } 
        }
        private static Dictionary<string, ClientOPC> token_client_;
        //private static Dictionary<NodeId, Client> connection_client_;
        public static List<ClientOPC> clients
        {
            get
            {
                if (clients_ == null)
                {
                    clients_ = new List<ClientOPC>();
                    clients_.Add(new ClientOPC("test", null));
                }
                return clients_;
            }
        }

        public static ClientOPC addClient(object identifier, NodeId session = null)
        {
            string ct = ClientToken.getClientToken(identifier);
            ClientOPC cl;
            if(token_Client.TryGetValue(ct,out cl))
            {
                return cl;
            }
            cl = new ClientOPC(ct, session);
            clients.Add(cl);

            //renew dictionaries
            token_Client.Add(cl.token,cl);
            if (session != null)
            {
                session_client.Add(session,cl);
            }

            return cl;
        }

    }
    class ClientOPC
    {
        public string token { private set; get; }
        public NodeState RootObject { private set; get; }
        public ClientConnection Connection { private set; get;}
        public bool isRootset
        {
            get
            {
                if (RootObject == null)
                {
                    return false;
                }
                return true;
            }
            private set
            {
                
            }
        }
        
        public ClientOPC(object identifier,NodeId session)
        {
            token =ClientToken.getClientToken(identifier);
            Connection = new ClientConnection(session);
        }
        public void setRootObject(NodeState objroot)
        {
            if (!isRootset)
                throw new Exception("Object-Root-Node already setted");
            RootObject = objroot;
        }
        public void authenticate(string Token, NodeId session)
        {
            if (token == Token)
            {
                Clients.session_client.Remove(this.Connection.connectionID);
                Clients.session_client.Add(session, this);
                Connection.renew(session);
            }
        }
        
    }
    /// <summary>
    /// represent the authentification of a Client by a Token generated by an identifier Object
    /// </summary>
    public static class ClientToken
    {
        public static string getClientToken(object ident)
        {
            byte[] obj = ASCIIEncoding.ASCII.GetBytes(ident.ToString());
            obj = new MD5CryptoServiceProvider().ComputeHash(obj);
            return ASCIIEncoding.ASCII.GetString(obj); ;
        }
    }
    /// <summary>
    /// represent a Connection /Session to a client by the NodeId
    /// </summary>
    public class ClientConnection
    {
        public NodeId connectionID;
        uint SessionID;
        public ClientConnection(NodeId connection)
        {
            if (connection == null)
            {
                this.connectionID = null;
                return;
            }
            //if (connection.Identifier.GetType() != typeof(int))
            //throw new Exception("bad Session Node");
            Type typ = connection.Identifier.GetType();
            this.SessionID = (uint)connection.Identifier;
            this.connectionID= connection;
        }
        public void renew(NodeId newCon)
        {
            connectionID = newCon;
        }

    }
}
