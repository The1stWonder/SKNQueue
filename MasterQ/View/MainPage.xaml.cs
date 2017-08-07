using System;
using System.Collections.Generic;

using Xamarin.Forms;

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
			Navigation.PushAsync(new QueuePage());
		}

		public void OnImageQRcodePage(object sender, System.EventArgs args)
		{
			Navigation.PushAsync(new QRcodePage());
		}
	}
}
