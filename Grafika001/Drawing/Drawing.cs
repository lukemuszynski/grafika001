using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grafika001.Drawing.BuildingBlocks;

namespace Grafika001.Drawing
{
    public class Drawing
    {
        protected DirectBitmap DirectBitmap { get; set; }

        public int Color { get; set; }

        public int Height
        {
            get { return DirectBitmap.Height; }
        }

        public int Width
        {
            get { return DirectBitmap.Width; }
        }

        public Drawing(DirectBitmap directBitmap)
        {
            DirectBitmap = directBitmap;
            Color = Consts.defaultColor; //System.Drawing.Color.MediumSpringGreen.ToArgb();
        }

        public void ClearBitmap()
        {
            int emptyColor = System.Drawing.Color.Empty.ToArgb();
            int bits = DirectBitmap.Height * DirectBitmap.Width;

            //for (int i = 0; i < DirectBitmap.Height - 1; i++)
            //    for (int j = 0; j < DirectBitmap.Width - 1; j++)
            //        SetPixel(j, i, Color.DarkRed.ToArgb(), 1);

            for (int i = 0; i < bits; i++)
                DirectBitmap.Bits[i] = emptyColor;
        }

        public void DrawLine(Line line)
        {
            DrawLine(line.StartPoint.X, line.StartPoint.Y, line.EndPoint.X, line.EndPoint.Y, line.Color, line.Width);
        }

        public void DrawLines(IEnumerable<Line> lines)
        {
            foreach (var line in lines)
            {
                DrawLine(line.StartPoint.X, line.StartPoint.Y, line.EndPoint.X, line.EndPoint.Y, line.Color, line.Width);
            }
        }

        public void DrawCircle(Circle circle)
        {
            CircleOptimized(circle.Center.X, circle.Center.Y, circle.Radius, circle.Color, circle.Width);
        }

        public void SetPixel(Point point, int width, int color = 0)
        {
            if (color == 0)
                color = Color;
            SetPixel(point.X, point.Y, color, width);
        }

        public void SetPixel(int x, int y, int color, int width)
        {

            if (x + y * DirectBitmap.Bitmap.Width < 0 || x + y * DirectBitmap.Bitmap.Width >= DirectBitmap.Bits.Length)
                return;
            if (width == Consts.MediumWidth)
            {
                if (x - 1 + (y) * DirectBitmap.Bitmap.Width < 0 ||
                    x - 1 + (y) * DirectBitmap.Bitmap.Width >= DirectBitmap.Bits.Length)
                    return;
                if (x + 1 + (y) * DirectBitmap.Bitmap.Width < 0 ||
                    x + 1 + (y) * DirectBitmap.Bitmap.Width >= DirectBitmap.Bits.Length)
                    return;
                if (x + (y + 1) * DirectBitmap.Bitmap.Width < 0 ||
                    x + (y + 1) * DirectBitmap.Bitmap.Width >= DirectBitmap.Bits.Length)
                    return;
                if (x + (y - 1) * DirectBitmap.Bitmap.Width < 0 ||
                    x + (y - 1) * DirectBitmap.Bitmap.Width >= DirectBitmap.Bits.Length)
                    return;
            }
            if (width == Consts.BigWidth)
            {
                if (x + (y + 2) * DirectBitmap.Bitmap.Width < 0 || x + (y + 2) * DirectBitmap.Bitmap.Width >= DirectBitmap.Bits.Length) return;
                if (x - 2 + (y) * DirectBitmap.Bitmap.Width < 0 || x - 2 + (y) * DirectBitmap.Bitmap.Width >= DirectBitmap.Bits.Length) return;
                if (x + (y - 2) * DirectBitmap.Bitmap.Width < 0 || x + (y - 2) * DirectBitmap.Bitmap.Width >= DirectBitmap.Bits.Length) return;
                if (x + 2 + (y) * DirectBitmap.Bitmap.Width < 0 || x + 2 + (y) * DirectBitmap.Bitmap.Width >= DirectBitmap.Bits.Length) return;
            }

            DirectBitmap.Bits[x + y * DirectBitmap.Bitmap.Width] = color;
            if (width == Consts.MediumWidth)
            {
                DirectBitmap.Bits[x - 1 + (y) * DirectBitmap.Bitmap.Width] = color;
                DirectBitmap.Bits[x + 1 + (y) * DirectBitmap.Bitmap.Width] = color;
                DirectBitmap.Bits[x + (y + 1) * DirectBitmap.Bitmap.Width] = color;
                DirectBitmap.Bits[x + (y - 1) * DirectBitmap.Bitmap.Width] = color;
            }
            if (width == Consts.BigWidth)
            {
                DirectBitmap.Bits[x + (y + 2) * DirectBitmap.Bitmap.Width] = color;

                DirectBitmap.Bits[x - 1 + (y + 1) * DirectBitmap.Bitmap.Width] = color;
                DirectBitmap.Bits[x + (y + 1) * DirectBitmap.Bitmap.Width] = color;
                DirectBitmap.Bits[x + 1 + (y + 1) * DirectBitmap.Bitmap.Width] = color;

                DirectBitmap.Bits[x - 2 + (y) * DirectBitmap.Bitmap.Width] = color;
                DirectBitmap.Bits[x - 1 + (y) * DirectBitmap.Bitmap.Width] = color;
                DirectBitmap.Bits[x + (y) * DirectBitmap.Bitmap.Width] = color;
                DirectBitmap.Bits[x + 1 + (y) * DirectBitmap.Bitmap.Width] = color;
                DirectBitmap.Bits[x + 2 + (y) * DirectBitmap.Bitmap.Width] = color;

                DirectBitmap.Bits[x - 1 + (y - 1) * DirectBitmap.Bitmap.Width] = color;
                DirectBitmap.Bits[x + (y - 1) * DirectBitmap.Bitmap.Width] = color;
                DirectBitmap.Bits[x + 1 + (y - 1) * DirectBitmap.Bitmap.Width] = color;

                DirectBitmap.Bits[x + (y - 2) * DirectBitmap.Bitmap.Width] = color;
            }
        }

