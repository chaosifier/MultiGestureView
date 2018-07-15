using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

[assembly: UsesPermission(Android.Manifest.Permission.Vibrate)]
namespace MultiGestureViewPlugin.Droid
{
    public class Vibrator : IVibrator
    {
        public bool CanVibrate
        {
            get
            {
                if ((int)Build.VERSION.SdkInt >= 11)
                {
                    using (var v = (Android.OS.Vibrator)Android.App.Application.Context.GetSystemService(Context.VibratorService))
                        return v.HasVibrator;
                }
                return true;
            }
        }

        public void Vibrate(int milliseconds)
        {
            using (var v = (Android.OS.Vibrator)Android.App.Application.Context.GetSystemService(Context.VibratorService))
            {
                if ((int)Build.VERSION.SdkInt >= 11)
                {
#if __ANDROID_11__
                    if (!v.HasVibrator)
                    {
                        Console.WriteLine("Android device does not have vibrator.");
                        return;
                    }
#endif
                }

                if (milliseconds < 0)
                    milliseconds = 0;

                try
                {
                    v.Vibrate((int)milliseconds);
                }
                catch
                {
                    Console.WriteLine("Unable to vibrate Android device, ensure VIBRATE permission is set.");
                }
            }
        }
    }
}