using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Graphics;

namespace MauiBallAnimation2025
{
    public class Hearts : Ball
    {
        public Hearts(double x, double y, double radius,
                      double xVel, double yVel,
                      byte r, byte g, byte b)
            : base(x, y, radius, xVel, yVel, r, g, b) { }

        // Hide (not override) the Draw method
        public new void Draw(ICanvas canvas)
        {
            canvas.FillColor = Color.FromRgb(255, 105, 180);
            DrawHeart(canvas);
        }

        private void DrawHeart(ICanvas canvas)
        {
            float s = (float)(Radius * 2.0f);

            var p = new PathF();

            // Start at top cusp
            float curX = 0f, curY = -0.35f * s;
            p.MoveTo(curX, curY);

            // Left lobe cubic (compat)
            CubicToCompat(ref p, ref curX, ref curY,
                -0.50f * s, -1.00f * s,   // c1
                -1.00f * s, -0.10f * s,   // c2
                 0.00f * s, 0.60f * s);  // end

            // Right lobe cubic (compat)
            CubicToCompat(ref p, ref curX, ref curY,
                 1.00f * s, -0.10f * s,   // c1
                 0.50f * s, -1.00f * s,   // c2
                 0.00f * s, -0.35f * s);  // end

            p.Close();

            canvas.SaveState();
            canvas.Translate((float)X, (float)Y);
            canvas.FillColor = Color.FromRgb(R, G, B);
            canvas.FillPath(p);
            canvas.RestoreState();
        }

        /// <summary>
        /// Adds a cubic Bézier to a PathF by approximating with line segments.
        /// Works on MAUI builds without PathF.CubicTo/CubicBezierTo.
        /// </summary>
        private static void CubicToCompat(ref PathF path, ref float curX, ref float curY,
                                          float cx1, float cy1, float cx2, float cy2,
                                          float x, float y, int segments = 24)
        {
            // P0 = current point
            float x0 = curX, y0 = curY;

            // Parametric cubic Bézier
            // B(t) = (1-t)^3 P0 + 3(1-t)^2 t C1 + 3(1-t) t^2 C2 + t^3 P3
            for (int i = 1; i <= segments; i++)
            {
                float t = i / (float)segments;
                float u = 1f - t;
                float uu = u * u;
                float tt = t * t;

                float bx =
                    uu * u * x0 +
                    3f * uu * t * cx1 +
                    3f * u * tt * cx2 +
                    tt * t * x;

                float by =
                    uu * u * y0 +
                    3f * uu * t * cy1 +
                    3f * u * tt * cy2 +
                    tt * t * y;

                path.LineTo(bx, by);
            }

            // update current point
            curX = x; curY = y;
        }
    }
}
