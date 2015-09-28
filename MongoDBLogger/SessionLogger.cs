using System;
using System.Net;
using System.Linq;
using System.Text;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using log4net;
using pGina.Shared.Types;

namespace pGina.Plugin.MonogDBLogger
{
   
    public class Session
    {
        public ObjectId Id { get; set; }
        public DateTime loginstamp { get; set; }
        public DateTime  logoutstamp { get; set; }
        public string username { get; set; }
        public string machine { get; set; }
        public string ipaddress { get; set; }
    }

    class SessionLogger : ILoggerMode
    {
        private ILog m_logger = LogManager.GetLogger("MonogDBLogger");
        private MongoServer m_server;

        public SessionLogger(){}
        
        //Logs the session if it's a LogOn or LogOff event.
        public bool Log(SessionChangeDescription changeDescription, SessionProperties properties)
        {
            if (m_server == null)
                throw new InvalidOperationException("No MongoDB Connection present.");

            string username = "--UNKNOWN--";
            if (properties != null)
            {
                UserInformation ui = properties.GetTrackedSingle<UserInformation>();
                if ((bool)Settings.Store.UseModifiedName)
                    username = ui.Username;
                else
                    username = ui.OriginalUsername;
            }

            //Logon Event
            if (changeDescription.Reason == SessionChangeReason.SessionLogon)
            {
                if (m_server.State != MongoServerState.Connected)
                    m_server.Connect();

                string table = Settings.Store.SessionTable;
                string databaseName = Settings.Store.Database;

                var database = m_server.GetDatabase(databaseName);
                var collection = database.GetCollection<Event>(table);

                //Update the existing entry for this machine/ip if it exists.
                var query = Query.And(
                    Query.NotExists("logoutstamp"),
                    Query.EQ("machine", Environment.MachineName),
                    Query.EQ("ipaddress", getIPAddress())
                );
                var update = Update.Set("logoutstamp", DateTime.UtcNow);
                collection.Update(query, update);

                //Insert new entry for this logon event
                var pGinaSession = new Session { username = username, machine = Environment.MachineName, ipaddress = getIPAddress(), loginstamp = DateTime.UtcNow };
                collection.Insert(pGinaSession);

                m_logger.DebugFormat("Logged LogOn event for {0} at {1}", username, getIPAddress());

            }

            //LogOff Event
            else if (changeDescription.Reason == SessionChangeReason.SessionLogoff)
            {
                if (m_server.State != MongoServerState.Connected)
                    m_server.Connect(); 

                string table = Settings.Store.SessionTable;
                string databaseName = Settings.Store.Database;

                var database = m_server.GetDatabase(databaseName);
                var collection = database.GetCollection<Event>(table);

                //Update the existing entry for this machine/ip if it exists.
                var query = Query.And(
                    Query.NotExists("logoutstamp"),
                    Query.EQ("username", username),
                    Query.EQ("machine", Environment.MachineName),
                    Query.EQ("ipaddress", getIPAddress())
                );
                var update = Update.Set("logoutstamp", DateTime.UtcNow);
                m_logger.DebugFormat("Logged LogOff event for {0} at {1}", username, getIPAddress());
            }
            return true;
        }

        //Tests the table based on the registry data. Returns a string indicating the table status.
        public string TestTable()
        {
            if (m_server == null)
                throw new InvalidOperationException("No MongoDB Connection present.");
            //Open the connection if it's not presently open
            if (m_server.State != MongoServerState.Connected)
                m_server.Connect();

            string table = Settings.Store.SessionTable;
            string databaseName = Settings.Store.Database;

            var database = m_server.GetDatabase(databaseName);
            var collection = database.GetCollection<Event>(table);

            //Update the existing entry for this machine/ip if it exists.
            var pGinaSession = new Session { username = "test"};
            collection.Insert(pGinaSession);
            return "Table exists and is setup correctly.";
        }

        //Provides the MySQL connection to use
        public void SetConnection(MongoServer m_server)
        {
            this.m_server = m_server;
        }

        //Returns the IPv4 address of the current machine
        private string getIPAddress()
        {
            IPAddress[] ipList = Dns.GetHostAddresses("");

            // Grab the first IPv4 address in the list
            foreach (IPAddress addr in ipList)
            {
                if (addr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return addr.ToString();
                }
            }
            return "-INVALID IP ADDRESS-";
        }
    }
}
