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
                        List<Service> Service = (List<Service>)BranchActionsController.getInstance().getBranchServices().returnObject;
                        int CountService = Service.Count;

                        //CountService = 2;

                        if (CountService == 1)
                        {
                            App.NumberServiceBranch = 1;
                            Navigation.PushAsync(new Service1Page());
                        }
                        else if (CountService == 2)
                        {
                            App.NumberServiceBranch = 1;
                            Navigation.PushAsync(new Service2Page());
                        }
                        else if (CountService == 3)
                        {
                            App.NumberServiceBranch = 3;
                            Navigation.PushAsync(new Service3Page());
                        }
                        else if (CountService == 4)
                        {
                            App.NumberServiceBranch = 4;
                            Navigation.PushAsync(new Service4Page());
                        }
                        else if (CountService == 5)
                        {
                            App.NumberServiceBranch = 5;
                            Navigation.PushAsync(new Service5Page());
                        }
                        else if (CountService == 6)
                        {
                            App.NumberServiceBranch = 6;
                            Navigation.PushAsync(new Service6Page());
                        }
                        else if (CountService == 7)
                        {
                            App.NumberServiceBranch = 7;
                            Navigation.PushAsync(new Service7Page());
                        }
                        else if (CountService == 8)
                        {
                            App.NumberServiceBranch = 8;
                            Navigation.PushAsync(new Service8Page());
                        }
                        else if (CountService == 9)
                        {
                            App.NumberServiceBranch = 9;
                            Navigation.PushAsync(new Service9Page());
                        }
                        else if (CountService == 10)
                        {
                            App.NumberServiceBranch = 10;
                            Navigation.PushAsync(new Service10Page());
                        }
                        else if (CountService == 11)
                        {
                            App.NumberServiceBranch = 11;
                            Navigation.PushAsync(new Service11Page());
                        }
                        else if (CountService == 12)
                        {
                            App.NumberServiceBranch = 12;
                            Navigation.PushAsync(new Service12Page());
                        }
                        else if (CountService == 13)
                        {
                            App.NumberServiceBranch = 13;
                            Navigation.PushAsync(new Service13Page());
                        }
                        else if (CountService == 14)
                        {
                            App.NumberServiceBranch = 14;
                            Navigation.PushAsync(new Service14Page());
                        }
                        else if (CountService == 15)
                        {
                            App.NumberServiceBranch = 15;
                            Navigation.PushAsync(new Service15Page());
                        }
                        else if (CountService == 16)
                        {
                            App.NumberServiceBranch = 16;
                            Navigation.PushAsync(new Service16Page());
                        }
                        else if (CountService == 17)
                        {
                            App.NumberServiceBranch = 17;
                            Navigation.PushAsync(new Service17Page());
                        }
                        else if (CountService == 18)
                        {
                            App.NumberServiceBranch = 18;
                            Navigation.PushAsync(new Service18Page());
                        }
                        else if (CountService == 19)
                        {
                            App.NumberServiceBranch = 19;
                            Navigation.PushAsync(new Service19Page());
                        }
                        else if (CountService == 20)
                        {
                            App.NumberServiceBranch = 20;
                            Navigation.PushAsync(new Service20Page());
                        }
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
