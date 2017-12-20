using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class EditProfilePage : ContentPage
	{
        string PasswordEdit;

		public EditProfilePage()
		{
			InitializeComponent();

            ProfileQ.Text = Utils.getLabel(LabelConstants.PROFILE_PAGE_PROFILE);
            mNameEntry.IsEnabled = false;
            mLastNameEntry.IsEnabled = false;
            mEmailEntry.IsEnabled = false;
            mPhone.IsEnabled = false;
            mBirthdateEntry.IsEnabled = false;
            mPasswordEntry.IsEnabled = false;
            mPassword2Entry.IsEnabled = false;

            imgEditProfile.IsVisible = true;
            imgEditProfile.IsEnabled = true;
            imgSave1.IsVisible = false;
            imgSave1.IsEnabled = false;
            imgEditPassword.IsVisible = true;
            imgEditPassword.IsEnabled = true;
            imgSave2.IsVisible = false;
            imgSave2.IsEnabled = false;

            mNameEntry.Placeholder = Utils.getLabel(LabelConstants.REGISTER_PAGE_NAME);
            mLastNameEntry.Placeholder = Utils.getLabel(LabelConstants.REGISTER_PAGE_LASTNAME);
            mEmailEntry.Placeholder = Utils.getLabel(LabelConstants.MAPVIEW_PAGE_EMAIL);
            mPhone.Placeholder = Utils.getLabel(LabelConstants.REGISTER_PAGE_TEL);
            mPasswordEntry.Placeholder = Utils.getLabel(LabelConstants.LOGIN_PAGE_PASSWORD);
            mPassword2Entry.Placeholder = Utils.getLabel(LabelConstants.REGISTER_PAGE_CONFIRMPASS);

            Member memberid = SessionModel.loginMember;

            mNameEntry.Text = memberid.firstName;
            mLastNameEntry.Text = memberid.lastName;
            mEmailEntry.Text = memberid.email;
            mPhone.Text = memberid.tel;
            mPasswordEntry.Text = memberid.password.ToString();
            PasswordEdit = mPasswordEntry.Text.ToString();

            int Day = Convert.ToInt16(Convert.ToDateTime(memberid.birthDate).Day);
            int Month = Convert.ToInt16(Convert.ToDateTime(memberid.birthDate).Month);
            int Year = Convert.ToInt16(Convert.ToDateTime(memberid.birthDate).Year);

            mBirthdateEntry.Date = new DateTime(Year, Month, Day);
		}

        async void OnImageJoin(object sender, System.EventArgs args)
        {
            var name = mNameEntry.Text;
            var lastname = mLastNameEntry.Text;
            var Email = mEmailEntry.Text;

            var birthdate = mBirthdateEntry.Date.ToString("dd/MM/yyyy");
            var Password1 = PasswordEdit.ToString();
            var Password2 = PasswordEdit.ToString();
            var Phone = mPhone.Text;

            Member member = new Member();
            member.email = Email;
            member.password = Password1;
            member.confirmPassword = Password2;
            member.firstName = name;
            member.lastName = lastname;
            member.birthDate = birthdate;
            member.tel = Phone;
            member.memberID = SessionModel.loginMember.memberID;

            var answer = await DisplayAlert(Utils.getLabel(LabelConstants.PROFILE_PAGE_PROFILE), Utils.getLabel(LabelConstants.PROFILE_PAGE_EDITPROFILE), "Yes", "No");
            if (answer == true)
            {
                UIReturn result = EditProfileController.getInstance().editProfile(member);

                if (result.isSuccess)
                {
                    mNameEntry.IsEnabled = false;
                    mLastNameEntry.IsEnabled = false;
                    mEmailEntry.IsEnabled = false;
                    mPhone.IsEnabled = false;
                    mBirthdateEntry.IsEnabled = false;
                    mPasswordEntry.IsEnabled = false;
                    mPassword2Entry.IsEnabled = false;

                    imgEditProfile.IsVisible = true;
                    imgEditProfile.IsEnabled = true;
                    imgSave1.IsVisible = false;
                    imgSave1.IsEnabled = false;
                    imgEditPassword.IsVisible = true;
                    imgEditPassword.IsEnabled = true;
                    imgSave2.IsVisible = false;
                    imgSave2.IsEnabled = false;

                    await DisplayAlert("", result.descriptionEN, "OK");
                    await Navigation.PushAsync(new MainPage());
                }
                else
                {
                    await DisplayAlert("", result.descriptionEN, "Close");
                }
            }
        }

		public void OnImageBack(object sender, System.EventArgs args)
		{
            mNameEntry.IsEnabled = false;
            mLastNameEntry.IsEnabled = false;
            mEmailEntry.IsEnabled = false;
            mPhone.IsEnabled = false;
            mBirthdateEntry.IsEnabled = false;
            mPasswordEntry.IsEnabled = false;
            mPassword2Entry.IsEnabled = false;

            imgEditProfile.IsVisible = true;
            imgEditProfile.IsEnabled = true;
            imgSave1.IsVisible = false;
            imgSave1.IsEnabled = false;
            imgEditPassword.IsVisible = true;
            imgEditPassword.IsEnabled = true;
            imgSave2.IsVisible = false;
            imgSave2.IsEnabled = false;

            Navigation.PushAsync(new MainPage());
		}

        public void OnImageEditProfile(object sender, System.EventArgs args)
        {
            mNameEntry.IsEnabled = true;
            mLastNameEntry.IsEnabled = true;
            mEmailEntry.IsEnabled = true;
            mPhone.IsEnabled = true;
            mBirthdateEntry.IsEnabled = true;
            mPasswordEntry.IsEnabled = false;
            mPassword2Entry.IsEnabled = false;

            imgEditProfile.IsVisible = false;
            imgEditProfile.IsEnabled = false;
            imgSave1.IsVisible = true;
            imgSave1.IsEnabled = true;
            imgEditPassword.IsVisible = true;
            imgEditPassword.IsEnabled = false;
            imgSave2.IsVisible = false;
            imgSave2.IsEnabled = false;
        }

        public void OnImageEditPassword(object sender, System.EventArgs args)
        {
            mNameEntry.IsEnabled = false;
            mLastNameEntry.IsEnabled = false;
            mEmailEntry.IsEnabled = false;
            mPhone.IsEnabled = false;
            mBirthdateEntry.IsEnabled = false;
            mPasswordEntry.IsEnabled = true;
            mPassword2Entry.IsEnabled = true;

            imgEditProfile.IsVisible = true;
            imgEditProfile.IsEnabled = false;
            imgSave1.IsVisible = false;
            imgSave1.IsEnabled = false;
            imgEditPassword.IsVisible = false;
            imgEditPassword.IsEnabled = false;
            imgSave2.IsVisible = true;
            imgSave2.IsEnabled = true;

            mPasswordEntry.Text = "";
            mPassword2Entry.Text = "";
        }

        async void OnImageJoin2(object sender, System.EventArgs args)
        {
            var Password1 = mPasswordEntry.Text;
            var Password2 = mPassword2Entry.Text;

            var name = mNameEntry.Text;
            var lastname = mLastNameEntry.Text;
            var Email = mEmailEntry.Text;
            var birthdate = mBirthdateEntry.Date.ToString("dd/MM/yyyy");
            var Phone = mPhone.Text;

            Member member = new Member();
            member.email = Email;
            member.password = Password1;
            member.confirmPassword = Password2;
            member.firstName = name;
            member.lastName = lastname;
            member.birthDate = birthdate;
            member.tel = Phone;
            member.memberID = SessionModel.loginMember.memberID;

            var answer = await DisplayAlert(Utils.getLabel(LabelConstants.LOGIN_PAGE_PASSWORD), Utils.getLabel(LabelConstants.PROFILE_PAGE_EDITPASSWORD), "Yes", "No");
            if (answer == true)
            {
                UIReturn result = EditProfileController.getInstance().changePassword(member);

                if (result.isSuccess)
                {
                    mNameEntry.IsEnabled = false;
                    mLastNameEntry.IsEnabled = false;
                    mEmailEntry.IsEnabled = false;
                    mPhone.IsEnabled = false;
                    mBirthdateEntry.IsEnabled = false;
                    mPasswordEntry.IsEnabled = false;
                    mPassword2Entry.IsEnabled = false;

                    imgEditProfile.IsVisible = true;
                    imgEditProfile.IsEnabled = true;
                    imgSave1.IsVisible = false;
                    imgSave1.IsEnabled = false;
                    imgEditPassword.IsVisible = true;
                    imgEditPassword.IsEnabled = true;
                    imgSave2.IsVisible = false;
                    imgSave2.IsEnabled = false;

                    await DisplayAlert("", result.descriptionEN, "OK");
                    await Navigation.PushAsync(new MainPage());
                }
                else
                {
                    await DisplayAlert("", result.descriptionEN, "Close");
                }
            }
        }

	}
}
