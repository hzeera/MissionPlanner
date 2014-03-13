namespace ArdupilotMega.GCSViews
{
    partial class UAS
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UAS));
            this.hTrackBar = new System.Windows.Forms.TrackBar();
            this.vTrackBar = new System.Windows.Forms.TrackBar();
            this.reset = new System.Windows.Forms.Button();
            this.modeBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.stabilityCheck = new System.Windows.Forms.CheckBox();
            this.stabpitchCheck = new System.Windows.Forms.CheckBox();
            this.stabyawCheck = new System.Windows.Forms.CheckBox();
            this.pitchLabel = new System.Windows.Forms.Label();
            this.rollLabel = new System.Windows.Forms.Label();
            this.hud1 = new ArdupilotMega.Controls.TargetingHUD();
            this.compModeBar = new System.Windows.Forms.TrackBar();
            this.autoLabel = new System.Windows.Forms.Label();
            this.semiLabel = new System.Windows.Forms.Label();
            this.standbyLabel = new System.Windows.Forms.Label();
            this.trackButton = new System.Windows.Forms.Button();
            this.portNameBox = new System.Windows.Forms.ComboBox();
            this.portButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.hTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compModeBar)).BeginInit();
            this.SuspendLayout();
            // 
            // hTrackBar
            // 
            this.hTrackBar.Location = new System.Drawing.Point(0, 303);
            this.hTrackBar.Margin = new System.Windows.Forms.Padding(4);
            this.hTrackBar.Name = "hTrackBar";
            this.hTrackBar.Size = new System.Drawing.Size(427, 56);
            this.hTrackBar.TabIndex = 6;
            this.hTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // vTrackBar
            // 
            this.vTrackBar.Location = new System.Drawing.Point(423, 0);
            this.vTrackBar.Margin = new System.Windows.Forms.Padding(4);
            this.vTrackBar.Name = "vTrackBar";
            this.vTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.vTrackBar.Size = new System.Drawing.Size(56, 295);
            this.vTrackBar.TabIndex = 7;
            this.vTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.vTrackBar.ValueChanged += new System.EventHandler(this.UAS_vTrackBarMoved);
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(423, 303);
            this.reset.Margin = new System.Windows.Forms.Padding(4);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(60, 55);
            this.reset.TabIndex = 8;
            this.reset.Text = "reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.UAS_ResetClicked);
            // 
            // modeBox
            // 
            this.modeBox.FormattingEnabled = true;
            this.modeBox.ItemHeight = 16;
            this.modeBox.Items.AddRange(new object[] {
            "RETRACT",
            "NEUTRAL",
            "MAVLINK_TARGETING",
            "RC_TARGETING",
            "GPS_POINT"});
            this.modeBox.Location = new System.Drawing.Point(523, 59);
            this.modeBox.Margin = new System.Windows.Forms.Padding(4);
            this.modeBox.Name = "modeBox";
            this.modeBox.Size = new System.Drawing.Size(175, 84);
            this.modeBox.TabIndex = 9;
            this.modeBox.SelectedIndexChanged += new System.EventHandler(this.modeBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(545, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Control Panel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(519, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Mount mode:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(519, 181);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Stability:";
            // 
            // stabilityCheck
            // 
            this.stabilityCheck.AutoSize = true;
            this.stabilityCheck.Checked = true;
            this.stabilityCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.stabilityCheck.Location = new System.Drawing.Point(585, 181);
            this.stabilityCheck.Margin = new System.Windows.Forms.Padding(4);
            this.stabilityCheck.Name = "stabilityCheck";
            this.stabilityCheck.Size = new System.Drawing.Size(54, 21);
            this.stabilityCheck.TabIndex = 16;
            this.stabilityCheck.Text = "Roll";
            this.stabilityCheck.UseVisualStyleBackColor = true;
            this.stabilityCheck.CheckedChanged += new System.EventHandler(this.stabrollCheck_Changed);
            // 
            // stabpitchCheck
            // 
            this.stabpitchCheck.AutoSize = true;
            this.stabpitchCheck.Checked = true;
            this.stabpitchCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.stabpitchCheck.Location = new System.Drawing.Point(652, 181);
            this.stabpitchCheck.Margin = new System.Windows.Forms.Padding(4);
            this.stabpitchCheck.Name = "stabpitchCheck";
            this.stabpitchCheck.Size = new System.Drawing.Size(61, 21);
            this.stabpitchCheck.TabIndex = 17;
            this.stabpitchCheck.Text = "Pitch";
            this.stabpitchCheck.UseVisualStyleBackColor = true;
            this.stabpitchCheck.CheckedChanged += new System.EventHandler(this.stabpitchCheck_Changed);
            // 
            // stabyawCheck
            // 
            this.stabyawCheck.AutoSize = true;
            this.stabyawCheck.Checked = true;
            this.stabyawCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.stabyawCheck.Location = new System.Drawing.Point(727, 181);
            this.stabyawCheck.Margin = new System.Windows.Forms.Padding(4);
            this.stabyawCheck.Name = "stabyawCheck";
            this.stabyawCheck.Size = new System.Drawing.Size(56, 21);
            this.stabyawCheck.TabIndex = 18;
            this.stabyawCheck.Text = "Yaw";
            this.stabyawCheck.UseVisualStyleBackColor = true;
            this.stabyawCheck.CheckedChanged += new System.EventHandler(this.stabyawCheck_Changed);
            // 
            // pitchLabel
            // 
            this.pitchLabel.AutoSize = true;
            this.pitchLabel.Location = new System.Drawing.Point(519, 279);
            this.pitchLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pitchLabel.Name = "pitchLabel";
            this.pitchLabel.Size = new System.Drawing.Size(43, 17);
            this.pitchLabel.TabIndex = 19;
            this.pitchLabel.Text = "Pitch:";
            // 
            // rollLabel
            // 
            this.rollLabel.AutoSize = true;
            this.rollLabel.Location = new System.Drawing.Point(597, 279);
            this.rollLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rollLabel.Name = "rollLabel";
            this.rollLabel.Size = new System.Drawing.Size(36, 17);
            this.rollLabel.TabIndex = 20;
            this.rollLabel.Text = "Roll:";
            // 
            // hud1
            // 
            this.hud1.airspeed = 0F;
            this.hud1.alt = 0F;
            this.hud1.BackColor = System.Drawing.Color.Black;
            this.hud1.batterylevel = 0F;
            this.hud1.batteryremaining = 0F;
            this.hud1.bgimage = null;
            this.hud1.current = 0F;
            this.hud1.datetime = new System.DateTime(((long)(0)));
            this.hud1.disttowp = 0F;
            this.hud1.failsafe = false;
            this.hud1.gpsfix = 0F;
            this.hud1.gpshdop = 0F;
            this.hud1.groundalt = 0F;
            this.hud1.groundcourse = 0F;
            this.hud1.groundspeed = 0F;
            this.hud1.heading = 0F;
            this.hud1.hudcolor = System.Drawing.Color.White;
            this.hud1.linkqualitygcs = 0F;
            this.hud1.Location = new System.Drawing.Point(0, 0);
            this.hud1.lowvoltagealert = false;
            this.hud1.Margin = new System.Windows.Forms.Padding(5);
            this.hud1.message = "";
            this.hud1.mode = "Manual";
            this.hud1.Name = "hud1";
            this.hud1.navpitch = 0F;
            this.hud1.navroll = 0F;
            this.hud1.opengl = true;
            this.hud1.pitch = 0F;
            this.hud1.roll = 0F;
            this.hud1.Size = new System.Drawing.Size(415, 295);
            this.hud1.status = false;
            this.hud1.streamjpg = ((System.IO.MemoryStream)(resources.GetObject("hud1.streamjpg")));
            this.hud1.TabIndex = 21;
            this.hud1.targetalt = 0F;
            this.hud1.targetheading = 0F;
            this.hud1.targetspeed = 0F;
            this.hud1.turnrate = 0F;
            this.hud1.verticalspeed = 0F;
            this.hud1.VSync = false;
            this.hud1.wpno = 0;
            this.hud1.xtrack_error = 0F;
            // 
            // compModeBar
            // 
            this.compModeBar.Location = new System.Drawing.Point(523, 209);
            this.compModeBar.Margin = new System.Windows.Forms.Padding(4);
            this.compModeBar.Maximum = 2;
            this.compModeBar.Name = "compModeBar";
            this.compModeBar.Size = new System.Drawing.Size(229, 56);
            this.compModeBar.TabIndex = 22;
            this.compModeBar.ValueChanged += new System.EventHandler(this.UAS_ComputerModeChanged);
            // 
            // autoLabel
            // 
            this.autoLabel.AutoSize = true;
            this.autoLabel.Location = new System.Drawing.Point(519, 249);
            this.autoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.autoLabel.Name = "autoLabel";
            this.autoLabel.Size = new System.Drawing.Size(47, 17);
            this.autoLabel.TabIndex = 23;
            this.autoLabel.Text = "AUTO";
            // 
            // semiLabel
            // 
            this.semiLabel.AutoSize = true;
            this.semiLabel.Location = new System.Drawing.Point(597, 249);
            this.semiLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.semiLabel.Name = "semiLabel";
            this.semiLabel.Size = new System.Drawing.Size(84, 17);
            this.semiLabel.TabIndex = 24;
            this.semiLabel.Text = "SEMI-AUTO";
            // 
            // standbyLabel
            // 
            this.standbyLabel.AutoSize = true;
            this.standbyLabel.Location = new System.Drawing.Point(693, 249);
            this.standbyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.standbyLabel.Name = "standbyLabel";
            this.standbyLabel.Size = new System.Drawing.Size(73, 17);
            this.standbyLabel.TabIndex = 25;
            this.standbyLabel.Text = "STANDBY";
            // 
            // trackButton
            // 
            this.trackButton.Location = new System.Drawing.Point(564, 319);
            this.trackButton.Name = "trackButton";
            this.trackButton.Size = new System.Drawing.Size(169, 40);
            this.trackButton.TabIndex = 26;
            this.trackButton.Text = "Start Tracker";
            this.trackButton.UseVisualStyleBackColor = true;
            this.trackButton.Click += new System.EventHandler(this.trackButton_Click);
            // 
            // portNameBox
            // 
            this.portNameBox.FormattingEnabled = true;
            this.portNameBox.Location = new System.Drawing.Point(842, 59);
            this.portNameBox.Name = "portNameBox";
            this.portNameBox.Size = new System.Drawing.Size(121, 24);
            this.portNameBox.TabIndex = 27;
            this.portNameBox.Text = "Choose Port...";
            this.portNameBox.SelectedIndexChanged += new System.EventHandler(this.portNameBox_IndexChanged);
            // 
            // portButton
            // 
            this.portButton.Location = new System.Drawing.Point(842, 89);
            this.portButton.Name = "portButton";
            this.portButton.Size = new System.Drawing.Size(121, 34);
            this.portButton.TabIndex = 28;
            this.portButton.Text = "Open Port";
            this.portButton.UseVisualStyleBackColor = true;
            this.portButton.Click += new System.EventHandler(this.portButton_Click);
            // 
            // UAS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.portButton);
            this.Controls.Add(this.portNameBox);
            this.Controls.Add(this.trackButton);
            this.Controls.Add(this.standbyLabel);
            this.Controls.Add(this.semiLabel);
            this.Controls.Add(this.autoLabel);
            this.Controls.Add(this.compModeBar);
            this.Controls.Add(this.hud1);
            this.Controls.Add(this.rollLabel);
            this.Controls.Add(this.pitchLabel);
            this.Controls.Add(this.stabyawCheck);
            this.Controls.Add(this.stabpitchCheck);
            this.Controls.Add(this.stabilityCheck);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modeBox);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.vTrackBar);
            this.Controls.Add(this.hTrackBar);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UAS";
            this.Size = new System.Drawing.Size(1015, 465);
            this.ParentChanged += new System.EventHandler(this.UAS_ParentChanged);
            ((System.ComponentModel.ISupportInitialize)(this.hTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compModeBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar hTrackBar;
        private System.Windows.Forms.TrackBar vTrackBar;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.ListBox modeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox stabilityCheck;
        private System.Windows.Forms.CheckBox stabpitchCheck;
        private System.Windows.Forms.CheckBox stabyawCheck;
        private System.Windows.Forms.Label pitchLabel;
        private System.Windows.Forms.Label rollLabel;
        private Controls.TargetingHUD hud1;
        private System.Windows.Forms.TrackBar compModeBar;
        private System.Windows.Forms.Label autoLabel;
        private System.Windows.Forms.Label semiLabel;
        private System.Windows.Forms.Label standbyLabel;
        private System.Windows.Forms.Button trackButton;
        private System.Windows.Forms.ComboBox portNameBox;
        private System.Windows.Forms.Button portButton;


    }
}
