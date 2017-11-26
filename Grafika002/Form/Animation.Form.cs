using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grafika002.Drawing;
using Grafika002.Drawing.BuildingBlocks;

namespace Grafika002
{
    public partial class Form1
    {
        
        private void IntersectAllPolygonsWithAnimationPolygon()
        {
            Polygons.RemoveAll(x => x.Points.Count < 3);

            for (int i = 0; i < Polygons.Count; i++)
            {
                if (Polygons[i] == animationPolygon)
                    continue;

                var intersectedPoints = SutherlandHodgman.GetIntersectedPolygon(Polygons[i].Points.ToArray(), animationPolygon.Points.ToArray());

                Polygon intersectedPolygn = new Polygon(_drawing);
                intersectedPolygn.AddVerticle(intersectedPoints);
                intersectedPolygn.FillingColor = Polygons[i].FillingColor;
                intersectedPolygn.FillEnabled = true;
                intersectedPolygn.DrawPolygon(true);
            }

        }

        private void StopAnimation(object sender, EventArgs e)
        {
            _continueAnimation = false;
        }

        private bool _continueAnimation = false;
        private void StartAnimation(object sender, EventArgs e)
        {
            _continueAnimation = true;
            LockButtons(Grafika002.Form1.ActionType.animation);

            animationPolygon = Polygon.RandomPolygon(_drawing);

            animationPolygon.FinnishDrawing();
            animationPolygon.FillEnabled = true;
            Polygons.Add(animationPolygon);

            int maxRight = 0;
            while (_continueAnimation && maxRight < mainPictureBox.Width)
            {
                lock (this.mainPictureBox.Image)
                {
                    _drawing.ClearBitmap();
                    Polygons.ForEach(x => x.DrawPolygon());
                    maxRight = animationPolygon.MoveRigth();
                    IntersectAllPolygonsWithAnimationPolygon();
                    this.mainPictureBox.Image = directBitmap.Bitmap;
                    mainPictureBox.Update();
                    mainPictureBox.Refresh();
                    Application.DoEvents();
                }
            }
            Polygons.Remove(animationPolygon);
            _drawing.ClearBitmap();
            Polygons.ForEach(x => x.DrawPolygon());
            this.mainPictureBox.Image = directBitmap.Bitmap;
            LockButtons(Grafika002.Form1.ActionType.animation, true);
        }

    }
}
