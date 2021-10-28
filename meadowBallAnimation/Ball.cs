using Meadow;
using Meadow.Devices;
using Meadow.Foundation;
using Meadow.Foundation.Displays.TftSpi;
using Meadow.Foundation.Graphics;
using Meadow.Foundation.Leds;
using Meadow.Hardware;
using System;
using System.Threading;

namespace meadowBallAnimation
{
    class Ellipse
    {
        //public void DrawCircle(int centerX, int centerY, int radius, Color color, bool filled = false, bool centerBetweenPixels = false)
        public int centerX { get; set; }
        public int centerY { get; set; }
        public int radius { get; set; }
        public Color color { get; set; }
    }

    class Ball
    {
        St7735 st7735;
        GraphicsLibrary graphics;

        public int diameter { get; }

        public int positionX { get; set; }

        public int positionY { get; set; }

        public int speedX { get; set; }

        public int speedY { get; set; }

        public int frameRate { get; }

        public Color ballColor { get; }

        public Ellipse circle;  //Need something to replace this

        public Ball(int diameter,
                    int positionX,
                    int positionY,
                    int speedX,
                    int speedY,
                    int frameRate,
                    Color ballColor)
        {
            this.diameter = diameter;
            this.positionX = positionX;
            this.positionY = positionY;
            this.speedX = speedX;
            this.speedY = speedY;
            this.ballColor = ballColor;
            CreateBall();

        }

        private void CreateBall()
        {
            circle = new Ellipse();
        }

    }
}
