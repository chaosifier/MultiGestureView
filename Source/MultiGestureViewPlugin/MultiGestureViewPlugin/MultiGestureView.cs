using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MultiGestureViewPlugin
{
    /// <summary>
    /// A ContentView with built-in gesture recognizers.
    /// </summary>
    public class MultiGestureView : ContentView
    {
        public static readonly BindableProperty VibrateOnLongPressProperty = BindableProperty.Create(nameof(VibrateOnLongPress), typeof(bool), typeof(MultiGestureView), false);
        /// <summary>
        /// Enable vibration on long press.
        /// </summary>
        public bool VibrateOnLongPress
        {
            get => (bool)GetValue(VibrateOnLongPressProperty);
            set { SetValue(VibrateOnLongPressProperty, value); }
        }

        public static readonly BindableProperty LongPressVibrationDurationProperty = BindableProperty.Create(nameof(VibrateOnLongPress), typeof(int), typeof(MultiGestureView), 100);
        /// <summary>
        /// Vibration duration in milliseconds on long press. The default value is 100ms.
        /// </summary>
        public int LongPressVibrationDuration
        {
            get => (int)GetValue(LongPressVibrationDurationProperty);
            set { SetValue(LongPressVibrationDurationProperty, value); }
        }

        public static readonly BindableProperty VibrateOnTapProperty = BindableProperty.Create(nameof(VibrateOnLongPress), typeof(bool), typeof(MultiGestureView), false);
        /// <summary>
        /// Enable vibration on tap.
        /// </summary>
        public bool VibrateOnTap
        {
            get => (bool)GetValue(VibrateOnTapProperty);
            set { SetValue(VibrateOnTapProperty, value); }
        }

        public static readonly BindableProperty TapVibrationDurationProperty = BindableProperty.Create(nameof(VibrateOnLongPress), typeof(int), typeof(MultiGestureView), 100);
        /// <summary>
        /// Vibration duration in milliseconds on tap. The default value is 100ms.
        /// </summary>
        public int TapVibrationDuration
        {
            get => (int)GetValue(TapVibrationDurationProperty);
            set { SetValue(TapVibrationDurationProperty, value); }
        }

        /// <summary>
        /// Long press event.
        /// If the Content or its children have gesture recognizers set, in order to prevent gesture conflicts, it is recommended to set their InputTransparent property to True.
        /// </summary>
        public event EventHandler LongPressed
        {
            add { LongPressedHandler += value; }
            remove { LongPressedHandler -= value; }
        }
        public EventHandler LongPressedHandler;

        /// <summary>
        /// Long press event.
        /// If the Content or its children have gesture recognizers set, in order to prevent gesture conflicts, it is recommended to set their InputTransparent property to True.
        /// </summary>
        public static readonly BindableProperty LongPressedCommandProperty = BindableProperty.Create(nameof(LongPressedCommand), typeof(ICommand), typeof(MultiGestureView), null);
        public ICommand LongPressedCommand
        {
            get => (ICommand)GetValue(LongPressedCommandProperty);
            set { SetValue(LongPressedCommandProperty, value); }
        }

        /// <summary>
        /// Tap event.
        /// If the Content or its children have gesture recognizers set, in order to prevent gesture conflicts, it is recommended to set their InputTransparent property to True.
        /// </summary>
        public event EventHandler Tapped
        {
            add { TappedHandler += value; }
            remove { TappedHandler -= value; }
        }
        public EventHandler TappedHandler;

        /// <summary>
        /// Tap event.
        /// If the Content or its children have gesture recognizers set, in order to prevent gesture conflicts, it is recommended to set their InputTransparent property to True.
        /// </summary>
        public static readonly BindableProperty TappedCommandProperty = BindableProperty.Create(nameof(TappedCommand), typeof(ICommand), typeof(MultiGestureView), null);
        public ICommand TappedCommand
        {
            get => (ICommand)GetValue(TappedCommandProperty);
            set { SetValue(TappedCommandProperty, value); }
        }

        /// <summary>
        /// Right click event. Only works on UWP.
        /// </summary>
        public event EventHandler RightClicked
        {
            add { RightClickedHandler += value; }
            remove { RightClickedHandler -= value; }
        }
        public EventHandler RightClickedHandler;

        /// <summary>
        /// Right click event. Only works on UWP.
        /// </summary>
        public static readonly BindableProperty RightClickedCommandProperty = BindableProperty.Create(nameof(RightClickedCommand), typeof(ICommand), typeof(MultiGestureView), null);
        public ICommand RightClickedCommand
        {
            get => (ICommand)GetValue(RightClickedCommandProperty);
            set { SetValue(RightClickedCommandProperty, value); }
        }
    }
}
