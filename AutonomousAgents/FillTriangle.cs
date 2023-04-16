using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomousAgents
{
    public static class Extensions
    {
        public static void FillTriangle(this Graphics g, PaintEventArgs e, PointF p, int size)
        {
            e.Graphics.FillPolygon(Brushes.Black, new PointF[] { new PointF(p.X, p.Y - 20), new PointF(p.X - size, p.Y + (float)(size * Math.Sqrt(5))), new PointF(p.X + size, p.Y + (float)(size * Math.Sqrt(5))) });
        }
    }
}
