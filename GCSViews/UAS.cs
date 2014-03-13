using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.IO.Ports;

//using ArdupilotMega.Controls.BackstageView;

namespace ArdupilotMega.GCSViews
{
    public partial class UAS : MyUserControl//, IActivate, IDeactivate
    {
        private int startX=0, startY=0, endX=0, endY=0;
        private bool stabroll, stabpitch, stabyaw;
        private MAVLink.MAV_MOUNT_MODE mountMode;
        public static ArdupilotMega.Controls.TargetingHUD myhud;
        private System.Timers.Timer timer; 
        public EventHandler ConnectHandler;
        private StepperController stepperController;

        public UAS()
        {
            foreach(string port in SerialPort.GetPortNames())
            {
                portNameBox.Items.Add(port);
            }
            stepperController = new StepperController("COM7", 9600);
            InitializeComponent();
            if (!hud1.Visible)
                hud1.Visible = true;
            if (!hud1.Enabled)
                hud1.Enabled = true;
            if (!hud1.hudon)
                hud1.hudon = true;

            /*vTrackBar.Enabled = false;
            hTrackBar.Enabled = false;
            reset.Enabled = false;
            modeBox.Enabled = false;
            stabilityCheck.Enabled = false;
            stabpitchCheck.Enabled = false;
            stabyawCheck.Enabled = false;
            compModeBar.Enabled = false;*/

            ConnectHandler = new EventHandler(UAS_Connect);
            myhud = hud1;

            myhud = hud1;
            timer = new System.Timers.Timer(3000);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();

            hTrackBar.Maximum = 360;
            hTrackBar.Minimum = 0;
            hTrackBar.Value = 180;
            vTrackBar.Maximum = 0;
            vTrackBar.Minimum = -9000;
            vTrackBar.Value = -4500;

            pitchLabel.Text = "Pitch: " + vTrackBar.Value / 100;
            rollLabel.Text = "Roll: " + hTrackBar.Value / 100;

            stabroll = true;
            stabpitch = true;
            stabyaw = true;
            mountMode = MAVLink.MAV_MOUNT_MODE.NEUTRAL;
        }

        private void UAS_ParentChanged(object sender, EventArgs e)
        {
            if (MainV2.cam != null)
            {
                MainV2.cam.camimage += new WebCamService.CamImage(cam_camimage);
            }
        }

        void cam_camimage(Image camimage)
        {
            hud1.bgimage = camimage;
            hud1.DrawImage(camimage, 0, 0, hud1.Width, hud1.Height);
        }

        //paint rectangle
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        void UAS_hTrackBarMoved(object sender, EventArgs e)
        {
            rollLabel.Text = "Roll: " + hTrackBar.Value / 100;
            stepperController.setAngle(hTrackBar.Value);
        }

        void UAS_vTrackBarMoved(object sender, EventArgs e)
        {
            //Not sure if this is the right value
            MainV2.comPort.setMountControl(vTrackBar.Value, 0, 0, false);
            pitchLabel.Text = "Pitch: " + vTrackBar.Value / 100;
            rollLabel.Text = "Roll: " + hTrackBar.Value / 100;
        }

        private void UAS_ResetClicked(object sender, EventArgs e)
        {
            MainV2.comPort.setMountControl(0, 0, 0, false);
            hTrackBar.Value = 0;
            vTrackBar.Value = -4500;
            pitchLabel.Text = "Pitch: " + vTrackBar.Value / 100;
            rollLabel.Text = "Roll: " + hTrackBar.Value / 100;
        }

        private void modeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mountMode = (MAVLink.MAV_MOUNT_MODE) Enum.Parse(typeof(MAVLink.MAV_MOUNT_MODE), modeBox.Text);

            MainV2.comPort.setMountConfigure(mountMode, stabroll, stabpitch, stabyaw);
        }

        private void stabrollCheck_Changed(object sender, EventArgs e)
        {
            stabroll = !stabroll;
            MainV2.comPort.setMountConfigure(mountMode, stabroll, stabpitch, stabyaw);
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
        }

        private void stabpitchCheck_Changed(object sender, EventArgs e)
        {
            stabpitch = !stabpitch;
            MainV2.comPort.setMountConfigure(mountMode, stabroll, stabpitch, stabyaw);
        }

        private void stabyawCheck_Changed(object sender, EventArgs e)
        {
            stabyaw = !stabyaw;
            MainV2.comPort.setMountConfigure(mountMode, stabroll, stabpitch, stabyaw);
        }

        private void UAS_ComputerModeChanged(object sender, EventArgs e)
        {
            MAVLink.mavlink_computer_mode_t computer_mode = new MAVLink.mavlink_computer_mode_t();
            computer_mode.mode = (byte)compModeBar.Value;
            MainV2.comPort.sendPacket(computer_mode);
        }

        private void UAS_Connect(Object sender, EventArgs e)
        {
            vTrackBar.Enabled = true;
            hTrackBar.Enabled = true;
            reset.Enabled = true;
            modeBox.Enabled = true;
            stabilityCheck.Enabled = true;
            stabpitchCheck.Enabled = true;
            stabyawCheck.Enabled = true;
            compModeBar.Enabled = true;
        }

        private void portNameBox_IndexChanged(object sender, EventArgs e)
        {
            stepperController.setPortName(portNameBox.Items[portNameBox.SelectedIndex].ToString());
        }

        private void trackButton_Click(object sender, EventArgs e)
        {
            TLDTracker tldTracker = new TLDTracker();
            Thread thread = new Thread(new ThreadStart(tldTracker.runTLD));
            thread.Start();
        }

        private void portButton_Click(object sender, EventArgs e)
        {
            stepperController.Open();
            hTrackBar.ValueChanged += UAS_hTrackBarMoved;
        }
    }

    class TLDTracker
    {
        public void runTLD()
        {
            Process TLDApp = new Process();
            TLDApp.StartInfo.UseShellExecute = false;
            TLDApp.StartInfo.RedirectStandardOutput = true;
            TLDApp.StartInfo.FileName = @"C:\Users\Hussain\Downloads\gnebehay-OpenTLD-808300c\bin\Debug\opentld.exe";
            TLDApp.StartInfo.Arguments = "-s";
            TLDApp.Start();

            string output;
            string[] splitOutput;
            while (!TLDApp.HasExited)
            {
                output = TLDApp.StandardOutput.ReadLine();
                if (output == null)
                    continue;
                splitOutput = output.Split(' ');

                int tx1 = 0;
                int ty1 = 0;
                int tx2 = 0;
                int ty2 = 0;
                try
                {
                    tx1 = Convert.ToInt32(splitOutput[1]);
                    ty1 = Convert.ToInt32(splitOutput[2]);
                    tx2 = tx1 + Convert.ToInt32(splitOutput[3]);
                    ty2 = ty1 + Convert.ToInt32(splitOutput[4]);
                }
                catch (Exception e)
                {
                    continue;
                }

                MAVLink.mavlink_set_vision_target_box_t vision_position = new MAVLink.mavlink_set_vision_target_box_t();
                vision_position.topLeftX = tx1;
                vision_position.topLeftY = ty1;
                vision_position.bottomRightX = tx2;
                vision_position.bottomRightY = ty2;
                MainV2.comPort.sendPacket(vision_position);
            }

        }
    }
}
