using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grafika001.Drawing;
using Grafika001.Drawing.BuildingBlocks;
using Grafika001.Logic;

namespace Grafika001
{
    public partial class MainForm : Form
    {
        private Drawing.Drawing _drawing;
        private FormLogic _formLogic;
        //double buffering
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        public MainForm()
        {
            InitializeComponent();

            directBitmap = new DirectBitmap(1124, 680);
            this.mainPictureBox.Image = directBitmap.Bitmap;
            _drawing = new Drawing.Drawing(directBitmap);
            var buttonControl = new ButtonControl(this);
            _formLogic = new FormLogic(_drawing, TimeTextBox, buttonControl);
        }

       

        private void SetPixelButton_Click(object sender, EventArgs e)
        {
            _formLogic.SetAction(FormAction.SetPixel);
        }

        private void mainPictureBox_Click(object sender, MouseEventArgs e)
        {
            _formLogic.Click(new Point(e.X, e.Y));
            this.mainPictureBox.Image = directBitmap.Bitmap;
        }

        private void DrawLineButton_Click(object sender, EventArgs e)
        {
            _formLogic.SetAction(FormAction.DrawLine);
        }

        private void DrawPolygonButton_Click(object sender, EventArgs e)
        {
            _formLogic.SetAction(FormAction.StartDrawPolygon);
        }

        private void StopDrawPolygonButton_Click(object sender, EventArgs e)
        {
            _formLogic.SetAction(FormAction.StopDrawPolygon);
            this.mainPictureBox.Image = directBitmap.Bitmap;
        }

        private void smallWidth_Click(object sender, EventArgs e)
        {
            _formLogic.Width = Consts.SmallWidth;
        }

        private void mediumWidth_Click(object sender, EventArgs e)
        {
            _formLogic.Width = Consts.MediumWidth;
        }

        private void bigWidth_Click(object sender, EventArgs e)
        {
            _formLogic.Width = Consts.BigWidth;
        }

        private void SelectLineButton_Click(object sender, EventArgs e)
        {
            _formLogic.SetAction(FormAction.SelectLine);
        }

        private void drawCircleButton_Click(object sender, EventArgs e)
        {
            _formLogic.SetAction(FormAction.DrawCircleOptimized);
        }

        private void ClearBitmapButton_Click(object sender, EventArgs e)
        {
            _formLogic.SetAction(FormAction.ClearBitmap);
            this.mainPictureBox.Image = directBitmap.Bitmap;
        }

        private void RedrawBitmapButton_Click(object sender, EventArgs e)
        {
            _formLogic.SetAction(FormAction.RedrawBitmap);
            this.mainPictureBox.Image = directBitmap.Bitmap;
        }

        private void MoveVerticle_Click(object sender, EventArgs e)
        {
            _formLogic.SetAction(FormAction.MoveVerticle);
            this.mainPictureBox.Image = directBitmap.Bitmap;
        }

        private void DeleteObjectButton_Click(object sender, EventArgs e)
        {
            _formLogic.SetAction(FormAction.DeleteObject);
            this.mainPictureBox.Image = directBitmap.Bitmap;
        }

        private void MoveObjectButton_Click(object sender, EventArgs e)
        {
            _formLogic.SetAction(FormAction.MoveObject);
            this.mainPictureBox.Image = directBitmap.Bitmap;
        }

        private void ChangeRadiusTrackBar_Scroll(object sender, EventArgs e)
        {
            _formLogic.ChangeRadius(CircleRadiusTrackBar.Value);
            this.mainPictureBox.Image = directBitmap.Bitmap;
        }

        private void LineLengthTrackBar_Scroll(object sender, EventArgs e)
        {
            _formLogic.ChangeLength(LineLengthTrackBar.Value * 5);
        }

        private void AddVerticleButton_Click(object sender, EventArgs e)
        {
            _formLogic.SetAction(FormAction.AddVerticle);
            this.mainPictureBox.Image = directBitmap.Bitmap;
        }

        private void colorButton1_Click(object sender, EventArgs e)
        {
            _drawing.Color = Color.MediumSpringGreen.ToArgb();
            _formLogic.ChangeOrSetColor(_drawing.Color);
            this.mainPictureBox.Image = directBitmap.Bitmap;

        }

