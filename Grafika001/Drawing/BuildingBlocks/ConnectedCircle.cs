using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grafika001.Logic;

namespace Grafika001.Drawing.BuildingBlocks
{
    public class ConnectedCircle : GraphicObject
    {
        public List<Circle> Circles { get; private set; }

        public ConnectedCircle(Circle c1, Circle c2, Drawing drawing, GuidMapLogic guidMapLogic) : base(drawing, guidMapLogic)
        {
            GraphicObjectType = GraphicObjectType.ConnectedCircles;
            Circles = new List<Circle>(2);
            c1.ParentGraphicObject = this;
            c2.ParentGraphicObject = this;
            Circles.Add(c1);
            Circles.Add(c2);
        }

        public ConnectedCircle(ConnectedCircle c1, Circle c2, Drawing drawing, GuidMapLogic guidMapLogic) : base(drawing, guidMapLogic)
        {
            GraphicObjectType = GraphicObjectType.ConnectedCircles;
            Circles = new List<Circle>(2);
            Circles.AddRange(c1.Circles);
            Circles.Add(c2);
        }

        public void AddCircle(Circle circle)
        {
            Circles.Add(circle);
            circle.ParentGraphicObject = this;
        }

        public override void DrawItself()
        {
            foreach (var circle in Circles)
            {
                circle.DrawItself();
                circle.DrawOnGuidMap();
            }
        }

        public override void DrawOnGuidMap()
        {
            foreach (var circle in Circles)
            {
                circle.DrawOnGuidMap();
            }
        }

        public override void Move(int x, int y)
        {
            foreach (var circle in Circles)
            {
                circle.Center = new Point(circle.Center.X + x, circle.Center.Y + y);
            }
        }
    }
}
