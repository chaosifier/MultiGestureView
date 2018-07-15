using MultiGestureViewPlugin;
using MultiGestureViewPlugin.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(MultiGestureView), typeof(MultiGestureViewRenderer))]
namespace MultiGestureViewPlugin.UWP
{
    public class MultiGestureViewRenderer : ViewRenderer<MultiGestureView, Windows.UI.Xaml.FrameworkElement>
    {
        private MultiGestureView _view;
        protected override void OnElementChanged(ElementChangedEventArgs<MultiGestureView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                _view = e.NewElement as MultiGestureView;
            }

            IsRightTapEnabled = true;
            IsHoldingEnabled = true;
            if (_view != null)
            {
                RightTapped += (s, ea) =>
                {
                    _view?.RightClickedHandler?.Invoke(_view, null);
                };
                
                Holding += (s, ea) =>
                {
                    if (ea.HoldingState == Windows.UI.Input.HoldingState.Started)
                    {
                        _view?.LongPressedHandler?.Invoke(_view, null);
                    }
                };

                Tapped += (s, ea) =>
                {
                    _view?.TappedHandler?.Invoke(_view, null);
                };
            }
        }
    }
}
