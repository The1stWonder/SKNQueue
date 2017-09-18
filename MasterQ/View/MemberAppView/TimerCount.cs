using System;

using Xamarin.Forms;

namespace MasterQ
{
	public class TimerCount : ContentPage
	{
		public TimerCount()
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

