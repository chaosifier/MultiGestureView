using System;
using System.Collections.Generic;
using System.Text;

namespace MultiGestureViewPlugin
{
    public interface IVibrator
    {
        void Vibrate(int milliseconds);
        bool CanVibrate { get; }
    }
}
