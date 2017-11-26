using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika002.ExtensionMethods
{
    static partial class ExtensionMethods
    {
        public static Point Substract(this Point p1, Point p2)
        {
            return
                new Point()
                {
                    X = p1.X - p2.X,
                    Y = p1.Y - p2.Y
                };
        }

        public static Point Add(this Point p1, Point p2)
        {
            return
                new Point()
                {
                    X = p1.X + p2.X,
                    Y = p1.Y + p2.Y
                };
        }

        public static Point Multiply(this Point p1, int m)
        {
            return new Point()
            {
                X = p1.X * m,
                Y = p1.Y * m
            };
        }

        public static Point Multiply(this Point p1, double m)
        {
            return new Point()
            {
                X = (int)(p1.X * m),
                Y = (int)(p1.Y * m)
            };
        }
    }
}
