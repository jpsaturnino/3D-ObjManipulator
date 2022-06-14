namespace _3DViewerJPMM.Models
{
    internal class _AET
    {
        private List<NodeAET> aet;

        public _AET() => aet = new List<NodeAET>();

        public void Insert(NodeAET info) => aet.Add(info);
        
        public List<NodeAET> LIST => aet;

        public void Insert(List<NodeAET> L)
        {
            foreach (NodeAET n in L)
                aet.Add(n);
        }

        public void Sort()
        {
            if (aet.Count > 1)
            {
                Stack<int> pilha = new Stack<int>();
                int inicio = 0, fim = aet.Count - 1, i, j, meio;
                NodeAET aux;
                double pivoX;
                pilha.Push(inicio);
                pilha.Push(fim);
                while (pilha.Count > 0)
                {
                    fim = pilha.Pop();
                    inicio = pilha.Pop();
                    i = inicio;
                    j = fim;
                    meio = (i + j) / 2;
                    pivoX = aet[meio].XMin;
                    while (i < j)
                    {
                        while (aet[i].XMin < pivoX)
                            ++i;
                        while (aet[j].XMin > pivoX)
                            --j;
                        if (i <= j)
                        {
                            aux = aet[i];
                            aet[i] = aet[j];
                            aet[j] = aux;
                            ++i;
                            --j;
                        }
                    }
                    if (inicio < j)
                    {
                        pilha.Push(inicio);
                        pilha.Push(j);
                    }
                    if (i < fim)
                    {
                        pilha.Push(i);
                        pilha.Push(fim);
                    }
                }

            }
        }
    }
}