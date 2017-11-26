using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grafika002.Drawing.BuildingBlocks;


namespace Grafika002
{
    public partial class Form1
    {
        private Polygon polygon;
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
    }
}
