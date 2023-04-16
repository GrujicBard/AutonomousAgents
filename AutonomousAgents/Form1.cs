using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Forms;


namespace AutonomousAgents
{
    public partial class Form1 : Form
    {
        private int _height;
        private int _width;
        private int _numberOfBoids = 1;
        private Boid[]? boids = null;
        private PVector _target;
        private const float PI = (float)Math.PI;
        private bool _isDev = false;
        private bool _isEdge = false;

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            SetDoubleBuffered(panel1);
            SetDoubleBuffered(panel2);
            SetDoubleBuffered(panel3);
            SetDoubleBuffered(tc);

            _width = panel1.Width;
            _height = panel1.Height;
            _target = new PVector(0, 0);
        }


        // Tab 1

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            ControlPaint.DrawBorder(g, panel1.ClientRectangle, Color.LightGray, ButtonBorderStyle.Solid);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (boids != null)
            {
                DrawTarget(_target.X, _target.Y, 50, g);
                foreach (Boid boid in boids)
                {
                    var x = boid.Location.X;
                    var y = boid.Location.Y;
                    float angle = boid.Velocity.Heading() * 180 / PI;
                    g.TranslateTransform(x, y);
                    g.RotateTransform(angle + 90);
                    g.TranslateTransform(-x, -y);
                    g.FillTriangle(e, new PointF(x, y), 12);
                    g.ResetTransform();
                }
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            var x = e.X;
            var y = e.Y;
            _target.X = x;
            _target.Y = y;
            tb_mouse_1.Text = string.Format("X: {0} , Y: {1}", x, y);
        }

        private void btn_start_1_Click(object sender, EventArgs e)
        {
            BtnStart(btn_start_1, btn_pause_1, timer_1, tb_input_1);
        }

        private void btn_pause_1_Click(object sender, EventArgs e)
        {
            BtnPause(btn_pause_1, timer_1);
        }

        private void timer_1_Tick(object sender, EventArgs e)
        {
            SeekAndArrive();
        }

        private void SeekAndArrive()
        {
            if (boids != null)
            {
                foreach (Boid boid in boids)
                {
                    boid.SeekAndArrive(_target);
                    boid.Update();
                    boid.CheckEdges(_width, _height);
                }
            }
            Refresh();
        }


