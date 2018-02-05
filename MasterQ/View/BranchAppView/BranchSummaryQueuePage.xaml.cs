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


            //App.CheckSocket = true;


            if (App.CheckSocket == true)
            {
                Device.StartTimer(new TimeSpan(0, 0, 1), () =>
               {
                   App.Recount = App.Recount + 1;

                   if (App.Recount == 2)
                   {
                       App.Recount = 0;
                       App.timercheck = false;

                        if (App.NumberServiceBranch == 1)
                       {
                           Navigation.PushAsync(new Service1Page());
                       }
                        else if (App.NumberServiceBranch == 2)
                       {
                           Navigation.PushAsync(new Service2Page());
                       }
                        else if (App.NumberServiceBranch == 3)
                       {
                           Navigation.PushAsync(new Service3Page());
                       }
                        else if (App.NumberServiceBranch == 4)
                       {
                           Navigation.PushAsync(new Service4Page());
                       }
                        else if (App.NumberServiceBranch == 5)
                       {
                           Navigation.PushAsync(new Service5Page());
                       }
                        else if (App.NumberServiceBranch == 6)
                       {
                           Navigation.PushAsync(new Service6Page());
                       }
                        else if (App.NumberServiceBranch == 7)
                       {
                           Navigation.PushAsync(new Service7Page());
                       }
                        else if (App.NumberServiceBranch == 8)
                       {
                           Navigation.PushAsync(new Service8Page());
                       }
                        else if (App.NumberServiceBranch == 9)
                       {
                           Navigation.PushAsync(new Service9Page());
                       }
                        else if (App.NumberServiceBranch == 10)
                       {
                           Navigation.PushAsync(new Service10Page());
                       }
                        else if (App.NumberServiceBranch == 11)
                       {
                           Navigation.PushAsync(new Service11Page());
                       }
                        else if (App.NumberServiceBranch == 12)
                       {
                           Navigation.PushAsync(new Service12Page());
                       }
                        else if (App.NumberServiceBranch == 13)
                       {
                           Navigation.PushAsync(new Service13Page());
                       }
                        else if (App.NumberServiceBranch == 14)
                       {
                           Navigation.PushAsync(new Service14Page());
                       }
                        else if (App.NumberServiceBranch == 15)
                       {
                           Navigation.PushAsync(new Service15Page());
                       }
                        else if (App.NumberServiceBranch == 16)
                       {
                           Navigation.PushAsync(new Service16Page());
                       }
                        else if (App.NumberServiceBranch == 17)
                       {
                           Navigation.PushAsync(new Service17Page());
                       }
                        else if (App.NumberServiceBranch == 18)
                       {
                           Navigation.PushAsync(new Service18Page());
                       }
                        else if (App.NumberServiceBranch == 19)
                       {
                           Navigation.PushAsync(new Service19Page());
                       }
                        else if (App.NumberServiceBranch == 20)
                       {
                           Navigation.PushAsync(new Service20Page());
                       }
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
