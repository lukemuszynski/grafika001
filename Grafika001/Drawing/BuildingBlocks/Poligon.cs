using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grafika001.Logic;

namespace Grafika001.Drawing.BuildingBlocks
{
    public class Poligon : GraphicObject
    {
        public Poligon(Drawing drawing, GuidMapLogic guidMapLogic) : base(drawing, guidMapLogic)
        {
            GraphicObjectType = GraphicObjectType.Poligon;
            Lines = new List<Line>();
            Verticies = new List<Verticle>();
        }

        public List<Line> Lines { get; private set; }
        public List<Verticle> Verticies { get; private set; }

        public void AddLine(Line line)
        {
            Lines.Add(line);
            line.ParentGraphicObject = this;

            if (Verticies.Any())
                line.StartVerticle = Verticies.Last();

            if (!Verticies.Any())
                Verticies.Add(line.StartVerticle);

            Verticies.Add(line.EndVerticle);
        }

        public void AddLastLine(Line line)
        {
            Lines.Add(line);
            line.StartVerticle = Verticies.Last();
            line.EndVerticle = Verticies.First();
        }

        public override void DrawItself()
        {
            foreach (var line in Lines)
            {
                line.DrawItself();
            }
            Fill();
        }

        public override void DrawOnGuidMap()
        {
            GuidMapLogic.SetOnMap(this);
        }

        public Line DeleteVerticle(Verticle verticle)
        {
            var lastLine = Lines.Where(x => x.StartVerticle == verticle).FirstOrDefault();
            var firstLine = Lines.Where(x => x.EndVerticle == verticle).FirstOrDefault();
            firstLine.EndVerticle = lastLine.EndVerticle;
            Verticies.Remove(verticle);
            Lines.Remove(lastLine);
            return lastLine;
        }

        public override void Move(int x, int y)
        {
            if (ParentGraphicObject == null)
            {
                foreach (var verticle in Verticies)
                {
                    verticle.Point = new Point(verticle.Point.X + x, verticle.Point.Y + y);
                }
            }
        }

        public Line InsertLine(Line line, Point newVerticlePoint)
        {
            int lineIndex = Lines.FindIndex(x => x.Guid == line.Guid);
            var newLine = new Line(newVerticlePoint, line.EndPoint, line.Width, Drawing, GuidMapLogic, this);
            newLine.EndVerticle = line.EndVerticle;
            line.EndVerticle = newLine.StartVerticle;
            Lines.Insert(lineIndex, newLine);
            Verticies.Add(newLine.StartVerticle);
            return newLine;
        }

        public bool IwantToBeVertical(Line line)
        {
            int index = Lines.FindIndex(x => x.Guid == line.Guid);

            int prevIndex, nextIndex;
            if (index == 0)
            {
                prevIndex = Lines.Count - 1;
            }
            else
            {
                prevIndex = index - 1;
            }
            if (index == Lines.Count - 1)
                nextIndex = 0;
            else
                nextIndex = index + 1;

            if (!Lines[prevIndex].IsHorizontal && !Lines[nextIndex].IsHorizontal)
                return true;

            return false;
        }

        public bool IwantToBeHorizontal(Line line)
        {
            int index = Lines.FindIndex(x => x.Guid == line.Guid);

            int prevIndex, nextIndex;
            if (index == 0)
            {
                prevIndex = Lines.Count - 1;
            }
            else
            {
                prevIndex = index - 1;
            }
            if (index == Lines.Count - 1)
                nextIndex = 0;
            else
                nextIndex = index + 1;

            if (!Lines[prevIndex].IsVertical && !Lines[nextIndex].IsVertical)
                return true;

            return false;
        }

        public bool Fill()
        {
            int n = Verticies.Count;
            List<SortedLine> sortedLines = new List<SortedLine>();
            List<SortedLine> currentSortedLines = new List<SortedLine>();

            Line tempLine;
            for (int i = 0; i < Lines.Count; i++)
            {
                tempLine = Lines[i];
                Point lowerPoint, higherPoint;

                if (tempLine.StartPoint.Y > tempLine.EndPoint.Y)
                {
                    lowerPoint = tempLine.EndPoint;
                    higherPoint = tempLine.StartPoint;
                }
                else
                {
                    lowerPoint = tempLine.StartPoint;
                    higherPoint = tempLine.EndPoint;
                }
                var sortedLine = new SortedLine()
                {
                    Ymin = lowerPoint.Y,
                    Ymax = higherPoint.Y,
                    X = lowerPoint.X,
                    Line = tempLine,
                    IndexInLines = i,
                    A = (float)(higherPoint.Y - lowerPoint.Y) / (float)(higherPoint.X - lowerPoint.X)
                };
                sortedLines.Add(sortedLine);

            }

            sortedLines.Sort((x, y) => y.Ymin - x.Ymin);

            currentSortedLines.Add(sortedLines[0]);
            currentSortedLines.Add(sortedLines[1]);
            for (int i = currentSortedLines[0].Ymin; i < currentSortedLines[0].Ymax; i++)
            {
                Drawing.DrawLine((int)currentSortedLines[0].X,i, (int)currentSortedLines[1].X,i, currentSortedLines[0].Line.Color,Consts.SmallWidth);
                currentSortedLines[0].X += currentSortedLines[0].A;
                currentSortedLines[1].X += currentSortedLines[1].A;

                if (i == currentSortedLines[1].Ymax)
                    break;
            }
            return true;
        }

        private class SortedLine
        {
            public int Ymax { get; set; }
            public float X { get; set; }
            public int Ymin { get; set; }
            public float A { get; set; }
            public Line Line { get; set; }
            public int IndexInLines { get; set; }
        }

    }
}
