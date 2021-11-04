/* meadowBallAnimation Project
 * 
 * ECET 230
 * Camosun College
 * Tony Biccum
 * November 4th, 2021
 * 
 * This project creates a ball on the ST7735 display and 
 * bounces it off the edges. We use an Initialize function to setup our 
 * meadow board, and create an instance of our ball from the ball class.
 * We do some timing in this as well to produce a frame rate for the ball
 * and the screen. To draw the ball we use an event handler based on this
 * timer. Every time the timer interval is hit we trigger the event handler
 * and draw the ball on the screen. This replaced our framerate from the
 * WPF version of this app. We then use the drawcircle function from
 * the meadow graphics library to draw our ball using pre defined 
 * parameters.
 * 
 */

using Meadow;
using Meadow.Devices;
using Meadow.Foundation;
using Meadow.Foundation.Displays.TftSpi;
using Meadow.Foundation.Graphics;
using Meadow.Foundation.Leds;
using Meadow.Hardware;
using System;
using System.Threading;
using System.Timers;

namespace meadowBallAnimation
{
    public class MeadowApp : App<F7Micro, MeadowApp>
    { 
        St7735 st7735;
        GraphicsLibrary graphics;
        Ball ball;

        static int displayWidth = 128;
        static int displayHeight = 160;
        int radius = 10;
        int positionX = displayWidth / 2;
        int positionY = displayHeight / 2;
        int speedX = 10;
        int speedY = 10;
        Color ballColor = Color.Yellow;
        Color BackgroundColor = Color.White;
        

        DateTime lastDateTime = new DateTime();

        private const int MOVE_INTERVAL = 200;

        private readonly System.Timers.Timer moveTimer = new System.Timers.Timer(MOVE_INTERVAL);

        public object LockObject
        {
            get { return this.graphics; }
        }
        public MeadowApp()
        {
            Initialize();
        }
        void Initialize()
        {
            var led = new RgbLed(Device, 
                                Device.Pins.OnboardLedRed, 
                                Device.Pins.OnboardLedGreen, 
                                Device.Pins.OnboardLedBlue);
            led.SetColor(RgbLed.Colors.Red); //Turn on the red led before initialization

            var config = new SpiClockConfiguration(6000, SpiClockConfiguration.Mode.Mode3); //Setup our spi at 6000 baud
            st7735 = new St7735 //Create a new instance of our display
            (
                device: Device,
                spiBus: Device.CreateSpiBus(Device.Pins.SCK, Device.Pins.MOSI, Device.Pins.MISO, config), 
                                                                                                          
                chipSelectPin: Device.Pins.D02,
                dcPin: Device.Pins.D01,
                resetPin: Device.Pins.D00,
                width: displayWidth, height: displayHeight, St7735.DisplayType.ST7735R_BlackTab  
            );

            ball = new Ball
            (
                displayWidth: displayWidth,
                displayHeight: displayHeight,
                backgroundColor: BackgroundColor,
                radius: radius,
                positionX: positionX,
                positionY: positionY,
                speedX: speedX,
                speedY: speedY,
                ballColor: ballColor
            );

            graphics = new GraphicsLibrary(st7735);

            graphics.Clear(true);

            moveTimer.AutoReset = true;
            moveTimer.Elapsed += MoveTimer_Elapsed;
            moveTimer.Start();
            lastDateTime = DateTime.Now;

            led.SetColor(RgbLed.Colors.Green);
        }

        private void MoveTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            lock(this.LockObject)
            {
                graphics.Clear();  
            }

            ball.MoveBall();
            ball.BounceBall(displayWidth, displayHeight);

            lock(this.LockObject)
            {
                graphics.DrawCircle
                (
                    centerX: ball.positionX,
                    centerY: ball.positionY,
                    radius: ball.radius,
                    color: ball.ballColor,
                    filled: false
                );
                graphics.Show();
            }
        }
    }  
}
