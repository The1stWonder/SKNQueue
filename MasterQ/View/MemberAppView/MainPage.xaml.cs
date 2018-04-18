using System;
using System.Collections.Generic;
using ZXing.Net.Mobile.Forms;
using System.Threading.Tasks;
using MasterQ.Helpers;
using Plugin.Connectivity;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Mobile;

namespace MasterQ
{
    [XamlCompilation(XamlCompilationOptions.Compile)] //alexpook link all
	public partial class MainPage : ContentPage
	{
		int ChkTime = 0;
		int ChkTime2 = 0;
        bool CountstartMain = true;

		public MainPage()
		{
			InitializeComponent();
            btn_cancel.IsVisible = false;
            btn_cancel2.IsVisible = false;
            b_booking1.IsVisible = true;
            b_booking2.IsVisible = false;
            b_qr1.IsVisible = true;
            b_qr2.IsVisible = false;

            if (CrossConnectivity.Current.IsConnected)
            {
                if (App.Thai == true)
                {
                    LanguageThai.IsVisible = true;
                    LanguageThai.IsEnabled = true;

                    LanguageEng.IsVisible = false;
                    LanguageEng.IsEnabled = false;
                }
                else
                {
                    LanguageThai.IsVisible = false;
                    LanguageThai.IsEnabled = false;

                    LanguageEng.IsVisible = true;
                    LanguageEng.IsEnabled = true;
                }

                Main_History.Text = Utils.getLabel(LabelConstants.MAIN_PAGE_HISTORY);
                Main_Booking.Text = Utils.getLabel(LabelConstants.MAIN_PAGE_BOOKING);
                Main_QR.Text = Utils.getLabel(LabelConstants.MAIN_PAGE_QR);
                YourQ.Text = Utils.getLabel(LabelConstants.MAIN_PAGE_YOURQUEUE);
                AllQ.Text = Utils.getLabel(LabelConstants.MAIN_PAGE_ALLQUEUE);
                WaitTime.Text = Utils.getLabel(LabelConstants.MAIN_PAGE_WATETIME);


                if (SessionModel.loginMember != null)
                {
                    UserNames.Text = Utils.getLabel(LabelConstants.MAIN_PAGE_HELLO) + " " + SessionModel.loginMember.firstName + "  " + SessionModel.loginMember.lastName;
                }

                if (SessionModel.bookingQ != null)
                {
                    if (!String.IsNullOrEmpty(SessionModel.bookingQ.queueNumber))
                    {
                        if (App.fristtime)
                        {
                            NumberQ.Text = SessionModel.bookingQ.queueNumber;
                            NumberQ2.Text = SessionModel.bookingQ.queueBefore.ToString();
                            App.timercheck = true;
                            App.timerStart();
                            App.RePage = false;
                        }

                        if (SessionModel.bookingQ.queueNumber != "0" || SessionModel.bookingQ.queueNumber != "" || SessionModel.bookingQ.queueNumber != null)
                        {
                            //App.timercheck = true;
                            //App.timerStart();

                            if (App.Thai == true)
                            {
                                btn_cancel2.IsVisible = true;
                            }
                            else
                            {
                                btn_cancel.IsVisible = true;
                            }

                            b_booking1.IsVisible = false;
                            b_booking2.IsVisible = true;
                            b_qr1.IsVisible = false;
                            b_qr2.IsVisible = true;

                            Process();
                            App.RePage = false;
                        }
                    }
                }
            }
            else
            {
                App.RePagelogin = true;
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
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

            if (App.RePage == false)
            {
                Device.StartTimer(new TimeSpan(0, 0, 1), () =>
                {
                    if (SessionModel.bookingQ != null)
                    {
                        if (CrossConnectivity.Current.IsConnected)
                        {
                            if (CountstartMain == true)
                            {
                                App.Recount = App.Recount + 1;
                            }
                            TimeSpan time = TimeSpan.FromSeconds(App.timercount);

                            TimesQ.Text = time.ToString(@"hh\:mm\:ss");
                            if (App.timercount == 0)
                            {
                                App.Massage15 = false;
                                App.Massage5 = false;
                            }

                            if (App.timercount <= 900 && App.Massage15 == true)
                            {
                                DependencyService.Get<IFNotification>().SendNotification(Utils.getLabel(LabelConstants.MAIN_PAGE_YOURQUEUE) + " " + SessionModel.bookingQ.queueNumber, Utils.getLabel(LabelConstants.MAIN_PAGE_NOTIFICATION1));
                                App.Massage15 = false;
                            }

                            if (App.timercount == 300 && App.Massage5 == true)
                            {
                                DependencyService.Get<IFNotification>().SendNotification(Utils.getLabel(LabelConstants.MAIN_PAGE_YOURQUEUE) + " " + SessionModel.bookingQ.queueNumber, Utils.getLabel(LabelConstants.MAIN_PAGE_NOTIFICATION2));
                                App.Massage5 = false;
                            }

                            if (App.timercount == 0 && App.Massage0 == true)
                            {
                                DependencyService.Get<IFNotification>().SendNotification(Utils.getLabel(LabelConstants.MAIN_PAGE_YOURQUEUE) + " " + SessionModel.bookingQ.queueNumber, String.Format(ChkQueue.getDescription(), SessionModel.bookingQ.queueBefore));
                                App.Massage0 = false;
                            }

                            if (!ChkQueue.isSuccess)
                            {
                                DisplayAlert(App.AppicationName, ChkQueue.getDescription(), "Close");
                                TimesQ.Text = "00:00:00";
                                App.timercheck = false;
                            }
                            else
                            {
                                DetailQ.Text = String.Format(ChkQueue.getDescription(), SessionModel.bookingQ.queueBefore);
                                NumberQ.Text = SessionModel.bookingQ.queueNumber;
                                NumberQ2.Text = SessionModel.bookingQ.queueBefore.ToString();
                                if (SessionModel.loginMember != null)
                                {
                                    UserNames.Text = Utils.getLabel(LabelConstants.MAIN_PAGE_HELLO) + " " + SessionModel.loginMember.firstName + "  " + SessionModel.loginMember.lastName;
                                }

                                Main_History.Text = Utils.getLabel(LabelConstants.MAIN_PAGE_HISTORY);
                                Main_Booking.Text = Utils.getLabel(LabelConstants.MAIN_PAGE_BOOKING);
                                Main_QR.Text = Utils.getLabel(LabelConstants.MAIN_PAGE_QR);
                                YourQ.Text = Utils.getLabel(LabelConstants.MAIN_PAGE_YOURQUEUE);
                                AllQ.Text = Utils.getLabel(LabelConstants.MAIN_PAGE_ALLQUEUE);
                                WaitTime.Text = Utils.getLabel(LabelConstants.MAIN_PAGE_WATETIME);

                                if (App.Thai == true)
                                {
                                    btn_cancel.IsVisible = false;
                                    btn_cancel2.IsVisible = true;
                                }
                                else
                                {
                                    btn_cancel.IsVisible = true;
                                    btn_cancel2.IsVisible = false;
                                }

                                if (App.timercount == 0)
                                {
                                    TimesQ.Text = "00:00:00";
                                }
                            }

                            if (App.Recount == App.TimeReface)
                            {
                                App.Recount = 0;

                                Queue Queue = (Queue)ReserveQController.getInstance().reserveQueue(SessionModel.bookingQ).returnObject;
                                ChkTime2 = SessionModel.bookingQ.estimateTime * 60;
                                if (ChkTime2 < App.timercount)
                                {
                                    ChkTime = SessionModel.bookingQ.estimateTime * 60;
                                    App.timercount = SessionModel.bookingQ.estimateTime * 60;
                                    NumberQ2.Text = SessionModel.bookingQ.queueBefore.ToString();
                                }

                                ChkQueue = ReserveQController.getInstance().reserveQueue(SessionModel.bookingQ);
                                if (!ChkQueue.isSuccess)
                                {
                                    App.timercheck = false;
                                    DisplayAlert(App.AppicationName, ChkQueue.getDescription(), "Close");
                                    TimesQ.Text = "00:00:00";
                                }
                                else
                                {
                                    if (ChkQueue.id == 58)
                                    {
                                        DependencyService.Get<IFNotification>().SendNotification(Utils.getLabel(LabelConstants.MAIN_PAGE_YOURQUEUE) + " " + SessionModel.bookingQ.queueNumber, ChkQueue.getDescription());
                                        DetailQ.Text = ChkQueue.getDescription();
                                        App.timercheck = false;
                                        CountstartMain = false;
                                        App.fristtime = true;
                                        Navigation.PushAsync(new RatingPage());
                                        TimesQ.Text = "00:00:00";
                                        b_booking1.IsVisible = true;
                                        b_booking2.IsVisible = false;
                                        b_qr1.IsVisible = true;
                                        b_qr2.IsVisible = false;
                                    }
                                    else if (ChkQueue.id == 63)
                                    {
                                        DependencyService.Get<IFNotification>().SendNotification(Utils.getLabel(LabelConstants.MAIN_PAGE_YOURQUEUE) + " " + SessionModel.bookingQ.queueNumber, ChkQueue.getDescription());
                                        SessionModel.clearQueue();
                                        DetailQ.Text = ChkQueue.getDescription();
                                        NumberQ.Text = "-";
                                        App.timercheck = false;
                                        CountstartMain = false;
                                        App.fristtime = true;
                                        TimesQ.Text = "00:00:00";
                                        b_booking1.IsVisible = true;
                                        b_booking2.IsVisible = false;
                                        b_qr1.IsVisible = true;
                                        b_qr2.IsVisible = false;
                                        btn_cancel.IsVisible = false;
                                        btn_cancel2.IsVisible = false;
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
                    }
                    return App.timercheck;
                });
            }
        }

		public void OnImageMainProfilePage(object sender, System.EventArgs args)
		{
            if (CrossConnectivity.Current.IsConnected)
            {
                if (App.RePagemain == true)
                {
                    App.RePagemain= false;
                    Navigation.PushAsync(new MainPage());
                }
                else
                {
                    CountstartMain = false;
                    Navigation.InsertPageBefore(new EditProfilePage(), this);
                    Navigation.PopAsync();
                }
            }
            else
            {
                App.RePagemain = true;
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
		}

        async void OnImageMainExit(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                if (App.RePagemain == true)
                {
                    App.RePagemain = false;
                    await Navigation.PushAsync(new MainPage());
                }
                else
                {
                    var answer = await DisplayAlert(Utils.getLabel(LabelConstants.MAIN_PAGE_LOGOUT), Utils.getLabel(LabelConstants.MAIN_PAGE_CONFIRMLOGOUT), "Yes", "No");
                    if (answer == true)
                    {
                        UIReturn Chklogout = LoginController.getInstance().LogutMember();
                        if (!Chklogout.isSuccess)
                        {
                            App.timercheck = false;
                            CountstartMain = false;
                            await DisplayAlert(App.AppicationName, Chklogout.getDescription(), "Close");
                        }
                        else
                        {
                            App.timercheck = false;
                            CountstartMain = false;
                            //SessionModel.bookingQ = null;
                            Navigation.InsertPageBefore(new LoginPage(), this);
                            await Navigation.PopAsync();
                        }
                    }
                }
            }
            else
            {
                App.RePagemain = false;
                await DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        public void OnImageHistoryPage(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                if (App.RePagemain == true)
                {
                    App.RePagemain = false;
                    Navigation.PushAsync(new MainPage());
                }
                else
                {
                    Image image = sender as Image;
                    if (image != null)
                    {
                        string source = image.Source as FileImageSource;
                        if (String.Equals(source, "btn_history.png"))
                        {
                            image.Source = "btn_history_click.png";
                        }
                    }

                    CountstartMain = false;
                    Navigation.InsertPageBefore(new HistoryPage(), this);
                    Navigation.PopAsync();
                }
            }
            else
            {
                App.RePagemain = true;
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        public void OnImageQueuePage(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                if (App.RePagemain == true)
                {
                    App.RePagemain = false;
                    Navigation.PushAsync(new MainPage());
                }
                else
                {
                    if (SessionModel.bookingQ == null || String.IsNullOrEmpty(SessionModel.bookingQ.queueNumber))
                    {
                        Image image = sender as Image;
                        if (image != null)
                        {
                            string source = image.Source as FileImageSource;
                            if (String.Equals(source, "btn_booking.png"))
                            {
                                image.Source = "btn_booking_click.png";
                            }
                        }

                        App.TextSearch = "";
                        CountstartMain = false;
                        Navigation.InsertPageBefore(new SearchPage(), this);
                        Navigation.PopAsync();
                    }
                    else
                    {
                        DisplayAlert(App.AppicationName, Utils.getLabel(LabelConstants.MAIN_PAGE_QBLOCK), "Close");
                    }
                }
            }
            else
            {
                App.RePagemain = false;
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        public void OnImageQueuePage2(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                if (App.RePagemain == true)
                {
                    App.RePagemain = false;
                    Navigation.PushAsync(new MainPage());
                }
                else
                {
                    if (SessionModel.bookingQ == null || String.IsNullOrEmpty(SessionModel.bookingQ.queueNumber))
                    {
                        Image image = sender as Image;
                        if (image != null)
                        {
                            string source = image.Source as FileImageSource;
                            if (String.Equals(source, "btn_booking3.png"))
                            {
                                image.Source = "btn_booking_click.png";
                            }
                        }

                        App.TextSearch = "";
                        CountstartMain = false;
                        Navigation.InsertPageBefore(new SearchPage(), this);
                        Navigation.PopAsync();
                    }
                    else
                    {
                        DisplayAlert(App.AppicationName, Utils.getLabel(LabelConstants.MAIN_PAGE_QBLOCK), "Close");
                    }
                }
            }
            else
            {
                App.RePagemain = false;
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        public void OnImageQRcodePage(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                if (App.RePagemain == true)
                {
                    App.RePagemain = false;
                    Navigation.PushAsync(new MainPage());
                }
                else
                {
                    //QRCode();

                    if (CrossConnectivity.Current.IsConnected)
                    {
                        App.TextSearch = "";
                        bool CheckQR = false;
                        if (SessionModel.bookingQ == null || String.IsNullOrEmpty(SessionModel.bookingQ.queueNumber))
                        {
                            Branch b = new Branch();
                            Branch BranchID = new Branch();
                            double BranchNumber;
                            var scanPage = new ZXingScannerPage();
                            scanPage.Title = "Scan QR Code";
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
                                    try
                                    {
                                        BranchNumber = Convert.ToDouble(result.Text.Substring(1));
                                        CheckQR = true;
                                    }
                                    catch
                                    {
                                        await DisplayAlert(App.AppicationName, Utils.getLabel(LabelConstants.MAIN_PAGE_NOINFORMATION), "Close");
                                        CheckQR = false;
                                    }

                                    if (CheckQR == true)
                                    {
                                        b.branchID = result.Text;
                                        if (b.branchID != null || b.branchID != "")
                                        {
                                            UIReturn uiR = SearchController.getInstance().getBranchDetail(b);
                                            if (!uiR.isSuccess)
                                            {
                                                await DisplayAlert(App.AppicationName, uiR.getDescription(), "Close");
                                            }
                                            else
                                            {
                                                BranchID = (Branch)uiR.returnObject;
                                                await Navigation.PushAsync(new ServicePage(BranchID));
                                                App.SearchID = 2;
                                            }
                                        }
                                    }
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

                                IsAnalyzing = true,
                                DefaultOverlayTopText = "Align the barcode within the frame",
                                DefaultOverlayBottomText = string.Empty,
                                DefaultOverlayShowFlashButton = true
                            };
                        }
                        else
                        {
                            DisplayAlert(App.AppicationName, Utils.getLabel(LabelConstants.MAIN_PAGE_QBLOCK), "Close");
                        }
                    }
                    else
                    {
                        DisplayAlert(App.AppicationName, App.NoInternet, "Close");
                    }
                }
            }
            else
            {
                App.RePagemain = false;
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }  
        }

        public void OnImageQRcodePage2(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                if (App.RePagemain == true)
                {
                    App.RePagemain = false;
                    Navigation.PushAsync(new MainPage());
                }
                else
                {
                    //QRCode();

                    if (CrossConnectivity.Current.IsConnected)
                    {
                        App.TextSearch = "";
                        bool CheckQR = false;
                        if (SessionModel.bookingQ == null || String.IsNullOrEmpty(SessionModel.bookingQ.queueNumber))
                        {
                            Branch b = new Branch();
                            Branch BranchID = new Branch();
                            double BranchNumber;
                            var scanPage = new ZXingScannerPage();
                            scanPage.Title = "Scan QR Code";
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
                                    try
                                    {
                                        BranchNumber = Convert.ToDouble(result.Text.Substring(1));
                                        CheckQR = true;
                                    }
                                    catch
                                    {
                                        await DisplayAlert(App.AppicationName, Utils.getLabel(LabelConstants.MAIN_PAGE_NOINFORMATION), "Close");
                                        CheckQR = false;
                                    }

                                    if (CheckQR == true)
                                    {
                                        b.branchID = result.Text;
                                        if (b.branchID != null || b.branchID != "")
                                        {
                                            UIReturn uiR = SearchController.getInstance().getBranchDetail(b);
                                            if (!uiR.isSuccess)
                                            {
                                                await DisplayAlert(App.AppicationName, uiR.getDescription(), "Close");
                                            }
                                            else
                                            {
                                                BranchID = (Branch)uiR.returnObject;
                                                await Navigation.PushAsync(new ServicePage(BranchID));
                                                App.SearchID = 2;
                                            }
                                        }
                                    }
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

                                IsAnalyzing = true,
                                DefaultOverlayTopText = "Align the barcode within the frame",
                                DefaultOverlayBottomText = string.Empty,
                                DefaultOverlayShowFlashButton = true
                            };
                        }
                        else
                        {
                            DisplayAlert(App.AppicationName, Utils.getLabel(LabelConstants.MAIN_PAGE_QBLOCK), "Close");
                        }
                    }
                    else
                    {
                        DisplayAlert(App.AppicationName, App.NoInternet, "Close");
                    }
                }
            }
            else
            {
                App.RePagemain = false;
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        public void QRCode()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                App.TextSearch = "";
                bool CheckQR = false;
                if (SessionModel.bookingQ == null || String.IsNullOrEmpty(SessionModel.bookingQ.queueNumber))
                {
                    Branch b = new Branch();
                    Branch BranchID = new Branch();
                    double BranchNumber;
                    var scanPage = new ZXingScannerPage();
                    scanPage.Title = "Scan QR Code";
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
                            try
                            {
                                BranchNumber = Convert.ToDouble(result.Text.Substring(1));
                                CheckQR = true;
                            }
                            catch
                            {
                                await DisplayAlert(App.AppicationName, Utils.getLabel(LabelConstants.MAIN_PAGE_NOINFORMATION), "Close");
                                CheckQR = false;
                            }

                            if (CheckQR == true)
                            {
                                b.branchID = result.Text;
                                if (b.branchID != null || b.branchID != "")
                                {
                                    UIReturn uiR = SearchController.getInstance().getBranchDetail(b);
                                    if (!uiR.isSuccess)
                                    {
                                        await DisplayAlert(App.AppicationName, uiR.getDescription(), "Close");
                                    }
                                    else
                                    {
                                        BranchID = (Branch)uiR.returnObject;
                                        await Navigation.PushAsync(new ServicePage(BranchID));
                                        App.SearchID = 2;
                                    }
                                }
                            }
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

                        IsAnalyzing = true,
                        DefaultOverlayTopText = "Align the barcode within the frame",
                        DefaultOverlayBottomText = string.Empty,
                        DefaultOverlayShowFlashButton = true
                    };
                }
                else
                {
                    DisplayAlert(App.AppicationName, Utils.getLabel(LabelConstants.MAIN_PAGE_QBLOCK), "Close");
                }
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

		public void OnImageSummaryPage(object sender, System.EventArgs args)
		{
            if (CrossConnectivity.Current.IsConnected)
            {
                if (App.RePagemain == true)
                {
                    App.RePagemain = false;
                    Navigation.PushAsync(new MainPage());
                }
                else
                {
                    SelectingPage();
                }
            }
            else
            {
                App.RePagemain = false;
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
		}

        public void OnLabalMainProfilePage2(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                if (App.RePagemain == true)
                {
                    App.RePagemain = false;
                    Navigation.PushAsync(new MainPage());
                }
                else
                {
                    SelectingPage();
                }
            }
            else
            {
                App.RePagemain = false;
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        public void SelectingPage()
        {
            if (SessionModel.bookingQ != null)
            {
                if (!String.IsNullOrEmpty(SessionModel.bookingQ.queueNumber))
                {
                    //DisplayAlert("", Utils.getLabel(LabelConstants.MAIN_PAGE_QBLOCK), "Close");
                }
                else
                {
                    
                    App.TextSearch = "";
                    CountstartMain = false;
                    Navigation.InsertPageBefore(new SearchPage(), this);
                    Navigation.PopAsync();
                    App.SearchID = 0;
                }
            }
            else
            {
                App.TextSearch = "";
                CountstartMain = false;
                Navigation.InsertPageBefore(new SearchPage(), this);
                Navigation.PopAsync();
                App.SearchID = 0;
            }
        }

        async void OnImageDelete(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                if (App.RePagemain == true)
                {
                    App.RePagemain = false;
                    await Navigation.PushAsync(new MainPage());
                }
                else
                {
                    App.TextSearch = "";
                    if (SessionModel.bookingQ != null)
                    {
                        var answer = await DisplayAlert(Utils.getLabel(LabelConstants.MAIN_PAGE_CANCEL), Utils.getLabel(LabelConstants.MAIN_PAGE_CONFIRMCANCEL) + " " + SessionModel.bookingQ.queueNumber, "Yes", "No");
                        if (answer == true)
                        {
                            DependencyService.Get<IFNotification>().SendNotification(Utils.getLabel(LabelConstants.MAIN_PAGE_YOURQUEUE) + " " + SessionModel.bookingQ.queueNumber, " " + Utils.getLabel(LabelConstants.MAIN_PAGE_BOOKINGCANCEL));

                            UIReturn uiReturn = ReserveQController.getInstance().cancelQueue(SessionModel.bookingQ);
                            if (uiReturn.isSuccess)
                            {
                                App.fristtime = true;
                                App.timercheck = false;
                                CountstartMain = false;
                                //Navigation.PushAsync(new MainPage());
                                App.Massage0 = true;
                                App.Massage5 = true;
                                App.Massage15 = true;
                                TimesQ.Text = "00:00:00";
                                NumberQ.Text = "-";
                                NumberQ2.Text = "-";
                                DetailQ.Text = "";
                                btn_cancel.IsVisible = false;
                                btn_cancel2.IsVisible = false;

                                b_booking1.IsVisible = true;
                                b_booking2.IsVisible = false;
                                b_qr1.IsVisible = true;
                                b_qr2.IsVisible = false;
                            }
                            else
                            {
                                App.timercheck = false;
                                CountstartMain = false;
                                await DisplayAlert(App.AppicationName, uiReturn.getDescription(), "Close");
                            }
                        }
                    }
                }
            }
            else
            {
                App.RePagemain = false;
                await DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        public void OnImageMainchangeAppLanguageThai(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                if (App.RePagemain == true)
                {
                    App.RePagemain = false;
                    Navigation.PushAsync(new MainPage());
                }
                else
                {
                    //Utils.changeAppLanguageToThai();
                    //LanguageThai.IsVisible = false;
                    //LanguageThai.IsEnabled = false;

                    //LanguageEng.IsVisible = true;
                    //LanguageEng.IsEnabled = true;
                    //App.Thai = true;
                    //DependencyService.Get<IFNotification>().SendNotification("TestENG", "ทดสอบเปลี่ยนเป็นภาษาอังกฤษ");
                     

                    Utils.changeAppLanguageToEng();
                    LanguageThai.IsVisible = false;
                    LanguageThai.IsEnabled = false;

                    LanguageEng.IsVisible = true;
                    LanguageEng.IsEnabled = true;
                    App.Thai = false;

                    if (SessionModel.bookingQ == null)
                    {
                        App.timercheck = false;
                        App.RePage = true;
                        Navigation.InsertPageBefore(new MainPage(), this);
                        Navigation.PopAsync();
                    }
                    else
                    {
                        if (SessionModel.bookingQ.queueNumber == null || SessionModel.bookingQ.queueNumber == "" || SessionModel.bookingQ.queueNumber == "0")
                        {
                            App.timercheck = false;
                            App.RePage = true;
                            Navigation.InsertPageBefore(new MainPage(), this);
                            Navigation.PopAsync();
                        }
                    }
                }
            }
            else
            {
                App.RePagemain = false;
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        public void OnImageMainchangeAppLanguageEng(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                if (App.RePagemain == true)
                {
                    App.RePagemain = false;
                    Navigation.PushAsync(new MainPage());
                }
                else
                {
                    //Utils.changeAppLanguageToEng();
                    //LanguageThai.IsVisible = true;
                    //LanguageThai.IsEnabled = true;

                    //LanguageEng.IsVisible = false;
                    //LanguageEng.IsEnabled = false;
                    //App.Thai = false;

                    //DependencyService.Get<IFNotification>().SendNotification("TestTHAI", "ทดสอบเปลี่ยนเป็นภาษาไทย");
                                        
                    Utils.changeAppLanguageToThai();
                    LanguageThai.IsVisible = true;
                    LanguageThai.IsEnabled = true;

                    LanguageEng.IsVisible = false;
                    LanguageEng.IsEnabled = false;
                    App.Thai = true;

                    if (SessionModel.bookingQ == null)
                    {
                        App.timercheck = false;
                        App.RePage = true;

                        Navigation.InsertPageBefore(new MainPage(), this);
                        Navigation.PopAsync();
                    }
                    else
                    {
                        if (SessionModel.bookingQ.queueNumber == null || SessionModel.bookingQ.queueNumber == "" || SessionModel.bookingQ.queueNumber == "0")
                        {
                            App.timercheck = false;
                            App.RePage = true;

                            Navigation.InsertPageBefore(new MainPage(), this);
                            Navigation.PopAsync();
                        }
                    }
                }
            }
            else
            {
                App.RePagemain = false;
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }
    }
}
