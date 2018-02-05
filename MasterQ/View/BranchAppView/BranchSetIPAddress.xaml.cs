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

            if (App.SetIPPage == 1)
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }
            else
            {
                NavigationPage.SetHasNavigationBar(this, true);
            }
        }

        public void OnImageJoin(object sender, System.EventArgs args)
        {
            if (App.SetIPPage == 0)
            {
                App.IPAdress = IPAddress.Text.Trim();
                App.Database.SaveItem(DBConstants.ID_IP_BRANCH, App.IPAdress);
                Navigation.PushAsync(new BranchLoginPage());
            }
            else if (App.SetIPPage == 1)
            {
                App.IPAdress = IPAddress.Text.Trim();
                App.Database.SaveItem(DBConstants.ID_IP_BRANCH, App.IPAdress);

                if (App.NumberServiceBranch == 1)
                {
                    Navigation.PushAsync(new Service1Page());
                }
                else if (App.NumberServiceBranch == 2)
                {
                    Navigation.PushAsync(new Service2Page());
                }
                else if (App.NumberServiceBranch == 3)
                {
                    Navigation.PushAsync(new Service3Page());
                }
                else if (App.NumberServiceBranch == 4)
                {
                    Navigation.PushAsync(new Service4Page());
                }
                else if (App.NumberServiceBranch == 5)
                {
                    Navigation.PushAsync(new Service5Page());
                }
                else if (App.NumberServiceBranch == 6)
                {
                    Navigation.PushAsync(new Service6Page());
                }
                else if (App.NumberServiceBranch == 7)
                {
                    Navigation.PushAsync(new Service7Page());
                }
                else if (App.NumberServiceBranch == 8)
                {
                    Navigation.PushAsync(new Service8Page());
                }
                else if (App.NumberServiceBranch == 9)
                {
                    Navigation.PushAsync(new Service9Page());
                }
                else if (App.NumberServiceBranch == 10)
                {
                    Navigation.PushAsync(new Service10Page());
                }
                else if (App.NumberServiceBranch == 11)
                {
                    Navigation.PushAsync(new Service11Page());
                }
                else if (App.NumberServiceBranch == 12)
                {
                    Navigation.PushAsync(new Service12Page());
                }
                else if (App.NumberServiceBranch == 13)
                {
                    Navigation.PushAsync(new Service13Page());
                }
                else if (App.NumberServiceBranch == 14)
                {
                    Navigation.PushAsync(new Service14Page());
                }
                else if (App.NumberServiceBranch == 15)
                {
                    Navigation.PushAsync(new Service15Page());
                }
                else if (App.NumberServiceBranch == 16)
                {
                    Navigation.PushAsync(new Service16Page());
                }
                else if (App.NumberServiceBranch == 17)
                {
                    Navigation.PushAsync(new Service17Page());
                }
                else if (App.NumberServiceBranch == 18)
                {
                    Navigation.PushAsync(new Service18Page());
                }
                else if (App.NumberServiceBranch == 19)
                {
                    Navigation.PushAsync(new Service19Page());
                }
                else if (App.NumberServiceBranch == 20)
                {
                    Navigation.PushAsync(new Service20Page());
                }
            }

        }
    }
}
