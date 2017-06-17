using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
		}

		void Login_Clicked(object sender, System.EventArgs e)
		{
			var username = mUsernameEntry.Text;
			var password = mPasswordEntry.Text;
			Login MasQLogin = new Login(username, password);
			LoginController.authen(MasQLogin);
			if (MasQLogin.callBack.isSuccess)
			{
				Navigation.PushAsync(new MainPage());
			}
			else
			{
				DisplayAlert("Click", MasQLogin.callBack.message, "Close");
			}
			mUsernameEntry.Text = "";
			mPasswordEntry.Text = "";
		}
		void Account_Clicked(object sender, System.EventArgs e)
		{
			Navigation.PushAsync(new RegisterPage());
			mUsernameEntry.Text = "";
			mPasswordEntry.Text = "";
		}
	}
}
