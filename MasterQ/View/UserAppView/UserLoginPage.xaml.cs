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

        public void OnImageSignin(object sender, System.EventArgs args)
        {
            var username = mUsernameEntry.Text;
            var password = mPasswordEntry.Text;
            Login MasQLogin = new Login(username, password);
            UIReturn uiReturn = UserLoginController.getInstance().LoginUser(MasQLogin);

            if (uiReturn.isSuccess)
            {
                Navigation.PushAsync(new UserChooseServicePage());
            }
            else
            {
                DisplayAlert("Click", uiReturn.getDescription(), "Close");
            }
        }

        public void OnLabelSetIP(object sender, System.EventArgs args)
        {
            Navigation.PushAsync(new UserSetIPAddress());
            mUsernameEntry.Text = "";
            mPasswordEntry.Text = "";
        }
    }
}
