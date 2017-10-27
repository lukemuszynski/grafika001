using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grafika001.Logic;

namespace Grafika001.Drawing.BuildingBlocks
{
    public class Circle : GraphicObject, ICloneable
    {
        public Point Center { get; set; }

        public int Radius { get; set; }

        public int Width { get; set; }

        public Circle(Point p, int radius, Drawing drawing, GuidMapLogic guidMapLogic, int width) : base(drawing, guidMapLogic)
        {
            GraphicObjectType = GraphicObjectType.Circle;
            Center = p;
            Radius = radius;
            Width = width;
        }

        public override void DrawItself()
        {
            Drawing.DrawCircle(this);
        }

        public override void DrawOnGuidMap()
        {
            GuidMapLogic.SetOnMap(this);
        }

        public object Clone()
        {
            return new Circle(Center, Radius, Drawing, GuidMapLogic,Width);
        }

        public override void Move(int x, int y)
        {
            if (ParentGraphicObject == null)
            {
                Center = new Point(Center.X + x, Center.Y + y);
            }
            else
                ParentGraphicObject.Move(x, y);
        }
    }
}
