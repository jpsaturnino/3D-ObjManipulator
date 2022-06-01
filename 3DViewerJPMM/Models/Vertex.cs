using static _3DViewerJPMM.Utils.Helper;

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

        public Vertex Division(double d)
        {
            return new Vertex(this.x / d, this.y / d, this.z / d);
        }
        
        private double GetMagnitude()
        {
            return Math.Sqrt(Math.Pow(this.x, 2) + Math.Pow(this.y, 2) + Math.Pow(this.z, 2));
        }

        public Vertex Normalize()
        {
            double magnitude = GetMagnitude();
            if (magnitude == 0)
                return new Vertex(1, 1, 1);
            return this.Division(magnitude);
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

        public double[,] ToMatrix()
        {
            return new double[,] {
                { this.x },
                { this.y },
                { this.z },
                { 1 }
            };
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
