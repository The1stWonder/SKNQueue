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
					Process();
				}
			}
		}

        public void Process()
        {
            Service s = new Service();
            s.serviceID = SessionModel.bookingQ.serviceID;
            s.branchID = SessionModel.bookingQ.branchID;
            UIReturn ChkQueue = ReserveQController.getInstance().reserveQueue(s);

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
                    DetailQ.Text = String.Format(ChkQueue.getDescription(), SessionModel.bookingQ.queueBefore);
                    if (App.timercount == 0)
                    {
                        TimesQ.Text = "00:00:00";
                    }
                }

                if (App.Recount == 10)
                {
                    App.Recount = 0;

                    Queue Queue = (Queue)ReserveQController.getInstance().reserveQueue(s).returnObject;
                    ChkTime2 = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;
                    if (ChkTime != ChkTime2)
                    {
                        ChkTime = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;
                        App.timercount = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;
                    }

                    ChkQueue = ReserveQController.getInstance().reserveQueue(s);
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

		public void OnImageMainProfilePage(object sender, System.EventArgs args)
		{
			Navigation.InsertPageBefore(new MainProfilePage(), this);
			Navigation.PopAsync();
		}

        public void OnImageHistoryPage(object sender, System.EventArgs args)
        {
			Navigation.InsertPageBefore(new HistoryPage(), this);
			Navigation.PopAsync();
        }

        public void OnImageQueuePage(object sender, System.EventArgs args)
        {
            if (SessionModel.bookingQ.queueNumber == 0)
            {
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
                        await Navigation.PushAsync(new ServicePage(BranchID));
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
                    Navigation.InsertPageBefore(new SummaryPage(), this);
                    Navigation.PopAsync();
                }
                else
                {
                    Navigation.InsertPageBefore(new SearchPage(), this);
					Navigation.PopAsync();
                }
			}
			else
			{
				Navigation.InsertPageBefore(new SearchPage(), this);
				Navigation.PopAsync();
			}
		}
    }
}
