using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meadow;
using Meadow.Devices;
using Meadow.Foundation;
using Meadow.Foundation.Leds;

namespace meadowBallAnimation
{
    class Ball
    {
        public int diameter { get; }

        public int positionX { get; set; }

        public int positionY { get; set; }

        public int speedX { get; set; }

        public int speedY { get; set; }

        public int frameRate { get; }

        public Color ballColor { get; }

        public Ellipse circle;

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
            
        }
    }
}
