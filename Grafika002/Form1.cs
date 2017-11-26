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
    public partial class Form1 : System.Windows.Forms.Form
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



        private Polygon animationPolygon;

        public List<Polygon> Polygons { get; set; }


        public Form1()
        {
            InitializeComponent();
            Polygons = new List<Polygon>();
            directBitmap = new DirectBitmap(mainPictureBox.Width, mainPictureBox.Height);
            this.mainPictureBox.Image = directBitmap.Bitmap;
            _drawing = new Drawing.Drawing(directBitmap);
        }



        private void mainPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (_selectPolygonAction)
            {
                MainPictureBoxSelectPolygon(new Point(e.X, e.Y));
            }

            else
            {
                polygon?.AddVerticle(new Point(e.X, e.Y));
                this.mainPictureBox.Image = directBitmap.Bitmap;
            }
        }

        private void LockButtons(ActionType actionType, bool enabled = false)
        {
            if (actionType == ActionType.animation)
            {
                StartAnimationButton.Enabled = enabled;
                StopAnimationButton.Enabled = !enabled;
                StartDrawingButton.Enabled = enabled;
                StopDrawingButton.Enabled = enabled;
                DeletePolygonButton.Enabled = enabled;
                UnselectPolygonButton.Enabled = enabled;
                SelectPolygonButton.Enabled = enabled;
                DeletePolygonButton.Enabled = enabled;
            }
            if (actionType == ActionType.selectPolygon)
            {
                StartAnimationButton.Enabled = enabled;
                StopAnimationButton.Enabled = enabled;
                StartDrawingButton.Enabled = enabled;
                StopDrawingButton.Enabled = enabled;
                UnselectPolygonButton.Enabled = !enabled;
                SelectPolygonButton.Enabled = enabled;
                DeletePolygonButton.Enabled = !enabled;
            }
        }

        enum ActionType
        {
            animation,
            selectPolygon
        }

        private void RedrawPolygons()
        {
            _drawing.ClearBitmap();
            Polygons.RemoveAll(x => x.Points.Count < 3);
            Polygons.ForEach(x => x.DrawPolygon());
            this.mainPictureBox.Image = directBitmap.Bitmap;
        }


    }
}
