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
using MultiGestureViewPlugin.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using MultiGestureViewPlugin;

[assembly: ExportRenderer(typeof(MultiGestureView), typeof(MultiGestureViewRenderer))]
namespace MultiGestureViewPlugin.Droid
{
    public class MultiGestureViewRenderer : ViewRenderer<MultiGestureView, Android.Views.View>
    {
        private MultiGestureView _view;
        private Vibrator _vibrator = new Vibrator();

        public MultiGestureViewRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<MultiGestureView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                SetNativeControl(new Android.Views.View(Android.App.Application.Context));
            }

            if (e.NewElement != null)
            {
                _view = e.NewElement as MultiGestureView;
            }

            Control.SoundEffectsEnabled = true;

            Control.LongClickable = true;
            Control.LongClick += (s, ea) =>
            {
                if (_view != null)
                {
                    _view.LongPressedHandler?.Invoke(s, ea);
                    if (_view.VibrateOnLongPress)
                    {
                     _vibrator.Vibrate(_view.LongPressVibrationDuration);
                    }
                }
            };

            Control.Clickable = true;
            Control.Click += (s, ea) =>
            {
                if (_view != null)
                {
                    _view.TappedHandler?.Invoke(s, ea);
                    if (_view.VibrateOnTap)
                    {
                        _vibrator.Vibrate(_view.TapVibrationDuration);
                    }
                }
            };
        }
    }
}