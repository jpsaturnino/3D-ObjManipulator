using static _3DViewerJPMM.Utils.Helper;
using System.Diagnostics;

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

        public double[,] ToMatrix()
        {
            return new double[,] {
                { x },
                { y },
                { z },
                { 1 }
            };
        }
        
        public Vertex Increment(Vertex v) => new Vertex(x + v.x, y + v.y, z + v.z);

        public Vertex Decrement(Vertex p) => new Vertex(x - p.x, y - p.y, z - p.z);

        public Vertex Normalize()
        {
            double magnitude = Math.Sqrt(x * x + y * y + z * z);
            if (magnitude != 0)
                return new Vertex(x / magnitude, y / magnitude, z / magnitude);
            return new Vertex(1, 1, 1);
        }

        public double DotProduct(Vertex v) => x * v.x + y * v.y + z * v.z;

        public Vertex CrossProduct(Vertex v) => new Vertex(y * v.z - z * v.y, z * v.x - x * v.z, x * v.y - y * v.x);
    }
}
