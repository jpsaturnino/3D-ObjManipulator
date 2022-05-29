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

        private void Load3DObject(string )
    }
}
