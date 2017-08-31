﻿using System;
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
        }
        void Account_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
            mUsernameEntry.Text = "";
            mPasswordEntry.Text = "";
        }
		//void Login_Clicked(object sender, System.EventArgs e)
		//{
		//    Task.Run(async () =>
		//    {
		//        var username = mUsernameEntry.Text;
		//        var password = mPasswordEntry.Text;
		//        Login MasQLogin = new Login(username, password);
		//        UIReturn uiReturn  = await LoginController.AuthenuserAsync(MasQLogin);

		//        Device.BeginInvokeOnMainThread(() =>
		//             {
		//            if (uiReturn.isSuccess)
		//                 {
		//                     Navigation.PushAsync(new MainPage());
		//                 }
		//                 else
		//                 {
		//                     DisplayAlert("Click", uiReturn.description, "Close");
		//                 }
		//             });
		//    });
		//}
		void Login_Clicked(object sender, System.EventArgs e)
        {

            var username = mUsernameEntry.Text;
            var password = mPasswordEntry.Text;
            Login MasQLogin = new Login(username, password);
            UIReturn uiReturn = LoginController.getInstance().Login(MasQLogin);

            if (uiReturn.isSuccess)
            {
                Navigation.PushAsync(new MainPage());
            }
            else
            {
                DisplayAlert("Click", uiReturn.getDescription(), "Close");
            }
        }

        public void OnLabelTapped(object sender, System.EventArgs args)
		{
			Navigation.PushAsync(new ForgetPasswordPage());
        }
    }
}
