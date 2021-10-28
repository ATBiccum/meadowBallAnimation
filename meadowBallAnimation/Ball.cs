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
    /*class Ellipse
    {
        //public void DrawCircle(int centerX, int centerY, int radius, Color color, bool filled = false, bool centerBetweenPixels = false)
        public int centerX { get; set; }
        public int centerY { get; set; }
        public int radius { get; set; }
        public Color color { get; set; }

        public Ellipse(int centerX,
                        int centerY,
                        int radius,
                        Color color)
        {
            this.centerX = centerX;
            this.centerY = centerY;
            this.radius = radius;
            this.color = color;
        }*/

    }

    class Ball
    {
        St7735 st7735;
        GraphicsLibrary graphics;

        public int centerX { get; set; }

        public int centerY { get; set; }

        public int radius { get; }
        
        public Color ballColor { get; }

        public int speedX { get; set; }

        public int speedY { get; set; }

        public int frameRate { get; }

        

        //public Ellipse circle;  //Need something to replace this

        public Ball(int centerX,
                    int centerY,
                    int radius,
                    int speedX,
                    int speedY,
                    int frameRate,
                    Color ballColor)
        {
            this.centerX = centerX;
            this.centerY = centerY;
            this.radius = radius;
            this.ballColor = ballColor;
            this.speedX = speedX;
            this.speedY = speedY;
            this.frameRate = frameRate;
            CreateBall();

        }

        private void CreateBall()
        {
               
        }

    }
}
