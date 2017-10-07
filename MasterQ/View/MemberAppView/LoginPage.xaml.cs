using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MasterQ
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent(); 

   //         var username = "t@t.co";
			//var password = "1";
			//Login MasQLogin = new Login(username, password);
			//UIReturn uiReturn = LoginController.getInstance().LoginMember(MasQLogin);

			//if (uiReturn.isSuccess)
			//{
			//	Navigation.PushAsync(new MainPage());
			//}
			//else
			//{
			//	DisplayAlert("Click", uiReturn.getDescription(), "Close");
			//}


		}

		public void OnLabelSignUp(object sender, System.EventArgs args)
		{
			Navigation.PushAsync(new RegisterPage());
			mUsernameEntry.Text = "";
			mPasswordEntry.Text = "";
		}

		public void OnImageSignin(object sender, System.EventArgs args)
		{

			var username = mUsernameEntry.Text;
			var password = mPasswordEntry.Text;
			Login MasQLogin = new Login(username, password);
            UIReturn uiReturn = LoginController.getInstance().LoginMember(MasQLogin);

			if (uiReturn.isSuccess)
			{
				Navigation.PushAsync(new MainPage());
			}
			else
			{
				DisplayAlert("Click", uiReturn.descriptionEN, "Close");
			}
		}

		public void OnLabelForgetpassword(object sender, System.EventArgs args)
		{
			Navigation.PushAsync(new ForgetPasswordPage());
		}
	}
}
