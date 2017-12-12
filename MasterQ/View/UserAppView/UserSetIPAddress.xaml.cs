using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
    public partial class UserSetIPAddress : ContentPage
    {
        public UserSetIPAddress()
        {
            InitializeComponent();
            IPAddress.Text = App.IPAdress;
        }

        public void OnImageJoin(object sender, System.EventArgs args)
        {
            App.IPAdress = IPAddress.Text.Trim();
            App.Database.SaveItem(DBConstants.ID_IP_USER, App.IPAdress);
            Navigation.PushAsync(new UserLoginPage());
        }
    }
}
