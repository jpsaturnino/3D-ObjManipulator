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
            faces = currentFacesVertex = new List<List<int>>();
            currentVertices = mainVertices = new List<Vertex>();
            normalFaces = normalVertices = null;
            MA = Identity(4);
            maxX = maxY = maxZ = minX = minY = minZ = 0;
            Load3DObject(file);
        }

        private void Load3DObject(string file)
        {
            Debug.WriteLine("Loading 3D object...");
            string[] lines = System.IO.File.ReadAllLines(file);
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
                    Debug.WriteLine("Adding face: " + face[0] + " " + face[1] + " " + face[2]);
                    faces.Add(face);
                }
            }
            UpdateNormalVertices();
            Debug.WriteLine("3D object loaded!");
        }

        private void UpdateVertices()
        {
            double[,] matrix;
            for (int i = 0; i < mainVertices.Count; i++)
            {
                matrix = Multiply(MA, mainVertices[i].ToMatrix());
                currentVertices.Add(new Vertex(matrix[0,0], matrix[1, 0], matrix[2, 0]));
            }
        }
        
        internal 
        
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
        
        public void RotationX(double angle, bool hiddenFaces)
        {
            MA = RotateX(angle, MA);
            UpdateVertices();
            if (!hiddenFaces)
                UpdateNormalFaces();
        }
        
        public void RotationY(double angle, bool hiddenFaces)
        {
            MA = RotateY(angle, MA);
            UpdateVertices();
            if (!hiddenFaces)
                UpdateNormalFaces();
        }
        
        public void RotationZ(double angle, bool hiddenFaces)
        {
            MA = RotateZ(angle, MA);
            UpdateVertices();
            if (!hiddenFaces)
                UpdateNormalFaces();
        }
        
        private void UpdateNormalFaces() /* da pra refatorar */
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
            for(int i = 0; i < normalVertices.Length; i++)
            {
                normalVertices[i] = new Vertex(0, 0, 0);
                for (int j = 0; j < currentFacesVertex[i].Count; j++)
                {
                    normalVertices[i] = normalVertices[i].Increment(normalFaces[currentFacesVertex[i][j]]);
                }
                normalVertices[i].Normalize();
            }
        }

        public double MAX_X { get => (int)Math.Round(maxX); set => maxX = value; }

        public double MAX_Y { get => (int)Math.Round(maxY); set => maxY = value; }

        public double MAX_Z { get => (int)Math.Round(maxZ); set => maxZ = value; }

        public double MIN_X { get => (int)Math.Round(minX); set => minX = value; }

        public double MIN_Y { get => (int)Math.Round(minY); set => minY = value; }

        public double MIN_Z { get => (int)Math.Round(minZ); set => minZ = value; }
    }
}
