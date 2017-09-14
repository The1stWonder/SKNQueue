using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
    public partial class BranchLoginPage : ContentPage
    {
        public BranchLoginPage()
        {
            InitializeComponent();
        }
		public void OnImageSignin(object sender, System.EventArgs args)
		{
			var username = mUsernameEntry.Text;
			var password = mPasswordEntry.Text;
			Login MasQLogin = new Login(username, password);
			UIReturn uiReturn = BranchLoginController.getInstance().LoginBranch(MasQLogin);

			if (uiReturn.isSuccess)
			{
                Navigation.PushAsync(new BranchChooseServiceQueuePage());
			}
			else
			{
				DisplayAlert("Click", uiReturn.getDescription(), "Close");
			}
		}
    }
}
