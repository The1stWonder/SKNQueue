using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
    public partial class BranchSummaryQueuePage : ContentPage
    {
        public BranchSummaryQueuePage()
        {
            InitializeComponent();
            if (BranchSessionModel.bookingQ != null)
			{
				NumberQ.Text = BranchSessionModel.bookingQ.queueNumber.ToString();
                TimeSpan time = TimeSpan.FromSeconds(BranchSessionModel.bookingQ.estimateTime);
                estimateTime.Text = time.ToString(@"hh\:mm\:ss");
			}
        }
		public void OnImageHomePage(object sender, System.EventArgs args)
		{
            Navigation.PushAsync(new BranchChooseServiceQueuePage());
		}

		public void OnImageDelete(object sender, System.EventArgs args)
		{
			
		}
    }
}
