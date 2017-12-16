using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
    public partial class BranchLoginPage : ContentPage
    {
        static bool IsPortrait(Page p) { return p.Width < p.Height; }

        public BranchLoginPage()
        {
            InitializeComponent();

            if (App.Thai == true)
            {
                Utils.changeAppLanguageToThai();
                LanguageThai.IsVisible = false;
                LanguageThai.IsEnabled = false;

                LanguageEng.IsVisible = true;
                LanguageEng.IsEnabled = true;

                Signin1.IsVisible = false;
                Signin2.IsVisible = true;
            }
            else
            {
                Utils.changeAppLanguageToEng();
                LanguageThai.IsVisible = true;
                LanguageThai.IsEnabled = true;

                LanguageEng.IsVisible = false;
                LanguageEng.IsEnabled = false;

                Signin1.IsVisible = true;
                Signin2.IsVisible = false;
            }

            mUsernameEntry.Placeholder = Utils.getLabel(LabelConstants.LOGIN_PAGE_USERNAME);
            mPasswordEntry.Placeholder = Utils.getLabel(LabelConstants.LOGIN_PAGE_PASSWORD);
            setIP.Text = Utils.getLabel(LabelConstants.BRANCHLOGIN_PAGE_SETIP);
        }

		public void OnImageSignin(object sender, System.EventArgs args)
		{
			var username = mUsernameEntry.Text;
			var password = mPasswordEntry.Text;
			Login MasQLogin = new Login(username, password);
			UIReturn uiReturn = BranchLoginController.getInstance().LoginBranch(MasQLogin);

            if (uiReturn.isSuccess)
            {
                if (App.IPAdress != "")
                {
                    Navigation.PushAsync(new BranchPickupCard());
                }
                else
                {
                    DisplayAlert("Error", "กรุณาตั้งค่า IP Address ก่อนเข้าระบบ", "Cancel");
                }
            }
			else
			{
				DisplayAlert("Click", uiReturn.getDescription(), "Close");
			}
		}

        public void OnLabelSetIP(object sender, System.EventArgs args)
        {
            Navigation.PushAsync(new BranchSetIPAddress());
            mUsernameEntry.Text = "";
            mPasswordEntry.Text = "";
        }

        public void OnImageMainchangeAppLanguageThai(object sender, System.EventArgs args)
        {
            Utils.changeAppLanguageToThai();
            App.Thai = true;

            Navigation.InsertPageBefore(new BranchLoginPage(), this);
            Navigation.PopAsync();

        }

        public void OnImageMainchangeAppLanguageEng(object sender, System.EventArgs args)
        {
            Utils.changeAppLanguageToEng();
            App.Thai = false;

            Navigation.InsertPageBefore(new BranchLoginPage(), this);
            Navigation.PopAsync();

        }
    }
}
