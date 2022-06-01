using static _3DViewerJPMM.Utils.Helper;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace _3DViewerJPMM.Models
{

    internal class Draw
    {
        private const double piNumber = Math.PI;
        private int CX, CY;
        
        public void ParallelProjectionXY(Bitmap bmp, _3DObject obj, int tx, int ty, Color corlinha, bool rmFacesOcultas)
        {
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                CX = tx;
                CY = ty;
                List<List<int>> faces = obj.Faces;
                List<Vertex> vertices = obj.CurrentVertices;
                if (rmFacesOcultas)
                {
                    for (int idf = 0; idf < faces.Count; ++idf)
                        if (obj.NormalFaceAt(idf).Z >= 0.0)
                            ParallelProjectionFaceXY(data, faces[idf], vertices, corlinha);
                }
                else
                {
                    for (int idf = 0; idf < faces.Count; ++idf)
                        ParallelProjectionFaceXY(data, faces[idf], vertices, corlinha);
                }
            }
            bmp.UnlockBits(data);
        }

        private unsafe void ParallelProjectionFaceXY(BitmapData data, List<int> f, List<Vertex> vertices, Color cor)
        {
            Vertex p1, p2;
            int i;
            for (i = 0; i + 1 < f.Count; ++i)
            {
                p1 = vertices[f[i]];
                p2 = vertices[f[i + 1]];
                Bresenham(data, (int)p1.X + CX, (int)p1.Y + CY, (int)p2.X + CX, (int)p2.Y + CY, cor);
            }
            i = f.Count - 1;
            p1 = vertices[f[i]];
            p2 = vertices[f[0]];
            Bresenham(data, (int)p1.X + CX, (int)p1.Y + CY, (int)p2.X + CX, (int)p2.Y + CY, cor);
        }

        private unsafe void Bresenham(BitmapData data, int x1, int y1, int x2, int y2,
            Color cor)
        {
            int dx = x2 - x1, x, y;
            int dy = y2 - y1;
            int declive = 1;
            int incE, incNE, d;
            if (Math.Abs(dx) > Math.Abs(dy))
            { // for de x
                if (x1 > x2)
                { 
                    Bresenham(data, x2, y2, x1, y1, cor);
                    return;
                }
                if (y1 > y2)
                {   // pintar (x,-y)
                    declive = -1;
                    dy = -dy;
                }
                // definindo constantes de Bresenham para abs(dx) > abs(dy)
                incE = 2 * dy;
                incNE = 2 * (dy - dx);
                d = incNE;

                y = y1;
                for (x = x1; x <= x2; ++x)
                {
                    if (InImage(data, x, y))
                        WritePixel(data, x, y, cor);
                    if (d < 0) // escolhe incE
                        d += incE;
                    else
                    {   // escolhe incNE
                        d += incNE;
                        y += declive;
                    }
                }
            } // fim abs(dx) > abs(dy)
            else
            { // abs(dx) <= abs(dy)
              // for de y
                if (y1 > y2)
                { // trocar ponto p1 por p2
                    /*
                     * chamada recursiva trocando pontos
                     * para que todas a perguntas iniciais
                     * sejam feitas novamente
                     */
                    Bresenham(data, x2, y2, x1, y1, cor);
                    return;
                }
                if (x1 > x2)
                {   // pintar (x,-y)
                    declive = -1;
                    dx = -dx;
                }
                // definindo constantes de Bresenham para abs(dx) <= abs(dy)
                incE = 2 * dx;
                incNE = 2 * (dx - dy);
                d = incNE;

                x = x1;
                for (y = y1; y <= y2; ++y)
                {
                    if (InImage(data, x, y))
                        WritePixel(data, x, y, cor);
                    if (d < 0) // escolhe incE
                        d += incE;
                    else
                    {   // escolhe incNE
                        d += incNE;
                        x += declive;
                    }
                }
            } // abs(dx) <= abs(dy)
        }

        private bool InImage(BitmapData data, int x, int y)
        {
            return x >= 0 && x < data.Width && y >= 0 && y < data.Height;
        }

        private void WritePixel(BitmapData data, int x, int y, Color cor)
        {
            unsafe
            {
                byte* p = (byte*)data.Scan0;
                p += y * data.Stride + x * 3;
                *p = cor.B;
                *(p + 1) = cor.G;
                *(p + 2) = cor.R;
            }
        }
        
        public void paint(Bitmap bmp, Color cor)
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
                        *(aux++) = cor.B;
                        *(aux++) = cor.G;
                        *(aux++) = cor.R;
                    }
                    aux += padding;
                }
            }// fim unsafe

            // unluck dados
            bmp.UnlockBits(bmpdata);
        }// fim paint
    }
}