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
        private double xmin, incx;
        private double zmin, bzmin, rxmin, gymin;
        private double inczy, incrx, incgy, incbz;

<<<<<<< HEAD
        public NodeAET(int ymax, int xmin, int incx, double zmin, double bzmin, double rxmin, double gymin, double inczy, double incrx, double incgy, double incbz)
        {
=======
        public NodeAET(int ymax, double xmin, double incx, double zmin, double inczy, double rxmin, double gymin, double bzmin, double incrx, double incgy, double incbz){
>>>>>>> bbf9611bd8ac367d2642a2bb7ae5c41b3fac2b64
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

<<<<<<< HEAD
        public int YMax
        {
=======
        public int Ymax{
>>>>>>> bbf9611bd8ac367d2642a2bb7ae5c41b3fac2b64
            get { return ymax; }
            set { ymax = value; }
        }

<<<<<<< HEAD
        public int XMin
=======
        public double Xmin
>>>>>>> bbf9611bd8ac367d2642a2bb7ae5c41b3fac2b64
        {
            get { return xmin; }
            set { xmin = value; }
        }
<<<<<<< HEAD

        public int IncX
=======
    
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
        
        public double Incx
>>>>>>> bbf9611bd8ac367d2642a2bb7ae5c41b3fac2b64
        {
            get { return incx; }
            set { incx = value; }
        }
<<<<<<< HEAD

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
=======
    
        public double Inczy
>>>>>>> bbf9611bd8ac367d2642a2bb7ae5c41b3fac2b64
        {
            get { return inczy; }
            set { inczy = value; }
        }

<<<<<<< HEAD
        public double IncRX
=======
        public double Incrx
>>>>>>> bbf9611bd8ac367d2642a2bb7ae5c41b3fac2b64
        {
            get { return incrx; }
            set { incrx = value; }
        }

<<<<<<< HEAD
        public double IncGY
=======
        public double Incgy
>>>>>>> bbf9611bd8ac367d2642a2bb7ae5c41b3fac2b64
        {
            get { return incgy; }
            set { incgy = value; }
        }

<<<<<<< HEAD
        public double IncBZ
=======
        public double Incbz
>>>>>>> bbf9611bd8ac367d2642a2bb7ae5c41b3fac2b64
        {
            get { return incbz; }
            set { incbz = value; }
        }
    }
}