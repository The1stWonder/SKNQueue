using System;
using System.Collections.Generic;
using Plugin.Connectivity;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterQ
{
    [XamlCompilation(XamlCompilationOptions.Compile)] //alexpook link all
    public partial class RatingPage : ContentPage
    {
        public RatingPage()
        {
            InitializeComponent();
            HeaderRating.Text = Utils.getLabel(LabelConstants.RATING_PAGE_THANKYOU);
        }

        public void OnImageRating1(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                SessionModel.bookingQ.rank = "2";
                UIReturn uiReturn = ReserveQController.getInstance().ratingStaff(SessionModel.bookingQ);
                if (uiReturn.isSuccess)
                {
                    App.Massage0 = true;
                    App.Massage5 = true;
                    App.Massage15 = true;
                    Navigation.PushAsync(new MainPage());
                }
                else
                {
                    DisplayAlert(App.AppicationName, uiReturn.getDescription(), "Close");
                }
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        public void OnImageRating2(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                SessionModel.bookingQ.rank = "3";
                UIReturn uiReturn = ReserveQController.getInstance().ratingStaff(SessionModel.bookingQ);
                if (uiReturn.isSuccess)
                {
                    App.Massage0 = true;
                    App.Massage5 = true;
                    App.Massage15 = true;
                    Navigation.PushAsync(new MainPage());
                }
                else
                {
                    DisplayAlert(App.AppicationName, uiReturn.getDescription(), "Close");
                }
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        public void OnImageRating3(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                SessionModel.bookingQ.rank = "4";
                UIReturn uiReturn = ReserveQController.getInstance().ratingStaff(SessionModel.bookingQ);
                if (uiReturn.isSuccess)
                {
                    App.Massage0 = true;
                    App.Massage5 = true;
                    App.Massage15 = true;
                    Navigation.PushAsync(new MainPage());
                }
                else
                {
                    DisplayAlert(App.AppicationName, uiReturn.getDescription(), "Close");
                }
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        public void OnImageRating4(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                SessionModel.bookingQ.rank = "5";
                UIReturn uiReturn = ReserveQController.getInstance().ratingStaff(SessionModel.bookingQ);
                if (uiReturn.isSuccess)
                {
                    App.Massage0 = true;
                    App.Massage5 = true;
                    App.Massage15 = true;
                    Navigation.PushAsync(new MainPage());
                }
                else
                {
                    DisplayAlert(App.AppicationName, uiReturn.getDescription(), "Close");
                }
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }
    }
}
