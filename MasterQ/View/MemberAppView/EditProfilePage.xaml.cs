using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class EditProfilePage : ContentPage
	{
		bool timercheck = true;
		public EditProfilePage()
		{
			InitializeComponent();

            Member memberid = UserSessionModel.loginMember;

            mNameEntry.Text = memberid.firstName;
            //mLastNameEntry.Text = memberid.lastName;
            mEmailEntry.Text = memberid.email;
            mBirthdateEntry.Text = memberid.birthDate;
            mPhone.Text = memberid.tel;

			if (SessionModel.bookingQ != null)
			{
				if (timercheck == true)
				{
                    if (SessionModel.bookingQ.queueNumber != 0)
                    {
                        timerStart();
                    }
				}
			}
		}

		public void timerStart()
		{
			Device.StartTimer(new TimeSpan(0, 0, 1), () =>
				{
					// do something every 60 seconds
					// ItemsPage i = new ItemsPage();
					if (timercheck == true && QueuePage.timercount != 0)
					{
						QueuePage.timercount--;
						QueuePage.timercount.ToString();
						return true; // runs again, or false to stop
					}
					else
					{
						return false;
					}
				});
		}

        public void OnImageJoin(object sender, System.EventArgs args)
        {
            var name = mNameEntry.Text;
            //var lastname = mLastNameEntry.Text;
            var Email = mEmailEntry.Text;
            var birthdate = mBirthdateEntry.Text;
            //var Password1 = mPasswordEntry.Text;
            var Phone = mPhone.Text;

            Member member = new Member();
            member.email = Email;
            //member.password = Password1;
            member.firstName = name;
            //member.lastName = lastname;
            member.birthDate = birthdate;
            member.tel = Phone;

            UIReturn result = EditProfileController.getInstance().editProfile(member);

			if (result.isSuccess)
			{
				timercheck = false;
                DisplayAlert("Click", result.getDescription(), "OK");
				Navigation.PushAsync(new MainPage());
			}
			else
			{
				DisplayAlert("Click", result.getDescription(), "Close");
			}

        }

		public void OnImageBack(object sender, System.EventArgs args)
		{
			timercheck = false;
            Navigation.PushAsync(new MainProfilePage());
		}
	}
}
