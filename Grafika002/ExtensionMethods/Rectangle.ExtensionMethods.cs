using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika002.ExtensionMethods
{
    public static partial class ExtensionMethods
    {
        public static float MidX(this Rectangle rectangle)
        {
            return (float)(rectangle.X + rectangle.Width) / 2;
        }

        public static float MidY(this Rectangle rectangle)
        {
            return (float)(rectangle.Y + rectangle.Height) / 2;
        }
    }
}
