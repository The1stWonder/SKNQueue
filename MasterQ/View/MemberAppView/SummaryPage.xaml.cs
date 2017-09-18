using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class SummaryPage : ContentPage
	{
		bool timercheck = true;

		public SummaryPage()
		{
			InitializeComponent();

			if (SessionModel.bookingQ != null)
			{
				NumberQ.Text = SessionModel.bookingQ.queueNumber.ToString();

				if (timercheck == true)
				{
                    timerStart();
				}
			}
		}

		public void timerStart()
		{
			Device.StartTimer(new TimeSpan(0, 0, 1), () =>
				{
					if (timercheck == true)
					{
						MainPage.timercount--;
						TimeSpan time = TimeSpan.FromSeconds(MainPage.timercount);

						TimesQ.Text = time.ToString(@"hh\:mm\:ss");
						//setLabel(MainPage.timercount.ToString());
						return true; // runs again, or false to stop
					}
					else
					{
						return false;
					}
				});
		}

		//public void setLabel(string txt)
		//{
		//	TimesQ.Text = txt;
		//}

		public void OnImageHomePage(object sender, System.EventArgs args)
		{
            //Navigation.PushAsync(new MainPage());
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