        private void colorButton2_Click(object sender, EventArgs e)
        {
            _drawing.Color = Color.Crimson.ToArgb();
            _formLogic.ChangeOrSetColor(_drawing.Color);
            this.mainPictureBox.Image = directBitmap.Bitmap;
        }

        private void colorButton3_Click(object sender, EventArgs e)
        {
            _drawing.Color = Color.DarkOrange.ToArgb();
            _formLogic.ChangeOrSetColor(_drawing.Color);
            this.mainPictureBox.Image = directBitmap.Bitmap;
        }

        private void colorButton4_Click(object sender, EventArgs e)
        {
            _drawing.Color = Color.DeepSkyBlue.ToArgb();
            _formLogic.ChangeOrSetColor(_drawing.Color);
            this.mainPictureBox.Image = directBitmap.Bitmap;
        }

        private void SetHorizontal_Click(object sender, EventArgs e)
        {
            _formLogic.SetAction(FormAction.SetHorizontal);
            this.mainPictureBox.Image = directBitmap.Bitmap;
        }

        private void SetVertical_Click(object sender, EventArgs e)
        {
            _formLogic.SetAction(FormAction.SetVertical);
            this.mainPictureBox.Image = directBitmap.Bitmap;
        }

        public class ButtonControl
        {
            private MainForm MainForm { get; set; }
            public ButtonControl(MainForm mainForm)
            {
                MainForm = mainForm;
            }
            public void CircleSelected(int radiusOfSelectedCircle)
            {
                MainForm.DeleteObjectButton.Enabled = true;
                MainForm.MoveObjectButton.Enabled = true;
                MainForm.CircleRadiusTrackBar.Enabled = true;
                MainForm.CircleRadiusTrackBar.Value = radiusOfSelectedCircle;
            }

            public void GraphicObjectSelected()
            {
                MainForm.DeleteObjectButton.Enabled = true;
                MainForm.MoveObjectButton.Enabled = true;
                MainForm.AddVerticleButton.Enabled = true;
            }

            public void VerticleSelected()
            {
                MainForm.MoveVerticle.Enabled = true;
                MainForm.DeleteObjectButton.Enabled = true;
            }

            public bool LineSelected(int length)
            {
                MainForm.DeleteObjectButton.Enabled = true;
                MainForm.MoveObjectButton.Enabled = true;

                MainForm.SetHorizontal.Enabled = true;
                MainForm.SetVertical.Enabled = true;

                return true;
            }

            public void StartDrawingPoligon()
            {
                MainForm.SetPixelButton.Enabled = false;
                MainForm.DrawLineButton.Enabled = false;
                MainForm.StartDrawPolygonButton.Enabled = false;
                MainForm.StopDrawPolygonButton.Enabled = true;
                MainForm.SelectLineButton.Enabled = false;
                MainForm.DrawCircleButton.Enabled = false;
                MainForm.ConcentricCircles.Enabled = false;
            }

            public void StopDrawingPoligon()
            {
                MainForm.SetPixelButton.Enabled = true;
                MainForm.DrawLineButton.Enabled = true;
                MainForm.StartDrawPolygonButton.Enabled = true;
                MainForm.StopDrawPolygonButton.Enabled = false;
                MainForm.SelectLineButton.Enabled = true;
                MainForm.DrawCircleButton.Enabled = true;
                MainForm.ConcentricCircles.Enabled = true;
            }

            public void NullSelected()
            {
                MainForm.DeleteObjectButton.Enabled = false;
                MainForm.MoveObjectButton.Enabled = false;
                MainForm.MoveVerticle.Enabled = false;
                MainForm.CircleRadiusTrackBar.Enabled = false;
                MainForm.AddVerticleButton.Enabled = false;
                MainForm.SetHorizontal.Enabled = false;
                MainForm.SetVertical.Enabled = false;
            }
        }

        private void SetConcrenticCircle(object sender, EventArgs e)
        {
            _formLogic.SetAction(FormAction.SetConcrentic);
        }
    }
}
