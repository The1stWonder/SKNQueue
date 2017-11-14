using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class SummaryPage : ContentPage
	{
        public Service searchServece = new Service();

        public SummaryPage(Service selectedService)
		{
			InitializeComponent();

            searchServece = selectedService;
		}

        public void OnImageBack(object sender, System.EventArgs args)
        {
            Navigation.PushAsync(new SearchPage());
        }

        public void OnImageJoin1(object sender, System.EventArgs args)
        {
            Service s = new Service();
            s.serviceID = searchServece.serviceID;
            s.branchID = searchServece.branchID;
            UIReturn ChkQ = ReserveQController.getInstance().reserveQueue(s);
            if (!ChkQ.isSuccess)
            {
                DisplayAlert("", ChkQ.getDescription(), "Close");
                SessionModel.bookingQ = null;
            }
            else
            {
                App.timerStart();
                Navigation.PushAsync(new QueuePage());
            }
        }

        public void OnImageJoin2(object sender, System.EventArgs args)
        {
            
        }
	}
}
