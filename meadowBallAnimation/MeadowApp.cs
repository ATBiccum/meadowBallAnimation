using Meadow;
using Meadow.Devices;
using Meadow.Foundation;
using Meadow.Foundation.Displays.TftSpi;
using Meadow.Foundation.Graphics;
using Meadow.Foundation.Leds;
using Meadow.Hardware;
using System;
using System.Threading;

namespace MeadowClockGraphics
{
    public class MeadowApp : App<F7Micro, MeadowApp>
    {
        readonly Color WatchBackgroundColor = Color.White;

        St7735 st7735;
        GraphicsLibrary graphics;
        int displayWidth, displayHeight;
        int hour, minute, second, tick;

        public MeadowApp()
        {
            var led = new RgbLed(Device, Device.Pins.OnboardLedRed, Device.Pins.OnboardLedGreen, Device.Pins.OnboardLedBlue);
            led.SetColor(RgbLed.Colors.Red);

            var config = new SpiClockConfiguration(6000, SpiClockConfiguration.Mode.Mode3);
            st7735 = new St7735
            (
                device: Device,
                spiBus: Device.CreateSpiBus(Device.Pins.SCK, Device.Pins.MOSI, Device.Pins.MISO, config), //Old pinouts
                                                                                                          //spiBus: Device.CreateSpiBus(Device.Pins.SCK, Device.Pins.COPI, Device.Pins.CIPO, config),   //Changed MOSI and MISO To COPI and CIPO, new pin names
                chipSelectPin: Device.Pins.D02,
                dcPin: Device.Pins.D01,
                resetPin: Device.Pins.D00,
                width: 128, height: 160, St7735.DisplayType.ST7735R                                         //Added "St7735.DisplayType.ST7735R" from meadow website
            );

            //Call functions here

        }
    }  
}
