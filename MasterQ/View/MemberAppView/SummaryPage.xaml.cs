using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class SummaryPage : ContentPage
	{
		int ChkTime = 0;
		int ChkTime2 = 0;

		public SummaryPage()
		{
			InitializeComponent();

			if (SessionModel.bookingQ != null)
			{
                if (!String.IsNullOrEmpty(SessionModel.bookingQ.queueNumber))
				{
                    var ServiceName = SessionModel.getService(SessionModel.bookingQ.serviceID);
                    ServiceQ.Text = "บริการ : " + ServiceName.serviceName;
					NumberQ.Text = SessionModel.bookingQ.queueNumber.ToString();

					if (App.timercheck == true)
					{
                        ChkTime = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;
						Process();
					}
				}
			}
		}

        public void Process()
        {
            App.timercheck = true;
			Service s = new Service();
			s.serviceID = SessionModel.bookingQ.serviceID;
			s.branchID = SessionModel.bookingQ.branchID;
            UIReturn ChkQueue = ReserveQController.getInstance().reserveQueue(SessionModel.bookingQ);

			Device.StartTimer(new TimeSpan(0, 0, 1), () =>
			{
				App.Recount = App.Recount + 1;
				TimeSpan time = TimeSpan.FromSeconds(App.timercount);

				TimesQ.Text = time.ToString(@"hh\:mm\:ss");

				if (!ChkQueue.isSuccess)
				{
					DisplayAlert("", ChkQueue.getDescription(), "Close");
					TimesQ.Text = "00:00:00";
					App.timercheck = false;
				}
				else
				{
                    if (SessionModel.bookingQ != null)
                    {
                        DetailQ.Text = String.Format(ChkQueue.getDescription(), SessionModel.bookingQ.queueBefore);
                    }

					if (App.timercount == 0)
					{
						TimesQ.Text = "00:00:00";
					}
				}

				if (App.Recount == 10)
				{
					App.Recount = 0;

                    Queue Queue = (Queue)ReserveQController.getInstance().reserveQueue(SessionModel.bookingQ).returnObject;
					ChkTime2 = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;
					if (ChkTime != ChkTime2)
					{
						ChkTime = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;
						App.timercount = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;
					}

                    ChkQueue = ReserveQController.getInstance().reserveQueue(SessionModel.bookingQ);
					if (!ChkQueue.isSuccess)
					{
						DisplayAlert("", ChkQueue.getDescription(), "Close");
						TimesQ.Text = "00:00:00";
						App.timercheck = false;
						
					}
					else
					{
						if (ChkQueue.id == 58)
						{
                            Navigation.PushAsync(new RatingPage());
							TimesQ.Text = "00:00:00";
							App.timercheck = false;
							
						}
						else
						{
                            if (SessionModel.bookingQ != null)
                            {
                                DetailQ.Text = String.Format(ChkQueue.getDescription(), SessionModel.bookingQ.queueBefore);
                            }
						}
					}
				}
                return App.timercheck;
			});

        }

		public void OnImageHomePage(object sender, System.EventArgs args)
		{
			Navigation.InsertPageBefore(new MainPage(), this);
			Navigation.PopAsync();
		}

		public void OnImageDelete(object sender, System.EventArgs args)
		{
            if (SessionModel.bookingQ != null)
            {
                if (!String.IsNullOrEmpty(SessionModel.bookingQ.queueNumber))
				{
					UIReturn uiReturn = ReserveQController.getInstance().cancelQueue(SessionModel.bookingQ);
					if (uiReturn.isSuccess)
					{
						Navigation.PushAsync(new MainPage());
						App.timercheck = false;
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
