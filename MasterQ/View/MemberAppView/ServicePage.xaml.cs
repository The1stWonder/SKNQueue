using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class ServicePage : ContentPage
	{
		bool timercheck = true;
		public ServicePage(Branch selectedBranch)
		{
			InitializeComponent();
            getService(selectedBranch);

			if (SessionModel.bookingQ != null)
			{
				if (timercheck == true)
				{
                    if (SessionModel.bookingQ.queueNumber != 0)
                    {
                        timerStart();
                    }
				}
			}
		}

		public void timerStart()
		{
			Device.StartTimer(new TimeSpan(0, 0, 1), () =>
				{
			// do something every 60 seconds
			// ItemsPage i = new ItemsPage();
			if (timercheck == true && QueuePage.timercount != 0)
					{
						QueuePage.timercount--;
						QueuePage.timercount.ToString();
						return true; // runs again, or false to stop
			}
					else
					{
						return false;
					}
				});
		}

		public void getService(Branch selectedBranch)
		{
            List<Service> Service = (List<Service>)SearchController.getInstance().getBranchQueue(selectedBranch).returnObject;
            ServiceListview.ItemsSource = Service;
		}

		public void itemTapped(object sender, System.EventArgs args)
		{
			timercheck = false;
			Service serviceID = (Service)ServiceListview.SelectedItem;
            Navigation.PushAsync(new QueuePage(serviceID));
		}

		public void OnImageBack(object sender, System.EventArgs args)
		{
			timercheck = false;
			Navigation.PushAsync(new SearchPage());
		}
	}
}
