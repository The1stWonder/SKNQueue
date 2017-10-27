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
            Member memberid = SessionModel.loginMember;
			List<History> History = (List<History>)ShowHistoryController.getInstance().getHistory(memberid).returnObject;
			mListview.ItemsSource = History;
		}

		public void OnImageBack(object sender, System.EventArgs args)
		{
			Navigation.PushAsync(new MainPage());
		}

		public void OnImageSearch(object sender, System.EventArgs args)
		{
            if (SessionModel.bookingQ.queueNumber == 0)
            {
                Navigation.PushAsync(new SearchPage());
            }
		}

		public void itemTapped(object sender, System.EventArgs args)
		{
            if (SessionModel.bookingQ.queueNumber == 0)
            {
                Branch b = new Branch();
                Branch BranchID = new Branch();
                History BranchHis = (History)mListview.SelectedItem;
                b.branchID = BranchHis.branchID;
                UIReturn uiR = SearchController.getInstance().getBranchDetail(b);
                BranchID = (Branch)uiR.returnObject;

                Navigation.PushAsync(new ServicePage(BranchID));
            }
		}

	}
}