        public void DrawLine(int x, int y, int x2, int y2, int color, int width)
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
                SetPixel(x, y, color, width);
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

        public void CircleOptimized(int xc, int yc, int r, int color, int width)
        {
            int x = r;
            int y = 0;//local coords     
            int cd2 = 0;    //current distance squared - radius squared

            if (r == 0)
                return;

            SetPixel(xc - r, yc, color, width);
            SetPixel(xc + r, yc, color, width);
            SetPixel(xc, yc - r, color, width);
            SetPixel(xc, yc + r, color, width);

            while (x > y)    //only formulate 1/8 of circle
            {
                cd2 -= (--x) - (++y);
                if (cd2 < 0) cd2 += x++;

                SetPixel(xc - x, yc - y, color, width);//upper left left
                SetPixel(xc - y, yc - x, color, width);//upper upper left
                SetPixel(xc + y, yc - x, color, width);//upper upper right
                SetPixel(xc + x, yc - y, color, width);//upper right right
                SetPixel(xc - x, yc + y, color, width);//lower left left
                SetPixel(xc - y, yc + x, color, width);//lower lower left
                SetPixel(xc + y, yc + x, color, width);//lower lower right
                SetPixel(xc + x, yc + y, color, width);//lower right right
            }
        }


        public void CircleBresenham(int xc, int yc, int r, int color, int width)
        {
            int x = 0;
            int y = r;
            int p = 3 - 2 * r;
            if (r == 0)
                return;
            while (y >= x) // only formulate 1/8 of circle
            {
                SetPixel(xc - x, yc - y, color, width);//upper left left
                SetPixel(xc - y, yc - x, color, width);//upper upper left
                SetPixel(xc + y, yc - x, color, width);//upper upper right
                SetPixel(xc + x, yc - y, color, width);//upper right right
                SetPixel(xc - x, yc + y, color, width);//lower left left
                SetPixel(xc - y, yc + x, color, width);//lower lower left
                SetPixel(xc + y, yc + x, color, width);//lower lower right
                SetPixel(xc + x, yc + y, color, width);//lower right right
                if (p < 0) p += 4 * x++ + 6;
                else p += 4 * (x++ - y--) + 10;
            }
        }

    }
}
