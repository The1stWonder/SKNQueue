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

		void SendEmail_Clicked(object sender, System.EventArgs e)
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
	}
}
