﻿using Grafika003.ExtensionMethods;
using Grafika003.Filters;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Grafika003
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void enableButtons()
        {
            button_applyGenericMatrixFilter.Enabled = true;
            button_setLaplacian.Enabled = true;
            button_setLaplacian55.Enabled = true;
            button_setGaussian5x5type2.Enabled = true;
            button_setGaussian5x5type1.Enabled = true;
            checkbox_showHistogram.Enabled = true;
            button_reset_image.Enabled = true;
            button_setSobel3x3Hor.Enabled = true;
            button_setSobel3x3Ver.Enabled = true;
            button_prewitt3x3Horizontal.Enabled = true;
            button_prewitt3x3Vertical.Enabled = true;
        }

        private void button_openFile(object sender, System.EventArgs e)
        {
            openFileDialog.Filter = "Image Files(*.jpeg; *.bmp; *.png; *.jpg)| *.jpeg; *.bmp; *.png; *.jpg";
            var result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                loadBitmap();
                enableButtons();
            }
        }

        private void loadBitmap()
        {
            var path = openFileDialog.FileName;

            mainPictureBox.Image = Image.FromFile(path);

            reload_histograms();
        }

        private Bitmap applyFilter(Bitmap copiedBitmap)
        {
            var filterMatrix = JsonConvert.DeserializeObject<double[,]>(FilterJson.Text);

            if(filterMatrix == null || filterMatrix.GetUpperBound(0) != filterMatrix.GetUpperBound(1))
            {
                return copiedBitmap;
            }

            var normalizationFactor = (checkbox_normalization.Checked ? 1.0 / filterMatrix.Sum() : 1.0)/(double)trackBar_normalizationFactor.Value;

            var resultBitmap = GenericMatrixFilter.ConvolutionFilter(copiedBitmap, filterMatrix, normalizationFactor);

            return resultBitmap;
        }

        private void button_applyGenericMatrixFilter_Click(object sender, System.EventArgs e)
        {
            mainPictureBox.Image = applyFilter(new Bitmap(mainPictureBox.Image));

            reload_histograms();
        }

        private void checkbox_showHistogram_CheckedChanged(object sender, EventArgs e)
        {
            reload_histograms();
        }

        private void reload_histograms()
        {
            if (checkbox_showHistogram.Checked)
            {
                var histograms = Histogram.Get(mainPictureBox.Image as Bitmap, picturebox_histogram.Width, picturebox_histogram.Height);

                picturebox_histogram.Image = histograms.Item1;
                picturebox_histogramLeft.Image = histograms.Item2;

                picturebox_histogram.Show();
                picturebox_histogramLeft.Show();
            }
            else
            {
                picturebox_histogram.Hide();
                picturebox_histogramLeft.Hide();
            }
        }

        private void button_reset_image_Click(object sender, EventArgs e)
        {
            loadBitmap();
        }

        private void mainPictureBox_Paint(object sender, PaintEventArgs e)
        {
            Point local = mainPictureBox.PointToClient(Cursor.Position);
            int diameter = trackBar_brushSize.Value;

            e.Graphics.DrawEllipse(Pens.Red, local.X - diameter, local.Y - diameter, diameter * 2, diameter * 2);
        }

        private void mainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            mainPictureBox.Invalidate();
        }

        private void mainPictureBox_Click(object sender, EventArgs e)
        {
            if(mainPictureBox.Image == null)
            {
                return;
            }

            Point local = mainPictureBox.PointToClient(Cursor.Position);
            int diameter = trackBar_brushSize.Value;

            Rectangle cropRect = new Rectangle(local.X - diameter, local.Y - diameter, diameter * 2, diameter * 2);
            Bitmap target = new Bitmap(cropRect.Width, cropRect.Height);
            Bitmap targetWithFilter = new Bitmap(cropRect.Width, cropRect.Height);
            targetWithFilter.MakeTransparent();

            using (Graphics graphicsTarget = Graphics.FromImage(target))
            {
                graphicsTarget.DrawImage(mainPictureBox.Image,
                    new Rectangle(0, 0, target.Width, target.Height),
                    cropRect,
                    GraphicsUnit.Pixel);
                target = applyFilter(target);
            }

            using (Graphics graphicsTargetWithFilter = Graphics.FromImage(targetWithFilter))
            {
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(new Rectangle(0, 0, target.Width, target.Height));
                graphicsTargetWithFilter.SetClip(path);
                graphicsTargetWithFilter.DrawImage(target,
                    new Rectangle(0, 0, target.Width, target.Height),
                    new Rectangle(0, 0, target.Width, target.Height),
                    GraphicsUnit.Pixel);
            }

            using (Graphics graphicsMainPicture = Graphics.FromImage(mainPictureBox.Image))
            {
                graphicsMainPicture.DrawImage(targetWithFilter, local.X - diameter, local.Y - diameter);
            }
            // when done with all drawing you can enforce the display update by calling:
            mainPictureBox.Refresh();
            reload_histograms();
        }

        private void button_generate_gauss_Click(object sender, EventArgs e)
        {
            var xValue = textBox_gauss_x.Text;
            if(Int32.TryParse(xValue, out int x))
            {
                var matrix = MatrixFilters.GaussianBlur(x, x);

                FilterJson.Text = JsonConvert.SerializeObject(matrix, Formatting.Indented);
            }
        }
    }
}
