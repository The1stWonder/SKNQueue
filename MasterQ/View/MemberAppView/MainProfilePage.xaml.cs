using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterQ
{
    [XamlCompilation(XamlCompilationOptions.Compile)] //alexpook link all
	public partial class MainProfilePage : ContentPage
	{
		public MainProfilePage()
		{
			InitializeComponent();
		}

		public void OnImageMainPage(object sender, System.EventArgs args)
		{
			Navigation.PushAsync(new MainPage());
		}

		public void OnImageEditProfilePage(object sender, System.EventArgs args)
		{
			Navigation.PushAsync(new EditProfilePage());
		}

		public void OnImageLogout(object sender, System.EventArgs args)
		{
			Navigation.PushAsync(new LoginPage());
		}
	}
}
