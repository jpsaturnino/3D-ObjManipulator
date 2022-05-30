namespace _3DViewerJPMM.Models
{
    internal class EdgeTable
    {
        private ActiveEdgeTable[] edgeTable;
        private int maxsize, amount;
        
        public EdgeTable(int maxsize)
        {
            this.maxsize = maxsize;
            amount = 0;
            edgeTable = new ActiveEdgeTable[this.maxsize];
        }

        public int _MAXSIZE { get => maxsize; set => maxsize = value; }
        
        public int AMOUNT { get => amount; set => amount = value; }

        public ActiveEdgeTable? GetAET(int position)
        {
            if (position >= maxsize)
                return null;
            return edgeTable[position];
        }
        
        public void Initialize(int position)
        {
            edgeTable[position] = new ActiveEdgeTable();
            amount++;
        }

        public void AddNode(int position, NodeAET n)
        {
            if (edgeTable[position] == null)
                Initialize(position);
            edgeTable[position].insert(n);
        }
    }
}