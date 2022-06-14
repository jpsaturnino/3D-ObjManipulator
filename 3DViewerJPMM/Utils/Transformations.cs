using static _3DViewerJPMM.Utils.Helper;

namespace _3DViewerJPMM.Utils
{
    public static class Transformations
    {
        public static double[,] RotateX(double angle, double[,] MA)
        {
            double[,] matrix = IdentityMatrix(4);
            matrix[1, 1] = Math.Cos(angle);
            matrix[1, 2] = -Math.Sin(angle);
            matrix[2, 1] = Math.Sin(angle);
            matrix[2, 2] = Math.Cos(angle);
            return Multiply(matrix, MA);
        }

        public static double[,] RotateY(double angle, double[,] MA)
        {
            double[,] matrix = IdentityMatrix(4);
            matrix[0, 0] = Math.Cos(angle);
            matrix[0, 2] = Math.Sin(angle);
            matrix[2, 0] = -Math.Sin(angle);
            matrix[2, 2] = Math.Cos(angle);
            return Multiply(matrix, MA);
        }

        public static double[,] RotateZ(double angle, double[,] MA)
        {
            double[,] matrix = IdentityMatrix(4);
            matrix[0, 0] = Math.Cos(angle);
            matrix[0, 1] = -Math.Sin(angle);
            matrix[1, 0] = Math.Sin(angle);
            matrix[1, 1] = Math.Cos(angle);
            return Multiply(matrix, MA);
        }

        public static double[,] Scale(double x, double y, double z, double[,] MA)
        {
            double[,] S = IdentityMatrix(4);
            S[0, 0] = x;
            S[1, 1] = y;
            S[2, 2] = z;
            return Multiply(S, MA);
        }

        public static double[,] Translate(double x, double y, double z, double[,] MA)
        {
            double[,] T = IdentityMatrix(4);
            T[0, 3] = x;
            T[1, 3] = y;
            T[2, 3] = z;
            return Multiply(T, MA);
        }
    }
}
