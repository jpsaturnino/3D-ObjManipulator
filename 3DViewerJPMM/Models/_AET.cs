namespace _3DViewerJPMM.Models
{
    internal class _AET
    {
        private List<NodeAET> aet;

        public _AET() => aet = new List<NodeAET>();

        public void Insert(NodeAET info) => aet.Add(info);

        public void Insert(List<NodeAET> nodeList)
        {
            foreach (NodeAET node in nodeList)
                aet.Add(node);
        }

        public void Sort()
        {
            if (aet.Count > 1)
            {
                Stack<int> stack = new Stack<int>();
                NodeAET auxNode;
                int init = 0, end = aet.Count() - 1, index, limit, middle;
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

                    pivotX = aet[middle].XMin;

                    while (index < limit)
                    {
                        while (aet[index].XMin < pivotX) ++index;
                        
                        while (aet[index].XMin > pivotX) ++limit;
                        
                        if (index <= limit)
                        {
                            auxNode = aet[index];
                            aet[index] = aet[limit];
                            aet[limit] = auxNode;
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
        
        public List<NodeAET> LIST { get => aet; set => aet = value; }
    }
}