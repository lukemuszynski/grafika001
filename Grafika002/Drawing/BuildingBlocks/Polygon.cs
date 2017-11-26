using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grafika002.ExtensionMethods;

namespace Grafika002.Drawing.BuildingBlocks
{
    public class Polygon
    {
        private Color _color;
        public List<Point> Points { get; private set; }
        public bool FillEnabled { get; set; }
        private IDrawing _drawing;

        public int FillingColor { get; set; }

        public Polygon(IDrawing drawing)
        {
            Points = new List<Point>();
            _drawing = drawing;
            _color = Color.Aqua;
            FillingColor = Color.Chocolate.ToArgb();
            FillEnabled = false;
        }

        public int MoveRigth()
        {
            int maxRigth = 0;
            for (int i = 0; i < Points.Count; i++)
            {
                Points[i] = new Point(Points[i].X + 1, Points[i].Y);
                //todo przetrzymywac gdzies najbardziej prawy element
                if (maxRigth < Points[i].X)
                    maxRigth = Points[i].X;
            }
            return maxRigth;
        }

        public void FinnishDrawing()
        {
            if (Points.Count > 1)
                _drawing.DrawLine(Points[0], Points[Points.Count - 1], _color);
            else
                return;
        }

        public void DrawPolygon(bool fill = false)
        {
            if (Points.Count > 1)
            {
                for (int i = 1; i < Points.Count; i++)
                    _drawing.DrawLine(Points[i - 1], Points[i], _color);

                _drawing.DrawLine(Points.First(), Points.Last(), _color);
            }
            if (fill || FillEnabled)
                Fill();
        }

        private void Fill()
        {
            if (Points.Count < 3)
                return;

            List<SortedLine> sortedLines = new List<SortedLine>(Points.Count);
            List<SortedLine> currentLines = new List<SortedLine>(Points.Count);

            for (int i = 1; i < Points.Count; i++)
            {
                sortedLines.Add(new SortedLine(Points[i], Points[i - 1], i));
            }
            sortedLines.Add(new SortedLine(Points[0], Points[Points.Count - 1], 0));
            sortedLines.Sort((p1, p2) => p1.Ymin - p2.Ymin);

            int currentSortedLinesIndex = 0;

            Point point1 = default(Point), point2 = default(Point);

            for (int i = sortedLines[0].Ymin; i < sortedLines.Last().Ymax; i++)
            {
                while (currentSortedLinesIndex < sortedLines.Count && sortedLines[currentSortedLinesIndex].Ymin == i)
                {
                    currentLines.Add(sortedLines[currentSortedLinesIndex]);
                    ++currentSortedLinesIndex;
                    currentLines.Sort((x, y) => (int)(x.X - y.X));
                }
                int removed = currentLines.RemoveAll(x => x.Ymax == i);
                if (removed > 0)
                {
                    int g = 124;
                }
                if (currentLines.Count > 1)
                {
                    Color fillingColor = Color.FromArgb(FillingColor);
                    for (int j = 0; j < currentLines.Count - 1; j += 2)
                    {
                        point1.X = (int) currentLines[j].X;
                        point1.Y = i;

                        point2.X = (int) currentLines[j + 1].X;
                        point2.Y = i;

                        _drawing.DrawHorizontalLine(i, point1.X, point2.X, fillingColor);

                        currentLines[j].MoveX();
                        currentLines[j + 1].MoveX();
                    }
                }
            }
        }

        public void AddVerticle(Point p, bool drawLine = true)
        {
            Points.Add(p);

            if (Points.Count > 1 && drawLine)
            {
                _drawing.DrawLine(Points[Points.Count - 2], Points[Points.Count - 1], _color);
            }
        }

        public void AddVerticle(Point[] p, bool drawLines = false)
        {
            Points.AddRange(p);
            if (drawLines)
                DrawPolygon();
        }

        public static Polygon RandomPolygon(IDrawing drawing)
        {
            int vertices = rand.Next(3, 10);
            var points = Polygon.MakeRandomPolygon(vertices);
            var polygon = new Polygon(drawing);
            polygon.FillingColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256)).ToArgb();
            polygon.AddVerticle(points);
            return polygon;
        }

        private static Random rand = new Random();

        public static Point[] MakeRandomPolygon(int num_vertices)
        {
            // Pick random radii.
            Point[] points = new Point[num_vertices];

            List<double> onCircle  = new List<double>(num_vertices);
            for (int i = 0; i < num_vertices; i++)
                onCircle.Add(rand.NextDouble()*6);
            onCircle.Sort();
            int x0 = 100;
            int y0 = 200;
            for (int i = 0; i < num_vertices; i++)
            {
                points[i].X = (int)(x0 + 100 * Math.Cos(onCircle[i]));
                points[i].Y = (int)(y0 + 100 * Math.Sin(onCircle[i]));
            }

            return points;
        }

        public double LengthFromPoint(Point point)
        {
            double minimal = double.MaxValue;
            for(int i=1;i<Points.Count; i++)
            {
                Point l1 = Points[i];
                Point l2 = Points[i-1];
                var length = Math.Abs((l2.X - l1.X) * (l1.Y - point.Y) - (l1.X - point.X) * (l2.Y - l1.Y)) /
                             Math.Sqrt(Math.Pow(l2.X - l1.X, 2) + Math.Pow(l2.Y - l1.Y, 2));
                if (length < minimal)
                    minimal = length;
            }
            return minimal;
        }

        private class SortedLine
        {
            public int Ymax { get; set; }
            public float X { get; set; }
            public int Ymin { get; set; }
            public float A { get; set; }
            public int IndexInLines { get; set; }

            public SortedLine(Point p1, Point p2, int i)
            {
                Point lowerPoint, higherPoint;
                if (p1.Y >= p2.Y)
                {
                    lowerPoint = p2;
                    higherPoint = p1;
                }
                else
                {
                    lowerPoint = p1;
                    higherPoint = p2;
                }
                Ymin = lowerPoint.Y;
                Ymax = higherPoint.Y;
                X = lowerPoint.X;
                IndexInLines = i;
                A = 1 / ((float)(higherPoint.Y - lowerPoint.Y) / (float)(higherPoint.X - lowerPoint.X));
            }

            public void MoveX()
            {
                X += A;
            }
        }
    }
}
