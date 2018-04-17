using System;
using System.Collections.Generic;
using MasterQ.Helpers;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace MasterQ
{
    public partial class UserLoginPage : ContentPage
    {
        public UserLoginPage()
        {
            InitializeComponent();
            HeaderService.Text = "Device Name :  " + App.DeviceName;


            var chooseCouter = new List<string>();
            chooseCouter.Add("1");
            chooseCouter.Add("2");
            chooseCouter.Add("3");
            chooseCouter.Add("4");
            chooseCouter.Add("5");
            chooseCouter.Add("6");
            chooseCouter.Add("7");
            chooseCouter.Add("8");
            chooseCouter.Add("9");
            chooseCouter.Add("10");
            chooseCouter.Add("11");
            chooseCouter.Add("12");
            chooseCouter.Add("13");
            chooseCouter.Add("14");
            chooseCouter.Add("15");
            chooseCouter.Add("16");
            chooseCouter.Add("17");
            chooseCouter.Add("18");
            chooseCouter.Add("19");
            chooseCouter.Add("20");

            var picker = new Picker { Title = "Counter Number" };
            picker.ItemsSource = chooseCouter;
        }

        public void OnImageSignin(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var GroupID = mGroupID.Text;
                var password = mPasswordEntry.Text;
                App.CounterUser = mCounter.SelectedItem.ToString();
                App.UserGroupID = mGroupID.Text;

                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        DependencyService.Get<IFSocket>().SendMessage(App.DeviceName + "." + password + "." + App.CounterUser + "." + GroupID + "<EOF>", App.IPAdress, 11111);
                        break;
                    default:
                        DependencyService.Get<IFSocket>().SendMessage(App.DeviceName + "." + password + "." + App.CounterUser + "." + GroupID + "<EOF>", App.IPAdress, 11111);
                        break;
                }
                string ConnectSocket = App.CheckConnectSocket;
                if (App.CheckSocket == true)
                {
                    String MassageSocket = App.ShowMassageSocket.Replace("\0", "").ToUpper();

                    if (MassageSocket == "LOGIN SUCCESS")
                    {
                        Navigation.PushAsync(new UserActionQueuePage());
                    }
                    else
                    {
                        if (MassageSocket == "PLEASE LOGOUT.")
                        {
                            switch (Device.RuntimePlatform)
                            {
                                case Device.iOS:
                                    DependencyService.Get<IFSocket>().SendMessage(App.DeviceName + ".LOGOUT" + "<EOF>", App.IPAdress, 11111);
                                    break;
                                default:
                                    DependencyService.Get<IFSocket>().SendMessage(App.DeviceName + ".LOGOUT" + "<EOF>", App.IPAdress, 11111);
                                    break;
                            }

                            MassageSocket = App.ShowMassageSocket.Replace("\0", "").ToUpper();

                            if (App.CheckSocket == true)
                            {
                                if (MassageSocket == "LOGOUT SUCCESS.")
                                {
                                    switch (Device.RuntimePlatform)
                                    {
                                        case Device.iOS:
                                            DependencyService.Get<IFSocket>().SendMessage(App.DeviceName + "." + password + "." + App.CounterUser + "." + GroupID + "<EOF>", App.IPAdress, 11111);
                                            break;
                                        default:
                                            DependencyService.Get<IFSocket>().SendMessage(App.DeviceName + "." + password + "." + App.CounterUser + "." + GroupID + "<EOF>", App.IPAdress, 11111);
                                            break;
                                    }

                                    MassageSocket = App.ShowMassageSocket.Replace("\0", "").ToUpper();

                                    if (App.CheckSocket == true)
                                    {
                                        if (MassageSocket == "LOGIN SUCCESS")
                                        {
                                            Navigation.PushAsync(new UserActionQueuePage());
                                        }
                                        else
                                        {
                                            DisplayAlert(App.AppicationName, MassageSocket, "Close");
                                        }
                                    }
                                    else
                                    {
                                        App.SetIPPage = 0;
                                        DisplayAlert(App.AppicationName, ConnectSocket, "Close");
                                        Navigation.PushAsync(new UserSetIPAddress());
                                    }
                                }
                                else
                                {
                                    if (MassageSocket == "ACCEPT OR SKIP!")
                                    {
                                        switch (Device.RuntimePlatform)
                                        {
                                            case Device.iOS:
                                                DependencyService.Get<IFSocket>().SendMessage(App.DeviceName + ".SKIP" + "<EOF>", App.IPAdress, 11111);
                                                break;
                                            default:
                                                DependencyService.Get<IFSocket>().SendMessage(App.DeviceName + ".SKIP" + "<EOF>", App.IPAdress, 11111);
                                                break;
                                        }

                                        MassageSocket = App.ShowMassageSocket.Replace("\0", "").ToUpper();

                                        if (App.CheckSocket == true)
                                        {
                                            switch (Device.RuntimePlatform)
                                            {
                                                case Device.iOS:
                                                    DependencyService.Get<IFSocket>().SendMessage(App.DeviceName + ".LOGOUT" + "<EOF>", App.IPAdress, 11111);
                                                    break;
                                                default:
                                                    DependencyService.Get<IFSocket>().SendMessage(App.DeviceName + ".LOGOUT" + "<EOF>", App.IPAdress, 11111);
                                                    break;
                                            }

                                            MassageSocket = App.ShowMassageSocket.Replace("\0", "").ToUpper();

                                            if (App.CheckSocket == true)
                                            {
                                                if (MassageSocket == "LOGOUT SUCCESS.")
                                                {
                                                    switch (Device.RuntimePlatform)
                                                    {
                                                        case Device.iOS:
                                                            DependencyService.Get<IFSocket>().SendMessage(App.DeviceName + "." + password + "." + App.CounterUser + "." + GroupID + "<EOF>", App.IPAdress, 11111);
                                                            break;
                                                        default:
                                                            DependencyService.Get<IFSocket>().SendMessage(App.DeviceName + "." + password + "." + App.CounterUser + "." + GroupID + "<EOF>", App.IPAdress, 11111);
                                                            break;
                                                    }

                                                    MassageSocket = App.ShowMassageSocket.Replace("\0", "").ToUpper();

                                                    if (App.CheckSocket == true)
                                                    {
                                                        if (MassageSocket == "LOGIN SUCCESS")
                                                        {
                                                            Navigation.PushAsync(new UserActionQueuePage());
                                                        }
                                                        else
                                                        {
                                                            DisplayAlert(App.AppicationName, MassageSocket, "Close");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        App.SetIPPage = 0;
                                                        DisplayAlert(App.AppicationName, ConnectSocket, "Close");
                                                        Navigation.PushAsync(new UserSetIPAddress());
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                App.SetIPPage = 0;
                                                DisplayAlert(App.AppicationName, ConnectSocket, "Close");
                                                Navigation.PushAsync(new UserSetIPAddress());
                                            }
                                        }
                                        else
                                        {
                                            App.SetIPPage = 0;
                                            DisplayAlert(App.AppicationName, ConnectSocket, "Close");
                                            Navigation.PushAsync(new UserSetIPAddress());
                                        }
                                    }
                                }
                            }
                            else
                            {
                                App.SetIPPage = 0;
                                DisplayAlert(App.AppicationName, ConnectSocket, "Close");
                                Navigation.PushAsync(new UserSetIPAddress());
                            }
                        }
                        else
                        {
                            DisplayAlert(App.AppicationName, MassageSocket, "Close");
                        }
                    }
                }
                else
                {
                    App.SetIPPage = 0;
                    DisplayAlert(App.AppicationName, ConnectSocket, "Close");
                    Navigation.PushAsync(new UserSetIPAddress());
                }
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        public void OnLabelSetIP(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                App.SetIPPage = 0;
                Navigation.PushAsync(new UserSetIPAddress());
                mPasswordEntry.Text = "";
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }
    }
}
