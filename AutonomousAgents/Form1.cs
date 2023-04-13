using System;
using System.Drawing.Drawing2D;

namespace AutonomousAgents
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel1.ClientRectangle, Color.LightGray, ButtonBorderStyle.Solid);



            SolidBrush solidBrush = new SolidBrush(Color.Black);

            PointF[] coordinatesForTriangle = new PointF[] {
                        new PointF(400, 150),
                        new PointF(300, 300),
                        new PointF(500, 300)
                        };
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillPolygon(solidBrush, coordinatesForTriangle);


        }
    }
}