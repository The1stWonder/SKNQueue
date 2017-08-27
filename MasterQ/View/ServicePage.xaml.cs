using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class ServicePage : ContentPage
	{
		public ServicePage()
		{
			InitializeComponent();
            getService();
		}

		public void getService()
		{
			//Member member = new Member();
			//member.memberID = "01";
			//List<History> History = (List<History>)ShowHistoryController.getInstance().getHistory(member).returnObject;
			//mListview.ItemsSource = History;

			Service s = new Service();
			s.serviceID = "0001";
			s.branchID = "01";
			List<Service> Service = (List<Service>)ReserveQController.getInstance().reserveQueue(s).returnObject;
            ServiceListview.ItemsSource = Service;
		}
	}
}
