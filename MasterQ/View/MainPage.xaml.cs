using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		public void OnImageTapped(object sender, System.EventArgs args)
		{
			Navigation.PushAsync(new EditProfilePage());
		}
	}
}
