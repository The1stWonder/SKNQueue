using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
    public partial class BranchChooseServiceQueuePage : ContentPage
    {
        public BranchChooseServiceQueuePage()
        {
            InitializeComponent();
            getService();
        }
		public void getService()
		{
            List<Service> Service = (List<Service>)BranchActionsController.getInstance().getBranchServices().returnObject;
			ServiceListview.ItemsSource = Service;
		}

		public void itemTapped(object sender, System.EventArgs args)
		{
			Service service = (Service)ServiceListview.SelectedItem;
            UIReturn uiReturn = BranchActionsController.getInstance().reserveQueueBranch(service);
            if (uiReturn.isSuccess)
            {
                BranchSessionModel.bookingQ = (Queue)uiReturn.returnObject;
                //Navigation.PushAsync(new BranchSummaryQueuePage());
                if (BranchSessionModel.bookingQ != null)
                {
                    NumberQ.Text = BranchSessionModel.bookingQ.queueNumber;
                }
            }else{
                DisplayAlert("Error",uiReturn.getDescription(),"Cancel");
            }
		}
    }
}
