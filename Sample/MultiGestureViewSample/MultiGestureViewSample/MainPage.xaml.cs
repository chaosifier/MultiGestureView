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
