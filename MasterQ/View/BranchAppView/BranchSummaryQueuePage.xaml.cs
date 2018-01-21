using System;
using System.Collections.Generic;
using Plugin.Connectivity;
using Xamarin.Forms;
using MasterQ.Helpers;

namespace MasterQ
{
    public partial class BranchSummaryQueuePage : ContentPage
    {
        public BranchSummaryQueuePage()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                InitializeComponent();

                YourQ.Text = Utils.getLabel(LabelConstants.MAIN_PAGE_YOURQUEUE);
                AllQ.Text = Utils.getLabel(LabelConstants.MAIN_PAGE_ALLQUEUE);
                NumberQ.Text = BranchSessionModel.bookingQ.queueNumber;
                NumberQ2.Text = BranchSessionModel.bookingQ.queueBefore.ToString();

                App.timercheck = true;
                App.timerStart();

                ShowQ();
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        public void ShowQ()
        {
            TimeSpan time = TimeSpan.FromSeconds(BranchSessionModel.bookingQ.estimateTime * 60);
            string TimesQ = time.ToString(@"hh\:mm\:ss");

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    DependencyService.Get<IFSocket>().SendMessage("P," + BranchSessionModel.bookingQ.queueNumber + "," + BranchSessionModel.bookingQ.queueBefore + "," + App.servicename + "," + TimesQ + "<EOF>", App.IPAdress, 11111);
                    break;
                default:
                    DependencyService.Get<IFSocket>().SendMessage("P," + BranchSessionModel.bookingQ.queueNumber + "," + BranchSessionModel.bookingQ.queueBefore + "," + App.servicename + "," + TimesQ + "<EOF>", App.IPAdress, 11111);
                    break;
            }

            App.CheckSocket = true;
            if (App.CheckSocket == true)
            {
                Device.StartTimer(new TimeSpan(0, 0, 1), () =>
               {
                   App.Recount = App.Recount + 1;

                   if (App.Recount == 2)
                   {
                       App.Recount = 0;
                       App.timercheck = false;
                       Navigation.InsertPageBefore(new BranchChooseServiceQueuePage(), this);
                       Navigation.PopAsync();
                   }
                   return App.timercheck;
               });
            }
            else
            {
                Device.StartTimer(new TimeSpan(0, 0, 1), () =>
                {
                    App.Recount = 0;
                    App.timercheck = false;
                    App.SetIPPage = 1;
                    DisplayAlert(App.AppicationName, App.NoSocket, "Close");
                    Navigation.PushAsync(new BranchSetIPAddress());

                    return App.timercheck;
                });
            }
        }
    }
}
