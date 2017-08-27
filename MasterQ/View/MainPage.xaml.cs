using System;
using System.Collections.Generic;
using ZXing.Net.Mobile.Forms;


using Xamarin.Forms;
using ZXing.Mobile;

namespace MasterQ
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void OnImageMainProfilePage(object sender, System.EventArgs args)
        {
            Navigation.PushAsync(new MainProfilePage());
        }

        public void OnImageHistoryPage(object sender, System.EventArgs args)
        {
            Navigation.PushAsync(new HistoryPage());
        }

        public void OnImageQueuePage(object sender, System.EventArgs args)
        {
            Navigation.PushAsync(new SearchPage());
        }

        public void OnImageQRcodePage(object sender, System.EventArgs args)
        {
            //ZXingScannerPage scanPage = new ZXingScannerPage();
            //Navigation.PushAsync(scanPage);
            //Navigation.PushAsync(new QRcodePage());

            //scanPage.OnScanResult += (result) =>
            //{
            //	scanPage.IsScanning = false;
            //	ZXing.BarcodeFormat barcodeFormat = result.BarcodeFormat;
            //	string type = barcodeFormat.ToString();
            //	Device.BeginInvokeOnMainThread(() =>
            //	{
            //		Navigation.PopAsync();
            //		DisplayAlert("The Barcode type is : " + type, "The text is : " + result.Text, "OK");
            //	});
            //};

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
    }
}
