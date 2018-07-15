using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Haptics;
using Windows.Foundation.Metadata;

namespace MultiGestureViewPlugin.UWP
{
    public class Vibrator : IVibrator
    {
        public bool CanVibrate
        {
            get
            {
                if (ApiInformation.IsTypePresent("Windows.Phone.Devices.Notification.VibrationDevice"))
                {
                    VibrationDevice vibrationDevice = Task.Run(async () => await VibrationDevice.GetDefaultAsync()).Result;
                    var v = vibrationDevice;

                    if (v != null)
                        return true;
                }

                return false;
            }
        }

        public void Vibrate(int milliseconds)
        {
            if (ApiInformation.IsTypePresent("Windows.Phone.Devices.Notification.VibrationDevice"))
            {
                var v = Task.Run(async () => await VibrationDevice.GetDefaultAsync()).Result;

                if (v == null)
                {
                    System.Diagnostics.Debug.WriteLine("Default vibration device not found.");
                    return;
                }

                if (milliseconds < 0)
                    milliseconds = 0;
                else if (milliseconds > 5000)
                    milliseconds = 5000;

                var time = TimeSpan.FromMilliseconds(milliseconds);
               // v.SimpleHapticsController.SendHapticFeedbackForDuration(new SimpleHapticsControllerFeedback(), 1, TimeSpan.FromMilliseconds(milliseconds));
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Vibration not supported on this device family.");
            }
        }
    }
}
