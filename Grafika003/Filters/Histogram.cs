using System;
using System.Drawing;

namespace Grafika003.Filters
{
    public static class Histogram
    {
        public static Tuple<Bitmap, Bitmap> Get(Bitmap bmp, int width, int height)
        {
            Bitmap binary = new Bitmap(bmp, width, height);
            Bitmap histogramBitmap = new Bitmap(bmp, width, height);
            Bitmap histogramLeftBitmap = new Bitmap(bmp, width, height);

            int progBinaryzacji = 90;

            int[] histogram = new int[binary.Width];
            int[] histogramLeft = new int[binary.Height];

            int b;
            for (int col = 0; col < binary.Width; col++)
            {
                b = 0;
                for (int row = 0; row < binary.Height; row++)
                {
                    var pixel = binary.GetPixel(col, row);

                    if ((pixel.R + pixel.G + pixel.B) / 3 > progBinaryzacji)
                        pixel = Color.FromArgb(255, 255, 255);
                    else
                    {
                        pixel = Color.FromArgb(0, 0, 0);
                        b++;
                        histogramLeft[row]++;
                    }
                    binary.SetPixel(col, row, pixel);
                }
                histogram[col] = b;
            }

            for (int col = 0; col < histogramBitmap.Width; col++)
            {
                for (int row = histogramBitmap.Height - 1; row >= 0; row--)
                {
                    if (histogram[col] > 0)
                    {
                        var pixel = Color.FromArgb(0, 0, 0);
                        histogramBitmap.SetPixel(col, row, pixel);
                        histogram[col]--;
                    }
                    else
                    {
                        var pixel = Color.White;
                        histogramBitmap.SetPixel(col, row, pixel);
                    }
                }
            }

            for (int row = 0; row < binary.Height; row++)
            {
                for (int col = 0; col < binary.Width; col++)
                {
                    if (histogramLeft[row] > 0)
                    {
                        var pixel = Color.Black;
                        histogramLeftBitmap.SetPixel(col, row, pixel);
                        histogramLeft[row]--;
                    }
                    else
                    {
                        var pixel = Color.White;
                        histogramLeftBitmap.SetPixel(col, row, pixel);
                    }
                }
            }

            return new Tuple<Bitmap, Bitmap>(histogramBitmap, histogramLeftBitmap);
        }
    }
}
