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
            x = 0;
            y = 0;
            z = 0;
        }

        public Vertex Increment(Vertex v) => new Vertex(x + v.x, y + v.y, z + v.z);
        
        public Vertex Decrement(Vertex v) => new Vertex(x - v.x, y - v.y, z - v.z);

        public Vertex Division(double d) => new Vertex(x / d, y / d, z / d);
        
        private double GetMagnitude() => Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));

        public Vertex Normalize()
        {
            double magnitude = GetMagnitude();
            if (magnitude == 0)
                return new Vertex(1, 1, 1);
            return Division(magnitude);
        }
       
        public double DotProduct(Vertex v)
        {
            return x * v.x + y * v.y + z * v.z;
        }

        public Vertex CrossProduct(Vertex v)
        {
            return new Vertex(
                y * v.z - z * v.y, 
                z * v.x - x * v.z, 
                x * v.y - y * v.x
            );
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
    }
}
