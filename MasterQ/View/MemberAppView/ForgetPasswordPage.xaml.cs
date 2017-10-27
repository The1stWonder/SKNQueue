using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class ForgetPasswordPage : ContentPage
	{
		public ForgetPasswordPage()
		{
			InitializeComponent();
		}

        public void OnImageJoin(object sender, System.EventArgs args)
        {
            var username = mUsernameEntry.Text;
            Login m = new Login();
            m.username = username;
            UIReturn uiReturn = ForgetPasswordController.getInstance().getPassword(m);
            if (uiReturn.isSuccess)
            {
                DisplayAlert("Click", uiReturn.getDescription(), "Close");
            }
            else
            {
                DisplayAlert("Click", uiReturn.getDescription(), "Close");
            }
        }

        public void OnImageBack(object sender, System.EventArgs args)
        {
            Navigation.PushAsync(new LoginPage());
        }
	}
}
