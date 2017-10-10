using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class QueuePage : ContentPage
	{
		bool timercheck = true;
		public static int timercount;
        int Recount = 0;
        int ChkTime = 0;
        int ChkTime2 = 0;

        public QueuePage(Service selectedService)
		{
			InitializeComponent();
            //reserveQ(selectedService);

			if (SessionModel.bookingQ != null)
			{
				if (SessionModel.bookingQ.queueNumber != 0)
				{
                    var ServiceName = SessionModel.getService(SessionModel.bookingQ.serviceID);
                    ServiceQ.Text = "บริการ : " + ServiceName.serviceName;
					NumberQ.Text = SessionModel.bookingQ.queueNumber.ToString();
					timercount = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;
                    ChkTime = timercount;
                    timerStart();
				}
			}
		}

        public void timerStart()
        {
            //if (timercount.ToString() == "0")
            //{
            //	DetailQ.Text = "ถึงคิวคุณแล้ว";
            //	TimesQ.Text = "00:00:00";
            //	timercheck = false;
            //}
            //else
            //{
            //	Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            //	{
            //                 Recount = Recount + 1;
            //                 if (timercheck == true && timercount != 0)
            //                 {
            //                     // do something every 60 seconds
            //                     //timercheck = true;
            //                     timercount--;
            //                     TimeSpan time = TimeSpan.FromSeconds(timercount);

            //                     TimesQ.Text = time.ToString(@"hh\:mm\:ss");

            //                     if (timercount.ToString() == "0")
            //                     {
            //                         DetailQ.Text = "ถึงคิวคุณแล้ว";
            //                         TimesQ.Text = "00:00:00";
            //                         timercheck = false;
            //                     }
            //                     else
            //                     {
            //                         if (SessionModel.bookingQ != null)
            //                         {
            //                             DetailQ.Text = "คิวก่อนหน้า " + SessionModel.bookingQ.queueBefore + " คิว " + " โปรดรอ";
            //                         }
            //                     }

            //                     if (Recount == 10)
            //                     {
            //                         Recount = 0;
            //                         Service s = new Service();
            //                         s.serviceID = SessionModel.bookingQ.serviceID;
            //                         s.branchID = SessionModel.bookingQ.branchID;
            //                         Queue Queue = (Queue)ReserveQController.getInstance().reserveQueue(s).returnObject;
            //                         ChkTime2 = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;
            //                         if (ChkTime != ChkTime2)
            //                         {
            //                             ChkTime = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;
            //                             timercount = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;
            //                         }
            //                     }
            //                 }
            //                     return timercheck;

            //	});
            //}

            Service s = new Service();
            s.serviceID = SessionModel.bookingQ.serviceID;
            s.branchID = SessionModel.bookingQ.branchID;
            UIReturn ChkQueue = ReserveQController.getInstance().reserveQueue(s);

            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                Recount = Recount + 1;
                TimeSpan time = TimeSpan.FromSeconds(timercount);

                TimesQ.Text = time.ToString(@"hh\:mm\:ss");

                if (!ChkQueue.isSuccess)
                {
                    DisplayAlert("", ChkQueue.getDescription(), "Close");
                    TimesQ.Text = "00:00:00";
                    timercheck = false;
                    return false;
                }
                else
                {
                    DetailQ.Text = String.Format(ChkQueue.descriptionEN, SessionModel.bookingQ.queueBefore);
                    if (timercount != 0)
                    {
                        if (timercheck == true)
                        {
                            timercount--;
                        }
                    }
                    else
                    {
                        timercheck = false;
                        TimesQ.Text = "00:00:00";
                    }
                }

                if (Recount == 10)
                {
                    Recount = 0;

                    Queue Queue = (Queue)ReserveQController.getInstance().reserveQueue(s).returnObject;
                    ChkTime2 = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;
                    if (ChkTime != ChkTime2)
                    {
                        ChkTime = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;
                        timercount = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;
                    }

                    ChkQueue = ReserveQController.getInstance().reserveQueue(s);
                    if (!ChkQueue.isSuccess)
                    {
                        DisplayAlert("", ChkQueue.getDescription(), "Close");
                        TimesQ.Text = "00:00:00";
                        timercheck = false;
                        return false;
                    }
                    else
                    {
                        if (ChkQueue.id == 58)
                        {
                            TimesQ.Text = "00:00:00";
                            timercheck = false;
                            return timercheck;
                        }
                        else
                        {
                            DetailQ.Text = String.Format(ChkQueue.descriptionEN, SessionModel.bookingQ.queueBefore);
                        }
                    }
                }
                return timercheck;
            });
        }

		private void reserveQ(Service selectedService)
		{
			Service s = new Service();
            s.serviceID = selectedService.serviceID;
            s.branchID = selectedService.branchID;
            Queue Queue = (Queue)ReserveQController.getInstance().reserveQueue(s).returnObject;
		}

		public void OnImageHomePage(object sender, System.EventArgs args)
		{
			timercheck = false;
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
					//DisplayAlert("Click", uiReturn.getDescription(), "Close");
					Navigation.PushAsync(new MainPage());
					timercheck = false;
				}
				else
				{
					DisplayAlert("", uiReturn.descriptionEN, "Close");
				}
			}
		}


	}
}
