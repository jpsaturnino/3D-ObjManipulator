namespace _3DViewerJPMM.Utils
{
    public static class Helper
    {
        static public double[,] IdentityMatrix(int dim)
        {
            double[,] matrix = new double[dim, dim];
            for (int i = 0; i < dim; i++)
                matrix[i, i] = 1;
            return matrix;
        }

        static public double[,] CopyMatrix(double[,] mat)
        {
            int dim = mat.GetLength(0);
            double[,] copy = new double[dim, dim];
            for (int i = 0; i < dim; i++)
                for (int j = 0; j < dim; j++)
                    copy[i, j] = mat[i, j];
            return copy;
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
        
        static public double DegreesToRadians(double degrees) => degrees * Math.PI / 180;

        static public double CosH(double x) => Math.Cos(x / 2);

        static public double SinH(double x) => Math.Sin(x / 2);

        static public double[,] ZBuffer(int w, int h)
        {
            double[,] zBuffer = new double[w, h];
            for (int i = 0; i < w; ++i)
                for (int j = 0; j < h; ++j)
                    zBuffer[i, j] = int.MinValue;
            return zBuffer;
        }
    }
}
