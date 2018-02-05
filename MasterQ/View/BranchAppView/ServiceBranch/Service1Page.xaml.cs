﻿using System;
using System.Collections.Generic;
using System.Linq;
using MasterQ.Helpers;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace MasterQ
{
    public partial class Service1Page : ContentPage
    {
        public Service service1 = new Service();

        public Service1Page()
        {
            InitializeComponent();
            HeaderService.Text = Utils.getLabel(LabelConstants.BRANCHSERVICE_PAGE_SERVICE);
            getService();
        }
    
        public void getService()
        {
            List<Service> Service = (List<Service>)BranchActionsController.getInstance().getBranchServices().returnObject;

            service1 = Service[0];

            text_service1.Text = service1.serviceName;

            btn_service1.IsEnabled = true;
            text_service1.IsEnabled = true;
        }

        public void OnService1(object sender, System.EventArgs args)
        {
            btn_service1.IsEnabled = false;
            text_service1.IsEnabled = false;

            Image image = sender as Image;
            if (image != null)
            {
                string source = image.Source as FileImageSource;
                if (String.Equals(source, "bluebutton.png"))
                {
                    image.Source = "bluebutton2.png";
                }
                else
                {
                    image.Source = "bluebutton.png";
                }
            }

            UIReturn uiReturn = BranchActionsController.getInstance().reserveQueueBranch(service1);
            if (uiReturn.isSuccess)
            {
                BranchSessionModel.bookingQ = (Queue)uiReturn.returnObject;
                if (BranchSessionModel.bookingQ != null)
                {
                    //TimeSpan time = TimeSpan.FromSeconds(BranchSessionModel.bookingQ.estimateTime * 60);
                    //string TimesQ = time.ToString(@"hh\:mm\:ss");

                    Navigation.PushAsync(new BranchSummaryQueuePage());

                    //switch (Device.RuntimePlatform)
                    //{
                    //    case Device.iOS:
                    //        DependencyService.Get<IFSocket>().SendMessage("P," + BranchSessionModel.bookingQ.queueNumber + "," + BranchSessionModel.bookingQ.queueBefore + "," + servicename + "," + TimesQ + "<EOF>", App.IPAdress, 11111);
                    //        break;
                    //    default:
                    //        DependencyService.Get<IFSocket>().SendMessage("P," + BranchSessionModel.bookingQ.queueNumber + "," + BranchSessionModel.bookingQ.queueBefore + "," + servicename + "," + TimesQ + "<EOF>", App.IPAdress, 11111);
                    //        break;
                    //}

                    //if (App.CheckSocket == true)
                    //{
                    //    Navigation.PushAsync(new BranchSummaryQueuePage());
                    //}
                    //else
                    //{
                    //    App.SetIPPage = 1;
                    //    DisplayAlert(App.AppicationName, App.NoSocket, "Close");
                    //    Navigation.PushAsync(new BranchSetIPAddress());
                    //}
                }
            }
            else
            {
                DisplayAlert("Error", uiReturn.getDescription(), "Cancel");
            }
        }

        async void OnImageMainExit(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var answer = await DisplayAlert(Utils.getLabel(LabelConstants.MAIN_PAGE_LOGOUT), Utils.getLabel(LabelConstants.MAIN_PAGE_CONFIRMLOGOUT), "Yes", "No");
                if (answer == true)
                {
                    UIReturn Chklogout = BranchLoginController.getInstance().LogutBranch();
                    if (!Chklogout.isSuccess)
                    {
                        await DisplayAlert(App.AppicationName, Chklogout.getDescription(), "Close");
                    }
                    else
                    {
                        Navigation.InsertPageBefore(new BranchLoginPage(), this);
                        await Navigation.PopAsync();
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
