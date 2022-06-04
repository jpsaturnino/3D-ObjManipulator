using static _3DViewerJPMM.Utils.Helper;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace _3DViewerJPMM.Models
{

    internal class Draw
    {
        private int CX, CY;

        /*
         * Projeção paralela no plano XY 
         */
        public void ParallelProjectionXY(Bitmap bmp, _3DObject obj, int tx, int ty, Color lineColor, bool showHiddenFaces)
        {
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                CX = tx;
                CY = ty;
                List<List<int>> faces = obj.Faces;
                List<Vertex> vertices = obj.CurrentVertices;
                if (showHiddenFaces)
                {
                    for (int idf = 0; idf < faces.Count; ++idf)
                        ParallelProjectionFaceXY(data, faces[idf], vertices, lineColor);
                }
                else
                {
                    for (int idf = 0; idf < faces.Count; ++idf)
                        if (obj.NormalFaceAt(idf).Z >= 0.0)
                            ParallelProjectionFaceXY(data, faces[idf], vertices, lineColor);
                }
            }
            bmp.UnlockBits(data);
        }

        /*
         * Projeção paralela da face no plano XY 
         */
        private unsafe void ParallelProjectionFaceXY(BitmapData data, List<int> f, List<Vertex> vertices, Color color)
        {
            Vertex p1, p2;
            int i;
            for (i = 0; i + 1 < f.Count; ++i)
            {
                p1 = vertices[f[i]];
                p2 = vertices[f[i + 1]];
                Bresenham(data, (int)p1.X + CX, (int)p1.Y + CY, (int)p2.X + CX, (int)p2.Y + CY, color);
            }
            i = f.Count - 1;
            p1 = vertices[f[i]];
            p2 = vertices[f[0]];
            Bresenham(data, (int)p1.X + CX, (int)p1.Y + CY, (int)p2.X + CX, (int)p2.Y + CY, color);
        }

        public void PerspectiveProjectionXY(Bitmap bmp, _3DObject obj, int tx, int ty, Color lineColor, bool showHiddenFaces, double fov= -1000)
        {
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                CX = tx;
                CY = ty;
                List<List<int>> faces = obj.Faces;
                List<Vertex> vertices = obj.CurrentVertices;
                if (showHiddenFaces)
                    for (int idf = 0; idf < faces.Count; ++idf)
                        PerspectiveProjectionFaceXY(data, faces[idf], vertices, lineColor, fov);
                else
                    for (int idf = 0; idf < faces.Count; ++idf)
                        if (obj.NormalFaceAt(idf).Z >= 0.0)
                            PerspectiveProjectionFaceXY(data, faces[idf], vertices, lineColor, fov);
            }
            bmp.UnlockBits(data);
        }

        private unsafe void PerspectiveProjectionFaceXY(BitmapData data, List<int> f, List<Vertex> vertices, Color color, double fov)
        {
            Vertex v1, v2;
            int i;
            double x1, y1, z1, x2, y2, z2;
            for (i = 0; i + 1 < f.Count; ++i)
            {
                v1 = vertices[f[i]];
                if (i == f.Count - 1)
                    v2 = vertices[f[0]];
                else
                    v2 = vertices[f[i + 1]];
                x1 = v1.X; y1 = v1.Y; z1 = v1.Z;
                x2 = v2.X; y2 = v2.Y; z2 = v2.Z;
                x1 = x1 * fov / (z1 += fov);
                y1 = y1 * fov / z1;
                x2 = x2 * fov / (z2 += fov);
                y2 = y2 * fov / z2;
                Bresenham(data, (int)x1 + CX, (int)y1 + CY, (int)x2 + CX, (int)y2 + CY, color);
            }
        }
        
        public void ObliqueProjection(Bitmap bmp, _3DObject obj, int tx, int ty, Color cor, bool showHiddenFaces, double L)
        {
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                CX = tx;
                CY = ty;
                List<List<int>> faces = obj.Faces;
                List<Vertex> vertices = obj.CurrentVertices;
                if (showHiddenFaces)
                    for (int idf = 0; idf < faces.Count; ++idf)
                        ObliqueProjectionFaceXY(data, faces[idf], vertices, L, cor);                    
                else
                    for (int idf = 0; idf < faces.Count; ++idf)
                        if (obj.NormalFaceAt(idf).Y <= 0.0)
                            ObliqueProjectionFaceXY(data, faces[idf], vertices, L, cor);
            }
            bmp.UnlockBits(data);
        }

        private void ObliqueProjectionFaceXY(BitmapData data, List<int> f, List<Vertex> vertices, double L, Color cor)
        {
            Vertex v1, v2;
            int i;
            double x1, y1, x2, y2;
            double alpha = (Math.PI * 45) / 180;
            double cosh = Math.Cos(alpha), sinh = Math.Sin(alpha);
            double coshL = L * cosh, sinhL = L * sinh;
            for (i = 0; i < f.Count; ++i)
            {
                v1 = vertices[f[i]];
                if (i == f.Count - 1)
                    v2 = vertices[f[0]];
                else
                    v2 = vertices[f[i + 1]];
                x1 = (v1.X + v1.Z) * coshL;
                y1 = (v1.Y + v1.Z) * sinhL;
                x2 = (v2.X + v2.Z) * coshL;
                y2 = (v2.Y + v2.Z) * sinhL;
                Bresenham(data, (int)x1 + CX, (int)y1 + CY, (int)x2 + CX, (int)y2 + CY, cor);
            }
        }

        private unsafe void Bresenham(BitmapData data, int x1, int y1, int x2, int y2, Color color)
        {
            int deltaX = x2 - x1, x, y;
            int deltaY = y2 - y1;
            int declive = 1;
            int incE, incNE, d; 
            if (Math.Abs(deltaX) > Math.Abs(deltaY))
            {
                // mais distante em x
                if (x1 > x2) Bresenham(data, x2, y2, x1, y1, color);
                
                if (y1 > y2 && x1 < x2)
                {   
                    declive = -1;
                    deltaY = -deltaY;
                }
                
                incE = 2 * deltaY;
                incNE = 2 * (deltaY - deltaX);
                d = incNE;

                y = y1;
                for (x = x1; x <= x2; ++x)
                {
                    if (InImage(data, x, y)) WritePixel(data, x, y, color);
                    
                    if (d < 0) d += incE;
                    else
                    {
                        d += incNE;
                        y += declive;
                    }
                }
            }
            else
            {   
                // mais distante em y
                if (y1 > y2) Bresenham(data, x2, y2, x1, y1, color);

                if (x1 > x2 && y1 < y2)
                {  
                    declive = -1;
                    deltaX = -deltaX;
                }
                
                incE = 2 * deltaX;
                incNE = 2 * (deltaX - deltaY);
                d = incNE;

                x = x1;
                for (y = y1; y <= y2; ++y)
                {
                    if (InImage(data, x, y)) WritePixel(data, x, y, color);
                    
                    if (d < 0) d += incE;
                    else
                    {
                        d += incNE;
                        x += declive;
                    }
                }
            }
        }

        /* 
         * verifica se o pixel (x,y) esta dentro da imagem
         * retorna true se estiver, false caso contrario
         */
        private bool InImage(BitmapData data, int x, int y)
        {
            return x >= 0 && x < data.Width && y >= 0 && y < data.Height;
        }

        /* 
         * escreve o pixel (x,y) na imagem
         */
        private void WritePixel(BitmapData data, int x, int y, Color color)
        {
            unsafe
            {
                byte* p = (byte*)data.Scan0; // ponteiro para o inicio da imagem
                p += y * data.Stride + x * 3;
                *p = color.B;
                *(p + 1) = color.G;
                *(p + 2) = color.R;
            }
        }

        public void Paint(Bitmap bmp, Color color)
        {
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                byte* p = (byte*)data.Scan0;
                for (int i = 0; i < data.Height; ++i)
                {
                    /*
                     * ponteiro para o inicio da linha
                     * p += data.Stride: avança para o inicio da proxima linha
                     */
                    for (int j = 0; j < data.Width; ++j)
                    {
                        /* 
                         * ponteiro para o pixel da linha
                         * p += 3: avança para o pixel da proxima coluna
                         */
                        *p = color.B;
                        *(p + 1) = color.G;
                        *(p + 2) = color.R;
                        p += 3;
                    }
                    p += data.Stride - data.Width * 3;
                }
            }
            bmp.UnlockBits(data);
        }
        /*
        public void paint(Bitmap bmp, Color color)
        {

            // lock dados
            BitmapData bmpdata = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                int height = bmp.Height;
                int width = bmp.Width;
                int padding = bmpdata.Stride - width * 3;
                byte* aux = (byte*)bmpdata.Scan0.ToPointer();
                for (int y = 0, x; y < height; ++y)
                {
                    for (x = 0; x < width; ++x)
                    {
                        *(aux++) = color.B;
                        *(aux++) = color.G;
                        *(aux++) = color.R;
                    }
                    aux += padding;
                }
            }// fim unsafe

            // unluck dados
            bmp.UnlockBits(bmpdata);
        }// fim paint
        */
    }
}