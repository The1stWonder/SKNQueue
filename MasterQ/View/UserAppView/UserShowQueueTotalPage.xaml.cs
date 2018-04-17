using System;
using System.Collections.Generic;
using Plugin.Connectivity;
using MasterQ.Helpers;
using Xamarin.Forms;

namespace MasterQ
{
    public partial class UserShowQueueTotalPage : ContentPage
    {
        public Branch searchBranch = new Branch();

        public UserShowQueueTotalPage()
        {
            InitializeComponent();
        }

        public void OnImageSubmit(object sender, System.EventArgs args)
        {
            qNumber.Text = "";

            if (CrossConnectivity.Current.IsConnected)
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        DependencyService.Get<IFSocket>().SendMessage(App.DeviceName + ".CHECK." + mGroupID.Text + "<EOF>", App.IPAdress, 11111);
                        break;
                    default:
                        DependencyService.Get<IFSocket>().SendMessage(App.DeviceName + ".CHECK." + mGroupID.Text + "<EOF>", App.IPAdress, 11111);
                        break;
                }

                qNumber.Text = App.ShowMassageSocket.Replace("\0", "").ToUpper();
                string MassageSocket = App.ShowMassageSocket.Replace("\0", "").ToUpper();

                if (App.CheckSocket != true)
                {
                    App.SetIPPage = 1;
                    DisplayAlert(App.AppicationName, MassageSocket, "Close");
                    Navigation.PushAsync(new UserSetIPAddress());
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
                Navigation.PushAsync(new UserActionQueuePage());
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }
    }
}
