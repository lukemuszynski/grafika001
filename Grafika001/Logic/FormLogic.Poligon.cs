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

        private List<Point> Clicks
        {
            get
            {
                switch (_formAction)
                {
                    case FormAction.DrawLine:
                        return _clicksDrawLine;
                    case FormAction.StartDrawPolygon:
                        return _clicksStartDrawPolygon;
                    case FormAction.StopDrawPolygon:
                        return _clicksStartDrawPolygon;
                    case FormAction.DrawCircleOptimized:
                        return _clicksDrawCircleOptimized;
                    case FormAction.SetConcrentic:
                        return _clicksSetConcerntic;
                }
                return _clicksOther;
            }
        }

        private List<Point> _clicksDrawLine;
        private List<Point> _clicksStartDrawPolygon;
        private List<Point> _clicksOther;

        private int _width;

        private TextBox _timeTextBox;
        private readonly MainForm.ButtonControl _buttonControl;
        //private const int HighlightColor = Color.Yellow.ToArgb();
        private Dictionary<Guid, GraphicObject> GraphicObjects { get; set; }
        //private Dictionary<Guid, Line> Lines { get; set; }
        private Poligon CurrentPolygon { get; set; }
        private GuidMapLogic GuidMapLogic { get; set; }



        public int Width
        {
            get { return _width == 0 ? 1 : _width; }
            set { _width = value; }
        }

        public Drawing.Drawing Drawing { get; set; }

        private FormAction _formAction;

        //private readonly Action _graphicObjectSelected;
        //private readonly Action _verticleSelected;
        //private readonly Func<int, bool> _lineSelected;
        //private readonly Action _nullSelected;
        //private readonly Action _circleSelected;

        public FormLogic(Drawing.Drawing drawing, TextBox timeTextBox, MainForm.ButtonControl buttonControl)
        {
            GraphicObjects = new Dictionary<Guid, GraphicObject>();
            //Lines = new Dictionary<Guid, Line>();
            _timeTextBox = timeTextBox;
            _buttonControl = buttonControl;
            //this._graphicObjectSelected = graphicObjectSelected;
            //this._verticleSelected = verticleSelected;
            //this._lineSelected = lineSelected;
            //_nullSelected = nullSelected;
            //_circleSelected = circleSelected;

            Drawing = drawing;
            _formAction = FormAction.NoAction;

            _clicksDrawLine = new List<Point>(128);
            _clicksStartDrawPolygon = new List<Point>(128);
            _clicksDrawCircleOptimized = new List<Point>(128);
            _clicksOther = new List<Point>(128);
            _clicksSetConcerntic = new List<Point>(128);
            GuidMapLogic = new GuidMapLogic(drawing.Height, drawing.Width);
        }

        private void CreatePoint()
        {
            Drawing.SetPixel(Clicks.Last(), Width);
            Clicks.Clear();
        }

        private void DrawLine()
        {
            if (Clicks.Count == 2)
            {
                var line = new Line(Clicks[0], Clicks[1], Width, Drawing, GuidMapLogic);
                line.DrawItself();
                GraphicObjects.Add(line.Guid, line);
                GraphicObjects.Add(line.StartVerticle.Guid, line.StartVerticle);
                GraphicObjects.Add(line.EndVerticle.Guid, line.EndVerticle);
                line.DrawOnGuidMap();
                Clicks.Clear();
            }
        }

        private void StartDrawingPolygon()
        {
            if (Clicks.Count == 1)
            {
                Poligon poligon = new Poligon(Drawing, GuidMapLogic);
                CurrentPolygon = poligon;
                GraphicObjects.Add(poligon.Guid, poligon);
                return;
            }
            var line = new Line(Clicks[Clicks.Count - 2], Clicks.Last(), Width, Drawing, GuidMapLogic, CurrentPolygon);
            CurrentPolygon.AddLine(line);
            line.DrawItself();
        }

        private void MoveObject()
        {
            var line = (SelectedObject as Line);

            var pointOnLine = Clicks[Clicks.Count - 2];
            int diffOnX = Clicks.Last().X - pointOnLine.X;
            int diffOnY = Clicks.Last().Y - pointOnLine.Y;
            SelectedObject.Move(diffOnX, diffOnY);
            Redraw();
        }

        private void DeleteObject()
        {
            if (SelectedObject.GraphicObjectType == GraphicObjectType.Verticle)
            {
                Verticle verticle = (SelectedObject as Verticle);
                Line line = (verticle.ParentGraphicObject as Line);
                Poligon poligon = line.ParentGraphicObject != null ? line.ParentGraphicObject as Poligon : null;
                if (poligon == null)
                {
                    return;
                }
                else
                {
                    var lineToDelete = poligon.DeleteVerticle(verticle);
                    GraphicObjects.Remove(lineToDelete.Guid);
                    GraphicObjects.Remove(verticle.Guid);
                }
            }
            else if (SelectedObject.GraphicObjectType == GraphicObjectType.Line)
            {
                Line line = (SelectedObject as Line);

                if (line.ParentGraphicObject == null)
                {
                    GraphicObjects.Remove(line.StartVerticle.Guid);
                    GraphicObjects.Remove(line.EndVerticle.Guid);
                    GraphicObjects.Remove(line.Guid);
                }
                else
                {
                    Poligon poligon = line.ParentGraphicObject as Poligon;
                    poligon.Lines.ForEach(x => GraphicObjects.Remove(x.Guid));
                    poligon.Verticies.ForEach(x => GraphicObjects.Remove(x.Guid));
                    GraphicObjects.Remove(poligon.Guid);
                }
            }
            else if (SelectedObject.GraphicObjectType == GraphicObjectType.Circle)
            {
                GraphicObjects.Remove(SelectedObject.Guid);
            }

            SelectedObject = null;
            Redraw();
        }

        private void MoveVerticle()
        {
            if (SelectedObject?.GraphicObjectType != GraphicObjectType.Verticle)
                return;

            Verticle verticle = (SelectedObject as Verticle);
            verticle.Point = Clicks.Last();
            SelectedObject = null;

            Redraw();
        }

        private void ClearMap()
        {
            GraphicObjects = new Dictionary<Guid, GraphicObject>();
            //Lines = new Dictionary<Guid, Line>();
            _formAction = FormAction.NoAction;

            _clicksDrawLine = new List<Point>(128);
            _clicksStartDrawPolygon = new List<Point>(128);
            _clicksDrawCircleOptimized = new List<Point>(128);
            _clicksOther = new List<Point>(128);
            _clicksSetConcerntic = new List<Point>(128);

            GuidMapLogic = new GuidMapLogic(Drawing.Height, Drawing.Width);
            Drawing.ClearBitmap();
        }

        private GraphicObject _selectedObject;

        private GraphicObject SelectedObject
        {
            get { return _selectedObject; }
            set
            {
                _selectedObject = value;
                _buttonControl.NullSelected();

                //if (_selectedObject == null)
                //    _nullSelected();
                if (_selectedObject?.GraphicObjectType == GraphicObjectType.Verticle)
                    _buttonControl.VerticleSelected();
                if (_selectedObject?.GraphicObjectType == GraphicObjectType.Poligon)
                    _buttonControl.GraphicObjectSelected();
                if (_selectedObject?.GraphicObjectType == GraphicObjectType.Line)
                    _buttonControl.LineSelected(0);
                if (_selectedObject?.GraphicObjectType == GraphicObjectType.Line && _selectedObject.ParentGraphicObject != null)
                    _buttonControl.GraphicObjectSelected();
                if (_selectedObject?.GraphicObjectType == GraphicObjectType.Circle)
                    _buttonControl.CircleSelected((_selectedObject as Circle).Radius);
            }
        }


        private void SelectObject()
        {
            GraphicObject graphicObject = null;
            Guid mapGuid = GuidMapLogic.GuidMap[Clicks.Last().X + Clicks.Last().Y * Drawing.Width];
            if (mapGuid == Guid.Empty)
            {
                //Clicks.Clear();
                return;
            }
            if (mapGuid != Guid.Empty)
            {
                graphicObject = GraphicObjects[mapGuid];
                SelectedObject = graphicObject;
                Redraw();
                HighlightObject();
            }
            //Clicks.Clear();


            //return graphicObject;
        }

        private void HighlightObject()
        {
            if (SelectedObject == null)
                return;

            switch (SelectedObject.GraphicObjectType)
            {
                case GraphicObjectType.Circle:
                    if ((SelectedObject as Circle).ParentGraphicObject != null)
                    {
                        HightLightConnectedCircles();
                        break;
                    }
                    Circle biggerCircle = ((SelectedObject as Circle).Clone() as Circle);
                    Circle smallerCircle = ((SelectedObject as Circle).Clone() as Circle);
                    biggerCircle.Radius++;
                    smallerCircle.Radius--;
                    biggerCircle.Color = Consts.HightLightColor;
                    smallerCircle.Color = Consts.HightLightColor;
                    Drawing.DrawCircle(biggerCircle);
                    Drawing.DrawCircle(smallerCircle);
                    break;
                case GraphicObjectType.Verticle:
                    Circle circle = new Circle((SelectedObject as Verticle).Point, 10, Drawing, GuidMapLogic, Consts.MediumWidth);
                    circle.Color = Consts.HightLightColor;
                    circle.DrawItself();
                    break;
                case GraphicObjectType.Line:
                    var line = (SelectedObject as Line);
                    var highlightLine = line.Clone() as Line;
                    highlightLine.Color = Consts.HightLightColor;
                    highlightLine.Width = Consts.MediumWidth;
                    highlightLine.DrawItself();

                    break;
                case GraphicObjectType.ConnectedCircles:
                    
                    break;
            }
        }


        private FormAction[] NewObjectsActions =
            new[]{ FormAction.DrawLine,
            FormAction.DrawCircleOptimized,
            FormAction.DrawCircleBresenham,
            FormAction.StartDrawPolygon,
            FormAction.StopDrawPolygon};

        public void SetAction(FormAction action)
        {
            if (_formAction == FormAction.SelectLine && action != FormAction.SelectLine)
                Redraw();

            if (NewObjectsActions.Contains(action))
            {
                SelectedObject = null;
                //_clicksOther.Clear();
            }

            _formAction = action;
            if (action == FormAction.StartDrawPolygon)
            {
                _buttonControl.StartDrawingPoligon();
                Clicks.Clear();
            }
            if (action == FormAction.StopDrawPolygon)
                StopDrawPolygon();
            else if (action == FormAction.ClearBitmap)
                ClearMap();
            else if (action == FormAction.DeleteObject)
                DeleteObject();
            else if (action == FormAction.DrawCircleOptimized)
                _buttonControl.CircleSelected(Radius);
            else if (action == FormAction.AddVerticle)
                AddVerticle();
            else if (action == FormAction.SetHorizontal)
                SetHorizontal();
            else if (action == FormAction.SetVertical)
                SetVertical();
            else if (action == FormAction.SetConcrentic)
            {
                Clicks.Clear();
                ConnectedCircles.Clear();
            }
            //else if(action == FormAction.RedrawBitmap)
            //    Redraw();
        }

        public void Click(Point point)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Clicks.Add(point);
            switch (_formAction)
            {
                case FormAction.SetPixel:
                    CreatePoint();
                    break;
                case FormAction.DrawLine:
                    DrawLine();
                    break;
                case FormAction.StartDrawPolygon:
                    StartDrawingPolygon();
                    break;
                case FormAction.SelectLine:
                    SelectObject();
                    break;
                case FormAction.DrawCircleOptimized:
                    DrawCircle();
                    break;
                case FormAction.RedrawBitmap:
                    Redraw();
                    break;
                case FormAction.MoveObject:
                    MoveObject();
                    break;
                case FormAction.MoveVerticle:
                    MoveVerticle();
                    break;
                case FormAction.SetConcrentic:
                    SetConcrentic();
                    break;
            }
            stopWatch.Stop();
            _timeTextBox.Text = stopWatch.Elapsed.TotalSeconds.ToString();
        }

        private void SetHorizontal()
        {
            (SelectedObject as Line).SetHorizontal();
            Redraw();
        }

        private void SetVertical()
        {
            (SelectedObject as Line).SetVertical();
            Redraw();
        }

        private void AddVerticle()
        {
            var line = (SelectedObject as Line);
            Point newVerticlePoint = Clicks.Last();
            var newLine = (line.ParentGraphicObject as Poligon).InsertLine(line, newVerticlePoint);
            GraphicObjects.Add(newLine.Guid, newLine);
            GraphicObjects.Add(newLine.StartVerticle.Guid, newLine.StartVerticle);
            Redraw();
        }

        private void StopDrawPolygon()
        {
            if (Clicks.Count > 2)
            {
                var line = new Line(Clicks.Last(), Clicks.First(), Width, Drawing, GuidMapLogic, CurrentPolygon);
                CurrentPolygon.AddLastLine(line);
                line.DrawItself();

                CurrentPolygon
                     .Lines.ForEach(poligonLine => GraphicObjects.Add(poligonLine.Guid, poligonLine));

                CurrentPolygon
                     .Verticies.ForEach(poligonVerticle => GraphicObjects.Add(poligonVerticle.Guid, poligonVerticle));

                CurrentPolygon.DrawOnGuidMap();
                //GuidMapLogic.SetOnMap(CurrentPolygon);
            }
            _buttonControl.StopDrawingPoligon();
            Clicks.Clear();
        }

        private void Redraw()
        {
            Drawing.ClearBitmap();
            GuidMapLogic.ClearGuidMap();

            foreach (var graphicObjectDictPair in GraphicObjects)
            {
                graphicObjectDictPair.Value.DrawItself();

                if (graphicObjectDictPair.Value.ParentGraphicObject == null)
                    graphicObjectDictPair.Value.DrawOnGuidMap();
            }
        }

        public void ChangeOrSetColor(int color)
        {
            if (SelectedObject?.GraphicObjectType == GraphicObjectType.Line && SelectedObject.ParentGraphicObject != null)
                (SelectedObject.ParentGraphicObject as Poligon).Lines.ForEach(x => x.Color = color);

            else if (SelectedObject?.GraphicObjectType == GraphicObjectType.Line)
                (SelectedObject as Line).Color = color;

            else if (SelectedObject?.GraphicObjectType == GraphicObjectType.Circle)
                (SelectedObject as Circle).Color = color;
            Redraw();
        }

        public void ChangeLength(int i)
        {
            //if (SelectedObject.GraphicObjectType == GraphicObjectType.Line)
            //{
            //    var line = (SelectedObject as Line);
            //    int midX = (line.StartPoint.X + line.EndPoint.X) / 2;
            //    int midY = (line.StartPoint.Y + line.EndPoint.Y) / 2;

            //}
        }
    }

    public enum FormAction
    {
        NoAction,
        DrawLine,
        SetPixel,
        StartDrawPolygon,
        StopDrawPolygon,
        SelectLine,
        DrawCircleOptimized,
        DrawCircleBresenham,
        ClearBitmap,
        RedrawBitmap,
        MoveVerticle,
        DeleteObject,
        MoveObject,
        AddVerticle,
        SetHorizontal,
        SetVertical,
        SetConcrentic
    }

}
