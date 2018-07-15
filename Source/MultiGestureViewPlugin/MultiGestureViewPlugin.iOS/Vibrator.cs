using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AudioToolbox;
using Foundation;
using UIKit;

namespace MultiGestureViewPlugin.iOS
{
    public class Vibrator : IVibrator
    {
        public bool CanVibrate => true;

        /// <summary>
        /// Vibrate the phone for specified amount of time
        /// </summary>
        /// <param name="vibrateSpan">Time span to vibrate. 500ms is default if null</param>
        public void Vibrate(int milliseconds) =>
            SystemSound.Vibrate.PlaySystemSound();
    }
}