﻿using Meadow;
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
            var led = new RgbLed(Device, Device.Pins.OnboardLedRed, Device.Pins.OnboardLedGreen, Device.Pins.OnboardLedBlue);
            led.SetColor(RgbLed.Colors.Red);

            var config = new SpiClockConfiguration(6000, SpiClockConfiguration.Mode.Mode3);
            st7735 = new St7735
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
        }
    }  
}
