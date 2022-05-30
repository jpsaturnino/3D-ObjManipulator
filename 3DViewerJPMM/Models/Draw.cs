using static _3DViewerJPMM.Utils.Helper;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace _3DViewerJPMM.Models
{

    internal class Draw
    {
        private const double piNumber = Math.PI;
        private int CX, CY;

        private bool insideImage(BitmapData image, int x, int y)
        {
            return x >= 0 && x < image.Width && y >= 0 && y < image.Height;
        }

        private int abs(int a)
        {
            return Math.Abs(a);
        }

        private double[,] genZBuffer(int width, int height)
        {
            double[,] zbuffer = new double[width, height];
            for (int x = 0; x < width; ++x)
                for (int y = 0; y < height; ++y)
                    zbuffer[x, y] = int.MinValue;
            return zbuffer;
        }
        
        private unsafe byte* gotoxy(BitmapData image, int x, int y)
        {
            byte* auxByte = (byte*)image.Scan0.ToPointer();
            auxByte += y * image.Stride; // linha
            auxByte += 3 * x; // coluna
            return auxByte;
        }

        private unsafe byte* gotoxy(int x, int y, BitmapData image)
        {
            return this.gotoxy(image, x, y);
        }

        private unsafe void WritePixel(BitmapData image, int x, int y, Color color)
        {
            byte* aux = this.gotoxy(x, y, image);
            *aux = color.B;
            *(aux + 1) = color.G;
            *(aux + 2) = color.R;
        }

        /*
        private bool insideImage(BitmapData image, int x, int y, int w, int h)
        {
            return x >= 0 && x < image.Width && y >= 0 && y < image.Height && x + w < image.Width && y + h < image.Height;
        }
        */
        
        private void Bresenham(BitmapData data, int x1, int y1, int x2, int y2,  Color color)
        {
            
            int dx = x2 - x1, x, y;
            int dy = y2 - y1;
            int declive = 1;
            
            int incE, incNE, d;
            if (abs(dx) > abs(dy))
            {
                if (x1 > x2)
                {
                    Bresenham(data, x2, y2, x1, y1, color);
                    return;
                }
                if (y1 > y2)
                {
                    declive = -1;
                    dy = -dy;
                }
                incE = 2 * dy;
                incNE = 2 * (dy - dx);
                d = incNE;
                y = y1;
                for (x = x1; x <= x2; ++x)
                {
                    if (insideImage(data, x, y))
                        WritePixel(data, x, y, color);
                    if (d < 0)
                        d += incE;
                    else
                    {
                        d += incNE;
                        y += declive;
                    }
                }
            }
            else
            {
                if (y1 > y2)
                {
                    this.Bresenham(data, x2, y2, x1, y1, color);
                    return;
                }
                if (x1 > x2)
                {   
                    declive = -1;
                    dx = -dx;
                }
                incE = 2 * dx;
                incNE = 2 * (dx - dy);
                d = incNE;

                x = x1;
                for (y = y1; y <= y2; ++y)
                {
                    if (insideImage(data, x, y))
                        WritePixel(data, x, y, color);
                    if (d < 0)
                        d += incE;
                    else
                    {
                        d += incNE;
                        x += declive;
                    }
                }
            }
        }




    
    }
}