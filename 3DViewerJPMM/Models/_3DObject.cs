using System.Diagnostics;

using static _3DViewerJPMM.Utils.Helper;
using static _3DViewerJPMM.Utils.Transformations;

namespace _3DViewerJPMM.Models
{
    internal class _3DObject
    {
        private List<List<int>> faces, facesVertices;
        private List<Vertex> mainVertices, currentVertices;
        private Vertex[] normalFaces, normalVertices;
        private double[,] MA;
        private double mx, my, mz, lx, ly, lz;

        private _3DObject() => Initialize();

        public _3DObject(string filename)
        {
            Initialize();
            Load3DObject(filename);
        }
        
        private void Initialize()
        {
            faces = new List<List<int>>();
            facesVertices = new List<List<int>>();
            currentVertices = new List<Vertex>();
            mainVertices = new List<Vertex>();
            normalFaces = normalVertices = null;
            MA = IdentityMatrix(4);
            MaxX = MaxY = MaxZ = MinX = MinY = MinZ = 0;
        }

        public _3DObject Copy()
        {
            _3DObject o = new _3DObject();
            o.mainVertices = mainVertices;
            o.faces = faces;
            o.facesVertices = facesVertices;
            o.normalFaces = normalFaces;
            o.normalFaces = (Vertex[])normalFaces.Clone();
            o.MA = CopyMatrix(MA);
            return o;
        }

        public void Load3DObject(string file)
        {
            Debug.WriteLine("Loading 3D object...");
            string[] lines = File.ReadAllLines(file);
            double x, y, z;

            foreach (string line in lines)
            {
                string[] values = line.Split(' ');

                if (line.StartsWith("v "))
                {
                    x = double.Parse(values[1].Replace('.', ','));
                    y = double.Parse(values[2].Replace('.', ','));
                    z = double.Parse(values[3].Replace('.', ','));

                    if (x > MaxX) MaxX = x;
                    else if (x < MinX) MinX = x;

                    if (y > MaxY) MaxY = y;
                    else if (y < MinY) MinY = y;

                    if (z > MaxZ) MaxZ = z;
                    else if (z < MinZ) MinZ = z;

                    mainVertices.Add(new Vertex(x, y, z));
                    currentVertices.Add(new Vertex(x, y, z));
                    facesVertices.Add(new List<int>());
                }
                else if (line.StartsWith("f "))
                {

                    List<int> face = new List<int>();
                    for (int j = 1; j < values.Length; j++)
                    {
                        string[] v = values[j].Split('/');
                        int index = int.Parse(v[0]) - 1;
                        face.Add(index);
                        facesVertices[index].Add(faces.Count);
                    }
                    faces.Add(face);
                }
            }
            UpdateNormalFaces();
            Debug.WriteLine("3D object loaded!");
        }

        public List<Vertex> CurrentVertices
        {
            get { return currentVertices; }
            set { currentVertices = value; }
        }

        public List<List<int>> Faces
        {
            get { return faces; }
            set { faces = value; }
        }

        public void RotationX(double angle, bool showHiddenFaces)
        {
            MA = RotateX(angle, MA);
            UpdateVertices();
            if (!showHiddenFaces)
                UpdateNormalFaces();
        }

        public void RotationY(double angle, bool showHiddenFaces)
        {
            MA = RotateY(angle, MA);
            UpdateVertices();
            if (!showHiddenFaces)
                UpdateNormalFaces();
        }

        public void RotationZ(double angle, bool showHiddenFaces)
        {
            MA = RotateZ(angle, MA);
            UpdateVertices();
            if (!showHiddenFaces)
                UpdateNormalFaces();
        }

        public void Translation(int tx, int ty, int tz)
        {
            MA = Translate(tx, ty, tz, MA);
            UpdateVertices();
        }

        public void Scaling(double sx, double sy, double sz)
        {
            MA = Scale(sx, sy, sz, MA);
            UpdateVertices();
        }

        public void UpdateNormalFaces()
        {
            Vertex a, b, n, vn;
            normalFaces = new Vertex[faces.Count];
            normalVertices = new Vertex[mainVertices.Count];
            for (int i = 0; i < faces.Count; ++i)
            {
                a = currentVertices[faces[i][0]];
                b = currentVertices[faces[i][1]];
                n = currentVertices[faces[i][faces[i].Count - 1]];
                Vertex ab = b.Decrement(a);
                Vertex an = n.Decrement(a);
                vn = ab.CrossProduct(an);
                normalFaces[i] = vn.Normalize();
            }
        }

        public void UpdateNormalVertices()
        {
            for (int i = 0; i < normalVertices.Length; i++)
            {
                List<Vertex> normals = new List<Vertex>();
                for (int j = 0; j < facesVertices[i].Count; j++)
                    normals.Add(normalFaces[j]);
                normalVertices[i] = AvgNormalVertices(normals);
            }
        }

