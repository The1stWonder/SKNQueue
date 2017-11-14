using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class SummaryPage : ContentPage
	{
        public Service searchServece = new Service();
        public Branch searchBranch = new Branch();

        public SummaryPage(Service selectedService,Branch selectedBranch)
		{
			InitializeComponent();

            searchServece = selectedService;
            searchBranch = (Branch)SearchController.getInstance().getBranchDetail(selectedBranch).returnObject;
		}

        public void OnImageBack(object sender, System.EventArgs args)
        {
            Navigation.PushAsync(new ServicePage(searchBranch));
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
