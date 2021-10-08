# MultiGestureView
Extended ContentView with Events for gestures like Tap, Long Press and Right Click. Also supports Vibration and Vibration duration for haptic feedback.

#### Setup :
* Available on NuGet: https://www.nuget.org/packages/Xam.Plugin.MultiGestureView/ [![NuGet](https://img.shields.io/badge/NuGet-1.0.5-brightgreen.svg)](https://www.nuget.org/packages/Xam.Plugin.MultiGestureView/)
* Install in your PCL/.Net Standard 2.0 and client projects.

* Call Init() method of custom renderers in each platform.
```
MultiGestureViewRenderer.Init();
```

The library needs Vibration permission in Android for vibration to work. The permission should automatically be added if installed from NuGet. If the vibration still doesn't work, try adding the Vibration permission explicitly.

#### Gesture Support :

|Platform|Long Press|Tap|Right Click|
| ------------------- | :-----------: | :-----------: | :------------------: |
|Xamarin.iOS Unified|Yes|Yes|No|
|Xamarin.Android|Yes|Yes|No|
|UWP|No|Yes|Yes|


#### Basic Usage :

* Code behind
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

* XAML
```
<multigestureviewplugin:MultiGestureView
    x:Name="theMgv"
    Padding="30"
    BackgroundColor="Salmon"
    HeightRequest="200"
    HorizontalOptions="Center"
    LongPressVibrationDuration="1000"
    LongPressedCommand="{Binding MyLongPressedCommand}"
    RightClickedCommand="{Binding MyRightClickedCommand}"
    TapVibrationDuration="500"
    TappedCommand="{Binding MyTappedCommand}"
    TappedCommandParameter="{Binding Source={x:Reference theMgv}}"
    VibrateOnLongPress="True"
    VibrateOnTap="True">
    <Label
        FontSize="Large"
        HorizontalOptions="Center"
        Text="Click / Right-Click / Long Press here"
        TextColor="White"
        VerticalOptions="Center" />
</multigestureviewplugin:MultiGestureView>
```