        private Vertex AvgNormalVertices(List<Vertex> normais)
        {
            double x, y, z, d = normais.Count;
            x = y = z = 0;
            foreach (Vertex v in normais)
            {
                x += v.X;
                y += v.Y;
                z += v.Z;
            }
            return new Vertex(x / d, y / d, z / d);
        }

        private void UpdateVertices()
        {
            double[,] matrix;
            currentVertices = new List<Vertex>();
            for (int i = 0; i < mainVertices.Count; i++)
            {
                matrix = Multiply(MA, mainVertices[i].ToMatrix());
                currentVertices.Add(new Vertex(matrix[0, 0], matrix[1, 0], matrix[2, 0]));
            }
        }
        
        internal EdgeTable CreatePhongET(int f, int height, int tx, int ty, Vertex Luz, Vertex eye, int n, Vertex c)
        {
            EdgeTable et = new EdgeTable(height + 1);
            double xmax, ymax, zmax, xmin, ymin, zmin, dx, dy, dz, rl, rm, gl, gm, bl, bm;
            double incx, incz, incrx, incgy, incbz;
            int y;
            List<int> face = faces[f];
            for (int i = 0; i + 1 < face.Count; ++i)
            { 
                if (currentVertices[face[i]].Y >= currentVertices[face[i + 1]].Y)
                {
                    xmax = currentVertices[face[i]].X;
                    ymax = currentVertices[face[i]].Y;
                    zmax = currentVertices[face[i]].Z;
                    rm = normalVertices[face[i]].X;
                    gm = normalVertices[face[i]].Y;
                    bm = normalVertices[face[i]].Z;
                    xmin = currentVertices[face[i + 1]].X;
                    ymin = currentVertices[face[i + 1]].Y;
                    zmin = currentVertices[face[i + 1]].Z;
                    rl = normalVertices[face[i + 1]].X;
                    gl = normalVertices[face[i + 1]].Y;
                    bl = normalVertices[face[i + 1]].Z;
                }
                else
                {
                    xmin = currentVertices[face[i]].X;
                    ymin = currentVertices[face[i]].Y;
                    zmin = currentVertices[face[i]].Z;
                    rl = normalVertices[face[i]].X;
                    gl = normalVertices[face[i]].Y;
                    bl = normalVertices[face[i]].Z;
                    xmax = currentVertices[face[i + 1]].X;
                    ymax = currentVertices[face[i + 1]].Y;
                    zmax = currentVertices[face[i + 1]].Z;
                    rm = normalVertices[face[i + 1]].X;
                    gm = normalVertices[face[i + 1]].Y;
                    bm = normalVertices[face[i + 1]].Z;
                }
                dx = xmax - xmin;
                dy = ymax - ymin;
                dz = zmax - zmin;

                incx = (dy != 0) ? dx / dy : 0;
                incz = dy != 0 ? dz / dy : 0;
                incrx = (rm - rl) / dy;
                incgy = (gm - gl) / dy;
                incbz = (bm - bl) / dy;

                y = (int)ymin + ty;
                if (y < 0) y = 0;
                else if (y >= height) y = height - 1;
                if (et.AET(y) == null)
                    et.Initialize(y);
                et.AET(y).Insert(new NodeAET((int)ymax + ty, xmin + tx, incx, zmin, incz,
                    rl, gl, bl, incrx, incgy, incbz));
            }
            
            if (currentVertices[face[0]].Y >= currentVertices[face[face.Count - 1]].Y)
            {
                xmax = currentVertices[face[0]].X;
                ymax = currentVertices[face[0]].Y;
                zmax = currentVertices[face[0]].Z;
                rm = normalVertices[face[0]].X;
                gm = normalVertices[face[0]].Y;
                bm = normalVertices[face[0]].Z;
                xmin = currentVertices[face[face.Count - 1]].X;
                ymin = currentVertices[face[face.Count - 1]].Y;
                zmin = currentVertices[face[face.Count - 1]].Z;
                rl = normalVertices[face[face.Count - 1]].X;
                gl = normalVertices[face[face.Count - 1]].Y;
                bl = normalVertices[face[face.Count - 1]].Z;
            }
            else
            {
                xmin = currentVertices[face[0]].X;
                ymin = currentVertices[face[0]].Y;
                zmin = currentVertices[face[0]].Z;
                rl = normalVertices[face[0]].X;
                gl = normalVertices[face[0]].Y;
                bl = normalVertices[face[0]].Z;
                xmax = currentVertices[face[face.Count - 1]].X;
                ymax = currentVertices[face[face.Count - 1]].Y;
                zmax = currentVertices[face[face.Count - 1]].Z;
                rm = normalVertices[face[face.Count - 1]].X;
                gm = normalVertices[face[face.Count - 1]].Y;
                bm = normalVertices[face[face.Count - 1]].Z;
            }
            dx = xmax - xmin;
            dy = ymax - ymin;
            dz = zmax - zmin;

            incx = (dy != 0) ? dx / dy : 0;
            incz = dy != 0 ? dz / dy : 0;
            incrx = (rm - rl) / dy;
            incgy = (gm - gl) / dy;
            incbz = (bm - bl) / dy;

            y = (int)ymin + ty;
            if (y < 0) y = 0;
            else if (y >= height) y = height - 1;
            if (et.AET(y) == null)
                et.Initialize(y);
            et.AET(y).Insert(new NodeAET((int)ymax + ty, xmin + tx, incx, zmin, incz,
                rl, gl, bl, incrx, incgy, incbz));
            return et;
        }
        
