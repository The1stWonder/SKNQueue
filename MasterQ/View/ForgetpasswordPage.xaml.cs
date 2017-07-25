using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class ForgetpasswordPage : ContentPage
	{
		public ForgetpasswordPage()
		{
			InitializeComponent();
		}

		void SendEmail_Clicked(object sender, System.EventArgs e)
		{
			var username = mUsernameEntry.Text;
			Login m = new Login();
			m.username = username;
			UIReturn result = ForgetPasswordController.getInstance().getPassword(m);
		}
	}
}
