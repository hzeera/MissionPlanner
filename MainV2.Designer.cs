﻿namespace ArdupilotMega
{
    partial class MainV2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainV2));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.CTX_mainmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.autoHideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFlightData = new System.Windows.Forms.ToolStripButton();
            this.MenuFlightPlanner = new System.Windows.Forms.ToolStripButton();
            this.MenuConfiguration = new System.Windows.Forms.ToolStripButton();
            this.MenuSimulation = new System.Windows.Forms.ToolStripButton();
            this.MenuFirmware = new System.Windows.Forms.ToolStripButton();
            this.MenuTerminal = new System.Windows.Forms.ToolStripButton();
            this.MenuUAS = new System.Windows.Forms.ToolStripButton();
            this.MenuConnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripConnectionControl = new ArdupilotMega.Controls.ToolStripConnectionControl();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu = new ArdupilotMega.Controls.MyButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.MainMenu.SuspendLayout();
            this.CTX_mainmenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MainMenu.BackgroundImage")));
            this.MainMenu.ContextMenuStrip = this.CTX_mainmenu;
            this.MainMenu.GripMargin = new System.Windows.Forms.Padding(0);
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(76, 76);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFlightData,
            this.MenuFlightPlanner,
            this.MenuConfiguration,
            this.MenuSimulation,
            this.MenuFirmware,
            this.MenuTerminal,
            this.toolStripButton1,
            this.MenuUAS,
            this.MenuConnect,
            this.toolStripMenuItem1,
            this.toolStripConnectionControl});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Padding = new System.Windows.Forms.Padding(0);
            this.MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MainMenu.Size = new System.Drawing.Size(1200, 76);
            this.MainMenu.Stretch = false;
            this.MainMenu.TabIndex = 5;
            this.MainMenu.Text = "menuStrip1";
            this.MainMenu.MouseLeave += new System.EventHandler(this.MainMenu_MouseLeave);
            // 
            // CTX_mainmenu
            // 
            this.CTX_mainmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoHideToolStripMenuItem});
            this.CTX_mainmenu.Name = "CTX_mainmenu";
            this.CTX_mainmenu.Size = new System.Drawing.Size(143, 28);
            // 
            // autoHideToolStripMenuItem
            // 
            this.autoHideToolStripMenuItem.Checked = true;
            this.autoHideToolStripMenuItem.CheckOnClick = true;
            this.autoHideToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoHideToolStripMenuItem.Name = "autoHideToolStripMenuItem";
            this.autoHideToolStripMenuItem.Size = new System.Drawing.Size(142, 24);
            this.autoHideToolStripMenuItem.Text = "AutoHide";
            this.autoHideToolStripMenuItem.Click += new System.EventHandler(this.autoHideToolStripMenuItem_Click);
            // 
            // MenuFlightData
            // 
            this.MenuFlightData.AutoSize = false;
            this.MenuFlightData.BackgroundImage = global::ArdupilotMega.Properties.Resources.data;
            this.MenuFlightData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MenuFlightData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuFlightData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuFlightData.Margin = new System.Windows.Forms.Padding(0);
            this.MenuFlightData.Name = "MenuFlightData";
            this.MenuFlightData.Padding = new System.Windows.Forms.Padding(0, 0, 72, 72);
            this.MenuFlightData.Size = new System.Drawing.Size(76, 76);
            this.MenuFlightData.Click += new System.EventHandler(this.MenuFlightData_Click);
            // 
            // MenuFlightPlanner
            // 
            this.MenuFlightPlanner.AutoSize = false;
            this.MenuFlightPlanner.BackgroundImage = global::ArdupilotMega.Properties.Resources.planner;
            this.MenuFlightPlanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MenuFlightPlanner.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuFlightPlanner.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuFlightPlanner.Margin = new System.Windows.Forms.Padding(0);
            this.MenuFlightPlanner.Name = "MenuFlightPlanner";
            this.MenuFlightPlanner.Padding = new System.Windows.Forms.Padding(0, 0, 72, 72);
            this.MenuFlightPlanner.Size = new System.Drawing.Size(76, 76);
            this.MenuFlightPlanner.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuFlightPlanner.ToolTipText = "Flight Planner";
            this.MenuFlightPlanner.Click += new System.EventHandler(this.MenuFlightPlanner_Click);
            // 
            // MenuConfiguration
            // 
            this.MenuConfiguration.AutoSize = false;
            this.MenuConfiguration.BackgroundImage = global::ArdupilotMega.Properties.Resources.configuration;
            this.MenuConfiguration.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MenuConfiguration.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuConfiguration.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuConfiguration.Margin = new System.Windows.Forms.Padding(0);
            this.MenuConfiguration.Name = "MenuConfiguration";
            this.MenuConfiguration.Padding = new System.Windows.Forms.Padding(0, 0, 72, 72);
            this.MenuConfiguration.Size = new System.Drawing.Size(76, 76);
            this.MenuConfiguration.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuConfiguration.ToolTipText = "Configuration";
            this.MenuConfiguration.Click += new System.EventHandler(this.MenuConfiguration_Click);
            // 
            // MenuSimulation
            // 
            this.MenuSimulation.AutoSize = false;
            this.MenuSimulation.BackgroundImage = global::ArdupilotMega.Properties.Resources.simulation;
            this.MenuSimulation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MenuSimulation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuSimulation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuSimulation.Margin = new System.Windows.Forms.Padding(0);
            this.MenuSimulation.Name = "MenuSimulation";
            this.MenuSimulation.Padding = new System.Windows.Forms.Padding(0, 0, 72, 72);
            this.MenuSimulation.Size = new System.Drawing.Size(76, 76);
            this.MenuSimulation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuSimulation.ToolTipText = "Simulation";
            this.MenuSimulation.Click += new System.EventHandler(this.MenuSimulation_Click);
            // 
            // MenuFirmware
            // 
            this.MenuFirmware.AutoSize = false;
            this.MenuFirmware.BackgroundImage = global::ArdupilotMega.Properties.Resources.firmware;
            this.MenuFirmware.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MenuFirmware.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuFirmware.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuFirmware.Margin = new System.Windows.Forms.Padding(0);
            this.MenuFirmware.Name = "MenuFirmware";
            this.MenuFirmware.Padding = new System.Windows.Forms.Padding(0, 0, 72, 72);
            this.MenuFirmware.Size = new System.Drawing.Size(76, 76);
            this.MenuFirmware.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuFirmware.ToolTipText = "Firmware";
            this.MenuFirmware.Click += new System.EventHandler(this.MenuFirmware_Click);
            // 
            // MenuTerminal
            // 
            this.MenuTerminal.AutoSize = false;
            this.MenuTerminal.BackgroundImage = global::ArdupilotMega.Properties.Resources.terminal;
            this.MenuTerminal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MenuTerminal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuTerminal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuTerminal.Margin = new System.Windows.Forms.Padding(0);
            this.MenuTerminal.Name = "MenuTerminal";
            this.MenuTerminal.Padding = new System.Windows.Forms.Padding(0, 0, 72, 72);
            this.MenuTerminal.Size = new System.Drawing.Size(76, 76);
            this.MenuTerminal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuTerminal.ToolTipText = "Terminal";
            this.MenuTerminal.Click += new System.EventHandler(this.MenuTerminal_Click);
            // 
            // MenuUAS
            // 
            this.MenuUAS.AutoSize = false;
            this.MenuUAS.BackgroundImage = global::ArdupilotMega.Properties.Resources.Gaugebg;
            this.MenuUAS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MenuUAS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuUAS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuUAS.Margin = new System.Windows.Forms.Padding(0);
            this.MenuUAS.Name = "MenuUAS";
            this.MenuUAS.Padding = new System.Windows.Forms.Padding(0, 0, 72, 72);
            this.MenuUAS.Size = new System.Drawing.Size(76, 76);
            this.MenuUAS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuUAS.ToolTipText = "Terminal";
            this.MenuUAS.Click += new System.EventHandler(this.MenuUAS_Click);
            // 
            // MenuConnect
            // 
            this.MenuConnect.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MenuConnect.AutoSize = false;
            this.MenuConnect.BackgroundImage = global::ArdupilotMega.Properties.Resources.connect;
            this.MenuConnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MenuConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuConnect.Margin = new System.Windows.Forms.Padding(0);
            this.MenuConnect.Name = "MenuConnect";
            this.MenuConnect.Padding = new System.Windows.Forms.Padding(0, 0, 72, 72);
            this.MenuConnect.Size = new System.Drawing.Size(76, 76);
            this.MenuConnect.Click += new System.EventHandler(this.MenuConnect_Click);
            // 
            // toolStripConnectionControl
            // 
            this.toolStripConnectionControl.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripConnectionControl.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripConnectionControl.BackgroundImage = global::ArdupilotMega.Properties.Resources.bg;
            this.toolStripConnectionControl.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripConnectionControl.Name = "toolStripConnectionControl";
            this.toolStripConnectionControl.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.toolStripConnectionControl.Size = new System.Drawing.Size(299, 76);
            this.toolStripConnectionControl.MouseLeave += new System.EventHandler(this.MainMenu_MouseLeave);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(70, 76);
            this.toolStripMenuItem1.Text = "Donate";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // menu
            // 
            this.menu.Dock = System.Windows.Forms.DockStyle.Top;
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1344, 28);
            this.menu.TabIndex = 6;
            this.menu.Text = "Menu";
            this.menu.UseVisualStyleBackColor = true;
            this.menu.MouseEnter += new System.EventHandler(this.menu_MouseEnter);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.MainMenu);
            this.panel1.Location = new System.Drawing.Point(57, 57);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.MaximumSize = new System.Drawing.Size(133332, 94);
            this.panel1.MinimumSize = new System.Drawing.Size(1200, 94);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 94);
            this.panel1.TabIndex = 7;
            this.panel1.Visible = false;
            this.panel1.MouseLeave += new System.EventHandler(this.MainMenu_MouseLeave);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.BackgroundImage = global::ArdupilotMega.Properties.Resources.help;
            this.toolStripButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Padding = new System.Windows.Forms.Padding(0, 0, 72, 72);
            this.toolStripButton1.Size = new System.Drawing.Size(76, 76);
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.ToolTipText = "Terminal";
            // 
            // MainV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 661);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.MainMenu;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1359, 697);
            this.Name = "MainV2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "APM Planner - By Michael Oborne";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainV2_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainV2_FormClosed);
            this.Load += new System.EventHandler(this.MainV2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainV2_KeyDown);
            this.Resize += new System.EventHandler(this.MainV2_Resize);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.CTX_mainmenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion


        
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripButton MenuFlightData;
        private System.Windows.Forms.ToolStripButton MenuFlightPlanner;
        private System.Windows.Forms.ToolStripButton MenuConfiguration;
        private System.Windows.Forms.ToolStripButton MenuSimulation;
        private System.Windows.Forms.ToolStripButton MenuFirmware;
        private System.Windows.Forms.ToolStripButton MenuTerminal;
        private System.Windows.Forms.ToolStripButton MenuConnect;

        private System.Windows.Forms.ToolStripButton MenuUAS;
        private Controls.ToolStripConnectionControl toolStripConnectionControl;
        private Controls.MyButton menu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip CTX_mainmenu;
        private System.Windows.Forms.ToolStripMenuItem autoHideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}