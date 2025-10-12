using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBallAnimation2025
{
    public class Ball
    {
        public double X; // this is the x coordinate of the ball
        public double Y; // this is the y coordinate of the ball
        public double Radius = 5; // this is the radius of the ball
        public double XVel; // this is the x velocity of the ball
        public double YVel; // this is the y velocity of the ball
        public byte R, G, B; // this is the RGB value of the ball

        public Ball(double x, double y, double radius, double xVel, double yVel, byte r, byte g, byte b) // this is a constructor
        {
            X = x; // this is the x coordinate of the ball
            Y = y; // this is the y coordinate of the ball
            Radius = radius; // this is the radius of the ball
            XVel = xVel; // this is the x velocity of the ball
            YVel = yVel; // this is the y velocity of the ball
            R = r; // this is the red value of the ball
            G = g; // this is the green value of the ball
            B = b; // this is the blue value of the ball
        }
        public void Advance(double ballSpeed, double width, double height)
        {
            MoveBall(ballSpeed);
            Bounce(width, height);
        }

        private void MoveBall(double ballSpeed)
        {
            X += XVel * ballSpeed;
            Y += YVel * ballSpeed;
        }
        private void Bounce(double width, double height)
        {
            double minX = Radius; // left wall
            double maxX = width - Radius; // right wall
            double minY = Radius; // top wall
            double maxY = height - Radius; // bottom wall

            if (X < minX)
            {
                double overshoot = minX - X;
                X = minX + overshoot;
                XVel = -XVel;
            }
            else if(X > maxX)
            {
                double overshoot = X - maxX;
                X = maxX - overshoot;
                XVel = -XVel;
            }

            if (Y < minY)
            {
                double overshoot = minY - Y;
                Y = minY + overshoot;
                YVel = -YVel;
            }
            else if(Y > maxY)
            {
                double overshoot = Y - maxY; // how far did we go past the wall
                Y = maxY - overshoot;
                YVel = -YVel; // reverse Y velocity
            }
        }
      
        public void Draw(ICanvas canvas)
        {
            canvas.FillColor = Color.FromRgb(R, G, B);
            canvas.FillCircle((float)X, (float)Y, (float)Radius);
        }
        }
    }


