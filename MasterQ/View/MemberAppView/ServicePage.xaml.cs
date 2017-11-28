using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class ServicePage : ContentPage
	{
        public Branch searchBranch = new Branch();
		
		public ServicePage(Branch selectedBranch)
		{
			InitializeComponent();
            getService(selectedBranch);
            branchName.Text = selectedBranch.branchName;

            searchBranch = (Branch)SearchController.getInstance().getBranchDetail(selectedBranch).returnObject;
		}

		public void getService(Branch selectedBranch)
		{
            List<Service> Service = (List<Service>)SearchController.getInstance().getBranchQueue(selectedBranch).returnObject;
            ServiceListview.ItemsSource = Service;
		}

		public void itemTapped(object sender, System.EventArgs args)
		{
			Service serviceID = (Service)ServiceListview.SelectedItem;
			Service s = new Service();
			s.serviceID = serviceID.serviceID;
			s.branchID = serviceID.branchID;
			UIReturn ChkQ = ReserveQController.getInstance().reserveQueue(s);
			if (!ChkQ.isSuccess)
			{
				DisplayAlert("", ChkQ.getDescription(), "Close");
                SessionModel.bookingQ = null;
            }
            else
            {
                App.timerStart();
                Navigation.PushAsync(new MainPage());
            }

            //Service serviceID = (Service)ServiceListview.SelectedItem;
            //Navigation.PushAsync(new SummaryPage(serviceID,searchBranch));
		}

		public void OnImageBack(object sender, System.EventArgs args)
		{
			Navigation.PushAsync(new SearchPage());
		}

		public void OnImageMap(object sender, System.EventArgs args)
		{
            Navigation.PushAsync(new MapViewPage(searchBranch));
		}
	}
}
