using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using pGina.Shared.Settings;

namespace pGina.Plugin.MonogDBLogger
{
    class Settings
    {
        private static dynamic m_settings = new pGinaDynamicSettings(PluginImpl.m_uuid);
        public static dynamic Store
        {
            get { return m_settings; }
        }

        static Settings()
        {
            // Set defaults
            m_settings.SetDefault("EventMode", true);
            m_settings.SetDefault("SessionMode", false);
            m_settings.SetDefaultEncryptedSetting("ConnectionString", "mongodb://localhost", null);
            m_settings.SetDefault("Database", "pGinaDB");
            m_settings.SetDefault("SessionTable", "pGinaSession");
            m_settings.SetDefault("EventTable", "pGinaLog");

            m_settings.SetDefault("EvtLogon", true);
            m_settings.SetDefault("EvtLogoff", true);
            m_settings.SetDefault("EvtLock", false);
            m_settings.SetDefault("EvtUnlock", false);
            m_settings.SetDefault("EvtConsoleConnect", false);
            m_settings.SetDefault("EvtConsoleDisconnect", false);
            m_settings.SetDefault("EvtRemoteControl", false);
            m_settings.SetDefault("EvtRemoteConnect", false);
            m_settings.SetDefault("EvtRemoteDisconnect", false);

            m_settings.SetDefault("UseModifiedName", false);
        }
    }
}
