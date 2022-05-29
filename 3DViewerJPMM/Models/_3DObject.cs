using static _3DViewerJPMM.Utils.Helper;

namespace _3DViewerJPMM.Models
{
    internal class _3DObject
    {
        private List<int[]> faces, currentFacesVertex;
        private List<Vertex> currentVertices, mainVertices, indexFaces, indexVertices;
        private Vertex middle;
        private double[,] MA;
        private double mx, ma, mz, lx, ly, lz;
        
        public _3DObject() {
            this.middle = new Vertex(0, 0, 0);
            this.faces = new List<int[]>();
            this.currentVertices = this.mainVertices = this.indexFaces = this.indexVertices = new List<Vertex>();
            this.MA = Identity(4);
        }

        private void Load3DObject(string filepath)
        {
            string[] lines = System.IO.File.ReadAllLines(filepath);
            int i = 0;
            foreach (string line in lines)
            {
                if (line.StartsWith("v "))
                {
                    string[] values = line.Split(' ');
                    this.mainVertices.Add(new Vertex(double.Parse(values[1]), double.Parse(values[2]), double.Parse(values[3])));
                    this.currentVertices.Add(new Vertex(double.Parse(values[1]), double.Parse(values[2]), double.Parse(values[3])));
                }
                else if (line.StartsWith("f "))
                {
                    string[] values = line.Split(' ');
                    this.faces.Add(new int[] { int.Parse(values[1]) - 1, int.Parse(values[2]) - 1, int.Parse(values[3]) - 1 });
                }
                i++;
            }
        }
    }
}
