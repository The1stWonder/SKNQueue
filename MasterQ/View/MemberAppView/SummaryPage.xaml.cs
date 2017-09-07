using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class SummaryPage : ContentPage
	{
		public SummaryPage()
		{
			InitializeComponent();

			if (SessionModel.bookingQ != null)
			{
				NumberQ.Text = SessionModel.bookingQ.queueNumber.ToString();
			}
		}

		public void OnImageHomePage(object sender, System.EventArgs args)
		{
            Navigation.PushAsync(new MainPage());
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
