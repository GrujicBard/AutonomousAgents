using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Numerics;
using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace AutonomousAgents
{
    internal class Boid
    {
        private const float PI = (float)Math.PI;
        public PVector Location { get; set; }
        public PVector Velocity { get; set; }
        public PVector Acceleration { get; set; }
        public PVector? RedDotDraw { get; set; }
        public PVector? RedDotCalc { get; set; }
        public PVector? GreenDotDraw { get; set; }
        public PVector? GreenDotCalc { get; set; }
        public float R { get; set; }

        public float Theta { get; set; } = PI / 2;
        public float MaxForce { get; set; }
        public float MaxSpeed { get; set; }


        public Boid(float x, float y)
        {
            Acceleration = new PVector(0, 0);
            Velocity = new PVector(1, 0); // 0,0
            Location = new PVector(x, y);
            R = 50;
            MaxSpeed = 3.0f;
            MaxForce = 0.2f;
        }

        public void Update()
        {
            // Update Velocity
            Velocity.Add(Acceleration);
            // Limit speed
            Velocity.Limit(MaxSpeed);
            Location.Add(Velocity);
            // Each cycle reset Acceleration to 0
            Acceleration.Multiply(0);
        }


        public void SeekAndArrive(PVector target)
        {
            var d = 100;
            PVector direction = PVector.Sub(target, Location);
            float distance = direction.Mag(); // The distance is the magnitude of the vector pointing from location to target
            direction.Normalize();

            if (distance < d) // If closer than 100 pixels
            {
                float length = Map(distance, 0, d, 0, MaxSpeed); // Slows boid down according to how close we are
                direction.Multiply(length);
            }
            else
            {
                direction.Multiply(MaxSpeed);
            }

            PVector steer = PVector.Sub(direction, Velocity);
            steer.Limit(MaxForce);
            ApplyForce(steer);
        }

        public void Wander(int width, int height, int d)
        {
            var direction = Velocity.Copy();
            direction.SetMag(100);
            direction.Add(Location);
            RedDotDraw = direction;
            RedDotCalc = RedDotDraw.Copy();

            float angle = Theta + Velocity.Heading();
            var x = (float)(R * Math.Cos(angle));
            var y = (float)(R * Math.Sin(angle));
            RedDotCalc.Add(new(x, y));
            GreenDotDraw = new(RedDotCalc.X, RedDotCalc.Y);
            GreenDotCalc = GreenDotDraw.Copy();

            if (Location.X > d && Location.X < width - d && Location.Y > d && Location.Y < height - d)
            {
                var steer = PVector.Sub(RedDotCalc, Location);
                steer.SetMag(MaxForce);
                ApplyForce(steer);

                var displacementRange = 0.4;
                Theta += GetRandomFloat(-displacementRange, displacementRange);
            }

        }

        public void StayWithinWalls(int width, int height, int d)
        {
            PVector desired = null;

            if (Location.X < d)
            {
                desired = new PVector(MaxSpeed, Velocity.Y);
            }
            else if (Location.X > width - d)
            {
                desired = new PVector(-MaxSpeed, Velocity.Y); ;
            }

            if (Location.Y < d)
            {
                desired = new PVector(Velocity.X, MaxSpeed);
            }
            else if (Location.Y > height - d)
            {
                desired = new PVector(Velocity.X, -MaxSpeed);
            }

            if (desired != null)
            {

                PVector steer = PVector.Sub(desired, Velocity);
                steer.Limit(MaxForce);
                ApplyForce(steer);

            }

        }

        private void ApplyForce(PVector force)
        {
            Acceleration.Add(force);
        }

        public void CheckEdges(int width, int height)
        {
            if (Location.X > width)
            {
                Location.X = 0;
            }
            else if (Location.X < 0)
            {
                Location.X = width;
            }

            if (Location.Y > height)
            {
                Location.Y = 0;
            }
            else if (Location.Y < 0)
            {
                Location.Y = height;
            }
        }

        static public float Map(float value, float istart, float istop, float ostart, float ostop)
        {
            return ostart + (ostop - ostart) * ((value - istart) / (istop - istart));
        }

        public float GetRandomFloat(double minimum, double maximum)
        {
            Random random = new Random();
            return (float)(random.NextDouble() * (maximum - minimum) + minimum);
        }

    }
}
