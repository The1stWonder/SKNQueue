﻿using System;
using System.Collections.Generic;
using Plugin.Connectivity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterQ
{
    [XamlCompilation(XamlCompilationOptions.Compile)] //alexpook link all
	public partial class EditProfilePage : ContentPage
	{
        string PasswordEdit;

		public EditProfilePage()
		{
			InitializeComponent();
            imgEditProfile.IsVisible = true;
            imgEditProfile.IsEnabled = true;

            imgSave1.IsVisible = false;
            imgSave1.IsEnabled = false;

            imgEditPassword.IsVisible = true;
            imgEditPassword.IsEnabled = true;

            imgSave2.IsVisible = false;
            imgSave2.IsEnabled = false;

            if (CrossConnectivity.Current.IsConnected)
            {
                ProfileQ.Text = Utils.getLabel(LabelConstants.PROFILE_PAGE_PROFILE);

                mNameEntry.IsEnabled = false;
                mLastNameEntry.IsEnabled = false;
                mEmailEntry.IsEnabled = false;
                mPhone.IsEnabled = false;
                mBirthdateEntry.IsEnabled = false;
                mPasswordEntry.IsEnabled = false;
                mPassword2Entry.IsEnabled = false;

                if (App.Thai == true)
                {
                    imgEditProfile.IsVisible = false;
                    imgEditProfile.IsEnabled = false;
                    imgEditProfile2.IsVisible = true;
                    imgEditProfile2.IsEnabled = true;

                    imgSave1.IsVisible = false;
                    imgSave1.IsEnabled = false;
                    imgSave3.IsVisible = false;
                    imgSave3.IsEnabled = false;

                    imgEditPassword.IsVisible = false;
                    imgEditPassword.IsEnabled = false;
                    imgEditPassword2.IsVisible = true;
                    imgEditPassword2.IsEnabled = true;

                    imgSave2.IsVisible = false;
                    imgSave2.IsEnabled = false;
                    imgSave4.IsVisible = false;
                    imgSave4.IsEnabled = false;
                }
                else
                {
                    imgEditProfile.IsVisible = true;
                    imgEditProfile.IsEnabled = true;
                    imgEditProfile2.IsVisible = false;
                    imgEditProfile2.IsEnabled = false;

                    imgSave1.IsVisible = false;
                    imgSave1.IsEnabled = false;
                    imgSave3.IsVisible = false;
                    imgSave3.IsEnabled = false;

                    imgEditPassword.IsVisible = true;
                    imgEditPassword.IsEnabled = true;
                    imgEditPassword2.IsVisible = false;
                    imgEditPassword2.IsEnabled = false;

                    imgSave2.IsVisible = false;
                    imgSave2.IsEnabled = false;
                    imgSave4.IsVisible = false;
                    imgSave4.IsEnabled = false;
                }

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

                DateTime date = ConvertToDateTime(memberid.birthDate);

                int Day = Convert.ToInt16(date.Day);
                int Month = Convert.ToInt16(date.Month);
                int Year = Convert.ToInt16(date.Year);

                mBirthdateEntry.Date = new DateTime(Year, Month, Day);
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
		}

        private DateTime ConvertToDateTime(string strDateTime)
        {
            DateTime dtFinaldate; string sDateTime;
            try { dtFinaldate = Convert.ToDateTime(strDateTime); }
            catch (Exception e)
            {
                string[] sDate = strDateTime.Split('/');
                sDateTime = sDate[1] + '/' + sDate[0] + '/' + sDate[2];
                dtFinaldate = Convert.ToDateTime(sDateTime);
            }
            return dtFinaldate;
        }

        async void OnImageJoin(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
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

                        await DisplayAlert(App.AppicationName, result.getDescription(), "OK");
                        await Navigation.PushAsync(new MainPage());
                    }
                    else
                    {
                        await DisplayAlert(App.AppicationName, result.getDescription(), "Close");
                    }
                }
            }
            else
            {
                await DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        public void OnImageBack(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                mNameEntry.IsEnabled = false;
                mLastNameEntry.IsEnabled = false;
                mEmailEntry.IsEnabled = false;
                mPhone.IsEnabled = false;
                mBirthdateEntry.IsEnabled = false;
                mPasswordEntry.IsEnabled = false;
                mPassword2Entry.IsEnabled = false;

                if (App.Thai == true)
                {
                    imgEditProfile.IsVisible = false;
                    imgEditProfile.IsEnabled = false;
                    imgEditProfile2.IsVisible = true;
                    imgEditProfile2.IsEnabled = true;

                    imgSave1.IsVisible = false;
                    imgSave1.IsEnabled = false;
                    imgSave3.IsVisible = false;
                    imgSave3.IsEnabled = false;

                    imgEditPassword.IsVisible = false;
                    imgEditPassword.IsEnabled = false;
                    imgEditPassword2.IsVisible = true;
                    imgEditPassword2.IsEnabled = true;

                    imgSave2.IsVisible = false;
                    imgSave2.IsEnabled = false;
                    imgSave4.IsVisible = false;
                    imgSave4.IsEnabled = false;
                }
                else
                {
                    imgEditProfile.IsVisible = true;
                    imgEditProfile.IsEnabled = true;
                    imgEditProfile2.IsVisible = false;
                    imgEditProfile2.IsEnabled = false;

                    imgSave1.IsVisible = false;
                    imgSave1.IsEnabled = false;
                    imgSave3.IsVisible = false;
                    imgSave3.IsEnabled = false;

                    imgEditPassword.IsVisible = true;
                    imgEditPassword.IsEnabled = true;
                    imgEditPassword2.IsVisible = false;
                    imgEditPassword2.IsEnabled = false;

                    imgSave2.IsVisible = false;
                    imgSave2.IsEnabled = false;
                    imgSave4.IsVisible = false;
                    imgSave4.IsEnabled = false;
                }
                Navigation.PushAsync(new MainPage());
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        public void OnImageEditProfile(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                mNameEntry.IsEnabled = true;
                mLastNameEntry.IsEnabled = true;
                mEmailEntry.IsEnabled = true;
                mPhone.IsEnabled = true;
                mBirthdateEntry.IsEnabled = true;
                mPasswordEntry.IsEnabled = false;
                mPassword2Entry.IsEnabled = false;

                if (App.Thai == true)
                {
                    imgEditProfile.IsVisible = false;
                    imgEditProfile.IsEnabled = false;
                    imgEditProfile2.IsVisible = false;
                    imgEditProfile2.IsEnabled = false;

                    imgSave1.IsVisible = false;
                    imgSave1.IsEnabled = false;
                    imgSave3.IsVisible = true;
                    imgSave3.IsEnabled = true;

                    imgEditPassword.IsVisible = false;
                    imgEditPassword.IsEnabled = false;
                    imgEditPassword2.IsVisible = true;
                    imgEditPassword2.IsEnabled = false;

                    imgSave2.IsVisible = false;
                    imgSave2.IsEnabled = false;
                    imgSave4.IsVisible = false;
                    imgSave4.IsEnabled = false;
                }
                else
                {
                    imgEditProfile.IsVisible = false;
                    imgEditProfile.IsEnabled = false;
                    imgEditProfile2.IsVisible = false;
                    imgEditProfile2.IsEnabled = false;

                    imgSave1.IsVisible = true;
                    imgSave1.IsEnabled = true;
                    imgSave3.IsVisible = false;
                    imgSave3.IsEnabled = false;

                    imgEditPassword.IsVisible = true;
                    imgEditPassword.IsEnabled = false;
                    imgEditPassword2.IsVisible = false;
                    imgEditPassword2.IsEnabled = false;

                    imgSave2.IsVisible = false;
                    imgSave2.IsEnabled = false;
                    imgSave4.IsVisible = false;
                    imgSave4.IsEnabled = false;
                }
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        public void OnImageEditPassword(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
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

                if (App.Thai == true)
                {
                    imgEditProfile.IsVisible = false;
                    imgEditProfile.IsEnabled = false;
                    imgEditProfile2.IsVisible = true;
                    imgEditProfile2.IsEnabled = false;

                    imgSave1.IsVisible = false;
                    imgSave1.IsEnabled = false;
                    imgSave3.IsVisible = false;
                    imgSave3.IsEnabled = false;

                    imgEditPassword.IsVisible = false;
                    imgEditPassword.IsEnabled = false;
                    imgEditPassword2.IsVisible = false;
                    imgEditPassword2.IsEnabled = false;

                    imgSave2.IsVisible = false;
                    imgSave2.IsEnabled = false;
                    imgSave4.IsVisible = true;
                    imgSave4.IsEnabled = true;
                }
                else
                {
                    imgEditProfile.IsVisible = true;
                    imgEditProfile.IsEnabled = false;
                    imgEditProfile2.IsVisible = false;
                    imgEditProfile2.IsEnabled = false;

                    imgSave1.IsVisible = false;
                    imgSave1.IsEnabled = false;
                    imgSave3.IsVisible = false;
                    imgSave3.IsEnabled = false;

                    imgEditPassword.IsVisible = false;
                    imgEditPassword.IsEnabled = false;
                    imgEditPassword2.IsVisible = false;
                    imgEditPassword2.IsEnabled = false;

                    imgSave2.IsVisible = true;
                    imgSave2.IsEnabled = true;
                    imgSave4.IsVisible = false;
                    imgSave4.IsEnabled = false;
                }

                mPasswordEntry.Text = "";
                mPassword2Entry.Text = "";
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        async void OnImageJoin2(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
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

                        await DisplayAlert(App.AppicationName, result.getDescription(), "OK");
                        await Navigation.PushAsync(new MainPage());
                    }
                    else
                    {
                        await DisplayAlert(App.AppicationName, result.getDescription(), "Close");
                    }
                }
            }
            else
            {
                await DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }
	}
}
