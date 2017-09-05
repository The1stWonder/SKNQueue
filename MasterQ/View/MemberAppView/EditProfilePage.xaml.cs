using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class EditProfilePage : ContentPage
	{
		public EditProfilePage()
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

	Member member = new Member();
	member.email = Email;
	member.password = Password1;
	member.firstName = name;
	member.lastName = lastname;
	member.birthDate = birthdate;

UIReturn result = EditProfileController.getInstance().editProfile(member);

		}
	}
}
