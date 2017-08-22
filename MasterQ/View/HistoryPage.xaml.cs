using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class HistoryPage : ContentPage
	{
		public HistoryPage()
		{
			InitializeComponent();
			getHistory();
		}

		public void getHistory()
		{
			Member member = new Member();
			member.memberID = "01";
			//UIReturn result = ShowHistoryController.getInstance().getHistory(member);
			List<History> History = (List<History>)ShowHistoryController.getInstance().getHistory(member).returnObject;
			mListview.ItemsSource = History;
            //foreach (History h in History)
			//{
			//	mListview.ItemsSource = h.serviceID;
			//	mListview.ItemsSource = h.timeAccept;
			//}
		}

	}
}