        // Tab 2

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            ControlPaint.DrawBorder(g, panel1.ClientRectangle, Color.LightGray, ButtonBorderStyle.Solid);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (boids != null)
            {
                foreach (Boid boid in boids)
                {
                    var x = boid.Location.X;
                    var y = boid.Location.Y;
                    float angle = boid.Velocity.Heading() * 180 / PI;
                    g.TranslateTransform(x, y);
                    g.RotateTransform(angle + 90);
                    g.TranslateTransform(-x, -y);
                    g.FillTriangle(e, new PointF(x, y), 12);
                    g.ResetTransform();

                    if (_isDev)
                    {
                        g.DrawLine(Pens.Gray, new Point((int)boid.Location.X, (int)boid.Location.Y), new Point((int)boid.RedDotDraw.X, (int)boid.RedDotDraw.Y));
                        g.DrawLine(Pens.Gray, new Point((int)boid.Location.X, (int)boid.Location.Y), new Point((int)boid.GreenDotDraw.X, (int)boid.GreenDotDraw.Y));
                        DrawTarget(boid.RedDotDraw.X, boid.RedDotDraw.Y, boid.R * 2, g);
                        g.FillEllipse(Brushes.Green, boid.GreenDotDraw.X - 4, boid.GreenDotDraw.Y - 4, 8, 8);
                    }

                }
            }

        }
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            tb_mouse_2.Text = string.Format("X: {0} , Y: {1}", e.X, e.Y);
        }

        private void btn_start_2_Click(object sender, EventArgs e)
        {
            BtnStart(btn_start_2, btn_pause_2, timer_2, tb_input_2);
            //BtnStartTwoTimers(btn_start_2, btn_pause_2, timer_2, timer_2_target, tb_input_2);
        }

        private void btn_pause_2_Click(object sender, EventArgs e)
        {
            BtnPause(btn_pause_2, timer_2);
        }

        private void btn_dev_2_Click(object sender, EventArgs e)
        {
            _isDev = !_isDev;
        }

        private void btn_edges_2_Click(object sender, EventArgs e)
        {
            _isEdge = !_isEdge;
        }

        private void timer_2_Tick(object sender, EventArgs e)
        {
            int edgeLimit = 0;
            if (_isEdge)
            {
                edgeLimit = 100;
            }
            Wander(edgeLimit);
            StayWithinWalls(edgeLimit);
        }

        private void timer_2_target_Tick(object sender, EventArgs e)
        {
            _target = PVector.Random2D();
        }

        public void Wander(int d)
        {
            if (boids != null)
            {
                foreach (Boid boid in boids)
                {
                    boid.Wander(_width, _height, d);
                    boid.Update();
                    boid.CheckEdges(_width, _height);
                }
            }
            Refresh();
        }


        // Tab 3

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            ControlPaint.DrawBorder(g, panel1.ClientRectangle, Color.LightGray, ButtonBorderStyle.Solid);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawRectangle(Pens.LightGray, new Rectangle(25, 25, _width - 50, _height - 50)); //within walls rectangle

            if (boids != null)
            {
                foreach (Boid boid in boids)
                {
                    var x = boid.Location.X;
                    var y = boid.Location.Y;
                    float angle = boid.Velocity.Heading() * 180 / PI;
                    g.TranslateTransform(x, y);
                    g.RotateTransform(angle + 90);
                    g.TranslateTransform(-x, -y);
                    g.FillTriangle(e, new PointF(x, y), 12);
                    g.ResetTransform();

                }
            }
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            tb_mouse_3.Text = string.Format("X: {0} , Y: {1}", e.X, e.Y);
        }

        private void btn_start_3_Click(object sender, EventArgs e)
        {
            BtnStart(btn_start_3, btn_pause_3, timer_3, tb_input_3);
        }

        private void btn_pause_3_Click(object sender, EventArgs e)
        {
            BtnPause(btn_pause_3, timer_3);
        }


        private void timer_3_Tick(object sender, EventArgs e)
        {
            StayWithinWalls(50);
        }

        private void StayWithinWalls(int d)
        {
            if (boids != null)
            {
                foreach (Boid boid in boids)
                {
                    boid.StayWithinWalls(_width, _height, d);
                    boid.Update();
                    boid.CheckEdges(_width, _height);
                }
            }
            Refresh();
        }


        // Global functions

        private void InitializeGame(TextBox tb_input)
        {
            if (tb_input.Text != "")
            {
                _numberOfBoids = int.Parse(tb_input.Text);
            }
            boids = new Boid[_numberOfBoids];
            for (int i = 0; i < boids.Length; i++)
            {
                boids[i] = new Boid(new Random().Next(_width), new Random().Next(_height));
            }
        }

        private void tc_SelectedIndexChanged(object sender, EventArgs e)
        {
            // On tab changed reset data
            boids = null;
            _numberOfBoids = 1;
            _target = new(0, 0);
            btn_start_1.Text = "Start";
            btn_pause_1.Text = "Pause";
            btn_start_2.Text = "Start";
            btn_pause_2.Text = "Pause";
            btn_start_3.Text = "Start";
            btn_pause_3.Text = "Pause";
            timer_1.Stop();
            timer_2.Stop();
            timer_3.Stop();
        }

        private void BtnStart(Button btn_start, Button btn_pause, System.Windows.Forms.Timer timer, TextBox tb_input)
        {
            if (btn_start.Text == "Start")
            {
                timer.Start();
                InitializeGame(tb_input);
                btn_start.Text = "Stop";
            }
            else
            {
                timer.Stop();
                boids = null;
                Refresh();
                btn_start.Text = "Start";
                btn_pause.Text = "Pause";
            }
        }

        private void BtnPause(Button btn_pause, System.Windows.Forms.Timer timer)
        {
            if (btn_pause.Text == "Resume")
            {
                timer.Start();
                btn_pause.Text = "Pause";
            }
            else
            {
                timer.Stop();
                btn_pause.Text = "Resume";
            }
        }

        public static void DrawTarget(float x, float y, float r, Graphics g)
        {
            g.FillEllipse(Brushes.Red, x - 4, y - 4, 8, 8);
            g.DrawEllipse(Pens.Gray, x - r / 2, y - r / 2, r, r);
        }

        public static void SetDoubleBuffered(Control c)
        {
            if (SystemInformation.TerminalServerSession)
                return;
            PropertyInfo? aProp = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
            aProp?.SetValue(c, true, null);
        }


    }
}