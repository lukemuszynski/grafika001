using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grafika001.Logic;

namespace Grafika001.Drawing.BuildingBlocks
{
    public abstract class GraphicObject
    {
        public GraphicObjectType GraphicObjectType
        {
            get;
            protected set;
        }

        public Guid Guid { get; }
        public int Color { get; set; }

        protected Drawing Drawing { get; set; }
        protected GuidMapLogic GuidMapLogic { get; set; }
        public GraphicObject ParentGraphicObject { get; set; }

        public GraphicObject(Drawing drawing, GuidMapLogic guidMapLogic)
        {
            Drawing = drawing;
            Color = drawing.Color;//System.Drawing.Color.MediumSpringGreen.ToArgb();
            Guid = Guid.NewGuid();
            GuidMapLogic = guidMapLogic;
        }

        public override int GetHashCode()
        {
            return Guid.GetHashCode();
        }

        public abstract void DrawItself();

        public abstract void DrawOnGuidMap();

        public abstract void Move(int x, int y);

    }
}
