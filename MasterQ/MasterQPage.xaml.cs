using Xamarin.Forms;

namespace MasterQ
{
	public partial class MasterQPage : ContentPage
	{
		public MasterQPage()
		{
            InitializeComponent();
			Navigation.PushAsync(new LoginPage());
		}


	}
}
