using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DViewerJPMM.Models
{
    internal class NodeAET
    {
        private int ymax;
        private int xmin, incx;
        private double zmin, bzmin, rxmin, gymin;
        private double inczy, incrx, incgy, incbz;

        public NodeAET(int ymax, int xmin, int incx, double zmin, double bzmin, double rxmin, double gymin, double inczy, double incrx, double incgy, double incbz)
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

        public int YMax
        {
            get { return ymax; }
            set { ymax = value; }
        }

        public int XMin
        {
            get { return xmin; }
            set { xmin = value; }
        }

        public int IncX
        {
            get { return incx; }
            set { incx = value; }
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