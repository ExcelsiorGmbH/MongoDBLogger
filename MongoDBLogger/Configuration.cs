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

            this.eventModeCB.Checked = Settings.Store.EventMode;
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
            Settings.Store.EventMode = eventModeCB.Checked;
            return true;
        }
    }
}
