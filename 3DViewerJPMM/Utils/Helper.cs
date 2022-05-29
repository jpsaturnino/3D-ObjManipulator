namespace _3DViewerJPMM.Utils
{
    public static class Helper
    {
        static public double[,] Identity(int dim)
        {
            double[,] matrix = new double[dim, dim];
            for (int i = 0; i < dim; i++)
                matrix[i, i] = 1;
            return matrix;
        }
    }
}
