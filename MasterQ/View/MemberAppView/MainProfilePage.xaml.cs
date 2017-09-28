using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class MainProfilePage : ContentPage
	{
		bool timercheck = true;
		int Recount = 0;
		int ChkTime = 0;
		int ChkTime2 = 0;

		public MainProfilePage()
		{
			InitializeComponent();

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
                    if (timercheck == true && QueuePage.timercount != 0)
                    {
                        QueuePage.timercount--;
                        QueuePage.timercount.ToString();

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

		public void OnImageMainPage(object sender, System.EventArgs args)
		{
			timercheck = false;
			Navigation.PushAsync(new MainPage());
		}

		public void OnImageEditProfilePage(object sender, System.EventArgs args)
		{
			timercheck = false;
			Navigation.PushAsync(new EditProfilePage());
		}

		public void OnImageLogout(object sender, System.EventArgs args)
		{
			timercheck = false;
			Navigation.PushAsync(new LoginPage());
		}
	}
}
