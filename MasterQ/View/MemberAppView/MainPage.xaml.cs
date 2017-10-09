using System;
using System.Collections.Generic;
using ZXing.Net.Mobile.Forms;
using System.Threading.Tasks;


using Xamarin.Forms;
using ZXing.Mobile;

namespace MasterQ
{
	public partial class MainPage : ContentPage
	{
		bool timercheck = true;
        bool timercheck2 = true;
		int Recount = 0;
		int ChkTime = 0;
		int ChkTime2 = 0;

		public MainPage()
		{
			InitializeComponent();

			if (SessionModel.bookingQ != null)
			{
				if (SessionModel.bookingQ.queueNumber != 0)
				{
					NumberQ.Text = SessionModel.bookingQ.queueNumber.ToString();
                    ChkTime = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;
					timerStart();
				}
			}
		}

        public void timerStart()
        {
            Service s = new Service();
            s.serviceID = SessionModel.bookingQ.serviceID;
            s.branchID = SessionModel.bookingQ.branchID;
            UIReturn ChkQueue = ReserveQController.getInstance().reserveQueue(s);

            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                Recount = Recount + 1;
                TimeSpan time = TimeSpan.FromSeconds(QueuePage.timercount);

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
                    if (QueuePage.timercount != 0)
                    {
                        if (timercheck == true)
                        {
							QueuePage.timercount--;
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
                        QueuePage.timercount = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;
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
							return false;
                        }
                        else
                        {
                            DetailQ.Text = String.Format(ChkQueue.descriptionEN, SessionModel.bookingQ.queueBefore);
                        }
					}
                }
                return true;
            });
        }

		public void OnImageMainProfilePage(object sender, System.EventArgs args)
		{
			//Navigation.PushAsync(new MainProfilePage());
			timercheck = false;
			Navigation.InsertPageBefore(new MainProfilePage(), this);
			Navigation.PopAsync();
		}
 	

        public void OnImageHistoryPage(object sender, System.EventArgs args)
        {
            //Navigation.PushAsync(new HistoryPage());
			timercheck = false;
			Navigation.InsertPageBefore(new HistoryPage(), this);
			Navigation.PopAsync();
        }

        public void OnImageQueuePage(object sender, System.EventArgs args)
        {
            if (SessionModel.bookingQ.queueNumber == 0)
            {
                //Navigation.PushAsync(new SearchPage());
                timercheck = false;
                Navigation.InsertPageBefore(new SearchPage(), this);
                Navigation.PopAsync();
            }
        }

        public void OnImageQRcodePage(object sender, System.EventArgs args)
        {
            if (SessionModel.bookingQ.queueNumber == 0)
            {
                Branch b = new Branch();
                Branch BranchID = new Branch();
                timercheck = false;
                var scanPage = new ZXingScannerPage();
                // Navigate to our scanner page
                Navigation.PushAsync(scanPage);

                scanPage.OnScanResult += (result) =>
                {
                // Stop scanning
                scanPage.IsScanning = false;

                // Pop the page and show the result
                Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Navigation.PopAsync();
                    //await DisplayAlert("Scanned Barcode", result.Text, "OK");
                    b.branchID = result.Text;
                        UIReturn uiR = SearchController.getInstance().getBranchDetail(b);
                        BranchID = (Branch)uiR.returnObject;
                        Navigation.PushAsync(new ServicePage(BranchID));
                    });
                };

                var options = new MobileBarcodeScanningOptions
                {
                    AutoRotate = false,
                    UseFrontCameraIfAvailable = true,
                    TryHarder = true,
                    PossibleFormats = new List<ZXing.BarcodeFormat>
        {
           ZXing.BarcodeFormat.EAN_8, ZXing.BarcodeFormat.EAN_13
        }
                };

                //add options and customize page
                scanPage = new ZXingScannerPage(options)
                {
                    DefaultOverlayTopText = "Align the barcode within the frame",
                    DefaultOverlayBottomText = string.Empty,
                    DefaultOverlayShowFlashButton = true
                };
            }
        }

		public void OnImageSummaryPage(object sender, System.EventArgs args)
		{
			if (SessionModel.bookingQ != null)
			{
				if (SessionModel.bookingQ.queueNumber != 0)
				{
                    if (timercheck2 == true)
                    {
                        timercheck = false;
                        Navigation.InsertPageBefore(new SummaryPage(), this);
                        Navigation.PopAsync();
                    }
                    else
                    {
						timercheck = false;
                        Navigation.InsertPageBefore(new RatingPage(), this);
						Navigation.PopAsync();
                    }
				}
                else
                {
					timercheck = false;
                    Navigation.InsertPageBefore(new SearchPage(), this);
					Navigation.PopAsync();
                }
			}
			else
			{
				timercheck = false;
				Navigation.InsertPageBefore(new SearchPage(), this);
				Navigation.PopAsync();
			}
		}
    }
}
