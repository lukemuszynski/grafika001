using Grafika003.Filters;
using System;

namespace Grafika003
{
    public partial class Form1
    {
        private void button_setLaplacian_Click(object sender, EventArgs e)
        {
            FilterJson.Text = MatrixFilters.Laplacian3x3;
        }

        private void button_setLaplacian55_Click(object sender, EventArgs e)
        {
            FilterJson.Text = MatrixFilters.Laplacian5x5;
        }

        private void button_setSobel3x3Ver_Click(object sender, EventArgs e)
        {
            FilterJson.Text = MatrixFilters.Sobel3x3Ver;
        }

        private void button_setSobel3x3Hor_Click(object sender, EventArgs e)
        {
            FilterJson.Text = MatrixFilters.Sobel3x3Hor;
        }

        private void button_setGaussian5x5type2_Click(object sender, EventArgs e)
        {
            FilterJson.Text = MatrixFilters.Gaussian5x5Type2;
        }

        private void button_setGaussian5x5type1_Click(object sender, EventArgs e)
        {
            FilterJson.Text = MatrixFilters.Gaussian5x5Type1;
        }

        private void button_prewitt3x3Horizontal_Click(object sender, EventArgs e)
        {
            FilterJson.Text = MatrixFilters.Prewitt3x3Horizontal;
        }

        private void button_prewitt3x3Vertical_Click(object sender, EventArgs e)
        {
            FilterJson.Text = MatrixFilters.Prewitt3x3Vertical;
        }
    }
}
