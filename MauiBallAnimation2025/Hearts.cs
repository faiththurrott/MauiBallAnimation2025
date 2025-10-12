using Microsoft.Maui.Graphics;

namespace MauiBallAnimation2025
{
    // Same physics as Ball; only the drawing is different.
    public class Hearts : Ball
    {
        public Hearts(double x, double y, double radius,
                      double xVel, double yVel,
                      byte r, byte g, byte b)
            : base(x, y, radius, xVel, yVel, r, g, b) { }

        public new void Draw(ICanvas canvas)
        {
            // Make all hearts pink (tweak if you like)
            canvas.FillColor = Color.FromRgb(255, 105, 180); // HotPink

            // Draw at (X,Y) with size based on Radius
            canvas.SaveState();
            canvas.Translate((float)X, (float)Y);

            float r = (float)Radius;

            // Two circular lobes (slightly overlapping)
            float lobeOffset = 0.6f * r;
            float lobeRadius = 0.8f * r;
            canvas.FillCircle(-lobeOffset, -lobeOffset, lobeRadius); // left lobe
            canvas.FillCircle(+lobeOffset, -lobeOffset, lobeRadius); // right lobe

            // Bottom “point” as a simple triangle
            var p = new PathF();
            p.MoveTo(-1.2f * r, -0.2f * r);   // left base
            p.LineTo(0.0f * r, 1.4f * r);   // tip
            p.LineTo(1.2f * r, -0.2f * r);   // right base
            p.Close();
            canvas.FillPath(p);

            canvas.RestoreState();
        }
    }
}
