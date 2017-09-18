using System;

using Xamarin.Forms;

namespace MasterQ
{
	public class StartMainPage : TabbedPage
	{
		public StartMainPage()
		{
			//Page itemsPage;

			//itemsPage = new NavigationPage(new MainPage());

			Navigation.PushAsync(new MainPage());
		}

		protected override void OnCurrentPageChanged()
		{
			base.OnCurrentPageChanged();
			Title = CurrentPage?.Title ?? string.Empty;
		}
	}
}

