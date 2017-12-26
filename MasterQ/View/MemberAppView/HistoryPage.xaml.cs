using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Plugin.Connectivity;

namespace MasterQ
{
	public partial class HistoryPage : ContentPage
	{
		public HistoryPage()
		{
			InitializeComponent();

            if (CrossConnectivity.Current.IsConnected)
            {
                getHistory();
                HistoryQ.Text = Utils.getLabel(LabelConstants.MAIN_PAGE_HISTORY);
            }
		}


		public void getHistory()
		{
            Member memberid = SessionModel.loginMember;
			List<History> History = (List<History>)ShowHistoryController.getInstance().getHistory(memberid).returnObject;
			mListview.ItemsSource = History;
		}

		public void OnImageBack(object sender, System.EventArgs args)
		{
            if (CrossConnectivity.Current.IsConnected)
            {
                Navigation.PushAsync(new MainPage());
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
		}

        public void OnImageSearch(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                if (SessionModel.bookingQ == null || String.IsNullOrEmpty(SessionModel.bookingQ.queueNumber))
                {
                    Navigation.PushAsync(new SearchPage());
                    App.TextSearch = "";
                    App.SearchID = 0;
                }
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        public void itemTapped(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                if (SessionModel.bookingQ == null || String.IsNullOrEmpty(SessionModel.bookingQ.queueNumber))
                {
                    Branch b = new Branch();
                    Branch BranchID = new Branch();
                    History BranchHis = (History)mListview.SelectedItem;
                    b.branchID = BranchHis.branchID;
                    UIReturn uiR = SearchController.getInstance().getBranchDetail(b);
                    BranchID = (Branch)uiR.returnObject;

                    Navigation.PushAsync(new ServicePage(BranchID));
                    App.TextSearch = "";
                    App.SearchID = 1;
                }
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }
	}
}
