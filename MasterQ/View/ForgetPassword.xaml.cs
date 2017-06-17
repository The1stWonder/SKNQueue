using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class ForgetPassword : ContentPage
	{
		public ForgetPassword()
		{
			InitializeComponent();
		}

		void Submit_Clicked(object sender, System.EventArgs e)
		{
			var Email = mEmailEntry.Text;

			Navigation.PushAsync(new LoginPage());
		}
	}
}
