using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomousAgents
{
    internal class PVector
    {
        public float X { get; set; } = 0;
        public float Y { get; set; } = 0;

        const int WIDTH = 1248;
        const int HEIGHT = 823;

        public PVector(float x, float y)
        {
            X = x;
            Y = y;
        }
        public PVector() { }

        public void Add(PVector v)
        {
            X += v.X;
            Y += v.Y;
        }

        public static PVector Add(PVector v1, PVector v2)
        {
            PVector v3 = new(v1.X + v2.X, v1.Y + v2.Y);
            return v3;
        }

        public void Sub(PVector v)
        {
            X -= v.X;
            Y -= v.Y;
        }
        public static PVector Sub(PVector v1, PVector v2)
        {
            PVector v3 = new(v1.X - v2.X, v1.Y - v2.Y);
            return v3;
        }

        public void Multiply(float n)
        {
            X *= n;
            Y *= n;
        }

        public static PVector Multiply(PVector v1, PVector v2)
        {
            PVector v3 = new(v1.X * v2.X, v1.Y * v2.Y);
            return v3;
        }

        public void Divide(float n)
        {
            X /= n;
            Y /= n;
        }

        public static PVector Divide(PVector v1, PVector v2)
        {
            PVector v3 = new(v1.X / v2.X, v1.Y / v2.Y);
            return v3;
        }

        public float Mag() // Magnitutde/length of the vector
        {
            return (float)Math.Sqrt(X * X + Y * Y);
        }

        public void Normalize() // Vektor poljubne dolžine spremenimo v vektor enote
        {
            float m = Mag();

            if (m != 0.0f)
            {
                Divide(m);
            }
        }

        public void Limit(float max)
        {
            if (Mag() > max)
            {
                Normalize();
                Multiply(max);
            }

        }

        public void SetMag(float n)
        {
            Normalize();
            Multiply(n);
        }

        public PVector Copy()
        {
            return new PVector(X, Y);
        }

        public static PVector Random2D()
        {
            PVector test = new(new Random().Next(WIDTH + WIDTH) - WIDTH, new Random().Next(HEIGHT + HEIGHT) - HEIGHT);
            Debug.WriteLine(test.X + " " + test.Y);
            return test;
        }

        public float Heading()
        {
            return (float)(Math.Atan2(Y, X));
        }

        public float Distance(PVector v)
        {
            PVector result = v.Copy();
            result = Sub(result, this);
            return result.Mag();

        }

        public static float Distance(PVector v1, PVector v2)
        {
            return v1.Distance(v2);
        }

    }
}
