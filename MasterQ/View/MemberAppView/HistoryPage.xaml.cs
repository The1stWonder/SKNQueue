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
            Member memberid = UserSessionModel.loginMember;
			List<History> History = (List<History>)ShowHistoryController.getInstance().getHistory(memberid).returnObject;
			mListview.ItemsSource = History;
		}

		public void OnImageBack(object sender, System.EventArgs args)
		{
			Navigation.PushAsync(new MainPage());
		}

		public void OnImageSearch(object sender, System.EventArgs args)
		{
			Navigation.PushAsync(new SearchPage());
		}

	}
}
