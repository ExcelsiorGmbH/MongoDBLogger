namespace pGina.Plugin.MonogDBLogger
{
    partial class Configuration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.sessionModeCB = new System.Windows.Forms.CheckBox();
            this.eventModeCB = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.sessionTableTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.eventTableTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.showPassCB = new System.Windows.Forms.CheckBox();
            this.dbTB = new System.Windows.Forms.TextBox();
            this.dbLabel = new System.Windows.Forms.Label();
            this.hostTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.eventsBox = new System.Windows.Forms.GroupBox();
            this.remoteDisconnectEvtCB = new System.Windows.Forms.CheckBox();
            this.remoteConnectEvtCB = new System.Windows.Forms.CheckBox();
            this.remoteControlEvtCB = new System.Windows.Forms.CheckBox();
            this.consoleDisconnectEvtCB = new System.Windows.Forms.CheckBox();
            this.consoleConnectEvtCB = new System.Windows.Forms.CheckBox();
            this.unlockEvtCB = new System.Windows.Forms.CheckBox();
            this.lockEvtCB = new System.Windows.Forms.CheckBox();
            this.logoffEvtCB = new System.Windows.Forms.CheckBox();
            this.logonEvtCB = new System.Windows.Forms.CheckBox();
            this.optionsBox = new System.Windows.Forms.GroupBox();
            this.useModNameCB = new System.Windows.Forms.CheckBox();
            this.testButton = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.eventsBox.SuspendLayout();
            this.optionsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(349, 300);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 0;
            this.okBtn.Text = "Ok";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(430, 300);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.sessionModeCB);
            this.groupBox3.Controls.Add(this.eventModeCB);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(487, 32);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mode";
            // 
            // sessionModeCB
            // 
            this.sessionModeCB.AutoSize = true;
            this.sessionModeCB.Location = new System.Drawing.Point(318, 11);
            this.sessionModeCB.Name = "sessionModeCB";
            this.sessionModeCB.Size = new System.Drawing.Size(93, 17);
            this.sessionModeCB.TabIndex = 1;
            this.sessionModeCB.Text = "Session Mode";
            this.sessionModeCB.UseVisualStyleBackColor = true;
            // 
            // eventModeCB
            // 
            this.eventModeCB.AutoSize = true;
            this.eventModeCB.Location = new System.Drawing.Point(73, 11);
            this.eventModeCB.Name = "eventModeCB";
            this.eventModeCB.Size = new System.Drawing.Size(84, 17);
            this.eventModeCB.TabIndex = 0;
            this.eventModeCB.Text = "Event Mode";
            this.eventModeCB.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.sessionTableTB);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.eventTableTB);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.showPassCB);
            this.groupBox2.Controls.Add(this.dbTB);
            this.groupBox2.Controls.Add(this.dbLabel);
            this.groupBox2.Controls.Add(this.hostTB);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(11, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(494, 129);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Server";
            // 
            // sessionTableTB
            // 
            this.sessionTableTB.Location = new System.Drawing.Point(92, 96);
            this.sessionTableTB.Name = "sessionTableTB";
            this.sessionTableTB.Size = new System.Drawing.Size(307, 20);
            this.sessionTableTB.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Session Table:";
            // 
            // eventTableTB
            // 
            this.eventTableTB.Location = new System.Drawing.Point(92, 70);
            this.eventTableTB.Name = "eventTableTB";
            this.eventTableTB.Size = new System.Drawing.Size(308, 20);
            this.eventTableTB.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Event Table:";
            // 
            // showPassCB
            // 
            this.showPassCB.AutoSize = true;
            this.showPassCB.Location = new System.Drawing.Point(405, 21);
            this.showPassCB.Name = "showPassCB";
            this.showPassCB.Size = new System.Drawing.Size(77, 17);
            this.showPassCB.TabIndex = 7;
            this.showPassCB.Text = "Show Text";
            this.showPassCB.UseVisualStyleBackColor = true;
            // 
            // dbTB
            // 
            this.dbTB.Location = new System.Drawing.Point(93, 44);
            this.dbTB.Name = "dbTB";
            this.dbTB.Size = new System.Drawing.Size(307, 20);
            this.dbTB.TabIndex = 2;
            // 
            // dbLabel
            // 
            this.dbLabel.AutoSize = true;
            this.dbLabel.Location = new System.Drawing.Point(17, 47);
            this.dbLabel.Name = "dbLabel";
            this.dbLabel.Size = new System.Drawing.Size(56, 13);
            this.dbLabel.TabIndex = 12;
            this.dbLabel.Text = "Database:";
            // 
            // hostTB
            // 
            this.hostTB.Location = new System.Drawing.Point(92, 19);
            this.hostTB.Name = "hostTB";
            this.hostTB.Size = new System.Drawing.Size(307, 20);
            this.hostTB.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server:";
            // 
            // eventsBox
            // 
            this.eventsBox.Controls.Add(this.remoteDisconnectEvtCB);
            this.eventsBox.Controls.Add(this.remoteConnectEvtCB);
            this.eventsBox.Controls.Add(this.remoteControlEvtCB);
            this.eventsBox.Controls.Add(this.consoleDisconnectEvtCB);
            this.eventsBox.Controls.Add(this.consoleConnectEvtCB);
            this.eventsBox.Controls.Add(this.unlockEvtCB);
            this.eventsBox.Controls.Add(this.lockEvtCB);
            this.eventsBox.Controls.Add(this.logoffEvtCB);
            this.eventsBox.Controls.Add(this.logonEvtCB);
            this.eventsBox.Location = new System.Drawing.Point(11, 181);
            this.eventsBox.Name = "eventsBox";
            this.eventsBox.Size = new System.Drawing.Size(494, 66);
            this.eventsBox.TabIndex = 5;
            this.eventsBox.TabStop = false;
            this.eventsBox.Text = "Events";
            // 
            // remoteDisconnectEvtCB
            // 
            this.remoteDisconnectEvtCB.AutoSize = true;
            this.remoteDisconnectEvtCB.Location = new System.Drawing.Point(261, 42);
            this.remoteDisconnectEvtCB.Name = "remoteDisconnectEvtCB";
            this.remoteDisconnectEvtCB.Size = new System.Drawing.Size(120, 17);
            this.remoteDisconnectEvtCB.TabIndex = 7;
            this.remoteDisconnectEvtCB.Text = "Remote Disconnect";
            this.remoteDisconnectEvtCB.UseVisualStyleBackColor = true;
            // 
            // remoteConnectEvtCB
            // 
            this.remoteConnectEvtCB.AutoSize = true;
            this.remoteConnectEvtCB.Location = new System.Drawing.Point(261, 19);
            this.remoteConnectEvtCB.Name = "remoteConnectEvtCB";
            this.remoteConnectEvtCB.Size = new System.Drawing.Size(106, 17);
            this.remoteConnectEvtCB.TabIndex = 6;
            this.remoteConnectEvtCB.Text = "Remote Connect";
            this.remoteConnectEvtCB.UseVisualStyleBackColor = true;
            // 
            // remoteControlEvtCB
            // 
            this.remoteControlEvtCB.AutoSize = true;
            this.remoteControlEvtCB.Location = new System.Drawing.Point(383, 19);
            this.remoteControlEvtCB.Name = "remoteControlEvtCB";
            this.remoteControlEvtCB.Size = new System.Drawing.Size(99, 17);
            this.remoteControlEvtCB.TabIndex = 8;
            this.remoteControlEvtCB.Text = "Remote Control";
            this.remoteControlEvtCB.UseVisualStyleBackColor = true;
            // 
            // consoleDisconnectEvtCB
            // 
            this.consoleDisconnectEvtCB.AutoSize = true;
            this.consoleDisconnectEvtCB.Location = new System.Drawing.Point(134, 42);
            this.consoleDisconnectEvtCB.Name = "consoleDisconnectEvtCB";
            this.consoleDisconnectEvtCB.Size = new System.Drawing.Size(121, 17);
            this.consoleDisconnectEvtCB.TabIndex = 5;
            this.consoleDisconnectEvtCB.Text = "Console Disconnect";
            this.consoleDisconnectEvtCB.UseVisualStyleBackColor = true;
            // 
            // consoleConnectEvtCB
            // 
            this.consoleConnectEvtCB.AutoSize = true;
            this.consoleConnectEvtCB.Location = new System.Drawing.Point(134, 19);
            this.consoleConnectEvtCB.Name = "consoleConnectEvtCB";
            this.consoleConnectEvtCB.Size = new System.Drawing.Size(107, 17);
            this.consoleConnectEvtCB.TabIndex = 4;
            this.consoleConnectEvtCB.Text = "Console Connect";
            this.consoleConnectEvtCB.UseVisualStyleBackColor = true;
            // 
            // unlockEvtCB
            // 
            this.unlockEvtCB.AutoSize = true;
            this.unlockEvtCB.Location = new System.Drawing.Point(68, 42);
            this.unlockEvtCB.Name = "unlockEvtCB";
            this.unlockEvtCB.Size = new System.Drawing.Size(60, 17);
            this.unlockEvtCB.TabIndex = 3;
            this.unlockEvtCB.Text = "Unlock";
            this.unlockEvtCB.UseVisualStyleBackColor = true;
            // 
            // lockEvtCB
            // 
            this.lockEvtCB.AutoSize = true;
            this.lockEvtCB.Location = new System.Drawing.Point(68, 19);
            this.lockEvtCB.Name = "lockEvtCB";
            this.lockEvtCB.Size = new System.Drawing.Size(50, 17);
            this.lockEvtCB.TabIndex = 2;
            this.lockEvtCB.Text = "Lock";
            this.lockEvtCB.UseVisualStyleBackColor = true;
            // 
            // logoffEvtCB
            // 
            this.logoffEvtCB.AutoSize = true;
            this.logoffEvtCB.Location = new System.Drawing.Point(6, 42);
            this.logoffEvtCB.Name = "logoffEvtCB";
            this.logoffEvtCB.Size = new System.Drawing.Size(56, 17);
            this.logoffEvtCB.TabIndex = 1;
            this.logoffEvtCB.Text = "Logoff";
            this.logoffEvtCB.UseVisualStyleBackColor = true;
            // 
            // logonEvtCB
            // 
            this.logonEvtCB.AutoSize = true;
            this.logonEvtCB.Location = new System.Drawing.Point(6, 19);
            this.logonEvtCB.Name = "logonEvtCB";
            this.logonEvtCB.Size = new System.Drawing.Size(56, 17);
            this.logonEvtCB.TabIndex = 0;
            this.logonEvtCB.Text = "Logon";
            this.logonEvtCB.UseVisualStyleBackColor = true;
            // 
            // optionsBox
            // 
            this.optionsBox.Controls.Add(this.useModNameCB);
            this.optionsBox.Location = new System.Drawing.Point(11, 253);
            this.optionsBox.Name = "optionsBox";
            this.optionsBox.Size = new System.Drawing.Size(494, 41);
            this.optionsBox.TabIndex = 6;
            this.optionsBox.TabStop = false;
            this.optionsBox.Text = "Options";
            // 
            // useModNameCB
            // 
            this.useModNameCB.AutoSize = true;
            this.useModNameCB.Location = new System.Drawing.Point(7, 18);
            this.useModNameCB.Name = "useModNameCB";
            this.useModNameCB.Size = new System.Drawing.Size(139, 17);
            this.useModNameCB.TabIndex = 0;
            this.useModNameCB.Text = "Use Modified Username";
            this.useModNameCB.UseVisualStyleBackColor = true;
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(12, 298);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(67, 27);
            this.testButton.TabIndex = 7;
            this.testButton.Text = "Test...";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 330);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.optionsBox);
            this.Controls.Add(this.eventsBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Name = "Configuration";
            this.Text = "Configuration";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.eventsBox.ResumeLayout(false);
            this.eventsBox.PerformLayout();
            this.optionsBox.ResumeLayout(false);
            this.optionsBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox sessionModeCB;
        private System.Windows.Forms.CheckBox eventModeCB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox sessionTableTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox eventTableTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox showPassCB;
        private System.Windows.Forms.TextBox dbTB;
        private System.Windows.Forms.Label dbLabel;
        private System.Windows.Forms.TextBox hostTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox eventsBox;
        private System.Windows.Forms.CheckBox remoteDisconnectEvtCB;
        private System.Windows.Forms.CheckBox remoteConnectEvtCB;
        private System.Windows.Forms.CheckBox remoteControlEvtCB;
        private System.Windows.Forms.CheckBox consoleDisconnectEvtCB;
        private System.Windows.Forms.CheckBox consoleConnectEvtCB;
        private System.Windows.Forms.CheckBox unlockEvtCB;
        private System.Windows.Forms.CheckBox lockEvtCB;
        private System.Windows.Forms.CheckBox logoffEvtCB;
        private System.Windows.Forms.CheckBox logonEvtCB;
        private System.Windows.Forms.GroupBox optionsBox;
        private System.Windows.Forms.CheckBox useModNameCB;
        private System.Windows.Forms.Button testButton;
    }
}