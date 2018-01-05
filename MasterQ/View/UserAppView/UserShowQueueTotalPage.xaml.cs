using System;
using System.Collections.Generic;
using Plugin.Connectivity;

using Xamarin.Forms;

namespace MasterQ
{
    public partial class UserShowQueueTotalPage : ContentPage
    {
        public Branch searchBranch = new Branch();

        public UserShowQueueTotalPage()
        {
            InitializeComponent();

            if (CrossConnectivity.Current.IsConnected)
            {
                getService();
            }
        }

        public void getService()
        {
            UserSessionModel.choosedBranch.branchID = UserSessionModel.loginUser.branchID;
            UIReturn uiReturn = UserActionServiceController.getInstance().getServices(UserSessionModel.choosedBranch);
            List<Service> services = (List<Service>)uiReturn.returnObject;
            ServiceListview.ItemsSource = services;
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
