using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using MultiGestureViewPlugin;
using MultiGestureViewPlugin.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MultiGestureView), typeof(MultiGestureViewRenderer))]
namespace MultiGestureViewPlugin.iOS
{
    public class MultiGestureViewRenderer : ViewRenderer<MultiGestureView, UIKit.UIView>
    {
        private MultiGestureView _view;
        private Vibrator _vibrator = new Vibrator();
        private readonly UILongPressGestureRecognizer _longPressRecognizer;
        private readonly UITapGestureRecognizer _tapGestureRecognizer;

        public new static void Init() { }

        public MultiGestureViewRenderer()
        {
            _longPressRecognizer = new UILongPressGestureRecognizer((s) =>
            {
                if (s.State == UIGestureRecognizerState.Began && _view != null)
                {
                    if (_view.VibrateOnLongPress && _vibrator.CanVibrate)
                    {
                        _vibrator.Vibrate(_view.LongPressVibrationDuration);
                    }
                    _view.LongPressedHandler?.Invoke(_view, null);

                    if (_view.LongPressedCommand?.CanExecute(_view.LongPressedCommandParameter) == true)
                        _view.LongPressedCommand?.Execute(_view.LongPressedCommandParameter);
                }
            });

            _tapGestureRecognizer = new UITapGestureRecognizer(() =>
            {
                if (_view.VibrateOnTap && _vibrator.CanVibrate)
                {
                    _vibrator.Vibrate(_view.TapVibrationDuration);
                }
                _view.TappedHandler?.Invoke(_view, null);

                if (_view.TappedCommand?.CanExecute(_view.TappedCommandParameter) == true)
                    _view.TappedCommand?.Execute(_view.TappedCommandParameter);
            });
        }

        protected override void OnElementChanged(ElementChangedEventArgs<MultiGestureView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                var theView = new UIKit.UIView();
                SetNativeControl(theView);
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
            Control.UserInteractionEnabled = true;
            Control.AddGestureRecognizer(_longPressRecognizer);
            Control.AddGestureRecognizer(_tapGestureRecognizer);
        }

        private void destroyControl()
        {
            Control.RemoveGestureRecognizer(_longPressRecognizer);
            Control.RemoveGestureRecognizer(_tapGestureRecognizer);
        }
    }
}