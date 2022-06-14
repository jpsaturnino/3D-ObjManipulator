namespace _3DViewerJPMM.Models
{
    internal class EdgeTable
    {
        private _AET[] et;
        private int TF;
        public EdgeTable(int tf)
        {
            TF = tf;
            et = new _AET[TF];
        }
        
        public _AET AET(int pos)
        {
            if (pos >= TF)
                return null;
            return et[pos];
        }

        public int MAXSIZE { get => TF; set => TF = value; }

        public void Initialize(int pos) => et[pos] = new _AET();
        
    }
}