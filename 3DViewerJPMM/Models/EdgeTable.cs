namespace _3DViewerJPMM.Models
{
    internal class EdgeTable
    {
        private _AET[] edgeTable;
        private int maxsize, amount;
        
        public EdgeTable(int maxsize)
        {
            this.maxsize = maxsize;
            amount = 0;
            edgeTable = new _AET[this.maxsize];
        }

        public _AET? AET(int position)
        {
            if (position >= maxsize)
                return null;
            return edgeTable[position];
        }
        
        public void Initialize(int position)
        {
            edgeTable[position] = new _AET();
            amount++;
        }

        public void AddNode(int position, NodeAET n)
        {
            if (edgeTable[position] == null)
                Initialize(position);
            edgeTable[position].Insert(n);
        }

        public int _MAXSIZE { get => maxsize; set => maxsize = value; }

        public int AMOUNT { get => amount; set => amount = value; }
    }
}