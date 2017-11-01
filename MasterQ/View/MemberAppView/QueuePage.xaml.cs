using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class QueuePage : ContentPage
	{
        int ChkTime = 0;
        int ChkTime2 = 0;
        bool CountstartQ = true;

        public QueuePage()
		{
			InitializeComponent();

            //var ServiceName = SessionModel.getServiceFromBookingQ();
            //ServiceQ.Text = "บริการ : " + ServiceName.serviceName;

            App.timercheck = true;
            NumberQ.Text = SessionModel.bookingQ.queueNumber.ToString();
            Process();
		}

        public void Process()
        {
            Service s = new Service();
            s.serviceID = SessionModel.bookingQ.serviceID;
            s.branchID = SessionModel.bookingQ.branchID;
            UIReturn ChkQueue = ReserveQController.getInstance().reserveQueue(SessionModel.bookingQ);
            if (App.fristtime)
            {
                ChkTime = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;
                App.fristtime = false;
                App.timercount = ChkTime;
            }

            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                if (SessionModel.bookingQ != null)
                {
                    if (CountstartQ == true)
                    {
                        App.Recount = App.Recount + 1;
                    }

                    TimeSpan time = TimeSpan.FromSeconds(App.timercount);

                    TimesQ.Text = time.ToString(@"hh\:mm\:ss");


                    if (!ChkQueue.isSuccess)
                    {
                        App.timercheck = false;
                        DisplayAlert("", ChkQueue.getDescription(), "Close");
                        TimesQ.Text = "00:00:00";
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
                        if (ChkTime2 < App.timercount)
                        {
                            ChkTime = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;
                            App.timercount = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;
                        }

                        ChkQueue = ReserveQController.getInstance().reserveQueue(SessionModel.bookingQ);
                        if (!ChkQueue.isSuccess)
                        {
                            App.timercheck = false;
                            DisplayAlert("", ChkQueue.getDescription(), "Close");
                            TimesQ.Text = "00:00:00";
                        }
                        else
                        {
                            if (ChkQueue.id == 58)
                            {
                                App.timercheck = false;
                                CountstartQ = false;
                                Navigation.PushAsync(new RatingPage());
                                TimesQ.Text = "00:00:00";
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
                }
                return App.timercheck;
            });
        }

		public void OnImageHomePage(object sender, System.EventArgs args)
		{
            CountstartQ = false;
			Navigation.InsertPageBefore(new MainPage(), this);
			Navigation.PopAsync();
		}

		public void OnImageDelete(object sender, System.EventArgs args)
		{
			if (SessionModel.bookingQ != null)
			{
				UIReturn uiReturn = ReserveQController.getInstance().cancelQueue(SessionModel.bookingQ);
				if (uiReturn.isSuccess)
				{
                    App.fristtime = true;
                    App.timercheck = false;
                    CountstartQ = false;
					Navigation.PushAsync(new MainPage());
				}
				else
				{
                    App.timercheck = false;
                    CountstartQ = false;
					DisplayAlert("", uiReturn.getDescription(), "Close");
				}
			}
		}
	}
}
