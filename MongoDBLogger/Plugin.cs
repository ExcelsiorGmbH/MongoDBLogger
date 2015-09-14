using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using pGina.Shared.Interfaces;
using pGina.Shared.Types;

namespace pGina.Plugin.MonogDBLogger
{
    public class PluginImpl : IPluginConfiguration, IPluginEventNotifications
    {
        public static readonly Guid m_uuid = new Guid("5c938988-286c-4294-a4bd-b660d1da975e");
        private ILog m_logger = LogManager.GetLogger("LdapLoginMapper");

        public string Name
        {
            get { return "MonogDBLogger"; }
        }
        public string Description
        {
            get { return "MonogDBLoggerr."; }
        }
        public Guid Uuid
        {
            get { return m_uuid; }
        }
        public string Version
        {
            get { return "1.0"; }
        }
        public void Starting() { }
        public void Stopping() { }

        public void BeginChain(SessionProperties properties)
        {
            m_logger.Debug("BeginChain");
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
            if (properties != null)
            {
                switch (changeDescription.Reason)
                {
                    case System.ServiceProcess.SessionChangeReason.SessionLock:
                        m_logger.Error("LogEvent SessionLock");
                        break;
                    case System.ServiceProcess.SessionChangeReason.SessionLogoff:
                        m_logger.Error("LogEvent SesssionLogOff");
                        break;
                    case System.ServiceProcess.SessionChangeReason.SessionLogon:
                        m_logger.Error("LogEvent SessionLogOn");
                        break;
                    case System.ServiceProcess.SessionChangeReason.SessionUnlock:
                        m_logger.Error("LogEvent SessionUnlock");
                        break;
                    case System.ServiceProcess.SessionChangeReason.RemoteConnect:
                        m_logger.Error("LogEvent RemoteConnect");
                        break;
                    case System.ServiceProcess.SessionChangeReason.RemoteDisconnect:
                        m_logger.Error("LogEvent RemoteDisconnect");
                        break;
                }
            }
        }
    }
}
