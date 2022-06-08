using static _3DViewerJPMM.Utils.Helper;
using System.Drawing.Imaging;

namespace _3DViewerJPMM.Models
{
    internal class Draw
    {
        private int CX, CY;
        private Vertex eye = new Vertex(0, 0, 1);

        public void ParallelProjection(Bitmap bmp, _3DObject obj, int tx, int ty, Color lineColor, bool showHiddenFaces, string view)
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
                        ParallelProjectionFace(data, faces[idf], vertices, lineColor, view);
                }
                else
                {
                    for (int idf = 0; idf < faces.Count; ++idf)
                        if (obj.NormalFaceAt(idf).Z >= 0.0)
                            ParallelProjectionFace(data, faces[idf], vertices, lineColor, view);
                }
            }
            bmp.UnlockBits(data);
        }
                
        private unsafe void ParallelProjectionFace(BitmapData data, List<int> f, List<Vertex> vertices, Color color, string view)
        {
            Vertex v1, v2;
            for (int i = 0; i < f.Count; ++i)
            {
                v1 = vertices[f[i]];
                if (i == f.Count - 1)
                    v2 = vertices[f[0]];
                else
                    v2 = vertices[f[i + 1]];
                switch (view)
                {
                    case "XY":
                        Bresenham(data, (int)v1.X + CX, (int)v1.Y + CY, (int)v2.X + CX, (int)v2.Y + CY, color);
                        break;
                    case "ZX":
                        Bresenham(data, (int)v1.Z + CX, (int)v1.X + CY, (int)v2.Z + CX, (int)v2.X + CY, color);
                        break;
                    case "ZY":
                        Bresenham(data, (int)v1.Z + CX, (int)v1.Y + CY, (int)v2.Z + CX, (int)v2.Y + CY, color);
                        break;
                }
            }
        }

        public void PerspectiveProjection(Bitmap bmp, _3DObject obj, int tx, int ty, Color lineColor, bool showHiddenFaces, string view, double fov = -1000)
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
                        PerspectiveProjectionFace(data, faces[idf], vertices, lineColor, fov, view);
                else
                    for (int idf = 0; idf < faces.Count; ++idf)
                        if (obj.NormalFaceAt(idf).Z >= 0.0)
                            PerspectiveProjectionFace(data, faces[idf], vertices, lineColor, fov, view);
            }
            bmp.UnlockBits(data);
        }

        private unsafe void PerspectiveProjectionFace(BitmapData data, List<int> f, List<Vertex> vertices, Color color, double fov, string view)
        {
            Vertex v1, v2;
            double x1 = 0, y1 = 0, z1 = 0, x2 = 0, y2 = 0, z2 = 0;
            for (int i = 0; i < f.Count; ++i)
            {
                v1 = vertices[f[i]];
                if (i == f.Count - 1)
                    v2 = vertices[f[0]];
                else
                    v2 = vertices[f[i + 1]];
                switch (view)
                {
                    case "XY":
                        x1 = v1.X; y1 = v1.Y; z1 = v1.Z;
                        x2 = v2.X; y2 = v2.Y; z2 = v2.Z;
                        break;
                    case "ZX":
                        x1 = v1.Z; y1 = v1.X; z1 = v1.Y;
                        x2 = v2.Z; y2 = v2.X; z2 = v2.Y;
                        break;
                    case "ZY":
                        x1 = v1.Z; y1 = v1.Y; z1 = v1.X;
                        x2 = v2.Z; y2 = v2.Y; z2 = v2.X;
                        break;
                }
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
            double x1, y1, x2, y2;
            double alpha = DegreesToRadians(45);
            double cosh = CosH(alpha), sinh = SinH(alpha), coshL = L * cosh, sinhL = L * sinh;
            for (int i = 0; i < f.Count; ++i)
            {
                v1 = vertices[f[i]];
                if (i == f.Count - 1)
                    v2 = vertices[f[0]];
                else
                    v2 = vertices[f[i + 1]];
                x1 = v1.X + v1.Z * coshL;
                y1 = v1.Y + v1.Z * sinhL;
                x2 = v2.X + v2.Z * coshL;
                y2 = v2.Y + v2.Z * sinhL;
                Bresenham(data, (int)x1 + CX, (int)y1 + CY, (int)x2 + CX, (int)y2 + CY, cor);
            }
        }

        public void Flat(Bitmap bmp, _3DObject obj, int tx, int ty, Vertex lightPoint, Vertex eyePoint, int n,
            Vertex c)
        {
            int height = bmp.Height, width = bmp.Width;
            double[,] zbuffer = ZBuffer(width, height);
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            
            EdgeTable et;
            unsafe
            {
                obj.UpdateNormalFaces();
                for (int i = 0; i < obj.Faces.Count; ++i)
                    if (obj.NormalFaceAt(i).Z >= 0)
                    {
                        et = obj.CreateFlatET(i, height, tx, ty, lightPoint, eyePoint, n, c);
                        ScanLineFaceFlat(data, et, zbuffer);
                    }
            }
            bmp.UnlockBits(data);

        }

        private void ScanLineFaceFlat(BitmapData data, EdgeTable et, double[,] zbuffer)
        {
            List<NodeAET> lista;
            double z, inczx;
            int y = 0, cont = 0;
            while (y < et._MAXSIZE && et.AET(y) == null) ++y;
            
            _AET aet = new _AET(), aetAux;
            do
            {
                if (et.AET(y) != null)
                {
                    ++cont;
                    aet.Insert(et.AET(y).LIST);
                }
                
                aetAux = new _AET();
                foreach (NodeAET no in aet.LIST)
                {
                    if (no.YMax > y)
                        aetAux.Insert(no);
                }
                aet = aetAux;
                aet.Sort();
                
                // desenhando linhas
                lista = aet.LIST;
                for (int i = 0, x, x2; i + 1 < lista.Count; i += 2)
                {
                    x = (int)Math.Round(lista[i].XMin);
                    x2 = (int)Math.Round(lista[i + 1].XMin);
                    z = lista[i].Zmin;
                    inczx = (lista[i + 1].Zmin - lista[i].Zmin) / (x2 - x);
                    for (int c = x, c2 = (int)lista[i + 1].XMin; c <= c2; ++c)
                    {
                        if (InImage(data, x, y) && z > zbuffer[x, y])
                        {
                            zbuffer[x, y] = z;
                            WritePixel(data, x, y, Color.FromArgb(
                                (int)lista[i].Rxmin, (int)lista[i].Gymin, (int)lista[i].BZMin)
                            );
                        }
                        z += inczx;
                        ++x;
                    }
                }
                
                for (int i = 0; i < aet.LIST.Count; ++i)
                {
                    aet.LIST[i].XMin = aet.LIST[i].XMin + aet.LIST[i].IncX;
                    aet.LIST[i].ZMin = aet.LIST[i].ZMin + aet.LIST[i].IncZY;
                }
                ++y;
            } while (aet.LIST.Count > 0); // tem pontos na AET
        }

        public void Gouraud(Bitmap bmp, _3DObject obj, int tx, int ty, Vertex lightPoint, Vertex eyePoint, int n, Vertex c)
        {
            int height = bmp.Height, width = bmp.Width;
            double[,] zbuffer = ZBuffer(width, height);
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            EdgeTable et;
            unsafe
            {
                obj.UpdateNormalFaces();
                obj.UpdateNormalVertices();
                for (int i = 0; i < obj.Faces.Count; ++i)
                    if (obj.NormalFaceAt(i).Z >= 0)
                    {
                        et = obj.CreateGouraudET(i, height, tx, ty, lightPoint, eyePoint, n, c);
                        ScanLineFaceGouraud(data, et, zbuffer);
                    }
            }
            bmp.UnlockBits(data);
        }

        private void ScanLineFaceGouraud(BitmapData data, EdgeTable et, double[,] zbuffer)
        {
            List<NodeAET> lista;
            double z, inczx;
            int y = 0;
            _AET aet = new _AET(), aetAux;
            while (y < et._MAXSIZE && et.AET(y) == null)
                ++y;
            do // laço AET
            {
                if (et.AET(y) != null)
                    aet.Insert(et.AET(y).LIST); // adicionando novos nodos
                                                     // removendo nodos com Ymax == Y
                aetAux = new _AET();
                foreach (NodeAET no in aet.LIST)
                {
                    if (no.YMax > y)
                        aetAux.Insert(no);
                }
                aet = aetAux;
                aet.Sort();
                // desenhando linhas
                lista = aet.LIST;
                for (int i = 0, x, x2; i + 1 < lista.Count; i += 2)
                {
                    x = (int)Math.Round(lista[i].XMin);
                    x2 = (int)Math.Round(lista[i + 1].XMin);
                    z = lista[i].ZMin;
                    double r, g, b, incrx, incgx, incbx, dx = x2 - x;
                    r = lista[i].RXMin;
                    g = lista[i].GYMin;
                    b = lista[i].BZMin;
                    incrx = (lista[i + 1].RXMin - lista[i].RXMin) / dx;
                    incgx = (lista[i + 1].GYMin - lista[i].GYMin) / dx;
                    incbx = (lista[i + 1].BZMin - lista[i].BZMin) / dx;

                    inczx = (lista[i + 1].ZMin - lista[i].ZMin) / dx;
                    while (x <= x2)
                    {
                        if (InImage(data, x, y) && z > zbuffer[x, y])
                        {
                            zbuffer[x, y] = z;
                            WritePixel(data, x, y, Color.FromArgb((int)r, (int)g, (int)b));
                        }
                        r += incrx;
                        g += incgx;
                        b += incbx;
                        z += inczx;
                        ++x;
                    }
                }
                foreach (NodeAET no in aet.LIST)
                {
                    no.XMin = no.XMin + no.IncX;
                    no.ZMin = no.ZMin + no.IncZY;
                    no.RXMin = no.RXMin + no.IncRX;
                    no.GYMin = no.GYMin + no.IncGY;
                    no.BZMin = no.BZMin + no.IncBZ;
                }
                ++y;
            } while (aet.LIST.Count > 0); // tem pontos na AET
        }

        public void Phong(Bitmap bmp, _3DObject obj, int tx, int ty, Vertex lightPoint, Vertex eyePoint, int n, Vertex c)
        {
            int height = bmp.Height, width = bmp.Width;
            double[,] zbuffer = ZBuffer(width, height);
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            EdgeTable et;
            unsafe
            {
                obj.UpdateNormalFaces();
                obj.UpdateNormalVertices();
                for (int i = 0; i < obj.Faces.Count; ++i)
                    if (obj.NormalFaceAt(i).Z >= 0)
                    {
                        et = obj.CreatePhongET(i, height, tx, ty, lightPoint, eyePoint, n, c);
                        ScanLineFacePhong(data, et, zbuffer, lightPoint, eyePoint, n, c);
                    }
            }
            bmp.UnlockBits(data);
        }

        private void ScanLineFacePhong(BitmapData data, EdgeTable et, double[,] zbuffer, Vertex lightPoint, Vertex eyePoint, int n, Vertex c)
        {
            List<NodeAET> lista;
            double z, inczx;
            int y = 0;
            Vertex cor;
            _AET aet = new _AET(), aetAux;
            while (y < et._MAXSIZE && et.AET(y) == null)
                ++y;
            do // laço AET
            {
                if (et.AET(y) != null)
                    aet.Insert(et.AET(y).LIST); // adicionando novos nodos
                                                     // removendo nodos com Ymax == Y
                aetAux = new _AET();
                foreach (NodeAET no in aet.LIST)
                {
                    if (no.YMax > y)
                        aetAux.Insert(no);
                }
                aet = aetAux;
                aet.Sort();
                // desenhando linhas
                lista = aet.LIST;
                for (int i = 0, x, x2; i + 1 < lista.Count; i += 2)
                {
                    x = (int)Math.Round(lista[i].XMin);
                    x2 = (int)Math.Round(lista[i + 1].XMin);
                    z = lista[i].Zmin;
                    double r, g, b, incrx, incgx, incbx, dx = x2 - x;
                    r = lista[i].RXMin;
                    g = lista[i].GYMin;
                    b = lista[i].BZMin;
                    incrx = (lista[i + 1].RXMin - lista[i].RXMin) / dx;
                    incgx = (lista[i + 1].GYMin - lista[i].GYMin) / dx;
                    incbx = (lista[i + 1].BZMin - lista[i].BZMin) / dx;

                    inczx = (lista[i + 1].ZMin - lista[i].ZMin) / dx;
                    while (x <= x2)
                    {
                        if (InImage(data, x, y) && z > zbuffer[x, y])
                        {
                            cor = PhongShading(lightPoint, eyePoint, new Vertex(r, g, b), n, c);
                            zbuffer[x, y] = z;
                            WritePixel(data, x, y, Color.FromArgb((int)cor.X, (int)cor.Y, (int)cor.Z));
                        }
                        r += incrx;
                        g += incgx;
                        b += incbx;
                        z += inczx;
                        ++x;
                    }
                }
                foreach (NodeAET no in aet.LIST)
                {
                    no.XMin = no.XMin + no.IncX;
                    no.ZMin = no.ZMin + no.IncZY;
                    no.RXMin = no.RXMin + no.IncRX;
                    no.GYMin = no.GYMin + no.IncGY;
                    no.BZMin = no.BZMin + no.IncBZ;
                }
                ++y;
            } while (aet.LIST.Count > 0); // tem pontos na AET
        }

        public static Vertex PhongShading(Vertex lightPoint, Vertex eyePoint, Vertex N, int n,
            Vertex c)
        {
            Vertex H = lightPoint.Increment(eyePoint).Normalize();
            double hnn = Math.Pow(H.DotProduct(N), n), ln = lightPoint.DotProduct(N);

            double r = c.X * c.X + c.X * c.X * ln + c.X * c.X * hnn;
            double g = c.Y * c.Y + c.Y * c.Y * ln + c.Y * c.Y * hnn;
            double b = c.Z * c.Z + c.Z * c.Z * ln + c.Z * c.Z * hnn;
            
            r = r < 0 ? 0 : (r > 1 ? 1 : r);
            g = g < 0 ? 0 : (g > 1 ? 1 : g);
            b = b < 0 ? 0 : (b > 1 ? 1 : b);
            
            return new Vertex(r * 255, g * 255, b * 255);
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
        
        private bool InImage(BitmapData data, int x, int y)
        {
            return x >= 0 && x < data.Width && y >= 0 && y < data.Height;
        }

        private void WritePixel(BitmapData data, int x, int y, Color color)
        {
            unsafe
            {
                byte* p = gotoxy(x, y, data);
                *p = color.B;
                *(p + 1) = color.G;
                *(p + 2) = color.R;
            }
        }

        private unsafe byte* gotoxy(BitmapData bmp, int x, int y)
        {
            byte* aux = (byte*)bmp.Scan0.ToPointer();
            aux += y * bmp.Stride; // linha
            aux += 3 * x; // coluna
            return aux;
        }// fim gotoxy
        private unsafe byte* gotoxy(int x, int y, BitmapData bmp)
        {
            return gotoxy(bmp, x, y);
        }

        public void Paint(Bitmap bmp, Color color)
        {
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
            }

            bmp.UnlockBits(bmpdata);
        }
    }
}