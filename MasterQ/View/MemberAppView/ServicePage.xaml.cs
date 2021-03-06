﻿using System;
using System.Collections.Generic;
using Plugin.Connectivity;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterQ
{
    [XamlCompilation(XamlCompilationOptions.Compile)] //alexpook link all
	public partial class ServicePage : ContentPage
	{
        public Branch searchBranch = new Branch();

        public ServicePage(Branch selectedBranch)
        {
            InitializeComponent();

            if (CrossConnectivity.Current.IsConnected)
            {
                getService(selectedBranch);
                branchName.Text = selectedBranch.branchName;
                searchBranch = (Branch)SearchController.getInstance().getBranchDetail(selectedBranch).returnObject;
            }
        }

		public void getService(Branch selectedBranch)
		{
            List<Service> Service = (List<Service>)SearchController.getInstance().getBranchQueue(selectedBranch).returnObject;
            ServiceListview.ItemsSource = Service;
		}

        public void itemTapped(object sender, System.EventArgs args)
		{
            if (CrossConnectivity.Current.IsConnected)
            {
                Service serviceID = (Service)ServiceListview.SelectedItem;
                //Service s = new Service();
                //s.serviceID = serviceID.serviceID;
                //s.branchID = serviceID.branchID;

                //var answer = await DisplayAlert(Utils.getLabel(LabelConstants.MAIN_PAGE_BOOKING), Utils.getLabel(LabelConstants.SERVICE_PAGE_CONFIRMBOOKING) + " " + serviceID.serviceName​, "Yes", "No");
                //if (answer == true)
                //{
                    //UIReturn ChkQ = ReserveQController.getInstance().reserveQueue(s);
                    UIReturn ChkQ = ReserveQController.getInstance().reserveQueue(serviceID);
                    if (!ChkQ.isSuccess)
                    {
                        App.TextSearch = "";
                        DisplayAlert(App.AppicationName, ChkQ.getDescription(), "Close");
                        SessionModel.bookingQ = null;
                    }
                    else
                    {
                        App.RePage = false;
                        App.TextSearch = "";
                        //App.timerStart();
                        Navigation.PushAsync(new MainPage());
                    }
                //}
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
		}

        public void OnImageBack(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                if (App.SearchID == 0)
                {
                    Navigation.PushAsync(new SearchPage());
                }
                else if (App.SearchID == 1)
                {
                    Navigation.PushAsync(new HistoryPage());
                }
                else if (App.SearchID == 2)
                {
                    Navigation.PushAsync(new MainPage());
                }
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        public void OnImageMap(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                Navigation.PushAsync(new MapViewPage(searchBranch));
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }
	}
}
