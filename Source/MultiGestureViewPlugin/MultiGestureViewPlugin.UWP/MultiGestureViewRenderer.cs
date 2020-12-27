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
            IsRightTapEnabled = true;
            IsHoldingEnabled = true;

            RightTapped += MultiGestureViewRenderer_RightTapped;
            Holding += MultiGestureViewRenderer_Holding;
            Tapped += MultiGestureViewRenderer_Tapped;
        }

        private void destroyControl()
        {
            RightTapped -= MultiGestureViewRenderer_RightTapped;
            Holding -= MultiGestureViewRenderer_Holding;
            Tapped -= MultiGestureViewRenderer_Tapped;
        }

        private void MultiGestureViewRenderer_Holding(object sender, Windows.UI.Xaml.Input.HoldingRoutedEventArgs e)
        {
            if (e.HoldingState == Windows.UI.Input.HoldingState.Started)
            {
                _view?.LongPressedHandler?.Invoke(_view, null);
            }

            if (_view.LongPressedCommand?.CanExecute(_view.LongPressedCommandParameter) == true)
                _view.LongPressedCommand?.Execute(_view.LongPressedCommandParameter);
        }

        private void MultiGestureViewRenderer_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            _view?.TappedHandler?.Invoke(_view, null);

            if (_view.TappedCommand?.CanExecute(_view.TappedCommandParameter) == true)
                _view.TappedCommand?.Execute(_view.TappedCommandParameter);
        }

        private void MultiGestureViewRenderer_RightTapped(object sender, Windows.UI.Xaml.Input.RightTappedRoutedEventArgs e)
        {
            _view?.RightClickedHandler?.Invoke(_view, null);

            if (_view.RightClickedCommand?.CanExecute(_view.RightClickedCommandParameter) == true)
                _view.RightClickedCommand?.Execute(_view.RightClickedCommandParameter);
        }
    }
}
