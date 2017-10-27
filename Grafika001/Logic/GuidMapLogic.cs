using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grafika001.Drawing;
using Grafika001.Drawing.BuildingBlocks;

namespace Grafika001.Logic
{
    public class GuidMapLogic
    {
        public Guid[] GuidMap { get; set; }

        public int DrawingWidth { get; set; }

        public GuidMapLogic(int drawingHeight, int drawingWidth)
        {
            DrawingWidth = drawingWidth;
            GuidMap = new Guid[drawingHeight * drawingWidth];
        }

        public void ClearGuidMap()
        {
            GuidMap = new Guid[GuidMap.Length];
        }

        public void SetOnMap(List<Line> lines, Poligon poligon)
        {
            foreach (var line in lines)
            {
                DrawGuidLine(line.StartPoint.X,
                    line.StartPoint.Y,
                    line.EndPoint.X,
                    line.EndPoint.Y,
                    line.Width,
                    line.Guid);
            }
        }

        public void SetOnMap(Line line)
        {
            DrawGuidLine(line.StartPoint.X,
                  line.StartPoint.Y,
                  line.EndPoint.X,
                  line.EndPoint.Y,
                  line.Width,
                  line.Guid);

            SetGuid(line.StartPoint.X, line.StartPoint.Y, line.StartVerticle.Guid, Consts.MediumWidth);
            SetGuid(line.EndPoint.X, line.EndPoint.Y, line.EndVerticle.Guid, Consts.MediumWidth);
        }

        public void SetOnMap(Poligon poligon)
        {
            foreach (var line in poligon.Lines)
            {
                DrawGuidLine(line.StartPoint.X,
                   line.StartPoint.Y,
                   line.EndPoint.X,
                   line.EndPoint.Y,
                   line.Width,
                   line.Guid);
            }
            foreach (var verticle in poligon.Verticies)
            {
                SetGuid(verticle.Point.X, verticle.Point.Y, verticle.Guid, Consts.MediumWidth);
            }
        }

        public void SetOnMap(Circle circle)
        {
            SetGuidCircleOptimized(circle.Center.X, circle.Center.Y, circle.Radius, circle.Guid, circle.Width);
        }

        private void DrawGuidLine(int x, int y, int x2, int y2, int width, Guid lineGuid)
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
                SetGuid(x, y, lineGuid, width);
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

        private void SetGuid(int x, int y, Guid guid, int width)
        {
            if (x + y * DrawingWidth < 0 || x + y * DrawingWidth >= GuidMap.Length)
                return;

            if (width == Consts.MediumWidth)
            {
                if (x - 1 + (y) * DrawingWidth < 0 || x - 1 + (y) * DrawingWidth >= GuidMap.Length) return;
                if (x + 1 + (y) * DrawingWidth < 0 || x + 1 + (y) * DrawingWidth >= GuidMap.Length) return;
                if (x + (y + 1) * DrawingWidth < 0 || x + (y + 1) * DrawingWidth >= GuidMap.Length) return;
                if (x + (y - 1) * DrawingWidth < 0 || x + (y - 1) * DrawingWidth >= GuidMap.Length) return;
            }
            if (width == Consts.BigWidth)
            {
                if (x + (y + 2) * DrawingWidth < 0 || x + (y + 2) *DrawingWidth >= GuidMap.Length) return;
                if (x - 2 + (y) * DrawingWidth < 0 || x - 2 + (y) *DrawingWidth >= GuidMap.Length) return;
                if (x + (y - 2) * DrawingWidth < 0 || x + (y - 2) *DrawingWidth >= GuidMap.Length) return;
                if (x + 2 + (y) * DrawingWidth < 0 || x + 2 + (y) * DrawingWidth >= GuidMap.Length) return;
            }

            GuidMap[x + y * DrawingWidth] = guid;
            if (width == Consts.MediumWidth)
            {
                GuidMap[x - 1 + (y) * DrawingWidth] = guid;
                GuidMap[x + 1 + (y) * DrawingWidth] = guid;
                GuidMap[x + (y + 1) * DrawingWidth] = guid;
                GuidMap[x + (y - 1) * DrawingWidth] = guid;
            }
            if (width == Consts.BigWidth)
            {
                GuidMap[x + (y + 2) * DrawingWidth] = guid;
                
                GuidMap[x - 1 + (y + 1) * DrawingWidth] = guid;
                GuidMap[x + (y + 1) * DrawingWidth] = guid;
                GuidMap[x + 1 + (y + 1) * DrawingWidth] = guid;
                
                GuidMap[x - 2 + (y) * DrawingWidth] = guid;
                GuidMap[x - 1 + (y) * DrawingWidth] = guid;
                GuidMap[x + (y) * DrawingWidth] = guid;
                GuidMap[x + 1 + (y) * DrawingWidth] = guid;
                GuidMap[x + 2 + (y) * DrawingWidth] = guid;
                
                GuidMap[x - 1 + (y - 1) * DrawingWidth] = guid;
                GuidMap[x + (y - 1) * DrawingWidth] = guid;
                GuidMap[x + 1 + (y - 1) * DrawingWidth] = guid;
                
                GuidMap[x + (y - 2) * DrawingWidth] = guid;
            }
        }

        private void SetGuidCircleOptimized(int xc, int yc, int r, Guid guid, int width)
        {
            int x = r;
            int y = 0;//local coords     
            int cd2 = 0;    //current distance squared - radius squared

            if (r == 0)
                return;

            SetGuid(xc - r, yc, guid, width);
            SetGuid(xc + r, yc, guid, width);
            SetGuid(xc, yc - r, guid, width);
            SetGuid(xc, yc + r, guid, width);

            while (x > y)    //only formulate 1/8 of circle
            {
                cd2 -= (--x) - (++y);
                if (cd2 < 0) cd2 += x++;

                SetGuid(xc - x, yc - y, guid, width);//upper left left
                SetGuid(xc - y, yc - x, guid, width);//upper upper left
                SetGuid(xc + y, yc - x, guid, width);//upper upper right
                SetGuid(xc + x, yc - y, guid, width);//upper right right
                SetGuid(xc - x, yc + y, guid, width);//lower left left
                SetGuid(xc - y, yc + x, guid, width);//lower lower left
                SetGuid(xc + y, yc + x, guid, width);//lower lower right
                SetGuid(xc + x, yc + y, guid, width);//lower right right
            }
        }

        public void SetOnMap(Verticle verticle)
        {
            SetGuid(verticle.Point.X, verticle.Point.Y, verticle.Guid, verticle.Width);
        }
    }
}
