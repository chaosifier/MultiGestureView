using MultiGestureViewSample.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MultiGestureViewSample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new TestPage();
        }
    }
}
