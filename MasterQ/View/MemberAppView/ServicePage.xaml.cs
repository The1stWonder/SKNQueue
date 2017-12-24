using System;
using System.Collections.Generic;
using Plugin.Connectivity;

using Xamarin.Forms;

namespace MasterQ
{
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

        async void itemTapped(object sender, System.EventArgs args)
		{
            if (CrossConnectivity.Current.IsConnected)
            {
                Service serviceID = (Service)ServiceListview.SelectedItem;
                Service s = new Service();
                s.serviceID = serviceID.serviceID;
                s.branchID = serviceID.branchID;

                var answer = await DisplayAlert(Utils.getLabel(LabelConstants.MAIN_PAGE_BOOKING), Utils.getLabel(LabelConstants.SERVICE_PAGE_CONFIRMBOOKING) + " " + serviceID.serviceName​, "Yes", "No");
                if (answer == true)
                {
                    UIReturn ChkQ = ReserveQController.getInstance().reserveQueue(s);
                    if (!ChkQ.isSuccess)
                    {
                        App.TextSearch = "";
                        await DisplayAlert(App.AppicationName, ChkQ.getDescription(), "Close");
                        SessionModel.bookingQ = null;
                    }
                    else
                    {
                        App.RePage = false;
                        App.TextSearch = "";
                        //App.timerStart();
                        await Navigation.PushAsync(new MainPage());
                    }
                }
            }
		}

		public void OnImageBack(object sender, System.EventArgs args)
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

		public void OnImageMap(object sender, System.EventArgs args)
		{
            Navigation.PushAsync(new MapViewPage(searchBranch));
		}
	}
}
