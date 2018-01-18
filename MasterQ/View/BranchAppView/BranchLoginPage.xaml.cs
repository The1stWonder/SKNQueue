using System;
using System.Collections.Generic;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace MasterQ
{
    public partial class BranchLoginPage : ContentPage
    {
        static bool IsPortrait(Page p) { return p.Width < p.Height; }

        public BranchLoginPage()
        {
            InitializeComponent();

            if (CrossConnectivity.Current.IsConnected)
            {
                if (App.Thai == true)
                {
                    LanguageThai.IsVisible = true;
                    LanguageThai.IsEnabled = true;

                    LanguageEng.IsVisible = false;
                    LanguageEng.IsEnabled = false;

                    Signin1.IsVisible = false;
                    Signin2.IsVisible = true;
                }
                else
                {
                    LanguageThai.IsVisible = false;
                    LanguageThai.IsEnabled = false;

                    LanguageEng.IsVisible = true;
                    LanguageEng.IsEnabled = true;

                    Signin1.IsVisible = true;
                    Signin2.IsVisible = false;
                }

                mUsernameEntry.Placeholder = Utils.getLabel(LabelConstants.LOGIN_PAGE_USERNAME);
                mPasswordEntry.Placeholder = Utils.getLabel(LabelConstants.LOGIN_PAGE_PASSWORD);
                setIP.Text = Utils.getLabel(LabelConstants.BRANCHLOGIN_PAGE_SETIP);
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        public void OnImageSignin(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var username = mUsernameEntry.Text;
                var password = mPasswordEntry.Text;
                Login MasQLogin = new Login(username, password);
                UIReturn uiReturn = BranchLoginController.getInstance().LoginBranch(MasQLogin);

                if (uiReturn.isSuccess)
                {
                    if (App.IPAdress != "")
                    {
                        Navigation.PushAsync(new BranchChooseServiceQueuePage());
                    }
                    else
                    {
                        DisplayAlert(App.AppicationName, "กรุณาตั้งค่า IP Address ก่อนเข้าระบบ", "Close");
                        Navigation.PushAsync(new BranchSetIPAddress());
                    }
                }
                else
                {
                    DisplayAlert(App.AppicationName, uiReturn.getDescription(), "Close");
                }
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        public void OnLabelSetIP(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                App.SetIPPage = 0;
                Navigation.PushAsync(new BranchSetIPAddress());
                mUsernameEntry.Text = "";
                mPasswordEntry.Text = "";
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        public void OnImageMainchangeAppLanguageThai(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                Utils.changeAppLanguageToEng();
                App.Thai = false;

                Navigation.InsertPageBefore(new BranchLoginPage(), this);
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        public void OnImageMainchangeAppLanguageEng(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                Utils.changeAppLanguageToThai();
                App.Thai = true;

                Navigation.InsertPageBefore(new BranchLoginPage(), this);
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }
    }
}
