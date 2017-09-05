using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
    public partial class UserLoginPage : ContentPage
    {
        public UserLoginPage()
        {
            InitializeComponent();
        }
		void Login_Clicked(object sender, System.EventArgs e)
		{

			var username = mUsernameEntry.Text;
			var password = mPasswordEntry.Text;
			Login MasQLogin = new Login(username, password);
            UIReturn uiReturn = UserLoginController.getInstance().LoginUser(MasQLogin);

			if (uiReturn.isSuccess)
			{
				Navigation.PushAsync(new MainPage());
			}
			else
			{
				DisplayAlert("Click", uiReturn.getDescription(), "Close");
			}
		}
    }
}
