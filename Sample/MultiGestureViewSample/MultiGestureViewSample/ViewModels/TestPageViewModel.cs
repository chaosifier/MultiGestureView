using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MultiGestureViewSample.ViewModels
{
    public class TestPageViewModel : ObservableBase
    {
        public TestPageViewModel()
        {
            MyTappedCommand = new Command((prm) =>
            {
                LogMessage = "Tap Detected!" + Environment.NewLine + LogMessage;
            });

            MyLongPressedCommand = new Command(() =>
            {
                LogMessage = "Long Press Detected!" + Environment.NewLine + LogMessage;
            });

            MyRightClickedCommand = new Command(() =>
            {
                LogMessage = "Right Click Detected!" + Environment.NewLine + LogMessage;
            });
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        public ICommand MyTappedCommand { get; private set; }
        public ICommand MyLongPressedCommand { get; private set; }
        public ICommand MyRightClickedCommand { get; private set; }

        private string _logMessage;
        public string LogMessage
        {
            get { return _logMessage; }
            set { SetProperty(ref _logMessage, value); }
        }
    }
}
