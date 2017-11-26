using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void SetLight(Color color, Drawing.Drawing.Point3D point3d)
        {
            _drawing.CalculateColorMap(color,point3d);
            SetLightPositionAction = false;
        }

    }
}
