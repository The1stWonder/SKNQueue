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
			Validation varEmail = new Validation(username);
			Validate.validateEmail(varEmail);
			if(!varEmail.callBack.isSuccess)
			{
                DisplayAlert("Click", varEmail.callBack.message, "Close");
			}

			Navigation.PushAsync(new MainPage());
		}
		void Account_Clicked(object sender, System.EventArgs e)
		{
			Navigation.PushAsync(new RegisterPage());
		}
	}
}
