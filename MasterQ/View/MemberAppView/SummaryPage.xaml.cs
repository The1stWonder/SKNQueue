using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class SummaryPage : ContentPage
	{
		public SummaryPage()
		{
			InitializeComponent();
		}

		public void OnImageHomePage(object sender, System.EventArgs args)
		{
            Navigation.PushAsync(new MainPage());
		}
	}
}
