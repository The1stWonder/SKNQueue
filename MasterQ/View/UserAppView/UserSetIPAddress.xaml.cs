using System;
using System.Collections.Generic;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace MasterQ
{
    public partial class UserSetIPAddress : ContentPage
    {
        public UserSetIPAddress()
        {
            InitializeComponent();
            IPAddress.Text = App.IPAdress;
            DeviceName.Text = App.DeviceName;

            if (App.SetIPPage == 1)
            {
                ImageBack.IsVisible = false;
            }
            else
            {
                ImageBack.IsVisible = true;
            }
        }

        public void OnImageJoin(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                if (App.SetIPPage == 0)
                {
                    App.DeviceName = DeviceName.Text.Trim();
                    App.IPAdress = IPAddress.Text.Trim();
                    if (App.DeviceName != "")
                    {
                        App.Database.SaveItem(DBConstants.ID_DEVICE_USER, App.DeviceName);
                    }
                    if (App.IPAdress != "")
                    {
                        App.Database.SaveItem(DBConstants.ID_IP_USER, App.IPAdress);
                    }

                    Navigation.PushAsync(new UserLoginPage());
                }
                else if (App.SetIPPage == 1)
                {
                    App.DeviceName = DeviceName.Text.Trim();
                    App.IPAdress = IPAddress.Text.Trim();
                    App.Database.SaveItem(DBConstants.ID_DEVICE_USER, App.DeviceName);
                    App.Database.SaveItem(DBConstants.ID_IP_USER, App.IPAdress);
                    Navigation.PushAsync(new UserActionQueuePage());
                }
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        public void OnImageBack(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                if (App.SetIPPage == 0)
                {
                    Navigation.PushAsync(new UserLoginPage());
                }
                else if (App.SetIPPage == 1)
                {
                    Navigation.PushAsync(new UserActionQueuePage());
                }
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }
    }
}
