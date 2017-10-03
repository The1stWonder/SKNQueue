using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class SummaryPage : ContentPage
	{
		bool timercheck = true;
		int Recount = 0;
		int ChkTime = 0;
		int ChkTime2 = 0;

		public SummaryPage()
		{
			InitializeComponent();

			if (SessionModel.bookingQ != null)
			{
				if (SessionModel.bookingQ.queueNumber != 0)
				{
                    var ServiceName = SessionModel.getService(SessionModel.bookingQ.serviceID);
                    ServiceQ.Text = "บริการ : " + ServiceName.serviceName;
					NumberQ.Text = SessionModel.bookingQ.queueNumber.ToString();

					if (timercheck == true)
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
                    if (timercheck == true && QueuePage.timercount != 0)
                    {
                        QueuePage.timercount--;
                        TimeSpan time = TimeSpan.FromSeconds(QueuePage.timercount);

                        if (QueuePage.timercount.ToString() == "0")
                        {
                            TimesQ.Text = "00:00:00";
                            DetailQ.Text = "ถึงคิวคุณแล้ว";
                            timercheck = false;
                            return false;
                        }
                        else
                        {
                            if (SessionModel.bookingQ != null)
                            {
                                DetailQ.Text = "คิวก่อนหน้า " + SessionModel.bookingQ.queueBefore + " คิว " + " โปรดรอ";
                            }
                        }

                        TimesQ.Text = time.ToString(@"hh\:mm\:ss");
                        //setLabel(MainPage.timercount.ToString());

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
                        timercheck = false;
                        DetailQ.Text = "ถึงคิวคุณแล้ว";
                        TimesQ.Text = "00:00:00";
                        return false;
                    }
                });
        }

		//public void setLabel(string txt)
		//{
		//	TimesQ.Text = txt;
		//}

		public void OnImageHomePage(object sender, System.EventArgs args)
		{
            //Navigation.PushAsync(new MainPage());
			timercheck = false;
			Navigation.InsertPageBefore(new MainPage(), this);
			Navigation.PopAsync();
		}

		public void OnImageDelete(object sender, System.EventArgs args)
		{
            if (SessionModel.bookingQ != null)
            {
				if (SessionModel.bookingQ.queueNumber != 0)
				{
					UIReturn uiReturn = ReserveQController.getInstance().cancelQueue(SessionModel.bookingQ);
					if (uiReturn.isSuccess)
					{
						//DisplayAlert("Click", uiReturn.getDescription(), "Close");
						Navigation.PushAsync(new MainPage());
						timercheck = false;
					}
					else
					{
						DisplayAlert("", uiReturn.getDescription(), "Close");
					}
				}
            }
		}
	}
}
