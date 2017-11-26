using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grafika002.Drawing.BuildingBlocks;

namespace Grafika002
{
    public partial class Form1
    {

        private void DeletePolygon(object sender, EventArgs e)
        {
            Polygons.Remove(_selectedPolygon);
            _selectedPolygon = null;
            RedrawPolygons();
            LockButtons(Grafika002.Form1.ActionType.selectPolygon, true);
            _selectPolygonAction = false;
        }

        private void MainPictureBoxSelectPolygon(Point point)
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
            {
                SelectedPolygon = Polygons[indexToDelete];
                SelectedPolygon.FillEnabled = true;
                SelectedPolygon.FillingColor = Color.Yellow.ToArgb();
            }
            RedrawPolygons();
        }

        private bool _selectPolygonAction = false;

        private Polygon _selectedPolygon;
        private Polygon SelectedPolygon
        {
            get { return _selectedPolygon; }
            set
            {
                _selectedPolygon = value;

                if (_selectedPolygon == null)
                    DeletePolygonButton.Enabled = false;
                else
                    DeletePolygonButton.Enabled = true;
            }
        }

        private void SelectPolygon(object sender, EventArgs e)
        {
            LockButtons(Grafika002.Form1.ActionType.selectPolygon);
            _selectPolygonAction = true;
        }

        private void UnselectPolygon(object sender, EventArgs e)
        {
            SelectedPolygon = null;
            _selectPolygonAction = false;
            LockButtons(Grafika002.Form1.ActionType.selectPolygon, true);
        }
    }
}
