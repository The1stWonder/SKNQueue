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

        }
        private void InitialPage()
        {
            Branch b = new Branch();
            b.branchID = SessionModel.loginUser.branchID;
            UIReturn uiReturn = UserActionServiceController.getInstance().getServices(b);
            List<Service> services = (List<Service>)uiReturn.returnObject;
            foreach (Service s in services)
			{
                chooseService.Items.Add(s.serviceDesc);

			}
            staffName.Text = SessionModel.loginUser.firstName + " " + SessionModel.loginUser.lastName;
        }
    }
}
