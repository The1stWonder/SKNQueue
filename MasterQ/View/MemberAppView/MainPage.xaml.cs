using System;
using System.Collections.Generic;
using ZXing.Net.Mobile.Forms;
using System.Threading.Tasks;
using MasterQ.Helpers;

using Xamarin.Forms;
using ZXing.Mobile;

namespace MasterQ
{
	public partial class MainPage : ContentPage
	{
		int ChkTime = 0;
		int ChkTime2 = 0;
        bool CountstartMain = true;

		public MainPage()
		{
			InitializeComponent();

            if (SessionModel.bookingQ != null)
            {
                if (!String.IsNullOrEmpty(SessionModel.bookingQ.queueNumber))
                {
                    if (App.fristtime)
                    {
                        NumberQ.Text = SessionModel.bookingQ.queueNumber;
                        App.timercheck = true;
                        App.timerStart();
                    }

                    if (SessionModel.bookingQ.queueNumber != "0")
                    {
                        Process(); 
                    }
                }
            }
		}

        public void Process()
        {
            CountstartMain = true;
            Service s = new Service();
            s.serviceID = SessionModel.bookingQ.serviceID;
            s.branchID = SessionModel.bookingQ.branchID;
            UIReturn ChkQueue = ReserveQController.getInstance().reserveQueue(SessionModel.bookingQ);
            if (App.fristtime)
            {
                App.fristtime = false;
                ChkTime = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;
                App.timercount = ChkTime;
                if (App.timercount < 900)
                {
                    App.Massage15 = false;
                }

            }

            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                if (SessionModel.bookingQ != null)
                {
                    if (CountstartMain == true)
                    {
                        App.Recount = App.Recount + 1;
                    }
                    TimeSpan time = TimeSpan.FromSeconds(App.timercount);

                    TimesQ.Text = time.ToString(@"hh\:mm\:ss");

                    if (App.timercount <= 900 && App.Massage15 == true)
                    {
                        DependencyService.Get<IFNotification>().SendNotification("คิวเลขที่ " + SessionModel.bookingQ.queueNumber, "อีก 15 นาทีจะถึงคิวของคุณ");
                        App.Massage15 = false;
                    }

                    if (App.timercount <= 300 && App.Massage5 == true)
                    {
                        DependencyService.Get<IFNotification>().SendNotification("คิวเลขที่ " + SessionModel.bookingQ.queueNumber, "อีก 5 นาทีจะถึงคิวของคุณ");
                        App.Massage5 = false;
                    }

                    if (App.timercount == 0 && App.Massage0 == true)
                    {
                        DependencyService.Get<IFNotification>().SendNotification("คิวเลขที่ " + SessionModel.bookingQ.queueNumber, String.Format(ChkQueue.getDescription(), SessionModel.bookingQ.queueBefore));
                        App.Massage0 = false;
                    }

                    if (!ChkQueue.isSuccess)
                    {
                        DisplayAlert("", ChkQueue.getDescription(), "Close");
                        TimesQ.Text = "00:00:00";
                        App.timercheck = false;
                    }
                    else
                    {
                        DetailQ.Text = String.Format(ChkQueue.getDescription(), SessionModel.bookingQ.queueBefore);
                        NumberQ.Text = SessionModel.bookingQ.queueNumber;

                        if (App.timercount == 0)
                        {
                            TimesQ.Text = "00:00:00";
                        }
                    }

                    if (App.Recount == 10)
                    {
                        App.Recount = 0;

                        Queue Queue = (Queue)ReserveQController.getInstance().reserveQueue(SessionModel.bookingQ).returnObject;
                        ChkTime2 = SessionModel.bookingQ.estimateTime * 60;
                        if (ChkTime2 < App.timercount)
                        {
                            ChkTime = SessionModel.bookingQ.estimateTime * 60;
                            App.timercount = SessionModel.bookingQ.estimateTime * 60;
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
                                DependencyService.Get<IFNotification>().SendNotification("คิวเลขที่ " + SessionModel.bookingQ.queueNumber, ChkQueue.getDescription());
                                DetailQ.Text = ChkQueue.getDescription();
                                App.timercheck = false;
                                CountstartMain = false;
                                Navigation.PushAsync(new RatingPage());
                                TimesQ.Text = "00:00:00";
                            }
                            else if (ChkQueue.id == 63)
                            {
                                DependencyService.Get<IFNotification>().SendNotification("คิวเลขที่ " + SessionModel.bookingQ.queueNumber, ChkQueue.getDescription());
                                SessionModel.clearQueue();
                                DetailQ.Text = ChkQueue.getDescription();
                                NumberQ.Text = "-";
                                App.timercheck = false;
                                CountstartMain = false;
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

		public void OnImageMainProfilePage(object sender, System.EventArgs args)
		{
            CountstartMain = false;
            Navigation.InsertPageBefore(new EditProfilePage(), this);
			Navigation.PopAsync();
		}

        public void OnImageMainExit(object sender, System.EventArgs args)
        {
            UIReturn Chklogout = LoginController.getInstance().LogutMember();
            if (!Chklogout.isSuccess)
            {
                App.timercheck = false;
                CountstartMain = false;
                DisplayAlert("", Chklogout.getDescription(), "Close");
            }
            else
            {
                App.timercheck = false;
                CountstartMain = false;
                //SessionModel.bookingQ = null;
                Navigation.InsertPageBefore(new LoginPage(), this);
                Navigation.PopAsync();
            }
        }

        public void OnImageHistoryPage(object sender, System.EventArgs args)
        {
            CountstartMain = false;
			Navigation.InsertPageBefore(new HistoryPage(), this);
			Navigation.PopAsync();
        }

        public void OnImageQueuePage(object sender, System.EventArgs args)
        {
            if (SessionModel.bookingQ == null || String.IsNullOrEmpty(SessionModel.bookingQ.queueNumber))
            {
                CountstartMain = false;
                Navigation.InsertPageBefore(new SearchPage(), this);
                Navigation.PopAsync();
            }
        }

        public void OnImageQRcodePage(object sender, System.EventArgs args)
        {
            if (SessionModel.bookingQ == null || String.IsNullOrEmpty(SessionModel.bookingQ.queueNumber))
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
            SelectingPage();
		}

        public void OnLabalMainProfilePage2(object sender, System.EventArgs args)
        {
            SelectingPage();
        }

        public void SelectingPage()
        {
            if (SessionModel.bookingQ != null)
            {
                if (!String.IsNullOrEmpty(SessionModel.bookingQ.queueNumber))
                {
                    CountstartMain = false;
                    Navigation.InsertPageBefore(new QueuePage(), this);
                    Navigation.PopAsync();
                }
                else
                {
                    CountstartMain = false;
                    Navigation.InsertPageBefore(new SearchPage(), this);
                    Navigation.PopAsync();
                }
            }
            else
            {
                CountstartMain = false;
                Navigation.InsertPageBefore(new SearchPage(), this);
                Navigation.PopAsync();
            }
        }
    }
}
