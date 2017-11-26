using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grafika001.Drawing;
using Grafika001.Drawing.BuildingBlocks;

namespace Grafika001.Logic
{
    public partial class FormLogic
    {

       

        private List<Point> _clicksDrawCircleOptimized;

        private List<Point> _clicksSetConcerntic;


        private int _radius;


        public int Radius
        {
            get { return _radius < 15 ? 15 : _radius; }
            set { _radius = value; }
        }




        //private readonly Action _graphicObjectSelected;
        //private readonly Action _verticleSelected;
        //private readonly Func<int, bool> _lineSelected;
        //private readonly Action _nullSelected;
        //private readonly Action _circleSelected;


        private void DrawCircle()
        {
            var circle = new Circle(Clicks.Last(), Radius, Drawing, GuidMapLogic, Width);
            GraphicObjects.Add(circle.Guid, circle);
            circle.DrawItself();
            circle.DrawOnGuidMap();
            //GuidMapLogic.SetOnMap(circle);
            Clicks.Clear();
        }

        List<Circle> ConnectedCircles = new List<Circle>();

        private void SetConcrentic()
        {
            Guid mapGuid = GuidMapLogic.GuidMap[Clicks.Last().X + Clicks.Last().Y * Drawing.Width];
            GraphicObject graphicObject = null;

            //Guid mapGuiFirstCircle = GuidMapLogic.GuidMap[Clicks.First().X + Clicks.First().Y * Drawing.Width];

            if (mapGuid != Guid.Empty)
            {
                ConnectedCircle connectedCircle;
                graphicObject = GraphicObjects[mapGuid];

                if (GraphicObjects[mapGuid].GraphicObjectType == GraphicObjectType.Circle)
                    ConnectedCircles.Add(GraphicObjects[mapGuid] as Circle);


                if (graphicObject.GraphicObjectType == GraphicObjectType.Circle)
                {
                    var firstCircle = ConnectedCircles.FirstOrDefault();
                    var circle = ConnectedCircles.LastOrDefault();
                    if (ConnectedCircles.Count > 1)
                    {
                        if (firstCircle.ParentGraphicObject == null)
                        {
                            connectedCircle = new ConnectedCircle(firstCircle, circle, Drawing, GuidMapLogic);
                            firstCircle.ParentGraphicObject = connectedCircle;
                            circle.ParentGraphicObject = connectedCircle;
                            circle.Center = firstCircle.Center;
                            GraphicObjects.Add(connectedCircle.Guid, connectedCircle);
                        }
                        else
                        {
                            circle.Center = firstCircle.Center;
                            (firstCircle.ParentGraphicObject as ConnectedCircle).AddCircle(circle);
                        }
                    }
                }
            }

            Redraw();

        }



        public void ChangeRadius(int r)
        {
            Radius = r;
            if (SelectedObject?.GraphicObjectType == GraphicObjectType.Circle)
            {
                (SelectedObject as Circle).Radius = r;
                HighlightObject();
                Redraw();
            }
        }





        public void HightLightConnectedCircles()
        {
            List<Circle> CirclesToHighligth = new List<Circle>();
            var connectedCirle = (SelectedObject as Circle).ParentGraphicObject as ConnectedCircle;
            foreach (var circle1 in connectedCirle.Circles)
            {
                Circle biggerCircle1 = (circle1.Clone() as Circle);
                Circle smallerCircle1 = (circle1.Clone() as Circle);
                biggerCircle1.Radius += 5;
                smallerCircle1.Radius -= 5;
                biggerCircle1.Color = Consts.HightLightColor;
                smallerCircle1.Color = Consts.HightLightColor;
                CirclesToHighligth.Add(biggerCircle1);
                CirclesToHighligth.Add(smallerCircle1);
                //Drawing.DrawCircle(biggerCircle1);
                //Drawing.DrawCircle(smallerCircle1);
            }
            CirclesToHighligth.ForEach(x => Drawing.DrawCircle(x));

        }

    }


}
