using System;

using Xamarin.Forms;

namespace MasterQ
{
	public class StartMainPage : ContentPage
	{
		public StartMainPage()
		{
			Content = new StackLayout
			{
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}

