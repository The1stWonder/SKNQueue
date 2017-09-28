using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
    public partial class UserActionQueuePage : ContentPage
    {
        public UserActionQueuePage()
        {
            InitializeComponent();
            InitialPage();
        }
        private void InitialPage()
        {
        }
        public void OnCallTap(object sender, System.EventArgs args)
        {
			UIReturn uiReturn = UserActionQueueController.getInstance().callQueue(UserSessionModel.choosedBranch, UserSessionModel.choosedGroup);
			if (uiReturn.isSuccess)
			{
				CallQueueRs uiRes = (CallQueueRs)uiReturn.returnObject;
				UserSessionModel.choosedQueue.tranID = uiRes.tranID;
				qNumber.Text = uiRes.queueNumber + "";
			}
			else
			{
				DisplayAlert("Error", uiReturn.getDescription(), "cancel");
			}
        }
		public void OnAcceptTap(object sender, System.EventArgs args)
		{
			UIReturn uiReturn = UserActionQueueController.getInstance().callQueue(UserSessionModel.choosedBranch, UserSessionModel.choosedGroup);
			if (uiReturn.isSuccess)
			{
				CallQueueRs uiRes = (CallQueueRs)uiReturn.returnObject;
				UserSessionModel.choosedQueue.tranID = uiRes.tranID;
				qNumber.Text = uiRes.queueNumber + "";
			}
			else
			{
				DisplayAlert("Error", uiReturn.getDescription(), "cancel");
			}
		}
		public void OnFinishTap(object sender, System.EventArgs args)
		{
			UIReturn uiReturn = UserActionQueueController.getInstance().finishQueue(UserSessionModel.choosedQueue);
			if (uiReturn.isSuccess)
			{

			}
			else
			{
				DisplayAlert("Error", uiReturn.getDescription(), "cancel");
			}
		}
		public void OnSkipTap(object sender, System.EventArgs args)
		{
			UIReturn uiReturn = UserActionQueueController.getInstance().skipQueue(UserSessionModel.choosedQueue);
			if (uiReturn.isSuccess)
			{

			}
			else
			{
				DisplayAlert("Error", uiReturn.getDescription(), "cancel");
			}
		}
    }
}
