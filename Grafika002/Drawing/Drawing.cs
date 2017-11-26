using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika002.Drawing
{
    public interface IDrawing
    {
        void DrawLine(Point p1, Point p2, Color color);
        void DrawHorizontalLine(int y, int x1, int x2, Color color);
        void ClearBitmap();
    }

    public class Drawing : IDrawing
    {
        protected DirectBitmap DirectBitmap { get; set; }
        protected DirectBitmapDouble LightDirectBitmap { get; set; }
        private int _width;
        private int _heigth;

        public Drawing(DirectBitmap directBitmap)
        {
            DirectBitmap = directBitmap;
            _width = DirectBitmap.Bitmap.Width;
            _heigth = DirectBitmap.Bitmap.Height;
            LightDirectBitmap = new DirectBitmapDouble(_width, _heigth);
            CalculateColorMap(Color.White, new Point3D() { X = 200, Y = 300, Z = 300 });
        }

        public void DrawLine(Point p1, Point p2, Color color)
        {
            //Graphics g = Graphics.FromImage(DirectBitmap.Bitmap);

            //    g.DrawLine(new Pen(color), p1, p2);
            DrawLine(p1.X, p1.Y, p2.X, p2.Y, color);
        }

        public void DrawLine(int x, int y, int x2, int y2, Color color)
        {
            int w = x2 - x;
            int h = y2 - y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1;
            else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1;
            else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1;
            else if (w > 0) dx2 = 1;
            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);
            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1;
                else if (h > 0) dy2 = 1;
                dx2 = 0;
            }
            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                SetPixel(x, y, color);
                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    x += dx1;
                    y += dy1;
                }
                else
                {
                    x += dx2;
                    y += dy2;
                }
            }
        }


        public void DrawHorizontalLine(int y, int x1, int x2, Color color)
        {
            int i;
            //int colorInt = color;
            if (x1 > x2)
            {
                i = x1;
                x1 = x2;
                x2 = i;
            }
            for (i = x1; i <= x2; i++)
                SetPixel(i, y, color);
        }

        public void SetPixel(int x, int y, Color color)
        {
            lock (DirectBitmap.Bits)
            {
                int colorInt = Color.FromArgb((int)(color.R * LightDirectBitmap.BitsRed[x + (y) * _width]),
                    (int)(color.G * LightDirectBitmap.BitsGreen[x + (y) * _width]),
                    (int)(color.B * LightDirectBitmap.BitsBlue[x + (y) * _width])).ToArgb();
                DirectBitmap.Bits[x + (y) * _width] = colorInt;
            }
        }


        public void ClearBitmap()
        {
            int emptyColor = Color.Empty.ToArgb();
            int bits = DirectBitmap.Height * DirectBitmap.Width;


            for (int i = 0; i < bits; i++)
                DirectBitmap.Bits[i] = emptyColor;
        }

        private static double DotProduct(Vector3D normalVector, Vector3D ligthVector)
        {
            return normalVector.X * ligthVector.X + normalVector.Y * ligthVector.Y + normalVector.Z * ligthVector.Z;
        }

        public void CalculateColorMap(Color color, Point3D point3d)
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _heigth; y++)
                {
                    Vector3D normalVector = new Vector3D(0, 0, 1);
                    Vector3D ligthVector = new Vector3D(point3d.X - x, point3d.Y - y, point3d.Z);
                    double cos = Math.Abs(DotProduct(normalVector, ligthVector) / (normalVector.Length * ligthVector.Length));
                    LightDirectBitmap.BitsRed[x + (y) * _width] = (color.R * cos) / 255;
                    LightDirectBitmap.BitsGreen[x + (y) * _width] = (color.G * cos) / 255;
                    LightDirectBitmap.BitsBlue[x + (y) * _width] = (color.B * cos) / 255;
                }
            }


        }

        public struct Point3D
        {
            public int X, Y, Z;
        }

        public class Vector3D
        {
            public int X, Y, Z;

            public Vector3D(int x, int y, int z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            public double Length
            {
                get { return Math.Sqrt(X * X + Y * Y + Z * Z); }
            }
        }
    }
}
