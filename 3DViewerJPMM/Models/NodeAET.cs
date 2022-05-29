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
        // ----------------------------------------
        private double inczy, incrx, incgy, incbz;
        // ----------------------------------------

        public (int ymax, double xmin, double incx, double zmin, double inczy, double rxmin, double gymin, double bzmin, double incrx, double incgy, double incbz)
        {
            this.ymax = ymax;
            this.xmin = xmin;
            this.zmin = zmin;
            this.gymin = gymin;
            this.rxmin = rxmin;
            this.bzmin = bzmin;
            this.incx = incx;
            this.inczy = inczy;
            this.incrx = incrx;
            this.incgy = incgy;
            this.incbz = incbz;
        }

        public int ymax
        {
            get { return ymax; }
            set { ymax = value; }
        }

        public double xmin
        {
            get { return xmin; }
            set { xmin = value; }
        }
    
        public double zmin
        {
            get { return zmin; }
            set { zmin = value; }
        }
        
        public double gymin
        {
            get { return gymin; }
            set { gymin = value; }
        }
        
        public double rxmin
        {
            get { return rxmin; }
            set { rxmin = value; }
        }
        
        public double incx
        {
            get { return incx; }
            set { incx = value; }
        }
    
        public double inczy
        {
            get { return inczy; }
            set { inczy = value; }
        }

        public double incrx
        {
            get { return incrx; }
            set { incrx = value; }
        }

        public double incgy
        {
            get { return incgy; }
            set { incgy = value; }
        }

        public double incbz
        {
            get { return incbz; }
            set { incbz = value; }
        }
    }
}