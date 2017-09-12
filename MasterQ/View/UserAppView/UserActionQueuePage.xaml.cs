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
        void acceptBtn_Clicked(Object sender, System.EventArgs e)
        {
            UIReturn uiReturn = UserActionQueueController.getInstance().acceptQueue(UserSessionModel.choosedQueue);
            if (uiReturn.isSuccess)
            {

            }
            else
            {
                DisplayAlert("Error", uiReturn.getDescription(), "cancel");
            }
        }
        void callBtn_Clicked(Object sender, System.EventArgs e)
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
        void finishBtn_Clicked(Object sender, System.EventArgs e)
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
        void skipBtn_Clicked(Object sender, System.EventArgs e)
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
