using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class MainProfilePage : ContentPage
	{
		public MainProfilePage()
		{
			InitializeComponent();
		}

		public void OnImageTapped1(object sender, System.EventArgs args)
		{
			Navigation.PushAsync(new MainPage());
		}

		public void OnImageTapped2(object sender, System.EventArgs args)
		{
			Navigation.PushAsync(new EditProfilePage());
		}

		public void OnImageTapped3(object sender, System.EventArgs args)
		{
			
		}
	}
}
