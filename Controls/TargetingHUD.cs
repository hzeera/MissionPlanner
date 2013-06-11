using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArdupilotMega.Controls
{
    using System.Drawing.Drawing2D;
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using System.Drawing.Imaging;

    public partial class TargetingHUD : HUD
    {
        Graphics graphicsObjectGDIP;
        int tx1, tx2, ty1, ty2;

        public TargetingHUD() : base()
        {
            InitializeComponent();
        }

        Bitmap objBitmap = new Bitmap(1024, 1024);
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        public override void doPaint(PaintEventArgs e)
        {
            tx1 = (int)MainV2.comPort.MAV.cs.target_x1;
            tx2 = (int)MainV2.comPort.MAV.cs.target_x2;
            ty1 = (int)MainV2.comPort.MAV.cs.target_y1;
            ty2 = (int)MainV2.comPort.MAV.cs.target_y2;
            if (graphicsObjectGDIP == null || !opengl && (objBitmap.Width != this.Width || objBitmap.Height != this.Height))
            {
                objBitmap = new Bitmap(this.Width, this.Height);
                graphicsObjectGDIP = Graphics.FromImage(objBitmap);

                graphicsObjectGDIP.SmoothingMode = SmoothingMode.AntiAlias;
                graphicsObjectGDIP.InterpolationMode = InterpolationMode.NearestNeighbor;
                graphicsObjectGDIP.CompositingMode = CompositingMode.SourceOver;
                graphicsObjectGDIP.CompositingQuality = CompositingQuality.HighSpeed;
                graphicsObjectGDIP.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                graphicsObjectGDIP.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            }

            graphicsObjectGDIP.InterpolationMode = InterpolationMode.Bilinear;


            Clear(Color.Gray);

            if (bgimage != null)
            {
                bgon = false;
                DrawImage(bgimage, 0, 0, this.Width, this.Height);
            }
            else
            {
                bgon = true;
            }
            float _roll = 0;
            float _pitch = 0;
            float _heading = 0;
            if (float.IsNaN(_roll) || float.IsNaN(_pitch) || float.IsNaN(_heading))
            {
                _roll = 0;
                _pitch = 0;
                _heading = 0;
            }

            TranslateTransform(this.Width / 2, this.Height / 2);



            RotateTransform(-_roll);


            int fontsize = this.Height / 30; // = 10
            int fontoffset = fontsize - 10;

            float every5deg = -this.Height / 65;

            float pitchoffset = -_pitch * every5deg;

            int halfwidth = this.Width / 2;
            int halfheight = this.Height / 2;

            Pen whitePen = new Pen(Color.White, 2);
            SolidBrush whiteBrush = new SolidBrush(whitePen.Color);

            Pen blackPen = new Pen(Color.Black, 2);
            Pen greenPen = new Pen(Color.Green, 2);
            Pen redPen = new Pen(Color.Red, 2);

            // draw sky
            if (bgon == true)
            {
                RectangleF bg = new RectangleF(-halfwidth * 2, -halfheight * 2, this.Width * 2, halfheight * 2 + pitchoffset);

                if (bg.Height != 0)
                {
                    LinearGradientBrush linearBrush = new LinearGradientBrush(bg, Color.Blue,
                        Color.LightBlue, LinearGradientMode.Vertical);

                    FillRectangle(linearBrush, bg);
                }
                // draw ground

                bg = new RectangleF(-halfwidth * 2, pitchoffset, this.Width * 2, halfheight * 2 - pitchoffset);

                if (bg.Height != 0)
                {
                    LinearGradientBrush linearBrush = new LinearGradientBrush(bg, Color.FromArgb(0x9b, 0xb8, 0x24),
                        Color.FromArgb(0x41, 0x4f, 0x07), LinearGradientMode.Vertical);

                    FillRectangle(linearBrush, bg);
                }

                //draw centerline
                DrawLine(whitePen, -halfwidth * 2, pitchoffset + 0, halfwidth * 2, pitchoffset + 0);
            }

            ResetTransform();

            DrawRectangle(redPen, tx1, ty1, tx2 - tx1, ty2 - ty1);
            DrawRectangle(whitePen, 0,0,0,0);
        }

        private void Target_MouseDown(object sender, MouseEventArgs e)
        {
            tx1 = e.X;
            ty1 = e.Y;
            tx2 = e.X;
            ty2 = e.Y;

            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Target_MouseMove);
        }

        private void Target_MouseMove(object sender, MouseEventArgs e)
        {
            tx2 = e.X;
            ty2 = e.Y;
        }

        private void Target_MouseUp(object sender, MouseEventArgs e)
        {
            tx2 = e.X;
            ty2 = e.Y;
            this.MouseMove -= new System.Windows.Forms.MouseEventHandler(this.Target_MouseMove);

            MAVLink.mavlink_set_vision_target_box_t vision_position = new MAVLink.mavlink_set_vision_target_box_t();
            vision_position.topLeftX = tx1;
            vision_position.topLeftY = ty1;
            vision_position.bottomRightX = tx2;
            vision_position.bottomRightY = ty2;
            MainV2.comPort.sendPacket(vision_position);
        }
    }
}
