using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using pGina.Shared.Interfaces;
using pGina.Shared.Types;

namespace pGina.Plugin.MonogDBLogger
{
    enum LoggerMode { EVENT, SESSION };

    public class PluginImpl : IPluginConfiguration, IPluginEventNotifications
    {
        public static readonly Guid m_uuid = new Guid("5c938988-286c-4294-a4bd-b660d1da975e");
        private ILog m_logger = LogManager.GetLogger("MonogDBLogger");

        public string Description
        {
            get { return "MonogDBLoggerr."; }
        }
        public string Name
        {
            get { return "MonogDBLogger"; }
        }
        public Guid Uuid
        {
            get { return m_uuid; }
        }
        public string Version
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        public void Starting() { }
        public void Stopping() { }

        public void BeginChain(SessionProperties properties)
        {
            m_logger.Debug("BeginChain");
            try
            {
                SessionLogger m_sessionlogger = new SessionLogger();
                properties.AddTrackedSingle<SessionLogger>(m_sessionlogger);
            }
            catch (Exception e)
            {
                m_logger.ErrorFormat("Failed to create SessionLogger: {0}", e);
                properties.AddTrackedSingle<SessionLogger>(null);
            }
        }

        public void EndChain(SessionProperties properties)
        {
            m_logger.Debug("EndChain");
        }
        public void Configure()
        {
            Configuration conf = new Configuration();
            conf.ShowDialog();
        }
        public void SessionChange(System.ServiceProcess.SessionChangeDescription changeDescription, SessionProperties properties)
        {
            m_logger.DebugFormat("SessionChange({0}) - ID: {1}", changeDescription.Reason.ToString(), changeDescription.SessionId);

            //If SessionMode is enabled, send event to it.
            if ((bool)Settings.Store.SessionMode)
            {
                ILoggerMode mode = LoggerModeFactory.getLoggerMode(LoggerMode.SESSION);
                mode.Log(changeDescription, properties);
            }

            //If EventMode is enabled, send event to it.
            if ((bool)Settings.Store.EventMode)
            {
                ILoggerMode mode = LoggerModeFactory.getLoggerMode(LoggerMode.EVENT);
                mode.Log(changeDescription, properties);
            }

            //Close the connection if it's still open
            LoggerModeFactory.closeConnection();
        }
    }
}
