using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBallAnimation2025
{
    public class GraphicsDrawable : IDrawable
    {
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            // Drawing code goes here
            canvas.StrokeColor = Colors.Red;
            canvas.StrokeSize = 4;
            canvas.DrawEllipse(10, 10, 100, 100);
        }
    }
}
