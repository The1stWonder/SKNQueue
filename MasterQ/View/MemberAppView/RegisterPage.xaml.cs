using System;
using System.Collections.Generic;
using Plugin.Connectivity;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage()
		{
			InitializeComponent();

            if (CrossConnectivity.Current.IsConnected)
            {
                SignUpQ.Text = Utils.getLabel(LabelConstants.LOGIN_PAGE_SIGNUP);
                mNameEntry.Placeholder = Utils.getLabel(LabelConstants.REGISTER_PAGE_NAME);
                mLastNameEntry.Placeholder = Utils.getLabel(LabelConstants.REGISTER_PAGE_LASTNAME);
                mEmailEntry.Placeholder = Utils.getLabel(LabelConstants.MAPVIEW_PAGE_EMAIL);
                mPhone.Placeholder = Utils.getLabel(LabelConstants.REGISTER_PAGE_TEL);
                mPasswordEntry.Placeholder = Utils.getLabel(LabelConstants.LOGIN_PAGE_PASSWORD);
                mPassword2Entry.Placeholder = Utils.getLabel(LabelConstants.REGISTER_PAGE_CONFIRMPASS);

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
		}

		public void OnImageJoin(object sender, System.EventArgs args)
		{
            if (CrossConnectivity.Current.IsConnected)
            {
                var name = mNameEntry.Text;
                var lastname = mLastNameEntry.Text;
                var Phone = mPhone.Text;
                var Email = mEmailEntry.Text;
                var birthdate = mBirthdateEntry.Date.ToString("dd/MM/yyyy");
                var Password1 = mPasswordEntry.Text;
                var Password2 = mPassword2Entry.Text;

                Member member = new Member();
                member.email = Email;
                member.password = Password1;
                member.confirmPassword = Password2;
                member.firstName = name;
                member.lastName = lastname;
                member.birthDate = birthdate;
                member.tel = Phone;

                UIReturn uiReturn = RegisterController.getInstance().register(member);

                if (uiReturn.isSuccess)
                {
                    Navigation.PushAsync(new MainPage());
                }
                else
                {
                    DisplayAlert(App.AppicationName, uiReturn.getDescription(), "Close");
                }
            }
		}

        public void OnImageBack(object sender, System.EventArgs args)
        {
            Navigation.PushAsync(new LoginPage());
        }
	}
}
