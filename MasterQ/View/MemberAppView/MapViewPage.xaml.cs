using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MasterQ
{
    public partial class MapViewPage : ContentPage
    {
        bool timercheck = true;
        public Branch searchBranch = new Branch();
        double latitude = 0;
        double longitude = 0;
		int Recount = 0;
		int ChkTime = 0;
		int ChkTime2 = 0;

        public MapViewPage(Branch selectedBranch)
        {
            InitializeComponent();
            searchBranch = (Branch)SearchController.getInstance().getBranchDetail(selectedBranch).returnObject;
            branchName.Text = selectedBranch.branchName;
            branchAddress.Text = "ที่อยู่ : " + selectedBranch.address;
            branchTel.Text = "โทร : " + selectedBranch.telNo;
            branchEmail.Text = "อีเมล : " + searchBranch.email;

            if (selectedBranch.latitude != "")
            {
                latitude = double.Parse(selectedBranch.latitude);
            }

			if (selectedBranch.longitude != "")
			{
				longitude = double.Parse(selectedBranch.longitude);
			}

			var pin = new CustomPin
			{
				Pin = new Pin
				{
					Type = PinType.Place,
					Position = new Position(latitude, longitude),
					Label = selectedBranch.branchName,
					Address = selectedBranch.address
				},
				//Id = "Xamarin",
				//Url = "http://xamarin.com/about/"
			};

			customMap.CustomPins = new List<CustomPin> { pin };
			customMap.Pins.Add(pin.Pin);
			customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(latitude, longitude), Distance.FromMiles(1.0)));

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

		public void OnImageBack(object sender, System.EventArgs args)
		{
            timercheck = false;
            Navigation.PushAsync(new ServicePage(searchBranch));
		}
    }
}
