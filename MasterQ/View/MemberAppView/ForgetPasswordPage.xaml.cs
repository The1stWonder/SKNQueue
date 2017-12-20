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
            Forget.Text = Utils.getLabel(LabelConstants.LOGIN_PAGE_FORGET);
            mUsernameEntry.Placeholder = Utils.getLabel(LabelConstants.MAPVIEW_PAGE_EMAIL);

            if (App.Thai == true)
            {
                submit1.IsVisible = false;
                submit2.IsVisible = true;
            }
            else
            {
                submit1.IsVisible = true;
                submit2.IsVisible = false;
            }
		}

        public void OnImageJoin(object sender, System.EventArgs args)
        {
            var username = mUsernameEntry.Text;
            Login m = new Login();
            m.username = username;
            UIReturn uiReturn = ForgetPasswordController.getInstance().getPassword(m);
            if (uiReturn.isSuccess)
            {
                DisplayAlert("", uiReturn.getDescription(), "Close");
            }
            else
            {
                DisplayAlert("", uiReturn.getDescription(), "Close");
            }
        }

        public void OnImageBack(object sender, System.EventArgs args)
        {
            Navigation.PushAsync(new LoginPage());
        }
	}
}
