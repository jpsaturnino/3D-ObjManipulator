using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DViewerJPMM.Models
{
    internal class ActiveEdgeTable
    {
        private List<NodeAET> _list;

        public ActiveEdgeTable()
        {
            _list = new List<NodeAET>();

        }

        public void insert(NodeAET info)
        {
            _list.Add(info);
        }

        public List<NodeAET> LIST { get => _list; set => _list = value; }

        public void insert(List<NodeAET> nodeList)
        {
            foreach (NodeAET node in nodeList)
                this._list.Add(node);
        }


        public void sort()
        {
            if (_list.Count > 1)
            {
                Stack<int> stack = new Stack<int>();
                NodeAET auxNode;
                int init = 0, end = _list.Count() - 1, index, limit, middle;
                double pivotX;

                stack.Push(init);
                stack.Push(end);
                while(stack.Count > 0)
                {
                    init = stack.Pop();
                    end = stack.Pop();

                    index = init;
                    limit = end;
                    middle = (init + limit) / 2;

                    pivotX = this._list[middle].XMin;

                    while (index < limit)
                    {
                        while (this._list[index].XMin < pivotX)
                        {
                            ++index;
                        }
                        while (this._list[index].XMin > pivotX)
                        {
                            ++limit;
                        }

                        if (index <= limit)
                        {
                            auxNode = this._list[index];
                            this._list[index] = this._list[limit];
                            this._list[limit] = auxNode;
                            ++index;
                            --limit;
                        }

                    }
                    if (init < limit)
                    {
                        stack.Push(init);
                        stack.Push(limit);
                    }
                    if (index < end)
                    {
                        stack.Push(index);
                        stack.Push(end);
                    }

                }
            }
        }
    }
}