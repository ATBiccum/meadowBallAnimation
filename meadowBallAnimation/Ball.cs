using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

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
    }
}
