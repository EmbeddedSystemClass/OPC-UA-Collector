﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opc.Ua.Server;
using Opc.Ua;
using System.Security.Cryptography;

namespace ServerCollector
{
    static class Clients
    {
        public static Dictionary<NodeId, ClientOPC> session_client = new Dictionary<NodeId, ClientOPC>();
        private static List<ClientOPC> clients_;
        public static Dictionary<string, ClientOPC> token_Client { private set; get; }
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
    static class ClientToken
    {
        public static string getClientToken(object ident)
        {
            byte[] obj = ASCIIEncoding.ASCII.GetBytes(ident.ToString());
            return new MD5CryptoServiceProvider().ComputeHash(obj).ToString();
        }
    }
    /// <summary>
    /// represent a Connection /Session to a client by the NodeId
    /// </summary>
    public class ClientConnection
    {
        public NodeId connectionID;
        int SessionID;
        public ClientConnection(NodeId connection)
        {
            if (connection == null)
            {
                this.connectionID = null;
                return;
            }
            if (connection.Identifier.GetType() != typeof(int))
                throw new Exception("bad Session Node");

            this.connectionID= connection;
        }
        public void renew(NodeId newCon)
        {
            connectionID = newCon;
        }

    }
}
