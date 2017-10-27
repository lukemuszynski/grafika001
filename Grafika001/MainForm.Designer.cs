using System;
using System.Drawing;
using Grafika001.Drawing;

namespace Grafika001
{
    partial class MainForm
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
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SetPixelButton = new System.Windows.Forms.Button();
            this.DrawLineButton = new System.Windows.Forms.Button();
            this.StartDrawPolygonButton = new System.Windows.Forms.Button();
            this.StopDrawPolygonButton = new System.Windows.Forms.Button();
            this.smallWidth = new System.Windows.Forms.RadioButton();
            this.mediumWidth = new System.Windows.Forms.RadioButton();
            this.bigWidth = new System.Windows.Forms.RadioButton();
            this.SelectLineButton = new System.Windows.Forms.Button();
            this.DrawCircleButton = new System.Windows.Forms.Button();
            this.ClearBitmapButton = new System.Windows.Forms.Button();
            this.RedrawBitmapButton = new System.Windows.Forms.Button();
            this.TimeTextBox = new System.Windows.Forms.TextBox();
            this.DeleteObjectButton = new System.Windows.Forms.Button();
            this.MoveObjectButton = new System.Windows.Forms.Button();
            this.CircleRadiusTrackBar = new System.Windows.Forms.TrackBar();
            this.LineLengthTrackBar = new System.Windows.Forms.TrackBar();
            this.AddVerticleButton = new System.Windows.Forms.Button();
            this.MoveVerticle = new System.Windows.Forms.Button();
            this.SetHorizontal = new System.Windows.Forms.Button();
            this.SetVertical = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.colorButton4 = new System.Windows.Forms.RadioButton();
            this.colorButton1 = new System.Windows.Forms.RadioButton();
            this.colorButton2 = new System.Windows.Forms.RadioButton();
            this.colorButton3 = new System.Windows.Forms.RadioButton();
            this.ConcentricCircles = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CircleRadiusTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineLengthTrackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.Location = new System.Drawing.Point(0, 0);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(1124, 680);
            this.mainPictureBox.TabIndex = 0;
            this.mainPictureBox.TabStop = false;
            this.mainPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.SetPixelButton);
            this.flowLayoutPanel1.Controls.Add(this.DrawLineButton);
            this.flowLayoutPanel1.Controls.Add(this.StartDrawPolygonButton);
            this.flowLayoutPanel1.Controls.Add(this.StopDrawPolygonButton);
            this.flowLayoutPanel1.Controls.Add(this.smallWidth);
            this.flowLayoutPanel1.Controls.Add(this.mediumWidth);
            this.flowLayoutPanel1.Controls.Add(this.bigWidth);
            this.flowLayoutPanel1.Controls.Add(this.SelectLineButton);
            this.flowLayoutPanel1.Controls.Add(this.DrawCircleButton);
            this.flowLayoutPanel1.Controls.Add(this.ClearBitmapButton);
            this.flowLayoutPanel1.Controls.Add(this.RedrawBitmapButton);
            this.flowLayoutPanel1.Controls.Add(this.TimeTextBox);
            this.flowLayoutPanel1.Controls.Add(this.DeleteObjectButton);
            this.flowLayoutPanel1.Controls.Add(this.MoveObjectButton);
            this.flowLayoutPanel1.Controls.Add(this.CircleRadiusTrackBar);
            this.flowLayoutPanel1.Controls.Add(this.LineLengthTrackBar);
            this.flowLayoutPanel1.Controls.Add(this.AddVerticleButton);
            this.flowLayoutPanel1.Controls.Add(this.MoveVerticle);
            this.flowLayoutPanel1.Controls.Add(this.SetHorizontal);
            this.flowLayoutPanel1.Controls.Add(this.SetVertical);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.ConcentricCircles);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1127, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 680);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // SetPixelButton
            // 
            this.SetPixelButton.Location = new System.Drawing.Point(3, 3);
            this.SetPixelButton.Name = "SetPixelButton";
            this.SetPixelButton.Size = new System.Drawing.Size(178, 23);
            this.SetPixelButton.TabIndex = 0;
            this.SetPixelButton.Text = "SetPixel";
            this.SetPixelButton.UseVisualStyleBackColor = true;
            this.SetPixelButton.Click += new System.EventHandler(this.SetPixelButton_Click);
            // 
            // DrawLineButton
            // 
            this.DrawLineButton.Location = new System.Drawing.Point(3, 32);
            this.DrawLineButton.Name = "DrawLineButton";
            this.DrawLineButton.Size = new System.Drawing.Size(178, 23);
            this.DrawLineButton.TabIndex = 2;
            this.DrawLineButton.Text = "DrawLine";
            this.DrawLineButton.UseVisualStyleBackColor = true;
            this.DrawLineButton.Click += new System.EventHandler(this.DrawLineButton_Click);
            // 
            // StartDrawPolygonButton
            // 
            this.StartDrawPolygonButton.Location = new System.Drawing.Point(3, 61);
            this.StartDrawPolygonButton.Name = "StartDrawPolygonButton";
            this.StartDrawPolygonButton.Size = new System.Drawing.Size(178, 23);
            this.StartDrawPolygonButton.TabIndex = 3;
            this.StartDrawPolygonButton.Text = "StartDrawPolygon";
            this.StartDrawPolygonButton.UseVisualStyleBackColor = true;
            this.StartDrawPolygonButton.Click += new System.EventHandler(this.DrawPolygonButton_Click);
            // 
            // StopDrawPolygonButton
            // 
            this.StopDrawPolygonButton.Location = new System.Drawing.Point(3, 90);
            this.StopDrawPolygonButton.Name = "StopDrawPolygonButton";
            this.StopDrawPolygonButton.Size = new System.Drawing.Size(178, 23);
            this.StopDrawPolygonButton.TabIndex = 4;
            this.StopDrawPolygonButton.Text = "StopDrawPolygon";
            this.StopDrawPolygonButton.UseVisualStyleBackColor = true;
            this.StopDrawPolygonButton.Click += new System.EventHandler(this.StopDrawPolygonButton_Click);
            // 
            // smallWidth
            // 
            this.smallWidth.AutoSize = true;
            this.smallWidth.Checked = true;
            this.smallWidth.Location = new System.Drawing.Point(3, 119);
            this.smallWidth.Name = "smallWidth";
            this.smallWidth.Size = new System.Drawing.Size(76, 17);
            this.smallWidth.TabIndex = 5;
            this.smallWidth.TabStop = true;
            this.smallWidth.Text = "smallWidth";
            this.smallWidth.UseVisualStyleBackColor = true;
            this.smallWidth.Click += new System.EventHandler(this.smallWidth_Click);
            // 
            // mediumWidth
            // 
            this.mediumWidth.AutoSize = true;
            this.mediumWidth.Location = new System.Drawing.Point(85, 119);
            this.mediumWidth.Name = "mediumWidth";
            this.mediumWidth.Size = new System.Drawing.Size(89, 17);
            this.mediumWidth.TabIndex = 6;
            this.mediumWidth.Text = "mediumWidth";
            this.mediumWidth.UseVisualStyleBackColor = true;
            this.mediumWidth.Click += new System.EventHandler(this.mediumWidth_Click);
            // 
            // bigWidth
            // 
            this.bigWidth.AutoSize = true;
            this.bigWidth.Location = new System.Drawing.Point(3, 142);
            this.bigWidth.Name = "bigWidth";
            this.bigWidth.Size = new System.Drawing.Size(67, 17);
            this.bigWidth.TabIndex = 7;
            this.bigWidth.Text = "bigWidth";
            this.bigWidth.UseVisualStyleBackColor = true;
            this.bigWidth.Click += new System.EventHandler(this.bigWidth_Click);
            // 
            // SelectLineButton
            // 
            this.SelectLineButton.Location = new System.Drawing.Point(3, 165);
            this.SelectLineButton.Name = "SelectLineButton";
            this.SelectLineButton.Size = new System.Drawing.Size(178, 23);
            this.SelectLineButton.TabIndex = 8;
            this.SelectLineButton.Text = "Select Element";
            this.SelectLineButton.UseVisualStyleBackColor = true;
            this.SelectLineButton.Click += new System.EventHandler(this.SelectLineButton_Click);
            // 
            // DrawCircleButton
            // 
            this.DrawCircleButton.Location = new System.Drawing.Point(3, 194);
            this.DrawCircleButton.Name = "DrawCircleButton";
            this.DrawCircleButton.Size = new System.Drawing.Size(178, 23);
            this.DrawCircleButton.TabIndex = 9;
            this.DrawCircleButton.Text = "DrawCircle";
            this.DrawCircleButton.UseVisualStyleBackColor = true;
            this.DrawCircleButton.Click += new System.EventHandler(this.drawCircleButton_Click);
            // 
            // ClearBitmapButton
            // 
            this.ClearBitmapButton.Location = new System.Drawing.Point(3, 223);
            this.ClearBitmapButton.Name = "ClearBitmapButton";
            this.ClearBitmapButton.Size = new System.Drawing.Size(178, 23);
            this.ClearBitmapButton.TabIndex = 10;
            this.ClearBitmapButton.Text = "ClearBitmap";
            this.ClearBitmapButton.UseVisualStyleBackColor = true;
            this.ClearBitmapButton.Click += new System.EventHandler(this.ClearBitmapButton_Click);
            // 
            // RedrawBitmapButton
            // 
            this.RedrawBitmapButton.Location = new System.Drawing.Point(3, 252);
            this.RedrawBitmapButton.Name = "RedrawBitmapButton";
            this.RedrawBitmapButton.Size = new System.Drawing.Size(178, 23);
            this.RedrawBitmapButton.TabIndex = 11;
            this.RedrawBitmapButton.Text = "RedrawBitmap";
            this.RedrawBitmapButton.UseVisualStyleBackColor = true;
            this.RedrawBitmapButton.Click += new System.EventHandler(this.RedrawBitmapButton_Click);
            // 
            // TimeTextBox
            // 
            this.TimeTextBox.Location = new System.Drawing.Point(3, 281);
            this.TimeTextBox.Name = "TimeTextBox";
            this.TimeTextBox.Size = new System.Drawing.Size(178, 20);
            this.TimeTextBox.TabIndex = 12;
            // 
            // DeleteObjectButton
            // 
            this.DeleteObjectButton.Enabled = false;
            this.DeleteObjectButton.Location = new System.Drawing.Point(3, 307);
            this.DeleteObjectButton.Name = "DeleteObjectButton";
            this.DeleteObjectButton.Size = new System.Drawing.Size(178, 23);
            this.DeleteObjectButton.TabIndex = 13;
            this.DeleteObjectButton.Text = "DeleteObjectButton";
            this.DeleteObjectButton.UseVisualStyleBackColor = true;
            this.DeleteObjectButton.Click += new System.EventHandler(this.DeleteObjectButton_Click);
            // 
            // MoveObjectButton
            // 
            this.MoveObjectButton.Enabled = false;
            this.MoveObjectButton.Location = new System.Drawing.Point(3, 336);
            this.MoveObjectButton.Name = "MoveObjectButton";
            this.MoveObjectButton.Size = new System.Drawing.Size(178, 23);
            this.MoveObjectButton.TabIndex = 14;
            this.MoveObjectButton.Text = "MoveObjectButton";
            this.MoveObjectButton.UseVisualStyleBackColor = true;
            this.MoveObjectButton.Click += new System.EventHandler(this.MoveObjectButton_Click);
            // 
            // CircleRadiusTrackBar
            // 
            this.CircleRadiusTrackBar.Enabled = false;
            this.CircleRadiusTrackBar.Location = new System.Drawing.Point(3, 365);
            this.CircleRadiusTrackBar.Maximum = 500;
            this.CircleRadiusTrackBar.Minimum = 10;
            this.CircleRadiusTrackBar.Name = "CircleRadiusTrackBar";
            this.CircleRadiusTrackBar.Size = new System.Drawing.Size(178, 45);
            this.CircleRadiusTrackBar.TabIndex = 15;
            this.CircleRadiusTrackBar.Value = 10;
            this.CircleRadiusTrackBar.Scroll += new System.EventHandler(this.ChangeRadiusTrackBar_Scroll);
            // 
            // LineLengthTrackBar
            // 
            this.LineLengthTrackBar.Enabled = false;
            this.LineLengthTrackBar.Location = new System.Drawing.Point(3, 416);
            this.LineLengthTrackBar.Name = "LineLengthTrackBar";
            this.LineLengthTrackBar.Size = new System.Drawing.Size(178, 45);
            this.LineLengthTrackBar.TabIndex = 16;
            this.LineLengthTrackBar.Scroll += new System.EventHandler(this.LineLengthTrackBar_Scroll);
            // 
            // AddVerticleButton
            // 
            this.AddVerticleButton.Enabled = false;
            this.AddVerticleButton.Location = new System.Drawing.Point(3, 467);
            this.AddVerticleButton.Name = "AddVerticleButton";
            this.AddVerticleButton.Size = new System.Drawing.Size(75, 23);
            this.AddVerticleButton.TabIndex = 17;
            this.AddVerticleButton.Text = "AddVerticleButton";
            this.AddVerticleButton.UseVisualStyleBackColor = true;
            this.AddVerticleButton.Click += new System.EventHandler(this.AddVerticleButton_Click);
            // 
            // MoveVerticle
            // 
            this.MoveVerticle.Enabled = false;
            this.MoveVerticle.Location = new System.Drawing.Point(84, 467);
            this.MoveVerticle.Name = "MoveVerticle";
            this.MoveVerticle.Size = new System.Drawing.Size(90, 23);
            this.MoveVerticle.TabIndex = 2;
            this.MoveVerticle.Text = "MoveVerticle";
            this.MoveVerticle.UseVisualStyleBackColor = true;
            this.MoveVerticle.Click += new System.EventHandler(this.MoveVerticle_Click);
            // 
            // SetHorizontal
            // 
            this.SetHorizontal.Enabled = false;
            this.SetHorizontal.Location = new System.Drawing.Point(3, 496);
            this.SetHorizontal.Name = "SetHorizontal";
            this.SetHorizontal.Size = new System.Drawing.Size(75, 23);
            this.SetHorizontal.TabIndex = 24;
            this.SetHorizontal.Text = "SetHorizontal";
            this.SetHorizontal.UseVisualStyleBackColor = true;
            this.SetHorizontal.Click += new System.EventHandler(this.SetHorizontal_Click);
            // 
            // SetVertical
            // 
            this.SetVertical.Enabled = false;
            this.SetVertical.Location = new System.Drawing.Point(84, 496);
            this.SetVertical.Name = "SetVertical";
            this.SetVertical.Size = new System.Drawing.Size(93, 23);
            this.SetVertical.TabIndex = 23;
            this.SetVertical.Text = "SetVertical";
            this.SetVertical.UseVisualStyleBackColor = true;
            this.SetVertical.Click += new System.EventHandler(this.SetVertical_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.colorButton4);
            this.groupBox1.Controls.Add(this.colorButton1);
            this.groupBox1.Controls.Add(this.colorButton2);
            this.groupBox1.Controls.Add(this.colorButton3);
            this.groupBox1.Location = new System.Drawing.Point(3, 525);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(197, 69);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // colorButton4
            // 
            this.colorButton4.AutoSize = true;
            this.colorButton4.Location = new System.Drawing.Point(91, 42);
            this.colorButton4.Name = "colorButton4";
            this.colorButton4.Size = new System.Drawing.Size(90, 17);
            this.colorButton4.TabIndex = 21;
            this.colorButton4.Text = "DeepSkyBlue";
            this.colorButton4.UseVisualStyleBackColor = true;
            this.colorButton4.Click += new System.EventHandler(this.colorButton4_Click);
            // 
            // colorButton1
            // 
            this.colorButton1.AutoSize = true;
            this.colorButton1.Checked = true;
            this.colorButton1.Location = new System.Drawing.Point(6, 19);
            this.colorButton1.Name = "colorButton1";
            this.colorButton1.Size = new System.Drawing.Size(84, 17);
            this.colorButton1.TabIndex = 18;
            this.colorButton1.TabStop = true;
            this.colorButton1.Text = "SpringGreen";
            this.colorButton1.UseVisualStyleBackColor = true;
            this.colorButton1.Click += new System.EventHandler(this.colorButton1_Click);
            // 
            // colorButton2
            // 
            this.colorButton2.AutoSize = true;
            this.colorButton2.Location = new System.Drawing.Point(6, 42);
            this.colorButton2.Name = "colorButton2";
            this.colorButton2.Size = new System.Drawing.Size(62, 17);
            this.colorButton2.TabIndex = 19;
            this.colorButton2.Text = "Crimson";
            this.colorButton2.UseVisualStyleBackColor = true;
            this.colorButton2.Click += new System.EventHandler(this.colorButton2_Click);
            // 
            // colorButton3
            // 
            this.colorButton3.AutoSize = true;
            this.colorButton3.Location = new System.Drawing.Point(91, 19);
            this.colorButton3.Name = "colorButton3";
            this.colorButton3.Size = new System.Drawing.Size(83, 17);
            this.colorButton3.TabIndex = 20;
            this.colorButton3.Text = "DarkOrange";
            this.colorButton3.UseVisualStyleBackColor = true;
            this.colorButton3.Click += new System.EventHandler(this.colorButton3_Click);
            // 
            // ConcentricCircles
            // 
            this.ConcentricCircles.Location = new System.Drawing.Point(3, 600);
            this.ConcentricCircles.Name = "ConcentricCircles";
            this.ConcentricCircles.Size = new System.Drawing.Size(181, 23);
            this.ConcentricCircles.TabIndex = 2;
            this.ConcentricCircles.Text = "ConcentricCircles";
            this.ConcentricCircles.UseVisualStyleBackColor = true;
            this.ConcentricCircles.Click += new System.EventHandler(this.SetConcrenticCircle);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1339, 680);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.mainPictureBox);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CircleRadiusTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineLengthTrackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button SetPixelButton;
        private DirectBitmap directBitmap;
        private System.Windows.Forms.Button DrawLineButton;
        private System.Windows.Forms.Button StartDrawPolygonButton;
        private System.Windows.Forms.Button StopDrawPolygonButton;
        private System.Windows.Forms.RadioButton smallWidth;
        private System.Windows.Forms.RadioButton mediumWidth;
        private System.Windows.Forms.RadioButton bigWidth;
        private System.Windows.Forms.Button SelectLineButton;
        private System.Windows.Forms.Button DrawCircleButton;
        private System.Windows.Forms.Button ClearBitmapButton;
        private System.Windows.Forms.Button RedrawBitmapButton;
        private System.Windows.Forms.TextBox TimeTextBox;
        private System.Windows.Forms.Button MoveVerticle;
        private System.Windows.Forms.Button DeleteObjectButton;
        private System.Windows.Forms.Button MoveObjectButton;
        private System.Windows.Forms.TrackBar CircleRadiusTrackBar;
        private System.Windows.Forms.TrackBar LineLengthTrackBar;
        private System.Windows.Forms.Button AddVerticleButton;
        private System.Windows.Forms.RadioButton colorButton1;
        private System.Windows.Forms.RadioButton colorButton2;
        private System.Windows.Forms.RadioButton colorButton3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton colorButton4;
        private System.Windows.Forms.Button SetHorizontal;
        private System.Windows.Forms.Button SetVertical;
        private System.Windows.Forms.Button ConcentricCircles;
    }
}

