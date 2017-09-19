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

		public MainPage()
		{
			InitializeComponent();

			if (SessionModel.bookingQ != null)
			{
				if (SessionModel.bookingQ.queueNumber != 0)
				{
					NumberQ.Text = SessionModel.bookingQ.queueNumber.ToString();
					timerStart();
				}
			}
		}

		public void timerStart()
		{
			if (QueuePage.timercount == 0)
			{
				timercheck = false;
			}
			else
			{
				Device.StartTimer(new TimeSpan(0, 0, 1), () =>
					{
						if (timercheck == true && QueuePage.timercount != 0)
						{
							QueuePage.timercount--;
							TimeSpan time = TimeSpan.FromSeconds(QueuePage.timercount);

							TimesQ.Text = time.ToString(@"hh\:mm\:ss");
						//setLabel(MainPage.timercount.ToString());
						return true; // runs again, or false to stop
					}
						else
						{
							return false;
						}
					});
			}
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
            //Navigation.PushAsync(new SearchPage());
			timercheck = false;
			Navigation.InsertPageBefore(new SearchPage(), this);
			Navigation.PopAsync();
        }

        public void OnImageQRcodePage(object sender, System.EventArgs args)
        {
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
                    await DisplayAlert("Scanned Barcode", result.Text, "OK");
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

		public void OnImageSummaryPage(object sender, System.EventArgs args)
		{
			if (SessionModel.bookingQ != null)
			{
				if (SessionModel.bookingQ.queueNumber != 0)
				{
					//Navigation.PushAsync(new SummaryPage());
					timercheck = false;
					Navigation.InsertPageBefore(new SummaryPage(), this);
					Navigation.PopAsync();
				}
			}
		}
    }
}