        public EdgeTable CreateGouraudET(int f, int height, int tx, int ty, Vertex Luz, Vertex Eye, int n,
            Vertex c)
        {
            Vertex cl, cm;
            EdgeTable et = new EdgeTable(height + 1);
            double xmax, ymax, zmax, xmin, ymin, zmin, dx, dy, dz;
            double incx, incz, incrx, incgy, incbz;
            int y;
            List<int> face = faces[f];
            for (int i = 0; i + 1 < face.Count; ++i)
            { 
                if (currentVertices[face[i]].Y >= currentVertices[face[i + 1]].Y)
                {
                    xmax = currentVertices[face[i]].X;
                    ymax = currentVertices[face[i]].Y;
                    zmax = currentVertices[face[i]].Z;
                    cm = Draw.PhongShading(Luz, Eye, normalVertices[face[i]], n, c);
                    xmin = currentVertices[face[i + 1]].X;
                    ymin = currentVertices[face[i + 1]].Y;
                    zmin = currentVertices[face[i + 1]].Z;
                    cl = Draw.PhongShading(Luz, Eye, normalVertices[face[i + 1]], n, c);
                }
                else
                {
                    xmin = currentVertices[face[i]].X;
                    ymin = currentVertices[face[i]].Y;
                    zmin = currentVertices[face[i]].Z;
                    cl = Draw.PhongShading(Luz, Eye, normalVertices[face[i]], n, c);
                    xmax = currentVertices[face[i + 1]].X;
                    ymax = currentVertices[face[i + 1]].Y;
                    zmax = currentVertices[face[i + 1]].Z;
                    cm = Draw.PhongShading(Luz, Eye, normalVertices[face[i + 1]], n, c);
                }
                dx = xmax - xmin;
                dy = ymax - ymin;
                dz = zmax - zmin;

                incx = (dy != 0) ? dx / dy : 0;
                incz = dy != 0 ? dz / dy : 0;
                incrx = (cm.X - cl.X) / dy;
                incgy = (cm.Y - cl.Y) / dy;
                incbz = (cm.Z - cl.Z) / dy;

                y = (int)ymin + ty;
                if (y < 0) y = 0;
                else if (y >= height) y = height - 1;
                if (et.AET(y) == null)
                    et.Initialize(y);
                et.AET(y).Insert(new NodeAET((int)ymax + ty, xmin + tx, incx, zmin, incz,
                    cl.X, cl.Y, cl.Z, incrx, incgy, incbz));
            }
            
            if (currentVertices[face[0]].Y >= currentVertices[face[face.Count - 1]].Y)
            {
                xmax = currentVertices[face[0]].X;
                ymax = currentVertices[face[0]].Y;
                zmax = currentVertices[face[0]].Z;
                cm = Draw.PhongShading(Luz, Eye, normalVertices[face[0]], n, c);
                xmin = currentVertices[face[face.Count - 1]].X;
                ymin = currentVertices[face[face.Count - 1]].Y;
                zmin = currentVertices[face[face.Count - 1]].Z;
                cl = Draw.PhongShading(Luz, Eye, normalVertices[face[face.Count - 1]], n, c);
            }
            else
            {
                xmin = currentVertices[face[0]].X;
                ymin = currentVertices[face[0]].Y;
                zmin = currentVertices[face[0]].Z;
                cl = Draw.PhongShading(Luz, Eye, normalVertices[face[0]], n, c);
                xmax = currentVertices[face[face.Count - 1]].X;
                ymax = currentVertices[face[face.Count - 1]].Y;
                zmax = currentVertices[face[face.Count - 1]].Z;
                cm = Draw.PhongShading(Luz, Eye, normalVertices[face[face.Count - 1]], n, c);
            }
            dx = xmax - xmin;
            dy = ymax - ymin;
            dz = zmax - zmin;

            incx = (dy != 0) ? dx / dy : 0;
            incz = dy != 0 ? dz / dy : 0;
            incrx = (cm.X - cl.X) / dy;
            incgy = (cm.Y - cl.Y) / dy;
            incbz = (cm.Z - cl.Z) / dy;

            y = (int)ymin + ty;
            if (y < 0) y = 0;
            else if (y >= height) y = height - 1;
            if (et.AET(y) == null)
                et.Initialize(y);
            et.AET(y).Insert(new NodeAET((int)ymax + ty, xmin + tx, incx, zmin, incz,
                cl.X, cl.Y, cl.Z, incrx, incgy, incbz));
            return et;
        }

