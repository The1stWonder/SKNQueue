using System;
using System.Collections.Generic;
using Plugin.Connectivity;
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
            if (CrossConnectivity.Current.IsConnected)
            {
                var username = mUsernameEntry.Text;
                var password = mPasswordEntry.Text;
                Login MasQLogin = new Login(username, password);
                UIReturn uiReturn = UserLoginController.getInstance().LoginUser(MasQLogin);

                if (uiReturn.isSuccess)
                {
                    if (App.IPAdress != "")
                    {
                        Navigation.PushAsync(new UserChooseServicePage());
                    }
                    else
                    {
                        DisplayAlert(App.AppicationName, "กรุณาตั้งค่า IP Address ก่อนเข้าระบบ", "Close");
                    }
                }
                else
                {
                    DisplayAlert(App.AppicationName, uiReturn.getDescription(), "Close");
                }
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        public void OnLabelSetIP(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                Navigation.PushAsync(new UserSetIPAddress());
                mUsernameEntry.Text = "";
                mPasswordEntry.Text = "";
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }
    }
}
