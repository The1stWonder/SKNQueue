using System;
using System.Collections.Generic;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace MasterQ
{
    public partial class UserChooseServicePage : ContentPage
    {
        public UserChooseServicePage()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                InitializeComponent();
                InitialPage();

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

                var picker = new Picker { Title = "เคาน์เตอร์" };
                picker.ItemsSource = chooseCouter;
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        public void OnImageSubmit(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                if (chooseCouter.SelectedItem != null)
                {
                    App.CounterUser = chooseCouter.SelectedItem.ToString();

                    UIReturn uiReturn = UserActionServiceController.getInstance().openService(UserSessionModel.choosedBranch, UserSessionModel.choosedGroup, App.CounterUser);
                    if (uiReturn.isSuccess)
                    {
                        Navigation.PushAsync(new UserActionQueuePage());
                    }
                    else
                    {
                        DisplayAlert(App.AppicationName, uiReturn.getDescription(), "cancel");
                    }
                }
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        private void InitialPage()
        {
            UserSessionModel.choosedBranch.branchID = UserSessionModel.loginUser.branchID;
            UIReturn uiReturn = UserActionServiceController.getInstance().getServices(UserSessionModel.choosedBranch);
            List<Service> services = (List<Service>)uiReturn.returnObject;

            foreach (Service s in services)
            {
                String groupID = s.groupID;
                String groupName = s.groupName;
                GroupService group = new GroupService();
                group.groupID = groupID;
                group.groupName = groupName;
                group.services = services.FindAll(sv => sv.groupID.Equals(groupID));
				if (UserSessionModel.groupServices.FindAll(gs => gs.groupID.Equals(groupID)).Count <= 0)
				{
                    UserSessionModel.groupServices.Add(group);
                }
            }

            foreach (GroupService tempGS in UserSessionModel.groupServices)
            {
                //String showText = "";
                //foreach (Service tempS in tempGS.services)
                //{
                //    showText+=tempS.serviceName+",";
                //}
                //chooseService.Items.Add(showText.Substring(0,showText.Length-1));

                String showText = tempGS.groupName;
                chooseService.Items.Add(showText);
            }

            chooseService.Unfocused += (sender, args) =>
            {
                if (chooseService.SelectedIndex >= 0)
                {
                    UserSessionModel.choosedGroup = UserSessionModel.groupServices.ToArray()[chooseService.SelectedIndex];
                }
            };

            UserQ.Text = UserSessionModel.loginUser.firstName + " " + UserSessionModel.loginUser.lastName;
        }

        async void OnImageMainExit(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var answer = await DisplayAlert(Utils.getLabel(LabelConstants.MAIN_PAGE_LOGOUT), Utils.getLabel(LabelConstants.MAIN_PAGE_CONFIRMLOGOUT), "Yes", "No");
                if (answer == true)
                {
                    UIReturn Chklogout = UserLoginController.getInstance().LogutUser();
                    if (!Chklogout.isSuccess)
                    {
                        await DisplayAlert(App.AppicationName, Chklogout.getDescription(), "Close");
                    }
                    else
                    {
                        Navigation.InsertPageBefore(new UserLoginPage(), this);
                        await Navigation.PopAsync();
                    }
                }
            }
            else
            {
                await DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }
    }
}