        public EdgeTable CreateFlatET(int f, int height, int tx, int ty, Vertex Luz, Vertex Eye, int n,
            Vertex c)
        {
            Vertex cor;
            EdgeTable et = new EdgeTable(height + 1);
            double xmax, ymax, zmax, xmin, ymin, zmin, dx, dy, dz;
            double incx, incz;
            int y;
            List<int> face = faces[f];
            cor = Draw.PhongShading(Luz, Eye, normalFaces[f], n, c);
            for (int i = 0; i+1 < face.Count; ++i)
            { 
                if (currentVertices[face[i]].Y >= currentVertices[face[i + 1]].Y)
                {
                    xmax = currentVertices[face[i]].X;
                    ymax = currentVertices[face[i]].Y;
                    zmax = currentVertices[face[i]].Z;
                    xmin = currentVertices[face[i + 1]].X;
                    ymin = currentVertices[face[i + 1]].Y;
                    zmin = currentVertices[face[i + 1]].Z;
                }
                else
                {
                    xmin = currentVertices[face[i]].X;
                    ymin = currentVertices[face[i]].Y;
                    zmin = currentVertices[face[i]].Z;
                    xmax = currentVertices[face[i + 1]].X;
                    ymax = currentVertices[face[i + 1]].Y;
                    zmax = currentVertices[face[i + 1]].Z;
                }
                dx = xmax - xmin;
                dy = ymax - ymin;
                dz = zmax - zmin;

                incx = (dy != 0) ? dx / dy : 0;
                incz = dy != 0 ? dz / dy : 0;

                y = (int)ymin + ty;
                if (y < 0) y = 0;
                else if (y >= height) y = height - 1;
                if (et.AET(y) == null)
                    et.Initialize(y);
                et.AET(y).Insert(new NodeAET((int)ymax + ty, xmin + tx, incx, zmin, incz,
                    cor.X, cor.Y, cor.Z, 0, 0, 0));
            }
            if (currentVertices[face[0]].Y >= currentVertices[face[face.Count - 1]].Y)
            {
                xmax = currentVertices[face[0]].X;
                ymax = currentVertices[face[0]].Y;
                zmax = currentVertices[face[0]].Z;
                xmin = currentVertices[face[face.Count - 1]].X;
                ymin = currentVertices[face[face.Count - 1]].Y;
                zmin = currentVertices[face[face.Count - 1]].Z;
            } else
            {
                xmin = currentVertices[face[0]].X;
                ymin = currentVertices[face[0]].Y;
                zmin = currentVertices[face[0]].Z;
                xmax = currentVertices[face[face.Count - 1]].X;
                ymax = currentVertices[face[face.Count - 1]].Y;
                zmax = currentVertices[face[face.Count - 1]].Z;
            }

            dx = xmax - xmin;
            dy = ymax - ymin;
            dz = zmax - zmin;

            incx = (dy != 0) ? dx / dy : 0;
            incz = dy != 0 ? dz / dy : 0;

            y = (int)ymin + ty;
            if (y < 0) y = 0;
            else if (y >= height) y = height - 1;
            if (et.AET(y) == null)
                et.Initialize(y);
            et.AET(y).Insert(new NodeAET((int)ymax + ty, xmin + tx, incx, zmin, incz,
                cor.X, cor.Y, cor.Z, 0, 0, 0));

            return et;
        }

        public Vertex NormalFaceAt(int id) => normalFaces[id];

        public double MaxX
        {
            get { return (int)Math.Round(mx); }
            set { mx = value; }
        }

        public double MinX
        {
            get { return (int)Math.Round(lx); }
            set { lx = value; }
        }

        private double MaxY
        {
            get { return (int)Math.Round(my); }
            set { my = value; }
        }

        private double MinY
        {
            get { return (int)Math.Round(ly); }
            set { ly = value; }
        }

        private double MaxZ
        {
            get { return (int)Math.Round(mz); }
            set { mz = value; }
        }

        private double MinZ
        {
            get { return (int)Math.Round(lz); }
            set { lz = value; }
        }
    }
}
