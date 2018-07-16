using MultiGestureViewPlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MultiGestureViewSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

var gestureView = new MultiGestureView()
{
    VibrateOnTap = true,
    TapVibrationDuration = 150,
    VibrateOnLongPress = true,
    LongPressVibrationDuration = 300,
    HeightRequest = 300,
    WidthRequest = 300,
    BackgroundColor = Color.Salmon,
    HorizontalOptions = LayoutOptions.Center,
    VerticalOptions = LayoutOptions.Center,
    Content = new Label() { Text = "Hello World!", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center }
};
gestureView.Tapped += (s, e) =>
{
    DisplayAlert("Tapped", "Tap gesture detected.", "Ok");
};
gestureView.LongPressed += (s, e) =>
{
    DisplayAlert("Long Pressed", "Long press gesture detected.", "Ok");
};
gestureView.RightClicked += (s, e) =>
{
    DisplayAlert("Right Click", "Right click detected.", "Ok");
};
            Content = gestureView;

            gv.Tapped += (s, e) =>
            {
                DisplayAlert("Tapped", "Tapped", "Ok");
            };
            gv.LongPressed += (s, e) =>
            {
                DisplayAlert("Long Pressed", "Long Pressed", "Ok");
            };
            gv.RightClicked += (s, e) =>
            {
                DisplayAlert("Right Clicked", "Right Clicked", "Ok");
            };
        }
    }
}
