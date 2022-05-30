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

        static public double[,] Multiply(double[,] a, double[,] b)
        {
            int aRows = a.GetLength(0);
            int aCols = a.GetLength(1);
            int bRows = b.GetLength(0);
            int bCols = b.GetLength(1);
            if (aCols != bRows)
                throw new Exception("Non-conformable matrices");
            
            double[,] result = new double[aRows, bCols];
            for (int i = 0; i < aRows; ++i)
                for (int j = 0; j < bCols; ++j)
                    for (int k = 0; k < aCols; ++k)
                        result[i, j] += a[i, k] * b[k, j];
            return result;
        }

        static public double[,] Transpose(double[,] a)
        {
            int aRows = a.GetLength(0);
            int aCols = a.GetLength(1);
            double[,] result = new double[aCols, aRows];
            for (int i = 0; i < aRows; ++i)
                for (int j = 0; j < aCols; ++j)
                    result[j, i] = a[i, j];
            return result;
        }
        
    }
}
