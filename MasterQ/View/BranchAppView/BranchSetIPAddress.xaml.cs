using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
    public partial class BranchSetIPAddress : ContentPage
    {
        public BranchSetIPAddress()
        {
            InitializeComponent();
            IPAddress.Text = App.IPAdress;
        }

        public void OnImageJoin(object sender, System.EventArgs args)
        {
            App.IPAdress = IPAddress.Text.Trim();
            App.Database.SaveItem(DBConstants.ID_IP_BRANCH,App.IPAdress);
            Navigation.PushAsync(new BranchLoginPage());
        }
    }
}
