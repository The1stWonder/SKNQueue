using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
    public partial class RatingPage : ContentPage
    {
        public RatingPage()
        {
            InitializeComponent();

        }

		void Rating1_Clicked(object sender, System.EventArgs e)
		{
            SessionModel.bookingQ.rank = "1";
            UIReturn uiReturn = ReserveQController.getInstance().ratingStaff(SessionModel.bookingQ);
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

		void Rating2_Clicked(object sender, System.EventArgs e)
		{
			SessionModel.bookingQ.rank = "2";
			UIReturn uiReturn = ReserveQController.getInstance().ratingStaff(SessionModel.bookingQ);
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

		void Rating3_Clicked(object sender, System.EventArgs e)
		{
			SessionModel.bookingQ.rank = "3";
			UIReturn uiReturn = ReserveQController.getInstance().ratingStaff(SessionModel.bookingQ);
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

		void Rating4_Clicked(object sender, System.EventArgs e)
		{
			SessionModel.bookingQ.rank = "4";
			UIReturn uiReturn = ReserveQController.getInstance().ratingStaff(SessionModel.bookingQ);
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

		void Rating5_Clicked(object sender, System.EventArgs e)
		{
			SessionModel.bookingQ.rank = "5";
			UIReturn uiReturn = ReserveQController.getInstance().ratingStaff(SessionModel.bookingQ);
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
