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
    }
}
