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
            UIReturn uiReturn = UserActionServiceController.getInstance().openService(UserSessionModel.choosedBranch, UserSessionModel.choosedGroup, counterNum);
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
            UserSessionModel.choosedBranch.branchID = UserSessionModel.loginUser.branchID;
            UIReturn uiReturn = UserActionServiceController.getInstance().getServices(UserSessionModel.choosedBranch);
            List<Service> services = (List<Service>)uiReturn.returnObject;

            foreach (Service s in services)
            {
                String groupID = s.groupID;
                GroupService group = new GroupService();
                group.groupID = groupID;
                group.services = services.FindAll(sv => sv.groupID.Equals(groupID));
				if (UserSessionModel.groupServices.FindAll(gs => gs.groupID.Equals(groupID)).Count <= 0)
				{
                    UserSessionModel.groupServices.Add(group);
                }
            }

            foreach (GroupService tempGS in UserSessionModel.groupServices)
            {
                String showText = "";
                foreach (Service tempS in tempGS.services)
                {
                    showText+=tempS.serviceName+",";
                }
                chooseService.Items.Add(showText.Substring(0,showText.Length-1));
            }

            chooseService.Unfocused += (sender, args) =>
            {
                if (chooseService.SelectedIndex >= 0)
                {
                    UserSessionModel.choosedGroup = UserSessionModel.groupServices.ToArray()[chooseService.SelectedIndex];
                }
            };
            staffName.Text = UserSessionModel.loginUser.firstName + " " + UserSessionModel.loginUser.lastName;
        }
    }
}
