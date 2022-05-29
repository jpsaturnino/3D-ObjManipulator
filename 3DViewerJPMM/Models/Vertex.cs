using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DViewerJPMM.Models
{
    internal class Vertex
    {
        private double x, y, z;

        public Vertex(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        
        public Vertex()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }

        public Vertex Increment(Vertex v)
        {
            return new Vertex(this.x + v.x, this.y + v.y, this.z + v.z);
        }

        public Vertex Decrement(Vertex v)
        {
            return new Vertex(this.x - v.x, this.y - v.y, this.z - v.z);
        }

        public Vertex Normalization()
        {
            double length = Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);
            return new Vertex(this.x / length, this.y / length, this.z / length);
        }

        public double DotProduct(Vertex v)
        {
            return this.x * v.x + this.y * v.y + this.z * v.z;
        }

        public Vertex CrossProduct(Vertex v)
        {
            return new Vertex(
                this.y * v.z - this.z * v.y, 
                this.z * v.x - this.x * v.z, 
                this.x * v.y - this.y * v.x
            );
        }

        public Vertex Division(double d)
        {
            return new Vertex(this.x / d, this.y / d, this.z / d);
        }
        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public double Z
        {
            get { return z; }
            set { z = value; }
        }
        public override string ToString()
        {
            return "(" + x + ", " + y + ", " + z + ")";
        }
    }
}
