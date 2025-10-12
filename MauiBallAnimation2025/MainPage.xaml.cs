using System.Timers;
using Timer = System.Timers.Timer;


namespace MauiBallAnimation2025
{
    public partial class MainPage : ContentPage

    {
        private double milliSecondPerFrame = 30;
        public Timer? timer;

        public MainPage()
        {
            InitializeComponent();
        }

        private void ContentPage_Loaded(object sender, EventArgs e)
        {
            timer = new Timer();
            timer.Interval = milliSecondPerFrame;
            timer.Elapsed += new ElapsedEventHandler(updateBallField);
            timer.Start();

        }

        private void updateBallField(object? sender, ElapsedEventArgs e)
        {
            var graphicsView = BallGraphicsView;
            graphicsView.Invalidate();
        }

        private void Speed_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(Speed.Text, out var spd))
            {

                //if (spd < 0) spd = 0;
                if (spd > 500) spd = 500;
                ((GraphicsDrawable)BallGraphicsView.Drawable).ballSpeed = spd;
                BallGraphicsView.Invalidate();
            }
        }

        private void Balls_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(Balls.Text, out var n))
            {
                if (n < 1) n = 1;
                if (n > 20000) n = 20000;

                ((GraphicsDrawable)BallGraphicsView.Drawable).SetBallCount(n);
                BallGraphicsView.Invalidate();
            }
        }
    }
}

