using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq.Expressions;
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
        private bool _isWall = false;

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            SetDoubleBuffered(panel1);

            _width = panel1.Width;
            _height = panel1.Height;
            _target = new PVector(0, 0);
            cb.SelectedIndex = 0;
        }

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
        public static void DrawTarget(float x, float y, float r, Graphics g)
        {
            g.FillEllipse(Brushes.Red, x - 4, y - 4, 8, 8);
            g.DrawEllipse(Pens.Gray, x - r / 2, y - r / 2, r, r);
        }



        /* Behavior */

        private void SeekAndArrive(float n = 1)
        {
            if (boids != null)
            {
                foreach (Boid boid in boids)
                {
                    boid.SeekAndArrive(_target, n);
                    boid.Update();
                    boid.CheckEdges(_width, _height);
                }
            }
            Refresh();
        }

        public void Wander(int d, float n = 1)
        {
            if (boids != null)
            {
                foreach (Boid boid in boids)
                {
                    boid.Wander(_width, _height, d, n);
                    boid.Update();
                    boid.CheckEdges(_width, _height);
                }
            }
            Refresh();
        }

        private void StayWithinWalls(int d, float n = 1)
        {
            if (boids != null)
            {
                foreach (Boid boid in boids)
                {
                    boid.StayWithinWalls(_width, _height, d, n);
                    boid.Update();
                    boid.CheckEdges(_width, _height);
                }
            }
            Refresh();
        }

        private void Seperate(float n = 1)
        {
            if (boids != null)
            {
                foreach (Boid boid in boids)
                {
                    boid.Seperate(boids, n);
                    boid.Update();
                    boid.CheckEdges(_width, _height);
                }
            }
            Refresh();
        }

        private void Flock(float sep = 1, float ali = 1, float coh = 1)
        {
            if (boids != null)
            {
                foreach (Boid boid in boids)
                {
                    boid.Flock(boids, sep, ali, coh);
                    boid.Update();
                    boid.CheckEdges(_width, _height);
                }
            }
            Refresh();
        }

        /** Behavior */

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            ControlPaint.DrawBorder(g, panel1.ClientRectangle, Color.LightGray, ButtonBorderStyle.Solid);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (boids != null)
            {
                if (cb.SelectedIndex == 0)
                {
                    DrawTarget(_target.X, _target.Y, 50, g);
                }

                foreach (Boid boid in boids)
                {
                    var x = boid.Location.X;
                    var y = boid.Location.Y;
                    float angle = boid.Velocity.Heading() * 180 / PI;
                    g.TranslateTransform(x, y);
                    g.RotateTransform(angle + 90);
                    g.TranslateTransform(-x, -y);
                    g.FillTriangle(e, new PointF(x, y), 8);
                    g.ResetTransform();
                    if (_isDev && (cb.SelectedIndex == 1 || cb.SelectedIndex == 3))
                    {
                        g.DrawLine(Pens.Gray, new Point((int)boid.Location.X, (int)boid.Location.Y), new Point((int)boid.RedDotDraw.X, (int)boid.RedDotDraw.Y));
                        g.DrawLine(Pens.Gray, new Point((int)boid.Location.X, (int)boid.Location.Y), new Point((int)boid.GreenDotDraw.X, (int)boid.GreenDotDraw.Y));
                        DrawTarget(boid.RedDotDraw.X, boid.RedDotDraw.Y, boid.R * 2, g);
                        g.FillEllipse(Brushes.Green, boid.GreenDotDraw.X - 4, boid.GreenDotDraw.Y - 4, 8, 8);
                    }

                }
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            //Coordinates
            var x = e.X;
            var y = e.Y;

            tb_mouse.Text = string.Format("X: {0} , Y: {1}", x, y);
            if (cb.SelectedIndex == 0)
            {
                _target.X = x;
                _target.Y = y;
            }
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (btn_start.Text == "Start")
            {
                timer_1.Start();
                InitializeGame(tb_input);
                btn_start.Text = "Stop";
            }
            else
            {
                timer_1.Stop();
                boids = null;
                Refresh();
                btn_start.Text = "Start";
                btn_pause.Text = "Pause";
            }
        }

        private void btn_pause_Click(object sender, EventArgs e)
        {
            if (btn_pause.Text == "Resume")
            {
                timer_1.Start();
                btn_pause.Text = "Pause";
            }
            else
            {
                timer_1.Stop();
                btn_pause.Text = "Resume";
            }
        }

        private void btn_dev_Click(object sender, EventArgs e)
        {
            _isDev = !_isDev;
        }


        private void btn_walls_Click(object sender, EventArgs e)
        {
            _isWall = !_isWall;
        }

        private void timer_1_Tick(object sender, EventArgs e) // Inputs here
        {
            int edgeLimit = 0;
            if (_isWall)
            {
                edgeLimit = 100;
                StayWithinWalls(edgeLimit);
            }
            switch (cb.SelectedIndex)
            {
                case 0:
                    Seperate(1.5f);
                    SeekAndArrive(0.5f);
                    break;

                case 1:
                    Wander(edgeLimit);
                    break;

                case 2:
                    Seperate(1.5f);
                    break;

                case 3:
                    Seperate(1.5f);
                    Wander(edgeLimit, 0.5f);
                    break;

                case 4:
                    Flock(1.2f, 1.0f, 1.5f);
                    break;

                default:
                    break;
            }

        }

        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            // On selected index change reset data
            boids = null;
            _numberOfBoids = 1;
            _target = new(0, 0);
            _isDev = false;
            _isWall = false;
            btn_start.Text = "Start";
            btn_pause.Text = "Pause";
            Refresh();

            //Show buttons
            if (cb.SelectedIndex == 0)
            {
                btn_walls.Visible = false;
            }
            else
            {
                btn_walls.Visible = true;
            }
            if (cb.SelectedIndex == 1 || cb.SelectedIndex == 3)
            {
                btn_dev.Visible = true;
            }
            else
            {
                btn_dev.Visible = false;
            }
        }

        private void cb_Click(object sender, EventArgs e)
        {
            timer_1.Stop();
        }

        public static void SetDoubleBuffered(Control c)
        {
            // Stops element flickering
            if (SystemInformation.TerminalServerSession)
                return;
            PropertyInfo? aProp = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
            aProp?.SetValue(c, true, null);
        }


    }
}