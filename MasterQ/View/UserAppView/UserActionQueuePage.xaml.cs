using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MasterQ.Helpers;
using Xamarin.Forms;
using Plugin.Connectivity;

namespace MasterQ
{
    public partial class UserActionQueuePage : ContentPage
    {
        string counterNumber;
        int ChkTime = 0;

        public UserActionQueuePage()
        {
            InitializeComponent();
            InitialPage();
            counterNumber = App.CounterUser;
            qNumber.Text = "";
            qCouter.Text = "เคาน์เตอร์ที่  " + counterNumber;

            //CallBtn.IsVisible = true;
            //AcceptBtn.IsVisible = false;
            //SkipBtn.IsVisible = false;
            //FinishBtn.IsVisible = false;
        }

        private void InitialPage()
        {
            CallBtn.IsVisible = true;
            AcceptBtn.IsVisible = false;
            SkipBtn.IsVisible = false;
            FinishBtn.IsVisible = false;
        }

        public void OnImageBack(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                Navigation.PushAsync(new UserChooseServicePage());
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        public void OnCallTap(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                qNumber.Text = "";
                CallBtn.IsEnabled = false;
                CallBtn.IsVisible = false;

                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        DependencyService.Get<IFSocket>().SendMessage(App.DeviceName + ".CALL" + "<EOF>", App.IPAdress, 11111);
                        break;
                    default:
                        DependencyService.Get<IFSocket>().SendMessage(App.DeviceName + ".CALL" + "<EOF>", App.IPAdress, 11111);
                        break;
                }

                qNumber.Text = App.ShowMassageSocket.Replace("\0", "").ToUpper();
                string MassageSocket = App.ShowMassageSocket.Replace("\0", "").ToUpper();

                if (App.CheckSocket == true)
                {
                    if (MassageSocket != "Q NOT FOUND.")
                    {
                        if (MassageSocket != "PLEASE LOGIN!")
                        {
                            AcceptBtn.IsVisible = true;
                            SkipBtn.IsVisible = true;
                            FinishBtn.IsVisible = false;
                            CallBtn.IsVisible = false;
                        }
                        else
                        {
                            DisplayAlert(App.AppicationName, MassageSocket, "Close");
                            Navigation.PushAsync(new UserLoginPage());
                        }
                    }

                    Device.StartTimer(new TimeSpan(0, 0, 1), () =>
                        {
                            ChkTime = ChkTime + 1;

                            if (ChkTime == 2)
                            {
                                ChkTime = 0;
                                CallBtn.IsEnabled = true;
                                CallBtn.IsVisible = true;
                                return false;
                            }

                            return true;
                        });
                }
                else
                {
                    App.SetIPPage = 1;
                    DisplayAlert(App.AppicationName, MassageSocket, "Close");
                    Navigation.PushAsync(new UserSetIPAddress());
                }
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        public void OnAcceptTap(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                qNumber.Text = "";

                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        DependencyService.Get<IFSocket>().SendMessage(App.DeviceName + ".ACCEPT" + "<EOF>", App.IPAdress, 11111);
                        break;
                    default:
                        DependencyService.Get<IFSocket>().SendMessage(App.DeviceName + ".ACCEPT" + "<EOF>", App.IPAdress, 11111);
                        break;
                }

                qNumber.Text = App.ShowMassageSocket.Replace("\0", "").ToUpper();
                string MassageSocket = App.ShowMassageSocket.Replace("\0", "").ToUpper();

                if (App.CheckSocket == true)
                {
                    if (MassageSocket == "PLEASE LOGIN!")
                    {
                        DisplayAlert(App.AppicationName, MassageSocket, "Close");
                        Navigation.PushAsync(new UserLoginPage());
                    }
                    else
                    {
                        CallBtn.IsVisible = false;
                        AcceptBtn.IsVisible = false;
                        SkipBtn.IsVisible = false;
                        FinishBtn.IsVisible = true;
                    }
                }
                else
                {
                    App.SetIPPage = 1;
                    DisplayAlert(App.AppicationName, MassageSocket, "Close");
                    Navigation.PushAsync(new UserSetIPAddress());
                }
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        public void OnFinishTap(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                qNumber.Text = "";

                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        DependencyService.Get<IFSocket>().SendMessage(App.DeviceName + ".FINISH" + "<EOF>", App.IPAdress, 11111);
                        break;
                    default:
                        DependencyService.Get<IFSocket>().SendMessage(App.DeviceName + ".FINISH" + "<EOF>", App.IPAdress, 11111);
                        break;
                }

                qNumber.Text = App.ShowMassageSocket.Replace("\0", "").ToUpper();
                string MassageSocket = App.ShowMassageSocket.Replace("\0", "").ToUpper();

                if (App.CheckSocket == true)
                {
                    if (MassageSocket == "PLEASE LOGIN!")
                    {
                        DisplayAlert(App.AppicationName, MassageSocket, "Close");
                        Navigation.PushAsync(new UserLoginPage());
                    }
                    else
                    {
                        CallBtn.IsVisible = true;
                        AcceptBtn.IsVisible = false;
                        SkipBtn.IsVisible = false;
                        FinishBtn.IsVisible = false;
                    }
                }
                else
                {
                    App.SetIPPage = 1;
                    DisplayAlert(App.AppicationName, MassageSocket, "Close");
                    Navigation.PushAsync(new UserSetIPAddress());
                }
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        public void OnSkipTap(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                qNumber.Text = "";

                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        DependencyService.Get<IFSocket>().SendMessage(App.DeviceName + ".SKIP" + "<EOF>", App.IPAdress, 11111);
                        break;
                    default:
                        DependencyService.Get<IFSocket>().SendMessage(App.DeviceName + ".SKIP" + "<EOF>", App.IPAdress, 11111);
                        break;
                }

                qNumber.Text = App.ShowMassageSocket.Replace("\0", "").ToUpper();
                string MassageSocket = App.ShowMassageSocket.Replace("\0", "").ToUpper();

                if (App.CheckSocket == true)
                {
                    if (MassageSocket == "PLEASE LOGIN!")
                    {
                        DisplayAlert(App.AppicationName, MassageSocket, "Close");
                        Navigation.PushAsync(new UserLoginPage());
                    }
                    else
                    {
                        CallBtn.IsVisible = true;
                        AcceptBtn.IsVisible = false;
                        SkipBtn.IsVisible = false;
                        FinishBtn.IsVisible = false;
                    }
                }
                else
                {
                    App.SetIPPage = 1;
                    DisplayAlert(App.AppicationName, MassageSocket, "Close");
                    Navigation.PushAsync(new UserSetIPAddress());
                }
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        async void OnImageMainExit(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var answer = await DisplayAlert(Utils.getLabel(LabelConstants.MAIN_PAGE_LOGOUT), Utils.getLabel(LabelConstants.MAIN_PAGE_CONFIRMLOGOUT), "Yes", "No");
                if (answer == true)
                {
                    switch (Device.RuntimePlatform)
                    {
                        case Device.iOS:
                            DependencyService.Get<IFSocket>().SendMessage(App.DeviceName + ".LOGOUT" + "<EOF>", App.IPAdress, 11111);
                            break;
                        default:
                            DependencyService.Get<IFSocket>().SendMessage(App.DeviceName + ".LOGOUT" + "<EOF>", App.IPAdress, 11111);
                            break;
                    }

                    String MassageSocket = App.ShowMassageSocket.Replace("\0", "").ToUpper();

                    if (App.CheckSocket == true)
                    {
                        if (MassageSocket == "LOGOUT SUCCESS." || MassageSocket == "PLEASE LOGIN!")
                        {
                            await Navigation.PushAsync(new UserLoginPage());
                        }
                        else
                        {
                            await DisplayAlert(App.AppicationName, MassageSocket, "Close");
                        }
                    }
                    else
                    {
                        App.SetIPPage = 1;
                        await DisplayAlert(App.AppicationName, MassageSocket, "Close");
                        await Navigation.PushAsync(new UserSetIPAddress());
                    }
                }
            }
            else
            {
                await DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        public void OnImageSearch(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                Navigation.PushAsync(new UserShowQueueTotalPage());
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }
    }
}
