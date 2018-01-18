using System;
using System.Collections.Generic;
using MasterQ.Helpers;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace MasterQ
{
    public partial class BranchChooseServiceQueuePage : ContentPage
    {

        public BranchChooseServiceQueuePage()
        {
            InitializeComponent();
            HeaderService.Text = Utils.getLabel(LabelConstants.BRANCHSERVICE_PAGE_SERVICE);
            getService();
        }
		public void getService()
		{
            List<Service> Service = (List<Service>)BranchActionsController.getInstance().getBranchServices().returnObject;
			ServiceListview.ItemsSource = Service;

            //if (App.Thai == true)
            //{
            //    ChooseIMG.Source = "NextQ2.png";
            //}
            //else
            //{
            //    ChooseIMG.Source = "NextQ1.png";
            //}
		}

        async void itemTapped(object sender, System.EventArgs args)
        {
            Service service = (Service)ServiceListview.SelectedItem;
            string servicename = service.serviceName;

            //var answer = await DisplayAlert(Utils.getLabel(LabelConstants.MAIN_PAGE_BOOKING), Utils.getLabel(LabelConstants.SERVICE_PAGE_CONFIRMBOOKING) + " " + servicename​, "Yes", "No");
            //if (answer == true)
            //{
                UIReturn uiReturn = BranchActionsController.getInstance().reserveQueueBranch(service);
                if (uiReturn.isSuccess)
                {
                    BranchSessionModel.bookingQ = (Queue)uiReturn.returnObject;
                    if (BranchSessionModel.bookingQ != null)
                    {
                        TimeSpan time = TimeSpan.FromSeconds(BranchSessionModel.bookingQ.estimateTime * 60);
                        string TimesQ = time.ToString(@"hh\:mm\:ss");

                        await Navigation.PushAsync(new BranchSummaryQueuePage());

                        switch (Device.RuntimePlatform)
                        {
                            case Device.iOS:
                                DependencyService.Get<IFSocket>().SendMessage("P," + BranchSessionModel.bookingQ.queueNumber + "," + BranchSessionModel.bookingQ.queueBefore + "," + servicename + "," + TimesQ + "<EOF>", App.IPAdress, 11111);
                                break;
                            default:
                                DependencyService.Get<IFSocket>().SendMessage("P," + BranchSessionModel.bookingQ.queueNumber + "," + BranchSessionModel.bookingQ.queueBefore + "," + servicename + "," + TimesQ + "<EOF>", App.IPAdress, 11111);
                                break;
                        }

                        if (App.CheckSocket == true)
                        {
                            await Navigation.PushAsync(new BranchSummaryQueuePage());
                        }
                        else
                        {
                            App.SetIPPage = 1;
                            await DisplayAlert(App.AppicationName, App.NoSocket, "Close");
                            await Navigation.PushAsync(new BranchSetIPAddress());
                        }
                    }
                }
                else
                {
                    await DisplayAlert("Error", uiReturn.getDescription(), "Cancel");
                }
            //}
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
