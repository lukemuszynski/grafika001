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
        void DrawHorizontalLine(int y, int x1, int x2, int color);
        void ClearBitmap();
    }

    public class Drawing : IDrawing
    {
        protected DirectBitmap DirectBitmap { get; set; }
        private int _width;
        public Drawing(DirectBitmap directBitmap)
        {
            DirectBitmap = directBitmap;
            _width = DirectBitmap.Bitmap.Width;
            //Color = Consts.defaultColor; //System.Drawing.Color.MediumSpringGreen.ToArgb();
        }

        public void DrawLine(Point p1, Point p2, Color color)
        {
            //Graphics g = Graphics.FromImage(DirectBitmap.Bitmap);

            //    g.DrawLine(new Pen(color), p1, p2);
            DrawLine(p1.X, p1.Y, p2.X, p2.Y, color.ToArgb());
        }

        public void DrawLine(int x, int y, int x2, int y2, int color)
        {
            int w = x2 - x;
            int h = y2 - y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);
            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
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


        public void DrawHorizontalLine(int y, int x1, int x2, int color)
        {
            int i;
            int colorInt = color;
            if (x1 > x2)
            {
                i = x1;
                x1 = x2;
                x2 = i;
            }
            for (i = x1; i <= x2; i++)
                SetPixel(i, y, colorInt);
        }

        public void SetPixel(int x, int y, int color)
        {
            lock (DirectBitmap.Bits)
            {

                color = GetFinalColorWithLambertModel(new Point(x, y), Color.FromArgb(color),
                    new Point3D() {X = 600, Y = 200, Z = 50}, Color.White).ToArgb();
                DirectBitmap.Bits[x + (y) * _width] = color;
            }
        }

        public void ClearBitmap()
        {
            int emptyColor = Color.Empty.ToArgb();
            int bits = DirectBitmap.Height * DirectBitmap.Width;

            //for (int i = 0; i < DirectBitmap.Height - 1; i++)
            //    for (int j = 0; j < DirectBitmap.Width - 1; j++)
            //        SetPixel(j, i, Color.DarkRed.ToArgb(), 1);

            for (int i = 0; i < bits; i++)
                DirectBitmap.Bits[i] = emptyColor;
        }

        public static Color GetFinalColorWithLambertModel(Point point, Color baseColor, Point3D ligthSource, Color ligthColor, int dxdh = 0, int dydh = 0)
        {
            Vector3D normalVector = new Vector3D(dxdh, dydh, 1);
            Vector3D ligthVector = new Vector3D(ligthSource.X - point.X, ligthSource.Y - point.Y, ligthSource.Z);
            double cos = Math.Abs(DotProduct(normalVector, ligthVector) / (normalVector.Length * ligthVector.Length));
            double R = (baseColor.R * ligthColor.R * cos) / 255;
            double G = (baseColor.G * ligthColor.G * cos) / 255;
            double B = (baseColor.B * ligthColor.B * cos) / 255;

            return Color.FromArgb((int)R, (int)G, (int)B);
        }

        private static double DotProduct(Vector3D normalVector, Vector3D ligthVector)
        {
            return normalVector.X * ligthVector.X + normalVector.Y * ligthVector.Y + normalVector.Z * ligthVector.Z;
        }
    }

    public struct Point3D
    {
        public int X, Y, Z;
    }

    public class Vector3D
    {
        public int X, Y, Z;

        public Vector3D(int x,int y, int z)
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
