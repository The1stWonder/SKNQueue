using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage()
		{
			InitializeComponent();
		}

		void Submit_Clicked(object sender, System.EventArgs e)
		{
			var name = mNameEntry.Text;
			var Email = mEmailEntry.Text;
			var Password1 = mPasswordEntry.Text;
			var Password2 = mPassword2Entry.Text;

			Navigation.PushAsync(new MainPage());
		}
	}
}
