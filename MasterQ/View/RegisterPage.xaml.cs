﻿using System;
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
			var lastname = mLastNameEntry.Text;
			var Email = mEmailEntry.Text;
			var birthdate = mBirthdateEntry.Text;
			var Password1 = mPasswordEntry.Text;
			var Password2 = mPassword2Entry.Text;

            Member member = new Member();
            member.email = Email;
            member.password = Password1;
            member.confirmPassword = Password2;
            member.firstName = name;
            member.lastName = lastname;
            member.birthDate = birthdate;

            UIReturn uiReturn = RegisterController.getInstance().register(member);

			if (uiReturn.isSuccess)
			{
				Navigation.PushAsync(new MainPage());
			}
			else
			{
                DisplayAlert("Click", "Register Fail : "+uiReturn.getDescription(), "Close");
			}
		}
	}
}
