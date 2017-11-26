using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using Grafika002.Drawing;
using Grafika002.Drawing.BuildingBlocks;

namespace Grafika002
{
    public partial class Form1 : Form
    {
        private DirectBitmap directBitmap;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
        private Drawing.Drawing _drawing;

        private Polygon polygon;

        private Polygon animationPolygon;

        private List<Polygon> Polygons { get; set; }


        public Form1()
        {
            InitializeComponent();
            Polygons = new List<Polygon>();
            directBitmap = new DirectBitmap(mainPictureBox.Width, mainPictureBox.Height);
            this.mainPictureBox.Image = directBitmap.Bitmap;
            _drawing = new Drawing.Drawing(directBitmap);
        }

        private void StartDrawingClick(object sender, EventArgs e)
        {
            polygon = new Polygon(_drawing);
            Polygons.Add(polygon);
        }

        private void StopDrawingClick(object sender, EventArgs e)
        {
            polygon?.FinnishDrawing();
            polygon = new Polygon(_drawing);
            Polygons.Add(polygon);
            RedrawPolygons();
        }

        private void mainPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (_deletePolygon)
            {
                MainPictureBoxDeletePolygon(new Point(e.X, e.Y));
            }
            else
            {
                polygon?.AddVerticle(new Point(e.X, e.Y));
                this.mainPictureBox.Image = directBitmap.Bitmap;
            }
        }


        private void IntersectAllPolygons(object sender, EventArgs e)
        {
            Polygons.RemoveAll(x => x.Points.Count < 3);

            if (Polygons.Count < 2)
                return;

            Polygon intersectedPolygon = Polygons.FirstOrDefault();

            if (intersectedPolygon == null)
                return;

            var intersectedPoints = SutherlandHodgman.GetIntersectedPolygon(Polygons[0].Points.ToArray(), Polygons[1].Points.ToArray());

            Polygon intersectedPolygn = new Polygon(_drawing);
            foreach (var intersectedPoint in intersectedPoints)
            {
                intersectedPolygn.AddVerticle(intersectedPoint);
            }
            intersectedPolygn.FillingColor = Color.Crimson.ToArgb();
            intersectedPolygn.FinnishDrawing();

            this.mainPictureBox.Image = directBitmap.Bitmap;
        }


        private void IntersectAllPolygonsWithAnimationPolygon()
        {
            Polygons.RemoveAll(x => x.Points.Count < 3);

            Polygon intersectedPolygon = Polygons.FirstOrDefault();

            if (intersectedPolygon == null)
                return;

            for (int i = 0; i < Polygons.Count; i++)
            {
                if (Polygons[i] == animationPolygon)
                    continue;

                var intersectedPoints = SutherlandHodgman.GetIntersectedPolygon(Polygons[i].Points.ToArray(), animationPolygon.Points.ToArray());

                Polygon intersectedPolygn = new Polygon(_drawing);
                intersectedPolygn.AddVerticle(intersectedPoints);
                intersectedPolygn.FillingColor = Color.Crimson.ToArgb();
                intersectedPolygn.DrawPolygon(true);
            }

        }

        private bool _continueAnimation = false;
        private void StartAnimation(object sender, EventArgs e)
        {
            _continueAnimation = true;
            LockButtons(ActionType.animation);

            animationPolygon = Polygon.RandomPolygon(_drawing);

            animationPolygon.FinnishDrawing();
            Polygons.Add(animationPolygon);

            int maxRight = 0;
            while (_continueAnimation && maxRight < mainPictureBox.Width)
            {
                lock (this.mainPictureBox.Image)
                {
                    _drawing.ClearBitmap();
                    Polygons.ForEach(x => x.DrawPolygon());
                    maxRight = animationPolygon.MoveRigth();
                    IntersectAllPolygonsWithAnimationPolygon();
                    this.mainPictureBox.Image = directBitmap.Bitmap;
                    mainPictureBox.Update();
                    mainPictureBox.Refresh();
                    Application.DoEvents();
                }
            }
            Polygons.Remove(animationPolygon);
            _drawing.ClearBitmap();
            Polygons.ForEach(x => x.DrawPolygon());
            this.mainPictureBox.Image = directBitmap.Bitmap;
            LockButtons(ActionType.animation,true);
        }

        private void LockButtons(ActionType actionType, bool enabled = false)
        {
            if (actionType == ActionType.animation)
            {
                IntersectAllPolygonsButton.Enabled = enabled;
                StartAnimationButton.Enabled = enabled;
                StopAnimationButton.Enabled = !enabled;
                StartDrawingButton.Enabled = enabled;
                StopDrawingButton.Enabled = enabled;
                DeletePolygonButton.Enabled = enabled;
            }
            if (actionType == ActionType.delete)
            {
                IntersectAllPolygonsButton.Enabled = enabled;
                StartAnimationButton.Enabled = enabled;
                StopAnimationButton.Enabled = enabled;
                StartDrawingButton.Enabled = enabled;
                StopDrawingButton.Enabled = enabled;
                
                //DeletePolygonButton.Enabled = enabled;
            }
        }

        enum ActionType
        {
            animation,
            delete
        }

        private void StopAnimation(object sender, EventArgs e)
        {
            _continueAnimation = false;
        }

        private void RedrawPolygons()
        {
            _drawing.ClearBitmap();
            Polygons.RemoveAll(x => x.Points.Count < 3);
            Polygons.ForEach(x => x.DrawPolygon());
            this.mainPictureBox.Image = directBitmap.Bitmap;
        }

        private bool _deletePolygon = false;
        private void DeletePolygon(object sender, EventArgs e)
        {
            RedrawPolygons();
            _deletePolygon = !_deletePolygon;
            LockButtons(ActionType.delete, !_deletePolygon);
        }

        private void MainPictureBoxDeletePolygon(Point point)
        {
            int indexToDelete = 0;
            double length = double.MaxValue;
            for (int i = 0; i < Polygons.Count; i++)
            {
                var currentLength = Polygons[i].LengthFromPoint(point);
                if (currentLength < length)
                {
                    length = currentLength;
                    indexToDelete = i;
                }
            }
            if (Polygons.Count > 0)
                Polygons.RemoveAt(indexToDelete);

            _deletePolygon = false;
            LockButtons(ActionType.delete,true);
            RedrawPolygons();
        }

    }
}
