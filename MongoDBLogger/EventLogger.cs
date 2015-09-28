/*
	Copyright (c) 2011, pGina Team
	All rights reserved.

	Redistribution and use in source and binary forms, with or without
	modification, are permitted provided that the following conditions are met:
		* Redistributions of source code must retain the above copyright
		  notice, this list of conditions and the following disclaimer.
		* Redistributions in binary form must reproduce the above copyright
		  notice, this list of conditions and the following disclaimer in the
		  documentation and/or other materials provided with the distribution.
		* Neither the name of the pGina Team nor the names of its contributors 
		  may be used to endorse or promote products derived from this software without 
		  specific prior written permission.

	THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
	ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
	WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
	DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY
	DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
	(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
	LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
	ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
	(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
	SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using MongoDB.Bson;
using MongoDB.Driver;
using log4net;
using pGina.Shared.Types;

namespace pGina.Plugin.MonogDBLogger
{
    public class Event
    {
        public ObjectId Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Host { get; set; }
        public string Ip { get; set; }
        public string Machine { get; set; }
        public string Message { get; set; }
    }

    class EventLoggerMode : ILoggerMode
    {
        private ILog m_logger = LogManager.GetLogger("MonogDBLogger");
        public static readonly string UNKNOWN_USERNAME = "--Unknown--";
        private MongoServer m_server;

        public EventLoggerMode() { }

        //Logs the event if it's an event we track according to the registry.
        public bool Log(System.ServiceProcess.SessionChangeDescription changeDescription, pGina.Shared.Types.SessionProperties properties)
        {
            //Get the logging message for this event.
            string msg = null;
            switch (changeDescription.Reason)
            {
                case System.ServiceProcess.SessionChangeReason.SessionLogon:
                    msg = LogonEvent(changeDescription.SessionId, properties);
                    break;
                case System.ServiceProcess.SessionChangeReason.SessionLogoff:
                    msg = LogoffEvent(changeDescription.SessionId, properties);
                    break;
                case System.ServiceProcess.SessionChangeReason.SessionLock:
                    msg = SessionLockEvent(changeDescription.SessionId, properties);
                    break;
                case System.ServiceProcess.SessionChangeReason.SessionUnlock:
                    msg = SessionUnlockEvent(changeDescription.SessionId, properties);
                    break;
                case System.ServiceProcess.SessionChangeReason.SessionRemoteControl:
                    msg = SesionRemoteControlEvent(changeDescription.SessionId, properties);
                    break;
                case System.ServiceProcess.SessionChangeReason.ConsoleConnect:
                    msg = ConsoleConnectEvent(changeDescription.SessionId, properties);
                    break;
                case System.ServiceProcess.SessionChangeReason.ConsoleDisconnect:
                    msg = ConsoleDisconnectEvent(changeDescription.SessionId, properties);
                    break;
                case System.ServiceProcess.SessionChangeReason.RemoteConnect:
                    msg = RemoteConnectEvent(changeDescription.SessionId, properties);
                    break;
                case System.ServiceProcess.SessionChangeReason.RemoteDisconnect:
                    msg = RemoteDisconnectEvent(changeDescription.SessionId, properties);
                    break;
            }

            m_logger.DebugFormat("SessionChange({0}) - Message: {1}", changeDescription.Reason.ToString(), msg);

            //Check if there is a message to log
            if (!string.IsNullOrEmpty(msg))
            {
                if (m_server == null)
                    throw new InvalidOperationException("No MySQL Connection present.");
                
                //Send it to the server
                logToServer(msg);
            }
            return true; //No msg to log
        }

        //Tests the table based on the registry data. Returns a string indicating the table status.
        public string TestTable()
        {
            if (m_server == null)
                throw new InvalidOperationException("No MongoDB Connection present.");
            if (m_server.State != MongoServerState.Connected)
                m_server.Connect();
            string databaseName = Settings.Store.Database;
            string table = Settings.Store.EventTable;

            var database = m_server.GetDatabase(databaseName);
            var collection = database.GetCollection<Event>(table);
            var pGinaEvent = new Event { Host = "test"};
            collection.Insert(pGinaEvent);
            return "Table exists and is setup correctly.";
        }

        //Provides the MySQL connection to use
        public void SetConnection(MongoServer m_server)
        {
            this.m_server = m_server;
        }

        //Connects to the server and logs the message.
        private bool logToServer(string message) {

            if (m_server.State != MongoServerState.Connected)
                m_server.Connect();

            string hostName = Dns.GetHostName();
            string databaseName = Settings.Store.Database;
            string table = Settings.Store.EventTable;
            string machine = Environment.MachineName;

            var database = m_server.GetDatabase(databaseName);
            var collection = database.GetCollection<Event>(table);
            var pGinaEvent = new Event { TimeStamp = DateTime.UtcNow, Host = hostName, Ip = getIPAddress(), Machine = machine, Message = message };
            m_logger.DebugFormat("Logging: {0}", message);
            collection.Insert(pGinaEvent);
            m_logger.DebugFormat("Event logged: {1}", message);

            return true;
        }

        //Returns the current IPv4 address
        private string getIPAddress()
        {
            IPAddress[] ipList = Dns.GetHostAddresses("");
            string m_ip = "";
            // Grab the first IPv4 address in the list
            foreach (IPAddress addr in ipList)
            {
                if (addr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    m_ip = addr.ToString();
                    break;
                }
            }
            return m_ip;
        }


        //The following functions determine if the specified event should be logged, and returns the logging message if so
        private string LogonEvent(int sessionId, SessionProperties properties)
        {
            bool okToLog = Settings.Store.EvtLogon;

            // Get the username
            string userName = getUsername(properties);

            // Since the username is not available at logoff time, we cache it
            // (tied to the session ID) so that we can get it back at the logoff
            // event.
            //if (userName != null)
            //    m_usernameCache.Add(sessionId, userName);
            if (userName == null)
                userName = UNKNOWN_USERNAME;

            if (okToLog)
                return string.Format("[{0}] Logon user: {1}", sessionId, userName);

            return "";
        }

        private string LogoffEvent(int sessionId, SessionProperties properties)
        {
            bool okToLog = Settings.Store.EvtLogoff;
            string userName = "";

            userName = getUsername(properties);
            // Delete the username from the cache because we are logging off?

            if (userName == null)
                userName = UNKNOWN_USERNAME;

            if (okToLog)
                return string.Format("[{0}] Logoff user: {1}", sessionId, userName);

            return "";
        }

        private string ConsoleConnectEvent(int sessionId, SessionProperties properties)
        {
            bool okToLog = Settings.Store.EvtConsoleConnect;

            if (okToLog)
                return string.Format("[{0}] Console connect", sessionId);

            return "";
        }

        private string ConsoleDisconnectEvent(int sessionId, SessionProperties properties)
        {
            bool okToLog = Settings.Store.EvtConsoleDisconnect;

            if (okToLog)
                return string.Format("[{0}] Console disconnect", sessionId);

            return "";
        }

        private string RemoteDisconnectEvent(int sessionId, SessionProperties properties)
        {
            bool okToLog = Settings.Store.EvtRemoteDisconnect;
            string userName = "";

            userName = getUsername(properties);
            if (userName == null)
                userName = UNKNOWN_USERNAME;


            if (okToLog)
                return string.Format("[{0}] Remote disconnect user: {1}", sessionId, userName);

            return "";
        }

        private string RemoteConnectEvent(int sessionId, SessionProperties properties)
        {
            bool okToLog = Settings.Store.EvtRemoteConnect;
            string userName = "";

            userName = getUsername(properties);
            if (userName == null)
                userName = UNKNOWN_USERNAME;


            if (okToLog)
                return string.Format("[{0}] Remote connect user: {1}", sessionId, userName);

            return "";
        }

        private string SesionRemoteControlEvent(int sessionId, SessionProperties properties)
        {
            bool okToLog = Settings.Store.EvtRemoteControl;
            string userName = "";

            userName = getUsername(properties);
            if (userName == null)
                userName = UNKNOWN_USERNAME;


            if (okToLog)
                return string.Format("[{0}] Remote control user: {1}", sessionId, userName);

            return "";
        }

        private string SessionUnlockEvent(int sessionId, SessionProperties properties)
        {
            bool okToLog = Settings.Store.EvtUnlock;
            string userName = "";

            userName = getUsername(properties);
            if (userName == null)
                userName = UNKNOWN_USERNAME;


            if (okToLog)
                return string.Format("[{0}] Session unlock user: {1}", sessionId, userName);

            return "";
        }

        private string SessionLockEvent(int sessionId, SessionProperties properties)
        {
            bool okToLog = Settings.Store.EvtLock;
            string userName = "";

            userName = getUsername(properties);
            if (userName == null)
                userName = UNKNOWN_USERNAME;


            if (okToLog)
                return string.Format("[{0}] Session lock user: {1}", sessionId, userName);

            return "";
        }

        private string getUsername(SessionProperties properties)
        {
            if (properties == null)
                return UNKNOWN_USERNAME;

            bool useModifiedName = Settings.Store.UseModifiedName;
            UserInformation userInfo = properties.GetTrackedSingle<UserInformation>();
            if (useModifiedName)
                return userInfo.Username;
            else
                return userInfo.OriginalUsername;
        }
    }
}
