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
            LoginController.login(MasQLogin);
            if (MasQLogin.callBack.isSuccess)
            {
				Navigation.PushAsync(new MainPage());
				mUsernameEntry.Text = "";
				mPasswordEntry.Text = "";
            }
            else
            {
                DisplayAlert("Click", MasQLogin.callBack.message, "Close");
            }
        }
        void Account_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
            mUsernameEntry.Text = "";
            mPasswordEntry.Text = "";
        }
    }
}
