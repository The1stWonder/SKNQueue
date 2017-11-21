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

            Member memberid = SessionModel.loginMember;

            mNameEntry.Text = memberid.firstName;
            mLastNameEntry.Text = memberid.lastName;
            mEmailEntry.Text = memberid.email;
            mPhone.Text = memberid.tel;

            int Day = Convert.ToInt16(Convert.ToDateTime(memberid.birthDate).Day);
            int Month = Convert.ToInt16(Convert.ToDateTime(memberid.birthDate).Month);
            int Year = Convert.ToInt16(Convert.ToDateTime(memberid.birthDate).Year);

            mBirthdateEntry.Date = new DateTime(Year, Month, Day);
		}

        public void OnImageJoin(object sender, System.EventArgs args)
        {
            var name = mNameEntry.Text;
            var lastname = mLastNameEntry.Text;
            var Email = mEmailEntry.Text;

            var birthdate = mBirthdateEntry.Date.ToString("dd/MM/yyyy");
            var Password1 = mPasswordEntry.Text;
            var Phone = mPhone.Text;

            Member member = new Member();
            member.email = Email;
            member.password = Password1;
            member.firstName = name;
            member.lastName = lastname;
            member.birthDate = birthdate;
            member.tel = Phone;

            UIReturn result = EditProfileController.getInstance().editProfile(member);

			if (result.isSuccess)
			{
                DisplayAlert("Click", result.descriptionEN, "OK");
				Navigation.PushAsync(new MainPage());
			}
			else
			{
				DisplayAlert("Click", result.descriptionEN, "Close");
			}

        }

		public void OnImageBack(object sender, System.EventArgs args)
		{
            Navigation.PushAsync(new MainPage());
		}

	}
}
