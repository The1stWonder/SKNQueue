using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class HistoryPage : ContentPage
	{
        //public History BranchHis = new History();
		bool timercheck = true;
		int Recount = 0;
		int ChkTime = 0;
		int ChkTime2 = 0;

		public HistoryPage()
		{
			InitializeComponent();
			getHistory();

			if (SessionModel.bookingQ != null)
			{
				if (timercheck == true)
				{
                    if (SessionModel.bookingQ.queueNumber != 0)
                    {
                        ChkTime = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;
                        timerStart();
                    }
				}
			}
		}

        public void timerStart()
        {
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
                {
                    Recount = Recount + 1;
                    // do something every 60 seconds
                    // ItemsPage i = new ItemsPage();
                    if (timercheck == true && QueuePage.timercount != 0)
                    {
                        QueuePage.timercount--;
                        QueuePage.timercount.ToString();

						if (QueuePage.timercount.ToString() == "0")
						{
							return false;
						}

                        if (Recount == 10)
                        {
                            Recount = 0;
                            Service s = new Service();
                            s.serviceID = SessionModel.bookingQ.serviceID;
                            s.branchID = SessionModel.bookingQ.branchID;
                            Queue Queue = (Queue)ReserveQController.getInstance().reserveQueue(s).returnObject;
                            ChkTime2 = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;
                            if (ChkTime != ChkTime2)
                            {
                                ChkTime = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;
                                QueuePage.timercount = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;
                            }
                        }
                        return true; // runs again, or false to stop
                    }
                    else
                    {
                        return false;
                    }
                });
        }

		public void getHistory()
		{
            Member memberid = SessionModel.loginMember;
			List<History> History = (List<History>)ShowHistoryController.getInstance().getHistory(memberid).returnObject;
			mListview.ItemsSource = History;
		}

		public void OnImageBack(object sender, System.EventArgs args)
		{
			timercheck = false;
			Navigation.PushAsync(new MainPage());
		}

		public void OnImageSearch(object sender, System.EventArgs args)
		{
			timercheck = false;
			Navigation.PushAsync(new SearchPage());
		}

		public void itemTapped(object sender, System.EventArgs args)
		{
            if (SessionModel.bookingQ.queueNumber == 0)
            {
                Branch b = new Branch();
                Branch BranchID = new Branch();
                timercheck = false;
                History BranchHis = (History)mListview.SelectedItem;
                b.branchID = BranchHis.branchID;
                UIReturn uiR = SearchController.getInstance().getBranchDetail(b);
                BranchID = (Branch)uiR.returnObject;

                Navigation.PushAsync(new ServicePage(BranchID));
            }
		}

	}
}
