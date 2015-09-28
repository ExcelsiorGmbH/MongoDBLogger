using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace pGina.Plugin.MonogDBLogger
{
    interface ILoggerMode
    {
        //Logs the specified event/properties
        bool Log(System.ServiceProcess.SessionChangeDescription changeDescription, pGina.Shared.Types.SessionProperties properties);
        
        //Mongo creates tables if it doesnt exsists and no Shema required
        //Creates table with username ntry test
        string TestTable();

        //Sets the connection to the MySql server, so that multiple loggers can share one stream
        void SetConnection(MongoServer m_server);
    }

    class LoggerModeFactory
    {

        static private MongoServer m_server = null;

        private LoggerModeFactory() { }

        public static ILoggerMode getLoggerMode(LoggerMode mode)
        {
            //Create a new MySqlConnection if no viable one is available
            if (m_server == null || m_server.State != MongoServerState.Connected)
            {
                string connectionString = Settings.Store.GetEncryptedSetting("ConnectionString");
                MongoClient client = new MongoClient(connectionString);
                m_server = client.GetServer();
            }

            ILoggerMode logger = null;
            if (mode == LoggerMode.EVENT)
                logger = new EventLoggerMode();
            else if (mode == LoggerMode.SESSION)
                logger = new SessionLogger();
            else
                throw new ArgumentException("Invalid LoggerMode");

            logger.SetConnection(m_server);
            return logger;
        }

        public static void closeConnection(){
            if (m_server != null)
                m_server.Disconnect();
            m_server = null;
        }
    }
}
