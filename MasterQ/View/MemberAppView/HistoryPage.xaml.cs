using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class HistoryPage : ContentPage
	{
		bool timercheck = true;
		public HistoryPage()
		{
			InitializeComponent();
			getHistory();

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
					if (timercheck == true)
					{
						MainPage.timercount--;
						MainPage.timercount.ToString();
						return true; // runs again, or false to stop
					}
					else
					{
						return false;
					}
				});
		}

		public void getHistory()
		{
            Member memberid = UserSessionModel.loginMember;
			List<History> History = (List<History>)ShowHistoryController.getInstance().getHistory(memberid).returnObject;
			mListview.ItemsSource = History;
		}

		public void OnImageBack(object sender, System.EventArgs args)
		{
			timercheck = false;
			Navigation.PushAsync(new MainPage());
		}

		public void OnImageSearch(object sender, System.EventArgs args)
		{
			timercheck = false;
			Navigation.PushAsync(new SearchPage());
		}

	}
}
