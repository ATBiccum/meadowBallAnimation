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
    class Ball
    {
        public int radius{ get; }

        public int positionY { get; set; }

        public int positionX { get; set; }

        public int speedX { get; set; }

        public int speedY { get; set; }

        public Color ballColor { get; }
       
        public int displayWidth { get; }

        public int displayHeight { get; }

        public Color backgroundColor { get; }

        public Ball(int radius,
                    int positionY,
                    int positionX,
                    int speedX,
                    int speedY,
                    Color ballColor,
                    int displayWidth,
                    int displayHeight,
                    Color backgroundColor)
        {
            this.radius = radius;
            this.positionY = positionY;
            this.positionX = positionX;
            this.speedX = speedX;
            this.speedY = speedY;
            this.ballColor = ballColor;
            this.displayWidth = displayWidth;
            this.displayHeight = displayHeight;
            this.backgroundColor = backgroundColor;
        }
        public void MoveBall()
        {
            positionX += speedX;
            positionY += speedY;
        }
        public void BounceBall(double actualWidth, double actualHeight)
        {
            if (positionX + radius > actualWidth) //If the positionX + diameter is greater than the width the change direction
            {
                speedX *= -1; //Reverse direction of the ball in X axis
            }

            if (positionY + radius > actualHeight) //If the positionY + diameter is greater than the height the change direction
            {
                speedY *= -1; //Reverse direction of the ball in Y axis
            }

            if (positionX < 0) //If the ball hits the left side 
            {
                speedX *= -1; //Reverse direction of the ball in X axis
            }

            if (positionY < 0) //Reverse direction of the ball in the Y axis
            {
                speedY *= -1; //Reverse direction of the ball in Y axis
            }
        }
    }
}


