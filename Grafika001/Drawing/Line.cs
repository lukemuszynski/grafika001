using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grafika001.Drawing.BuildingBlocks;
using Grafika001.Logic;

namespace Grafika001.Drawing
{
    public class Line : GraphicObject, ICloneable
    {
        public Line(Point startPoint,
            Point endPoint,
            int width, Drawing drawing,
            GuidMapLogic guidMapLogic,
            GraphicObject parentGraphicObject = null) : base(drawing, guidMapLogic)
        {
            //StartPoint = startPoint;
            //EndPoint = endPoint;
            Width = width;
            ParentGraphicObject = parentGraphicObject;

            GraphicObjectType = GraphicObjectType.Line;

            StartVerticle = new Verticle(startPoint, drawing, guidMapLogic, this);
            StartVerticle.ParentGraphicObject = this;

            EndVerticle = new Verticle(endPoint, drawing, guidMapLogic, this);
            EndVerticle.ParentGraphicObject = this;
        }

        public Point StartPoint
        {
            get { return StartVerticle.Point; }
        }

        public Point EndPoint
        {
            get { return EndVerticle.Point; }
        }

        public int Width { get; set; }

        private Verticle _startVerticle;
        private Verticle _endVerticle;

        public Verticle StartVerticle
        {
            get { return _startVerticle; }
            set { _startVerticle = value;
                IsHorizontal = false;
                IsVertical = false;
            }
        }

        public Verticle EndVerticle
        {
            get { return _endVerticle; }
            set
            {
                _endVerticle = value;
                IsHorizontal = false;
                IsVertical = false;
            }
        }

        public bool IsVertical { get; private set; }
        public bool IsHorizontal { get; private set; }

        public void SetVertical()
        {
            if (ParentGraphicObject != null && (ParentGraphicObject as Poligon).IwantToBeVertical(this))
            {
                IsHorizontal = true;
                IsVertical = false;
                int newX = (StartVerticle.Point.X + EndVerticle.Point.X) / 2;

                StartVerticle.Point = new Point(newX, StartVerticle.Point.Y);
                EndVerticle.Point = new Point(newX, EndVerticle.Point.Y);
            }
        }

        public void SetHorizontal()
        {
           
            if (ParentGraphicObject != null && (ParentGraphicObject as Poligon).IwantToBeHorizontal(this))
            {
                IsVertical = true;
                IsHorizontal = false;
                int newY = (StartVerticle.Point.Y + EndVerticle.Point.Y) / 2;
                StartVerticle.Point = new Point(StartVerticle.Point.X, newY);
                EndVerticle.Point = new Point(EndVerticle.Point.X, newY);
            }
        }

        public override void DrawItself()
        {
            Drawing.DrawLine(this);
            Drawing.SetPixel(StartVerticle.Point, StartVerticle.Width, System.Drawing.Color.Blue.ToArgb());
            Drawing.SetPixel(EndVerticle.Point, StartVerticle.Width, System.Drawing.Color.Blue.ToArgb());
        }

        public override void DrawOnGuidMap()
        {
            GuidMapLogic.SetOnMap(this);
        }

        public object Clone()
        {
            return new Line(StartPoint, EndPoint, Width, Drawing, GuidMapLogic);
        }

        public override void Move(int x, int y)
        {
            if (ParentGraphicObject == null)
            {
                StartVerticle.Point = new Point(StartPoint.X + x, StartPoint.Y + y);
                EndVerticle.Point = new Point(EndPoint.X + x, EndPoint.Y + y);
            }
            else
                ParentGraphicObject.Move(x, y);
        }
    }
}
