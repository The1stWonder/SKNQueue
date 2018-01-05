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
            qNumber.Text = "คิวที่ : ";
            qCouter.Text = "เคาน์เตอร์ที่  " + counterNumber;
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
                CallBtn.IsEnabled = false;
                CallBtn.IsVisible = false;

                UIReturn uiReturn = UserActionQueueController.getInstance().callQueue(UserSessionModel.choosedBranch, UserSessionModel.choosedGroup);
                if (uiReturn.isSuccess)
                {
                    CallQueueRs uiRes = (CallQueueRs)uiReturn.returnObject;
                    UserSessionModel.choosedQueue.tranID = uiRes.tranID;
                    qNumber.Text = "คิวที่ : " + uiRes.queueNumber;

                    switch (Device.RuntimePlatform)
                    {
                        case Device.iOS:
                            DependencyService.Get<IFSocket>().SendMessage(uiRes.queueNumber + "," + counterNumber + "<EOF>", App.IPAdress, 11111);
                            //DependencyService.Get<IFiOSSocket>().SendMessage("I001,9,<EOF>", "192.168.1.38", 11111);
                            break;
                        default:
                            DependencyService.Get<IFSocket>().SendMessage(uiRes.queueNumber + "," + counterNumber + "<EOF>", App.IPAdress, 11111);
                            //DependencyService.Get<IFiOSSocket>().SendMessage("I002,8,<EOF>", "192.168.1.38", 11111);
                            break;
                    }

                    if (App.CheckSocket == true)
                    {
                        AcceptBtn.IsVisible = true;
                        SkipBtn.IsVisible = true;
                        FinishBtn.IsVisible = false;
                        CallBtn.IsVisible = false;
                    }
                    else
                    {
                        App.SetIPPage = 1;
                        DisplayAlert(App.AppicationName, App.NoSocket, "Close");
                        Navigation.PushAsync(new UserSetIPAddress());
                        AcceptBtn.IsVisible = false;
                        SkipBtn.IsVisible = false;
                        FinishBtn.IsVisible = false;
                        CallBtn.IsVisible = false;
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
                    //Task.Delay(TimeSpan.FromSeconds(3)).Wait();

                }
                else
                {
                    DisplayAlert(App.AppicationName, uiReturn.getDescription(), "cancel");
                    CallBtn.IsEnabled = true;
                    CallBtn.IsVisible = true;
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
                UIReturn uiReturn = UserActionQueueController.getInstance().acceptQueue(UserSessionModel.choosedQueue);
                if (uiReturn.isSuccess)
                {
                    CallBtn.IsVisible = false;
                    AcceptBtn.IsVisible = false;
                    SkipBtn.IsVisible = false;
                    FinishBtn.IsVisible = true;
                }
                else
                {
                    DisplayAlert(App.AppicationName, uiReturn.getDescription(), "cancel");
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
                UIReturn uiReturn = UserActionQueueController.getInstance().finishQueue(UserSessionModel.choosedQueue);
                if (uiReturn.isSuccess)
                {
                    CallBtn.IsVisible = true;
                    AcceptBtn.IsVisible = false;
                    SkipBtn.IsVisible = false;
                    FinishBtn.IsVisible = false;
                }
                else
                {
                    DisplayAlert(App.AppicationName, uiReturn.getDescription(), "cancel");
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
                UIReturn uiReturn = UserActionQueueController.getInstance().skipQueue(UserSessionModel.choosedQueue);
                if (uiReturn.isSuccess)
                {
                    CallBtn.IsVisible = true;
                    AcceptBtn.IsVisible = false;
                    SkipBtn.IsVisible = false;
                    FinishBtn.IsVisible = false;
                }
                else
                {
                    DisplayAlert(App.AppicationName, uiReturn.getDescription(), "cancel");
                }
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
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
