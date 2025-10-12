using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBallAnimation2025
{
    public class GraphicsDrawable : IDrawable
    {
        public Ball[]? Balls;
       

        public int ballCount { get; set; } = 100;
        public double ballSpeed { get; set; } = 10;
        public double width { get; set; } = 1000;
        public double height { get; set; } = 1000;
        public GraphicsDrawable()
        {
            newBalls(ballCount);
            

        }

        private void newBalls(int ballCount)
        {
            Balls = new Ball[ballCount];
            Random rand = new();
            for (int i = 0; i < Balls.Length; i++)
            {
                double X = rand.NextDouble() * width;
                double Y = rand.NextDouble() * height;
                double Radius = rand.NextDouble() * 5 + 5;
                double XVel = rand.NextDouble() - .5;
                double YVel = rand.NextDouble() - .5;
                byte R = (byte)rand.Next(50, 256);
                byte G = (byte)rand.Next(50, 256);
                byte B = (byte)rand.Next(50, 256);

                // added
                if (rand.NextDouble() < 0.5)
                {
                    Balls[i] = new Ball(X, Y, Radius, XVel, YVel, R, G, B);
                }
                else
                {
                    byte pr = 255, pg = 105, pb = 180;
                    Balls[i] = new Hearts(X, Y, Radius, XVel, YVel, pr, pg, pb);
                }
            }
        }
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {

            if (Balls is null) return;

            foreach (var b in Balls)
            {
                b.Advance(ballSpeed, width, height);

                // If it's a heart, use its Draw; otherwise Ball.Draw
                if (b is Hearts h) h.Draw(canvas);
                else b.Draw(canvas);

            }
        }


         /*foreach (Ball ball in Balls!)
            {

                ball.Advance(ballSpeed, width, height);
                ball.Draw(canvas);
            }
        }
         */
        public void SetBallCount(int count)
        {
            if (count < 1) count = 1;
            ballCount = count;
            newBalls(ballCount);
        }
    }
}
