using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class ServicePage : ContentPage
	{
		public ServicePage(Branch selectedBranch)
		{
			InitializeComponent();
            getService(selectedBranch);
		}

		public void getService(Branch selectedBranch)
		{
            List<Service> Service = (List<Service>)SearchController.getInstance().getBranchQueue(selectedBranch).returnObject;
            ServiceListview.ItemsSource = Service;
		}

		public void itemTapped(object sender, System.EventArgs args)
		{
			Service serviceID = (Service)ServiceListview.SelectedItem;
            Navigation.PushAsync(new QueuePage(serviceID));
		}
	}
}
