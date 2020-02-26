namespace Grafika003
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button button_setSobel3x3Hor;
            System.Windows.Forms.Button button_setSobel3x3Ver;
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.FilterJson = new System.Windows.Forms.TextBox();
            this.button_applyGenericMatrixFilter = new System.Windows.Forms.Button();
            this.button_setLaplacian = new System.Windows.Forms.Button();
            this.button_setLaplacian55 = new System.Windows.Forms.Button();
            this.button_setGaussian5x5type2 = new System.Windows.Forms.Button();
            this.button_setGaussian5x5type1 = new System.Windows.Forms.Button();
            this.checkbox_normalization = new System.Windows.Forms.CheckBox();
            this.picturebox_histogramLeft = new System.Windows.Forms.PictureBox();
            this.picturebox_histogram = new System.Windows.Forms.PictureBox();
            this.checkbox_showHistogram = new System.Windows.Forms.CheckBox();
            this.button_reset_image = new System.Windows.Forms.Button();
            this.trackBar_brushSize = new System.Windows.Forms.TrackBar();
            button_setSobel3x3Hor = new System.Windows.Forms.Button();
            button_setSobel3x3Ver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_histogramLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_histogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_brushSize)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.Location = new System.Drawing.Point(2, 2);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(1080, 676);
            this.mainPictureBox.TabIndex = 2;
            this.mainPictureBox.TabStop = false;
            this.mainPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPictureBox_Paint);
            this.mainPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseMove);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button_reset_image);
            this.flowLayoutPanel1.Controls.Add(this.FilterJson);
            this.flowLayoutPanel1.Controls.Add(this.button_applyGenericMatrixFilter);
            this.flowLayoutPanel1.Controls.Add(this.button_setLaplacian);
            this.flowLayoutPanel1.Controls.Add(this.button_setLaplacian55);
            this.flowLayoutPanel1.Controls.Add(button_setSobel3x3Hor);
            this.flowLayoutPanel1.Controls.Add(button_setSobel3x3Ver);
            this.flowLayoutPanel1.Controls.Add(this.button_setGaussian5x5type2);
            this.flowLayoutPanel1.Controls.Add(this.button_setGaussian5x5type1);
            this.flowLayoutPanel1.Controls.Add(this.checkbox_normalization);
            this.flowLayoutPanel1.Controls.Add(this.checkbox_showHistogram);
            this.flowLayoutPanel1.Controls.Add(this.trackBar_brushSize);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1089, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(231, 676);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Wczytaj plik graficzny";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_openFile);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // FilterJson
            // 
            this.FilterJson.Location = new System.Drawing.Point(3, 61);
            this.FilterJson.Multiline = true;
            this.FilterJson.Name = "FilterJson";
            this.FilterJson.Size = new System.Drawing.Size(203, 137);
            this.FilterJson.TabIndex = 1;
            // 
            // button_applyGenericMatrixFilter
            // 
            this.button_applyGenericMatrixFilter.Location = new System.Drawing.Point(3, 204);
            this.button_applyGenericMatrixFilter.Name = "button_applyGenericMatrixFilter";
            this.button_applyGenericMatrixFilter.Size = new System.Drawing.Size(169, 23);
            this.button_applyGenericMatrixFilter.TabIndex = 2;
            this.button_applyGenericMatrixFilter.Text = "Wykonaj filtr";
            this.button_applyGenericMatrixFilter.UseVisualStyleBackColor = true;
            this.button_applyGenericMatrixFilter.Click += new System.EventHandler(this.button_applyGenericMatrixFilter_Click);
            // 
            // button_setLaplacian
            // 
            this.button_setLaplacian.Location = new System.Drawing.Point(3, 233);
            this.button_setLaplacian.Name = "button_setLaplacian";
            this.button_setLaplacian.Size = new System.Drawing.Size(169, 23);
            this.button_setLaplacian.TabIndex = 3;
            this.button_setLaplacian.Text = "Laplacian 3x3";
            this.button_setLaplacian.UseVisualStyleBackColor = true;
            this.button_setLaplacian.Click += new System.EventHandler(this.button_setLaplacian_Click);
            // 
            // button_setLaplacian55
            // 
            this.button_setLaplacian55.Location = new System.Drawing.Point(3, 262);
            this.button_setLaplacian55.Name = "button_setLaplacian55";
            this.button_setLaplacian55.Size = new System.Drawing.Size(169, 23);
            this.button_setLaplacian55.TabIndex = 4;
            this.button_setLaplacian55.Text = "Laplacian 5x5";
            this.button_setLaplacian55.UseVisualStyleBackColor = true;
            this.button_setLaplacian55.Click += new System.EventHandler(this.button_setLaplacian55_Click);
            // 
            // button_setSobel3x3Hor
            // 
            button_setSobel3x3Hor.AutoSize = true;
            button_setSobel3x3Hor.Location = new System.Drawing.Point(3, 291);
            button_setSobel3x3Hor.Name = "button_setSobel3x3Hor";
            button_setSobel3x3Hor.Size = new System.Drawing.Size(169, 23);
            button_setSobel3x3Hor.TabIndex = 5;
            button_setSobel3x3Hor.Text = "Sobel 3x3 Poziomy";
            button_setSobel3x3Hor.UseVisualStyleBackColor = true;
            button_setSobel3x3Hor.Click += new System.EventHandler(this.button_setSobel3x3Hor_Click);
            // 
            // button_setSobel3x3Ver
            // 
            button_setSobel3x3Ver.AutoSize = true;
            button_setSobel3x3Ver.Location = new System.Drawing.Point(3, 320);
            button_setSobel3x3Ver.Name = "button_setSobel3x3Ver";
            button_setSobel3x3Ver.Size = new System.Drawing.Size(169, 23);
            button_setSobel3x3Ver.TabIndex = 6;
            button_setSobel3x3Ver.Text = "Sobel 3x3 Pionowy";
            button_setSobel3x3Ver.UseVisualStyleBackColor = true;
            button_setSobel3x3Ver.Click += new System.EventHandler(this.button_setSobel3x3Ver_Click);
            // 
            // button_setGaussian5x5type2
            // 
            this.button_setGaussian5x5type2.Location = new System.Drawing.Point(3, 349);
            this.button_setGaussian5x5type2.Name = "button_setGaussian5x5type2";
            this.button_setGaussian5x5type2.Size = new System.Drawing.Size(169, 23);
            this.button_setGaussian5x5type2.TabIndex = 7;
            this.button_setGaussian5x5type2.Text = "Gauss 5x5 Typ 2";
            this.button_setGaussian5x5type2.UseVisualStyleBackColor = true;
            this.button_setGaussian5x5type2.Click += new System.EventHandler(this.button_setGaussian5x5type2_Click);
            // 
            // button_setGaussian5x5type1
            // 
            this.button_setGaussian5x5type1.Location = new System.Drawing.Point(3, 378);
            this.button_setGaussian5x5type1.Name = "button_setGaussian5x5type1";
            this.button_setGaussian5x5type1.Size = new System.Drawing.Size(169, 23);
            this.button_setGaussian5x5type1.TabIndex = 8;
            this.button_setGaussian5x5type1.Text = "Gauss 5x5 Typ 1";
            this.button_setGaussian5x5type1.UseVisualStyleBackColor = true;
            this.button_setGaussian5x5type1.Click += new System.EventHandler(this.button_setGaussian5x5type1_Click);
            // 
            // checkbox_normalization
            // 
            this.checkbox_normalization.AutoSize = true;
            this.checkbox_normalization.Checked = true;
            this.checkbox_normalization.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkbox_normalization.Location = new System.Drawing.Point(3, 407);
            this.checkbox_normalization.Name = "checkbox_normalization";
            this.checkbox_normalization.Size = new System.Drawing.Size(113, 17);
            this.checkbox_normalization.TabIndex = 9;
            this.checkbox_normalization.Text = "Normalizuj macierz";
            this.checkbox_normalization.UseVisualStyleBackColor = true;
            // 
            // picturebox_histogramLeft
            // 
            this.picturebox_histogramLeft.Location = new System.Drawing.Point(12, 564);
            this.picturebox_histogramLeft.Name = "picturebox_histogramLeft";
            this.picturebox_histogramLeft.Size = new System.Drawing.Size(220, 100);
            this.picturebox_histogramLeft.TabIndex = 4;
            this.picturebox_histogramLeft.TabStop = false;
            this.picturebox_histogramLeft.Visible = false;
            // 
            // picturebox_histogram
            // 
            this.picturebox_histogram.Location = new System.Drawing.Point(12, 458);
            this.picturebox_histogram.Name = "picturebox_histogram";
            this.picturebox_histogram.Size = new System.Drawing.Size(220, 100);
            this.picturebox_histogram.TabIndex = 5;
            this.picturebox_histogram.TabStop = false;
            this.picturebox_histogram.Visible = false;
            // 
            // checkbox_showHistogram
            // 
            this.checkbox_showHistogram.AutoSize = true;
            this.checkbox_showHistogram.Location = new System.Drawing.Point(122, 407);
            this.checkbox_showHistogram.Name = "checkbox_showHistogram";
            this.checkbox_showHistogram.Size = new System.Drawing.Size(104, 17);
            this.checkbox_showHistogram.TabIndex = 10;
            this.checkbox_showHistogram.Text = "Pokaż histogram";
            this.checkbox_showHistogram.UseVisualStyleBackColor = true;
            this.checkbox_showHistogram.CheckedChanged += new System.EventHandler(this.checkbox_showHistogram_CheckedChanged);
            // 
            // button_reset_image
            // 
            this.button_reset_image.Location = new System.Drawing.Point(3, 32);
            this.button_reset_image.Name = "button_reset_image";
            this.button_reset_image.Size = new System.Drawing.Size(75, 23);
            this.button_reset_image.TabIndex = 11;
            this.button_reset_image.Text = "Reset";
            this.button_reset_image.UseVisualStyleBackColor = true;
            this.button_reset_image.Click += new System.EventHandler(this.button_reset_image_Click);
            // 
            // trackBar_brushSize
            // 
            this.trackBar_brushSize.Location = new System.Drawing.Point(3, 430);
            this.trackBar_brushSize.Maximum = 30;
            this.trackBar_brushSize.Minimum = 3;
            this.trackBar_brushSize.Name = "trackBar_brushSize";
            this.trackBar_brushSize.Size = new System.Drawing.Size(223, 45);
            this.trackBar_brushSize.TabIndex = 12;
            this.trackBar_brushSize.Value = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 677);
            this.Controls.Add(this.picturebox_histogram);
            this.Controls.Add(this.picturebox_histogramLeft);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.mainPictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_histogramLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_histogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_brushSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox FilterJson;
        private System.Windows.Forms.Button button_applyGenericMatrixFilter;
        private System.Windows.Forms.Button button_setLaplacian;
        private System.Windows.Forms.Button button_setLaplacian55;
        private System.Windows.Forms.Button button_setGaussian5x5type2;
        private System.Windows.Forms.Button button_setGaussian5x5type1;
        private System.Windows.Forms.CheckBox checkbox_normalization;
        private System.Windows.Forms.PictureBox picturebox_histogramLeft;
        private System.Windows.Forms.CheckBox checkbox_showHistogram;
        private System.Windows.Forms.PictureBox picturebox_histogram;
        private System.Windows.Forms.Button button_reset_image;
        private System.Windows.Forms.TrackBar trackBar_brushSize;
    }
}

