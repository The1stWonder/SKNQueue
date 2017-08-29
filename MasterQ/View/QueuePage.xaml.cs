using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class QueuePage : ContentPage
	{
        public QueuePage(Service selectedService)
		{
			InitializeComponent();
            reserveQ(selectedService);
		}

		private void reserveQ(Service selectedService)
		{
			Service s = new Service();
            s.serviceID = selectedService.serviceID;
            s.branchID = selectedService.branchID;
            Queue Queue = (Queue)ReserveQController.getInstance().reserveQueue(s).returnObject;

            queueNumber2.Text = Queue.queueNumber.ToString();
            estimateTime2.Text = Queue.estimateTime.ToString();
            //serviceID2.Text = Queue.serviceID.ToString();
            //transID1.Text = Queue.transID.ToString();
		}
	}
}
