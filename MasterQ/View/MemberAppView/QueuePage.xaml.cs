using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class QueuePage : ContentPage
	{
		bool timercheck = true;
		public static int timercount;

        public QueuePage(Service selectedService)
		{
			InitializeComponent();
            reserveQ(selectedService);

			if (SessionModel.bookingQ != null)
			{
				if (SessionModel.bookingQ.queueNumber != 0)
				{
                    var ServiceName = SessionModel.getService(SessionModel.bookingQ.serviceID);
                    ServiceQ.Text = "บริการ : " + ServiceName.serviceName;
					NumberQ.Text = SessionModel.bookingQ.queueNumber.ToString();
					timercount = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;
                    timerStart();
				}
			}
		}

		public void timerStart()
		{
			if (timercount.ToString() == "0")
			{
				timercheck = false;
			}
			else
			{
				Device.StartTimer(new TimeSpan(0, 0, 1), () =>
				{
					// do something every 60 seconds
					//timercheck = true;
					timercount--;
					TimeSpan time = TimeSpan.FromSeconds(timercount);

					TimesQ.Text = time.ToString(@"hh\:mm\:ss");

					if (timercount.ToString() == "0")
					{
						timercheck = false;
					}
					return timercheck;
				});
			}
		}

		private void reserveQ(Service selectedService)
		{
			Service s = new Service();
            s.serviceID = selectedService.serviceID;
            s.branchID = selectedService.branchID;
            Queue Queue = (Queue)ReserveQController.getInstance().reserveQueue(s).returnObject;
		}

		public void OnImageHomePage(object sender, System.EventArgs args)
		{
			timercheck = false;
			Navigation.InsertPageBefore(new MainPage(), this);
			Navigation.PopAsync();
		}

		public void OnImageDelete(object sender, System.EventArgs args)
		{
			if (SessionModel.bookingQ != null)
			{
				UIReturn uiReturn = ReserveQController.getInstance().cancelQueue(SessionModel.bookingQ);
				if (uiReturn.isSuccess)
				{
					//DisplayAlert("Click", uiReturn.getDescription(), "Close");
					Navigation.PushAsync(new MainPage());
					timercheck = false;
				}
				else
				{
					DisplayAlert("Click", uiReturn.getDescription(), "Close");
				}
			}
		}


	}
}
