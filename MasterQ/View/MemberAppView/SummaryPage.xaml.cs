using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class SummaryPage : ContentPage
	{
		//int timercount = 0;
		//bool timercheck = false;

		public SummaryPage()
		{
			InitializeComponent();

			if (SessionModel.bookingQ != null)
			{
				NumberQ.Text = SessionModel.bookingQ.queueNumber.ToString();

				//timercount = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;

				//if (timercount.ToString() == "0")
				//{
				//	timercheck = false;
				//}
				//else
				//{
				//	timercheck = true;
				//	Device.StartTimer(new TimeSpan(0, 0, 1), () =>
				//	{
				//		// do something every 60 seconds
				//		timercount--;
				//		TimeSpan time = TimeSpan.FromSeconds(timercount);

				//		TimesQ.Text = time.ToString(@"hh\:mm\:ss");

				//		if (timercount.ToString() == "0")
				//		{

				//			timercheck = false;
				//		}

				//		return timercheck;
				//	});
				//}
			}
		}

		public void OnImageHomePage(object sender, System.EventArgs args)
		{
            //Navigation.PushAsync(new MainPage());

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
                }
                else
                {
                    DisplayAlert("Click", uiReturn.getDescription(), "Close");
                }
            }
		}
	}
}
