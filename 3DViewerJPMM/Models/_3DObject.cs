using System.Diagnostics;

using static _3DViewerJPMM.Utils.Helper;
using static _3DViewerJPMM.Utils.Transformations;

namespace _3DViewerJPMM.Models
{
    internal class _3DObject
    {
        private List<List<int>> faces, currentFacesVertex;
        private List<Vertex> currentVertices, mainVertices;
        private Vertex[] normalFaces, normalVertices;
        private double[,] MA;
        private double maxX, maxY, maxZ, minX, minY, minZ;

        public _3DObject(string file)
        {
            faces = new List<List<int>>();
            currentFacesVertex = new List<List<int>>();
            currentVertices = new List<Vertex>();
            mainVertices = new List<Vertex>();
            normalFaces = normalVertices = null;
            MA = Identity(4);
            maxX = maxY = maxZ = minX = minY = minZ = 0;
            Load3DObject(file);
        }
        
        public _3DObject()
        {
            faces = new List<List<int>>();
            currentFacesVertex = new List<List<int>>();
            currentVertices = new List<Vertex>();
            mainVertices = new List<Vertex>();
            normalFaces = normalVertices = null;
            MA = Identity(4);
            maxX = maxY = maxZ = minX = minY = minZ = 0;
        }

        public _3DObject Copy()
        {
            _3DObject o = new _3DObject();
            o.mainVertices = mainVertices;
            o.faces = faces;
            o.currentFacesVertex = currentFacesVertex ;
            o.normalFaces = normalFaces;
            o.normalFaces = (Vertex[])normalFaces.Clone();
            o.MA = cloneMat(MA);
            return o;
        }

        public double[,] cloneMat(double[,] mat)
        {
            double[,] nova = new double[mat.GetLength(0), mat.GetLength(1)];
            for (int i = 0; i < mat.GetLength(0); ++i)
                for (int j = 0; j < mat.GetLength(1); ++j)
                    nova[i, j] = mat[i, j];
            return nova;
        }

        private void Load3DObject(string file)
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

                    if (x > maxX) maxX = x;
                    else if (x < minX) minX = x;

                    if (y > maxY) maxY = y;
                    else if (y < minY) minY = y;

                    if (z > maxZ) maxZ = z;
                    else if (z < minZ) minZ = z;

                    mainVertices.Add(new Vertex(x, y, z));
                    currentVertices.Add(new Vertex(x, y, z));
                    currentFacesVertex.Add(new List<int>());
                }
                else if (line.StartsWith("f "))
                {

                    List<int> face = new List<int>();
                    for (int j = 1; j < values.Length; j++)
                    {
                        string[] v = values[j].Split('/');
                        int index = int.Parse(v[0]) - 1;
                        face.Add(index);
                        currentFacesVertex[index].Add(faces.Count);
                    }
                    faces.Add(face);
                }
            }
            UpdateNormalFaces();
            Debug.WriteLine("3D object loaded!");
        }

        private void UpdateVertices()
        {
            double[,] matrix;
            currentVertices.Clear();
            for (int i = 0; i < mainVertices.Count; i++)
            {
                matrix = Multiply(MA, mainVertices[i].ToMatrix());
                currentVertices.Add(new Vertex(matrix[0, 0], matrix[1, 0], matrix[2, 0]));
            }
        }

        public void Scaling(double sx, double sy, double sz)
        {
            MA = Scale(sx, sy, sz, MA);
            UpdateVertices();
        }

        public void Translation(double x, double y, double z)
        {
            MA = Translate(x, y, z, MA);
            UpdateVertices();
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

        public void UpdateNormalFaces() /* da pra refatorar */
        {
            normalFaces = new Vertex[faces.Count];
            normalVertices = new Vertex[mainVertices.Count];

            for (int i = 0; i < faces.Count; i++)
            {
                Vertex a, b, c;
                a = currentVertices[faces[i][0]];
                b = currentVertices[faces[i][1]];
                c = currentVertices[faces[i][2]];
                Vertex ab = b.Decrement(a);
                Vertex ac = c.Decrement(a);
                normalFaces[i] = ab.CrossProduct(ac);
                normalFaces[i].Normalize();
            }
        }

        private void UpdateNormalVertices() /* refatorada, se der merda refaz */
        {
            for (int i = 0; i < normalVertices.Length; i++)
            {
                normalVertices[i] = new Vertex(0, 0, 0);
                for (int j = 0; j < currentFacesVertex[i].Count; j++)
                {
                    normalVertices[i] = normalVertices[i].Increment(normalFaces[currentFacesVertex[i][j]]);
                }
                normalVertices[i].Normalize();
            }
        }

        public EdgeTable CreateFlatET(int f, int height, int tx, int ty, Vertex Luz, Vertex Eye, int n,
            Vertex ia, Vertex id, Vertex ie, Vertex ka, Vertex kd, Vertex ke)
        {
            Vertex cor;
            EdgeTable et = new EdgeTable(height + 1);
            List<int> face = faces[f];
            double xmax, ymax, zmax, xmin, ymin, zmin, dx, dy, dz, incx, incz;
            int y;
            cor = Draw.PhongShading(Luz, Eye, normalFaces[f], n, ia, id, ie, ka, kd, ke);
            for (int i = 0; i + 1 < face.Count; ++i)
            { // do primeiro ponto até o ultimo
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
                
                if (et.AET(y) == null) et.Initialize(y);
                
                et.AET(y).Insert(new NodeAET(ymax + ty, xmin + tx, incx, zmin, incz, cor.X, cor.Y, cor.Z, 0, 0, 0));
            }
            
            // ultimo com o primeiro
            if (currentVertices[face[0]].Y >= currentVertices[face[face.Count - 1]].Y)
            {
                xmax = currentVertices[face[0]].X;
                ymax = currentVertices[face[0]].Y;
                zmax = currentVertices[face[0]].Z;
                xmin = currentVertices[face[face.Count - 1]].X;
                ymin = currentVertices[face[face.Count - 1]].Y;
                zmin = currentVertices[face[face.Count - 1]].Z;
            }
            else
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
            et.AET(y).Insert(new NodeAET(ymax + ty, xmin + tx, incx, zmin, incz, cor.X, cor.Y, cor.Z, 0, 0, 0));
            return et;
        }
        
        public double MAX_X { get => (int)Math.Round(maxX); set => maxX = value; }

        public double MAX_Y { get => (int)Math.Round(maxY); set => maxY = value; }

        public double MAX_Z { get => (int)Math.Round(maxZ); set => maxZ = value; }

        public double MIN_X { get => (int)Math.Round(minX); set => minX = value; }

        public double MIN_Y { get => (int)Math.Round(minY); set => minY = value; }

        public double MIN_Z { get => (int)Math.Round(minZ); set => minZ = value; }

        public Vertex[] NormalFaces { get => normalFaces; set => normalFaces = value; }

        public Vertex NormalFaceAt(int index) { return normalFaces[index]; }

        public Vertex[] NormalVertices { get => normalVertices; set => normalVertices = value; }

        public List<List<int>> Faces { get => faces; set => faces = value; }

        public List<Vertex> CurrentVertices { get => currentVertices; set => currentVertices = value; }

        public List<Vertex> MainVertices { get => mainVertices; set => mainVertices = value; }

        public List<List<int>> CurrentFacesVertex { get => currentFacesVertex; set => currentFacesVertex = value; }

    }
}
