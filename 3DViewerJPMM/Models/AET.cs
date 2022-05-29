using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DViewerJPMM.Models
{
    internal class AET
    {
        private List<NodeAET> _list;

        public AET()
        {
            _list = new List<NodeAET>();

        }

        public void add(NodeAET info)
        {
            _list.Add(info);
        }

        public List<NodeAET> _list
        {
            get { return _list; }
            set { _list = value;}
        }

        public void add(NodeAET AETList)
        {
            foreach (NodeAET node in AETList)
                _list.Add(node);
        }

        public void sort()
        {
            if (_list.Count())
            {
                Stack<int> stack = new Stack<int>();
                NodeAET auxNode;
                int init = 0, end = _list.Count() - 1, index, limit, middle;
                double pivotX;



            }
        }



    }
}