# MultiGestureView
Extended ContentView with Events for gestures like Tap, Long Press and Right Click. Also supports Vibration and Vibration duration for haptic feedback.

#### Setup :
* Available on NuGet: https://www.nuget.org/packages/Xam.Plugin.MultiGestureView/ [![NuGet](https://img.shields.io/badge/NuGet-1.0.1-brightgreen.svg)](https://www.nuget.org/packages/Xam.Plugin.MultiGestureView/)
* Install in your PCL/.Net Standard 2.0 and client projects.

The library needs Vibration permission in Android for vibration to work. The permission should automatically be added if installed from NuGet. If the vibration still doesn't work, try adding the Vibration permission explicitly.

#### Gesture Support :

|Platform|Long Press|Tap|Right Click|
| ------------------- | :-----------: | :-----------: | :------------------: |
|Xamarin.iOS Unified|Yes|Yes|No|
|Xamarin.Android|Yes|Yes|No|
|UWP|No|Yes|Yes|


#### Basic Usage :

```
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
```
