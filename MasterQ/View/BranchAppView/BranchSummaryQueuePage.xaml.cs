﻿using System;
using System.Collections.Generic;
using Plugin.Connectivity;
using Xamarin.Forms;

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
                //WaitTime.Text = Utils.getLabel(LabelConstants.MAIN_PAGE_WATETIME);

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
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                App.Recount = App.Recount + 1;
                
            NumberQ.Text = BranchSessionModel.bookingQ.queueNumber;
            NumberQ2.Text = BranchSessionModel.bookingQ.queueBefore.ToString();

            //TimeSpan time = TimeSpan.FromSeconds(BranchSessionModel.bookingQ.estimateTime * 60);
            //TimesQ.Text = time.ToString(@"hh\:mm\:ss");

                if (App.Recount == 5)
                {
                    App.Recount = 0;
                    App.timercheck = false;
                    Navigation.InsertPageBefore(new BranchChooseServiceQueuePage(), this);
                    Navigation.PopAsync();
                }
                return App.timercheck;
            });
        }
		
    }
}
