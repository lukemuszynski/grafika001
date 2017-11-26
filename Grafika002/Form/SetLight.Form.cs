using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grafika002.Drawing;

namespace Grafika002
{
    public partial class Form1
    {
        private bool SetLightPositionAction { get; set; }

        private void SetLightPosition(object sender, EventArgs e)
        {
            SetLightPositionAction = true;
        }

        private Drawing.Drawing.Point3D _lightPoint = new Drawing.Drawing.Point3D() { X = 200, Y = 300, Z = 300 };
        private Color _lightColor = Color.White;

        public void SetLightPositionFromPoint(Drawing.Drawing.Point3D point3D)
        {
            _lightPoint = point3D;
            _drawing.CalculateColorMap(_lightColor, point3D);
            SetLightPositionAction = false;
            RedrawPolygons();
        }

        public void SetLightColor(Color lightColor)
        {
            _lightColor = lightColor;
            _drawing.CalculateColorMap(_lightColor, _lightPoint);
            FillColorPicker(SelectedLightColorViewer, lightColor);
        }

        private void FillColorPicker(PictureBox pictureBox, Color color)
        { 
      
            var colorPickerViewerBitmap = new Bitmap(pictureBox.Image ?? new Bitmap(59, 145));
            for (int y = 0; y < colorPickerViewerBitmap.Height; y++)
            {
                for (int x = 0; x < colorPickerViewerBitmap.Width; x++)
                {
                    colorPickerViewerBitmap.SetPixel(x, y, color);
                }
            }
            pictureBox.Image = colorPickerViewerBitmap;
        }

        private void SetLightColorClick(object sender, MouseEventArgs e)
        {
            Color c = _colorPickerBitmap.GetPixel(e.X, e.Y);
            SetLightColor(c);
        }

        private void SelectPolygonColorClick(object sender, MouseEventArgs e)
        {
            polygonDefaultColor = _colorPickerBitmap.GetPixel(e.X, e.Y);
            FillColorPicker(SelectedPolygonColorViewer, polygonDefaultColor);
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            int z;// =;
            if (!Int32.TryParse(textBox1.Text, out z))
                z = _lightPoint.Z;
            _lightPoint = new Drawing.Drawing.Point3D() { X = _lightPoint.X, Y = _lightPoint.Y, Z = z };
            SetLightPositionFromPoint(_lightPoint);
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            textBox1_Leave(sender,e);
        }
    }
}
