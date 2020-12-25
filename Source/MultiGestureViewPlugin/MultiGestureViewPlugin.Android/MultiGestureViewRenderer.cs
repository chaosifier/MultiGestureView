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
    public class MultiGestureViewRenderer : ViewRenderer<MultiGestureView, global::Android.Views.View>
    {
        private MultiGestureView _view;
        private Vibrator _vibrator = new Vibrator();

        public MultiGestureViewRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<MultiGestureView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                SetNativeControl(new global::Android.Views.View(global::Android.App.Application.Context));
            }

            if (e.NewElement != null)
            {
                _view = e.NewElement;
                setupControl();
            }

            if (e.OldElement != null)
            {
                destroyControl();
            }
        }

        private void setupControl()
        {
            Control.SoundEffectsEnabled = true;

            Control.LongClickable = true;
            Control.LongClick += Control_LongClick;

            Control.Clickable = true;
            Control.Click += Control_Click;
        }

        private void destroyControl()
        {
            Control.LongClick -= Control_LongClick;
            Control.Click -= Control_Click;
        }

        private void Control_Click(object sender, EventArgs e)
        {
            if (_view != null)
            {
                _view.TappedHandler?.Invoke(sender, e);

                if (_view.TappedCommand?.CanExecute(null) == true)
                    _view.TappedCommand?.Execute(null);

                if (_view.VibrateOnTap)
                {
                    _vibrator.Vibrate(_view.TapVibrationDuration);
                }
            }
        }

        private void Control_LongClick(object sender, LongClickEventArgs e)
        {
            if (_view != null)
            {
                _view.LongPressedHandler?.Invoke(sender, e);

                if (_view.LongPressedCommand?.CanExecute(null) == true)
                    _view.LongPressedCommand?.Execute(null);

                if (_view.VibrateOnLongPress)
                {
                    _vibrator.Vibrate(_view.LongPressVibrationDuration);
                }
            }
        }
    }
}