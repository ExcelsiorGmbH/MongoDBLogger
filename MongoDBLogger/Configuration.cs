using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pGina.Plugin.MonogDBLogger
{
    public partial class Configuration : Form
    {
        public Configuration()
        {
            InitializeComponent();
            InitUI();
        }
        private void InitUI()
        {
            this.sessionModeCB.Checked = Settings.Store.SessionMode;
            this.eventModeCB.Checked = Settings.Store.EventMode;
            string host = Settings.Store.GetEncryptedSetting("ConnectionString");
            this.hostTB.Text = host;
            string db = Settings.Store.Database;
            this.dbTB.Text = db;
            string eventTable = Settings.Store.EventTable;
            this.eventTableTB.Text = eventTable;
            string sessionTable = Settings.Store.SessionTable;
            this.sessionTableTB.Text = sessionTable;


            bool setting = Settings.Store.EvtLogon;
            this.logonEvtCB.Checked = setting;
            setting = Settings.Store.EvtLogoff;
            this.logoffEvtCB.Checked = setting;
            setting = Settings.Store.EvtLock;
            this.lockEvtCB.Checked = setting;
            setting = Settings.Store.EvtUnlock;
            this.unlockEvtCB.Checked = setting;
            setting = Settings.Store.EvtConsoleConnect;
            this.consoleConnectEvtCB.Checked = setting;
            setting = Settings.Store.EvtConsoleDisconnect;
            this.consoleDisconnectEvtCB.Checked = setting;
            setting = Settings.Store.EvtRemoteControl;
            this.remoteControlEvtCB.Checked = setting;
            setting = Settings.Store.EvtRemoteConnect;
            this.remoteConnectEvtCB.Checked = setting;
            setting = Settings.Store.EvtRemoteDisconnect;
            this.remoteDisconnectEvtCB.Checked = setting;

            this.useModNameCB.Checked = Settings.Store.UseModifiedName;

            updateUIOnModeChange();
        }
        private void okBtn_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        private bool Save()
        {
            if (sessionModeCB.Checked && eventModeCB.Checked
                && sessionTableTB.Text.Trim() == eventTableTB.Text.Trim())
            {
                MessageBox.Show("The Event Table must be different from the Session Table.");
                return false;
            }

            Settings.Store.SessionMode = sessionModeCB.Checked;
            Settings.Store.EventMode = eventModeCB.Checked;

            Settings.Store.SetEncryptedSetting("ConnectionString", this.hostTB.Text);
            Settings.Store.Database = this.dbTB.Text.Trim();
            Settings.Store.EventTable = this.eventTableTB.Text.Trim();
            Settings.Store.SessionTable = this.sessionTableTB.Text.Trim();

            Settings.Store.EvtLogon = this.logonEvtCB.Checked;
            Settings.Store.EvtLogoff = this.logoffEvtCB.Checked;
            Settings.Store.EvtLock = this.lockEvtCB.Checked;
            Settings.Store.EvtUnlock = this.unlockEvtCB.Checked;
            Settings.Store.EvtConsoleConnect = this.consoleConnectEvtCB.Checked;
            Settings.Store.EvtConsoleDisconnect = this.consoleDisconnectEvtCB.Checked;
            Settings.Store.EvtRemoteControl = this.remoteControlEvtCB.Checked;
            Settings.Store.EvtRemoteConnect = this.remoteConnectEvtCB.Checked;
            Settings.Store.EvtRemoteDisconnect = this.remoteDisconnectEvtCB.Checked;

            Settings.Store.UseModifiedName = this.useModNameCB.Checked;

            return true;
        }
        private void testButton_Click(object sender, EventArgs e)
        {
            if (!Save()) //Will pop up a message box with appropriate error.
                return;
            try
            {
                string sessionModeMsg = null;
                string eventModeMsg = null;

                if ((bool)Settings.Store.SessionMode)
                {
                    ILoggerMode mode = LoggerModeFactory.getLoggerMode(LoggerMode.SESSION);
                    sessionModeMsg = mode.TestTable();
                }

                if ((bool)Settings.Store.EventMode)
                {
                    ILoggerMode mode = LoggerModeFactory.getLoggerMode(LoggerMode.EVENT);
                    eventModeMsg = mode.TestTable();
                }

                //Show one or both messages
                if (sessionModeMsg != null && eventModeMsg != null)
                {
                    MessageBox.Show(String.Format("Event Mode Table: {0}\nSession Mode Table: {1}", eventModeMsg, sessionModeMsg));
                }
                else
                {
                    MessageBox.Show(sessionModeMsg ?? eventModeMsg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("The following error occurred: {0}", ex.Message));
            }

            //Since the server info may change, close the connection
            LoggerModeFactory.closeConnection();
        }
        private void updateUIOnModeChange()
        {   //Enables/disables the events box based on the mode selected.
            eventsBox.Enabled = eventModeCB.Checked;
            eventTableTB.Enabled = eventModeCB.Checked;
            sessionTableTB.Enabled = sessionModeCB.Checked;
        }

        private void showPassCB_CheckedChanged(object sender, EventArgs e)
        {
            this.hostTB.UseSystemPasswordChar = !this.showPassCB.Checked;
        }

        private void ModeChange(object sender, EventArgs e)
        {
            updateUIOnModeChange();
        }

    }
}
