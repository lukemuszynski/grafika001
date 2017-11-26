namespace Grafika002
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
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.StartDrawingButton = new System.Windows.Forms.Button();
            this.StopDrawingButton = new System.Windows.Forms.Button();
            this.IntersectAllPolygonsButton = new System.Windows.Forms.Button();
            this.StartAnimationButton = new System.Windows.Forms.Button();
            this.StopAnimationButton = new System.Windows.Forms.Button();
            this.DeletePolygonButton = new System.Windows.Forms.Button();
            this.AnimationBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.Location = new System.Drawing.Point(0, 0);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(1080, 676);
            this.mainPictureBox.TabIndex = 1;
            this.mainPictureBox.TabStop = false;
            this.mainPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.StartDrawingButton);
            this.flowLayoutPanel1.Controls.Add(this.StopDrawingButton);
            this.flowLayoutPanel1.Controls.Add(this.IntersectAllPolygonsButton);
            this.flowLayoutPanel1.Controls.Add(this.StartAnimationButton);
            this.flowLayoutPanel1.Controls.Add(this.StopAnimationButton);
            this.flowLayoutPanel1.Controls.Add(this.DeletePolygonButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1086, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(234, 676);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // StartDrawingButton
            // 
            this.StartDrawingButton.Location = new System.Drawing.Point(3, 3);
            this.StartDrawingButton.Name = "StartDrawingButton";
            this.StartDrawingButton.Size = new System.Drawing.Size(231, 23);
            this.StartDrawingButton.TabIndex = 0;
            this.StartDrawingButton.Text = "StartDrawingButton";
            this.StartDrawingButton.UseVisualStyleBackColor = true;
            this.StartDrawingButton.Click += new System.EventHandler(this.StartDrawingClick);
            // 
            // StopDrawingButton
            // 
            this.StopDrawingButton.Location = new System.Drawing.Point(3, 32);
            this.StopDrawingButton.Name = "StopDrawingButton";
            this.StopDrawingButton.Size = new System.Drawing.Size(231, 23);
            this.StopDrawingButton.TabIndex = 1;
            this.StopDrawingButton.Text = "StopDrawingButton";
            this.StopDrawingButton.UseVisualStyleBackColor = true;
            this.StopDrawingButton.Click += new System.EventHandler(this.StopDrawingClick);
            // 
            // IntersectAllPolygonsButton
            // 
            this.IntersectAllPolygonsButton.Location = new System.Drawing.Point(3, 61);
            this.IntersectAllPolygonsButton.Name = "IntersectAllPolygonsButton";
            this.IntersectAllPolygonsButton.Size = new System.Drawing.Size(231, 23);
            this.IntersectAllPolygonsButton.TabIndex = 2;
            this.IntersectAllPolygonsButton.Text = "IntersectAllPolygonsButton";
            this.IntersectAllPolygonsButton.UseVisualStyleBackColor = true;
            this.IntersectAllPolygonsButton.Click += new System.EventHandler(this.IntersectAllPolygons);
            // 
            // StartAnimationButton
            // 
            this.StartAnimationButton.Location = new System.Drawing.Point(3, 90);
            this.StartAnimationButton.Name = "StartAnimationButton";
            this.StartAnimationButton.Size = new System.Drawing.Size(231, 23);
            this.StartAnimationButton.TabIndex = 3;
            this.StartAnimationButton.Text = "StartAnimationButton";
            this.StartAnimationButton.UseVisualStyleBackColor = true;
            this.StartAnimationButton.Click += new System.EventHandler(this.StartAnimation);
            // 
            // StopAnimationButton
            // 
            this.StopAnimationButton.Location = new System.Drawing.Point(3, 119);
            this.StopAnimationButton.Name = "StopAnimationButton";
            this.StopAnimationButton.Size = new System.Drawing.Size(231, 23);
            this.StopAnimationButton.TabIndex = 4;
            this.StopAnimationButton.Text = "StopAnimationButton";
            this.StopAnimationButton.UseVisualStyleBackColor = true;
            this.StopAnimationButton.Click += new System.EventHandler(this.StopAnimation);
            // 
            // DeletePolygonButton
            // 
            this.DeletePolygonButton.Location = new System.Drawing.Point(3, 148);
            this.DeletePolygonButton.Name = "DeletePolygonButton";
            this.DeletePolygonButton.Size = new System.Drawing.Size(231, 23);
            this.DeletePolygonButton.TabIndex = 5;
            this.DeletePolygonButton.Text = "DeletePolygonButton";
            this.DeletePolygonButton.UseVisualStyleBackColor = true;
            this.DeletePolygonButton.Click += new System.EventHandler(this.DeletePolygon);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 677);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.mainPictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button StartDrawingButton;
        private System.Windows.Forms.Button StopDrawingButton;
        private System.Windows.Forms.Button IntersectAllPolygonsButton;
        private System.Windows.Forms.Button StartAnimationButton;
        private System.ComponentModel.BackgroundWorker AnimationBackgroundWorker;
        private System.Windows.Forms.Button StopAnimationButton;
        private System.Windows.Forms.Button DeletePolygonButton;
    }
}

