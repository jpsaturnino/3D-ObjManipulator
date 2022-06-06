namespace _3DViewerJPMM.Models
{
    internal class NodeAET
    { 
        private double ymax, xmin, incx, zmin, bzmin, rxmin, gymin, inczy, incrx, incgy, incbz;

        public NodeAET(double ymax, double xmin, double incx, double zmin, double bzmin, double rxmin, double gymin, double inczy, double incrx, double incgy, double incbz)
        {
            this.ymax = ymax;
            this.xmin = xmin;
            this.incx = incx;
            this.zmin = zmin;
            this.bzmin = bzmin;
            this.rxmin = rxmin;
            this.gymin = gymin;
            this.inczy = inczy;
            this.incrx = incrx;
            this.incgy = incgy;
            this.incbz = incbz;
        }

        public double YMax
        {
            get { return ymax; }
            set { ymax = value; }
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

        public double Zmin
        {
            get { return zmin; }
            set { zmin = value; }
        }
        
        public double Gymin
        {
            get { return gymin; }
            set { gymin = value; }
        }
        
        public double Rxmin
        {
            get { return rxmin; }
            set { rxmin = value; }
        }

        public double ZMin
        {
            get { return zmin; }
            set { zmin = value; }
        }

        public double BZMin
        {
            get { return bzmin; }
            set { bzmin = value; }
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

        public double IncZY
        {
            get { return inczy; }
            set { inczy = value; }
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
    }
}