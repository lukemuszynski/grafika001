using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grafika001.Logic;

namespace Grafika001.Drawing.BuildingBlocks
{
    public class Verticle : GraphicObject
    {
        public Verticle(Point point, Drawing drawing, GuidMapLogic guidMapLogic, GraphicObject parentObjectGuid = null) : base(drawing, guidMapLogic)
        {
            GraphicObjectType = GraphicObjectType.Verticle;
            Point = point;
            ParentGraphicObject = parentObjectGuid;
            Color = System.Drawing.Color.Blue.ToArgb();
            Width = Consts.BigWidth;
        }
        public Point Point { get; set; }
        public int Width { get; set; }

        public override void DrawItself()
        {
            Drawing.SetPixel(Point, Width, Color);
        }

        public override void DrawOnGuidMap()
        {
            GuidMapLogic.SetOnMap(this);
        }

        public override void Move(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
