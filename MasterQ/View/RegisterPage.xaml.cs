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

            Member member = new Member();
            member.email = Email;
            member.password = Password1;
            member.confirmPassword = Password2;
            member.firstName = name;
            member.birthDate = "12/12/1990";

            UIReturn uiReturn = RegisterController.getInstance().register(member);

			if (uiReturn.isSuccess)
			{
				DisplayAlert("Click", "Register Success", "Close");
			}
			else
			{
				DisplayAlert("Click", "Register Fail : "+uiReturn.description, "Close");
			}
		}
	}
}
