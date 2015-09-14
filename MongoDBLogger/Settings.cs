using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using pGina.Shared.Settings;
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
        }
    }
}
