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
    /**
     * Main UAS View
     **/
    public partial class UAS : MyUserControl
    {
        private int startX=0, startY=0, endX=0, endY=0, prevHValue, prevVValue;
        private bool stabroll, stabpitch, stabyaw;
        private MAVLink.MAV_MOUNT_MODE mountMode;
        public static ArdupilotMega.Controls.TargetingHUD myhud;
        private System.Timers.Timer timer; 
        public EventHandler ConnectHandler;
        private ServoController servoController;

        public UAS()
        {
            
            servoController = ServoController.getInstance();
            servoController.setBaudRate(115200);
            InitializeComponent();

            List<string> devices = WebCamService.Capture.getDevices();
            foreach (string device in devices)
            {
                cameraBox.Items.Add(device);
            }

            foreach (string port in SerialPort.GetPortNames())
            {
                portNameBox.Items.Add(port);
            }

            if (!hud1.Visible)
                hud1.Visible = true;
            if (!hud1.Enabled)
                hud1.Enabled = true;
            if (!hud1.hudon)
                hud1.hudon = true;

            ConnectHandler = new EventHandler(UAS_Connect);
            myhud = hud1;

            myhud = hud1;
            timer = new System.Timers.Timer(3000);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();

            hTrackBar.Maximum = 150;
            hTrackBar.Minimum = 50;
            hTrackBar.Value = 100;
            vTrackBar.Maximum = 150;
            vTrackBar.Minimum = 50;
            vTrackBar.Value = 100;

            pitchLabel.Text = "Pitch: " + vTrackBar.Value;
            rollLabel.Text = "Roll: " + hTrackBar.Value;

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

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        void UAS_hTrackBarMoved(object sender, EventArgs e)
        {
            rollLabel.Text = "Roll: " + hTrackBar.Value;
            servoController.setAngle(hTrackBar.Value, vTrackBar.Value);
            prevHValue = hTrackBar.Value;
        }

        void UAS_vTrackBarMoved(object sender, EventArgs e)
        {
            servoController.setAngle(hTrackBar.Value, vTrackBar.Value);
            pitchLabel.Text = "Pitch: " + vTrackBar.Value;
            prevVValue = vTrackBar.Value;
        }

        private void UAS_ResetClicked(object sender, EventArgs e)
        {
            MainV2.comPort.setMountControl(0, 0, 0, false);
            hTrackBar.Value = 90;
            vTrackBar.Value = 90;
            servoController.setAngle(90, 90);
            pitchLabel.Text = "Pitch: " + vTrackBar.Value;
            rollLabel.Text = "Roll: " + hTrackBar.Value;
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
            servoController.setPortName(portNameBox.Items[portNameBox.SelectedIndex].ToString());
        }

        private void trackButton_Click(object sender, EventArgs e)
        {
            int device = 0;
            if (cameraBox.SelectedIndex >= 0)
                device = cameraBox.SelectedIndex;
            TLDTracker tldTracker = new TLDTracker(device);
            Thread thread = new Thread(new ThreadStart(tldTracker.runTLD));
            thread.Start();
        }

        private void portButton_Click(object sender, EventArgs e)
        {
            servoController.Open();
            servoController.setAngle(90, 90);
            hTrackBar.MouseUp += UAS_hTrackBarMoved;
            vTrackBar.MouseUp += UAS_vTrackBarMoved;
        }

        private void closePort_Click(object sender, EventArgs e)
        {
            servoController.Close();
        }
    }

    /**
     * Class to move camera based on TLD Target's location on screen.
     * 
     **/
    class TLDTracker
    {
        private int device;
        private ServoController controller;

        public TLDTracker(int device)
        {
            this.device = device;
            controller = ServoController.getInstance();
        }

        public void runTLD()
        {
            Process TLDApp = new Process();
            TLDApp.StartInfo.UseShellExecute = false;
            TLDApp.StartInfo.RedirectStandardOutput = true;
            TLDApp.StartInfo.FileName = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\OpenTLD\opentld.exe";
            TLDApp.StartInfo.Arguments = "-s -n " + device;
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
                //80, 160, 480, 560
                //80, 160, 340, 420
                int xStep = 0;
                int yStep = 0;

                if (tx1 < 80)
                {
                    xStep = 3;
                }
                else if (tx1 < 160)
                {
                    xStep = 1;
                }
                else if (tx2 > 560)
                {
                    xStep = -3;
                }
                else if (tx2 > 480)
                {
                    xStep = -1;
                }

                if (ty1 < 60)
                {
                    yStep = -3;
                }
                else if (ty1 < 120)
                {
                    yStep = -1;
                }
                else if (ty2 > 420)
                {
                    yStep = 3;
                }
                else if (ty2 > 360)
                {
                    yStep = 1;
                }

                controller.setStep(xStep, yStep);
            }

        }
    }
}
