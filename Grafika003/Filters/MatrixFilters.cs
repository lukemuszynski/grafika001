using System;

namespace Grafika003.Filters
{
    public static class MatrixFilters
    {
        public static double[,] GaussianBlur(int lenght, double weight)
        {
            double[,] kernel = new double[lenght, lenght];
            double kernelSum = 0;
            int foff = (lenght - 1) / 2;
            double distance = 0;
            double constant = 1d / (2 * Math.PI * weight * weight);
            for (int y = -foff; y <= foff; y++)
            {
                for (int x = -foff; x <= foff; x++)
                {
                    distance = ((y * y) + (x * x)) / (2 * weight * weight);
                    kernel[y + foff, x + foff] = constant * Math.Exp(-distance);
                    kernelSum += kernel[y + foff, x + foff];
                }
            }
            for (int y = 0; y < lenght; y++)
            {
                for (int x = 0; x < lenght; x++)
                {
                    kernel[y, x] = kernel[y, x] * 1d / kernelSum;
                }
            }
            return kernel;
        }

        public static string Laplacian3x3 => @"[
[-1, -1, -1],
[-1, 8, -1],
[-1, -1, -1]
]";

        public static string Laplacian5x5 =>
            @"[ [-1, -1, -1, -1, -1, ],  
 [ -1, -1, -1, -1, -1,],  
 [ -1, -1, 24, -1, -1,],  
 [ -1, -1, -1, -1, -1,],  
 [ -1, -1, -1, -1, -1  ] ]";

        public static string Gaussian5x5Type2 =>
                        @"[
[ 1,   4,  6,  4,  1 ],  
[ 4,  16, 24, 16,  4 ],  
[ 6,  24, 36, 24,  6 ], 
[ 4,  16, 24, 16,  4 ], 
[ 1,   4,  6,  4,  1 ]
]";

        public static string Gaussian5x5Type1 =>
            @"[
[ 2, 4, 5, 4, 2 ],  
[ 4, 9, 12, 9, 4 ],  
[ 5, 12, 15, 12, 5 ], 
[ 4, 9, 12, 9, 4 ], 
[ 2, 4, 5, 4, 2 ] ]";

        public static string Sobel3x3Ver =>
@" [
[ -1,  0,  1, ],  
[ -2,  0,  2, ],  
[ -1,  0,  1, ] ]";

        public static string Sobel3x3Hor =>
        @"[ 
[ 1,  2,  1, ],  
[ 0,  0,  0, ],  
[ -1, -2, -1, ] ]";

    }
}
