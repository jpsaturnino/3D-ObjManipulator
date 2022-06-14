namespace _3DViewerJPMM.Models
{
    internal class NodeAET
    {
        private int ymax;
        private double incx, xmin;
        private double zmin, inczy;
        private double rxmin, gymin, bzmin;
        private double incrx, incgy, incbz;

        public NodeAET(int ymax, double xmin, double incx, double zmin, double inczy, double rxmin, double gymin, double bzmin, double incrx, double incgy, double incbz)
        {
            this.ymax = ymax;
            this.incx = incx;
            this.xmin = xmin;
            this.zmin = zmin;
            this.inczy = inczy;
            this.rxmin = rxmin;
            this.gymin = gymin;
            this.bzmin = bzmin;
            this.incrx = incrx;
            this.incgy = incgy;
            this.incbz = incbz;
        }

        public double XMin
        {
            get { return xmin; }
            set { xmin = value; }
        }

        public double IncX
        {
            get { return incx; }
            set { incx = value; }
        }

        public double ZMin
        {
            get { return zmin; }
            set { zmin = value; }
        }

        public double IncZ
        {
            get { return inczy; }
            set { inczy = value; }
        }

        public double ZYMin
        {
            get { return zmin; }
            set { zmin = value; }
        }
        public double IncZY
        {
            get { return inczy; }
            set { inczy = value; }
        }

        public double RXMin
        {
            get { return rxmin; }
            set { rxmin = value; }
        }

        public double GYMin
        {
            get { return gymin; }
            set { gymin = value; }
        }

        public double BZMin
        {
            get { return bzmin; }
            set { bzmin = value; }
        }

        public double IncRX
        {
            get { return incrx; }
            set { incrx = value; }
        }

        public double IncGY
        {
            get { return incgy; }
            set { incgy = value; }
        }

        public double IncBZ
        {
            get { return incbz; }
            set { incbz = value; }
        }

        public int YMax
        {
            get { return ymax; }
            set { ymax = value; }
        }

        public void Update(int y)
        {
            xmin += incx;
            zmin += inczy;
            rxmin += incrx;
            gymin += incgy;
            bzmin += incbz;
        }
    }
}