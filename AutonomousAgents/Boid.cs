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
            Velocity = new PVector(0, 0); // 0,0
            Location = new PVector(x, y);
            R = 50;
            MaxSpeed = 4.0f;
            MaxForce = 0.1f;
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

        /* Behavior */

        public PVector SeekAndArrive(PVector target, float n = 1)
        {
            var d = 100;
            PVector direction = PVector.Sub(target, Location);
            float distance = direction.Mag(); // The distance is the magnitude of the vector pointing from location to target
            direction.Normalize();

            if (distance < d) // If closer than 100 pixels
            {
                float length = Map(distance, 0, d, 0, MaxSpeed); // Slows speed down according to how close we are
                direction.Multiply(length);
            }
            else
            {
                direction.Multiply(MaxSpeed); // Normal speed
            }

            PVector steer = PVector.Sub(direction, Velocity); // Reynold's steering forumla
            steer.Limit(MaxForce);

            steer.Multiply(n); // adding variable into function

            ApplyForce(steer);

            return steer;
        }

        public void Wander(int width, int height, int d, float n = 1)
        {
            /*
             * RedDot = Target
             * GreenDot = Direction  
             * Theta angle is changed to move GreenDot in circle around RedDot
             */
            MaxSpeed = 3.0f;
            MaxForce = 0.2f;

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

            if (Location.X > d && Location.X < width - d && Location.Y > d && Location.Y < height - d) // Limit function on edges when walls are up
            {
                var steer = PVector.Sub(RedDotCalc, Location); // Modified Reynold's steering formula
                steer.SetMag(MaxForce);

                steer.Multiply(n);

                ApplyForce(steer);

                var displacementRange = 0.4;
                Theta += GetRandomFloat(-displacementRange, displacementRange);
            }
        }

        public void StayWithinWalls(int width, int height, int d, float n = 1)
        {
            /* 
             * Accelerate in opposite direction of walls
             */
            MaxSpeed = 2.0f;
            PVector? desired = null;

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
                PVector steer = PVector.Sub(desired, Velocity); // Reynold's steering formula
                steer.Limit(MaxForce);

                steer.Multiply(n);

                ApplyForce(steer);
            }
        }

        public PVector Seperate(Boid[] boids, float n = 1)
        {
            float desiredSeperation = R;
            PVector sum = new();
            int count = 0;

            foreach (Boid otherBoid in boids)
            {
                float distance = PVector.Distance(Location, otherBoid.Location);
                if ((distance > 0) && (distance < desiredSeperation)) // If other vehicle is within R * 2 distance, 0 is so it doesn't count itself
                {
                    PVector awayVector = PVector.Sub(Location, otherBoid.Location);
                    awayVector.Normalize();
                    awayVector.Divide(distance); // The closer the other Boid, the farther away the Boid moves
                    sum.Add(awayVector); // Sums all vectors into a vector that pulls away
                    count++; // Count other Boids that are within R * 2 distance
                }
            }

            if (count > 0)
            {
                sum.Divide(count); // Divides the summed vector by counted Boids
                sum.Normalize();
                sum.SetMag(MaxSpeed); // Max speed away from other Boids

                PVector steer = PVector.Sub(sum, Velocity); // Reynold's steering formula
                steer.Limit(MaxForce);
                ApplyForce(steer);

                steer.Multiply(n);

                return steer;
            }
            return new PVector(0, 0);
        }

        public PVector Align(Boid[] boids, float n = 1)
        {
            float neighboursDist = R;
            PVector sum = new();
            int count = 0;

            foreach (Boid otherBoid in boids)
            {
                float distance = PVector.Distance(Location, otherBoid.Location);
                if ((distance > 0) && (distance < neighboursDist)) // Count boids near distance R * 2
                {
                    sum.Add(otherBoid.Velocity);
                    count++;
                }
            }
            if (count > 0)
            {
                sum.Divide(count); // Divide speed by number of boids, aligning them
                sum.Normalize();
                sum.Multiply(MaxSpeed);

                PVector steer = PVector.Sub(sum, Velocity); // Reynold's steering formula

                steer.Multiply(n);

                steer.Limit(MaxForce);
                return steer;
            }
            return new PVector(0, 0); // Steering force is zero if no boids around
        }

        public PVector Cohesion(Boid[] boids, float n = 1) // Same as Align() but Location instead of Velocity
        {
            float neighboursDist = R;
            PVector sum = new();
            int count = 0;

            foreach (Boid otherBoid in boids)
            {
                float distance = PVector.Distance(Location, otherBoid.Location);
                if ((distance > 0) && (distance < neighboursDist)) // Count boids near distance R * 2
                {
                    sum.Add(otherBoid.Location);
                    count++;
                }
            }
            if (count > 0)
            {
                sum.Divide(count); // Divide speed by number of boids, aligning them
                sum.Multiply(n);

                return SeekAndArrive(sum); // The target we seek is the average location of other boids
            }
            return new PVector(0, 0); // Steering force is zero if no boids around
        }

        public void Flock(Boid[] boids, float n = 1, float m = 1, float o = 1)
        {
            PVector sep = Seperate(boids, n);
            PVector ali = Align(boids, m);
            PVector coh = Cohesion(boids, o);

            ApplyForce(sep);
            ApplyForce(ali);
            ApplyForce(coh);
        }

        /** Behavior */

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

        public static float GetRandomFloat(double minimum, double maximum)
        {
            Random random = new Random();
            return (float)(random.NextDouble() * (maximum - minimum) + minimum);
        }

    }
}
