using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBallAnimation2025
{
    public class GraphicsDrawable : IDrawable
    {
        public int count = 0;
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            // Drawing code goes here

            // Draw circle
            canvas.StrokeColor = Colors.DeepPink;
            canvas.StrokeSize = 4;
            canvas.DrawEllipse(10 + count++, 10 + count, 100, 100);
        }
    }
}
