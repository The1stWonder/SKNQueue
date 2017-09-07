using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
    public partial class UserChooseServicePage : ContentPage
    {
        public UserChooseServicePage()
        {
            InitializeComponent();
            InitialPage();
        }

        public void OnImageSubmit(object sender, System.EventArgs args)
        {
            var counterNum = counterNumber.Text;
            UIReturn uiReturn = UserActionServiceController.getInstance().openService(UserSessionModel.choosedBranch, UserSessionModel.choosedService, counterNum);
            if (uiReturn.isSuccess)
            {
                Navigation.PushAsync(new UserActionQueuePage());
            }
            else
            {
                DisplayAlert("Error", uiReturn.getDescription(), "cancel");
            }
        }
        private void InitialPage()
        {
            UserSessionModel.choosedBranch.branchID = SessionModel.loginUser.branchID;
            UIReturn uiReturn = UserActionServiceController.getInstance().getServices(UserSessionModel.choosedBranch);
            List<Service> services = (List<Service>)uiReturn.returnObject;
            foreach (Service s in services)
            {
                chooseService.Items.Add(s.serviceDesc);
            }
            chooseService.Unfocused += (sender, args) =>
            {
                if (chooseService.SelectedIndex >= 0)
                {
                    UserSessionModel.choosedService = services.ToArray()[chooseService.SelectedIndex];
                }
            };
            staffName.Text = SessionModel.loginUser.firstName + " " + SessionModel.loginUser.lastName;
        }
    }
}
