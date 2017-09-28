using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class ServicePage : ContentPage
	{
		bool timercheck = true;
        public Branch searchBranch = new Branch();
		int Recount = 0;
		int ChkTime = 0;
		int ChkTime2 = 0;

		public ServicePage(Branch selectedBranch)
		{
			InitializeComponent();
            getService(selectedBranch);
            branchName.Text = selectedBranch.branchName;

            searchBranch = (Branch)SearchController.getInstance().getBranchDetail(selectedBranch).returnObject;

			if (SessionModel.bookingQ != null)
			{
				if (timercheck == true)
				{
                    if (SessionModel.bookingQ.queueNumber != 0)
                    {
                        ChkTime = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;
                        timerStart();
                    }
				}
			}
		}

        public void timerStart()
        {
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
                {
                    Recount = Recount + 1;
                    // do something every 60 seconds
                    // ItemsPage i = new ItemsPage();
                    if (timercheck == true && QueuePage.timercount != 0)
                    {
                        QueuePage.timercount--;
                        QueuePage.timercount.ToString();

						if (QueuePage.timercount.ToString() == "0")
						{
							return false;
						}

                        if (Recount == 10)
                        {
                            Recount = 0;
                            Service s = new Service();
                            s.serviceID = SessionModel.bookingQ.serviceID;
                            s.branchID = SessionModel.bookingQ.branchID;
                            Queue Queue = (Queue)ReserveQController.getInstance().reserveQueue(s).returnObject;
                            ChkTime2 = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;
                            if (ChkTime != ChkTime2)
                            {
                                ChkTime = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;
                                QueuePage.timercount = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;
                            }
                        }
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

		public void OnImageMap(object sender, System.EventArgs args)
		{
			timercheck = false;
            Navigation.PushAsync(new MapViewPage(searchBranch));
		}
	}
}
