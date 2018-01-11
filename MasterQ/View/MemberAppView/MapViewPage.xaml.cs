using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Plugin.Connectivity;
using Xamarin.Forms.Xaml;

namespace MasterQ
{
    [XamlCompilation(XamlCompilationOptions.Compile)] //alexpook link all
    public partial class MapViewPage : ContentPage
    {
        public Branch searchBranch = new Branch();
        double latitude = 0;
        double longitude = 0;

        public MapViewPage(Branch selectedBranch)
        {
            InitializeComponent();

            if (CrossConnectivity.Current.IsConnected)
            {
                searchBranch = (Branch)SearchController.getInstance().getBranchDetail(selectedBranch).returnObject;
                branchName.Text = selectedBranch.branchName;
                branchAddress.Text = Utils.getLabel(LabelConstants.MAPVIEW_PAGE_ADDRESS) + " : " + selectedBranch.address;
                branchTel.Text = Utils.getLabel(LabelConstants.MAPVIEW_PAGE_TEL) + " : " + selectedBranch.telNo;
                branchEmail.Text = Utils.getLabel(LabelConstants.MAPVIEW_PAGE_EMAIL) + " : " + searchBranch.email;

                if (selectedBranch.latitude != "")
                {
                    latitude = double.Parse(selectedBranch.latitude);
                }

                if (selectedBranch.longitude != "")
                {
                    longitude = double.Parse(selectedBranch.longitude);
                }

                var pin = new CustomPin
                {
                    Pin = new Pin
                    {
                        Type = PinType.Place,
                        Position = new Position(latitude, longitude),
                        Label = selectedBranch.branchName,
                        Address = selectedBranch.address
                    },
                    //Id = "Xamarin",
                    //Url = "http://xamarin.com/about/"
                };

                customMap.CustomPins = new List<CustomPin> { pin };
                customMap.Pins.Add(pin.Pin);
                customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(latitude, longitude), Distance.FromMiles(1.0)));
            }
        }

		public void OnImageBack(object sender, System.EventArgs args)
		{
            if (CrossConnectivity.Current.IsConnected)
            {
                Navigation.PushAsync(new ServicePage(searchBranch));
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
		}
    }
}
