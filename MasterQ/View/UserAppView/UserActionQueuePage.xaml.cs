using System;
using System.Collections.Generic;
using MasterQ.Helpers;
using Xamarin.Forms;

namespace MasterQ
{
    public partial class UserActionQueuePage : ContentPage
    {
        string counterNumber;

        public UserActionQueuePage(string counterNum)
        {
            InitializeComponent();
            InitialPage();
            counterNumber = counterNum;
        }
        private void InitialPage()
        {
            CallBtn.IsVisible = true;
            AcceptBtn.IsVisible = false;
            SkipBtn.IsVisible = false;
            FinishBtn.IsVisible = false;
        }
        public void OnCallTap(object sender, System.EventArgs args)
        {
            UIReturn uiReturn = UserActionQueueController.getInstance().callQueue(UserSessionModel.choosedBranch, UserSessionModel.choosedGroup);
            if (uiReturn.isSuccess)
            {
                CallQueueRs uiRes = (CallQueueRs)uiReturn.returnObject;
                UserSessionModel.choosedQueue.tranID = uiRes.tranID;
                qNumber.Text = uiRes.queueNumber + "";
                //CallBtn.IsVisible = false;
                AcceptBtn.IsVisible = true;
                SkipBtn.IsVisible = true;
				FinishBtn.IsVisible = false;

                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        DependencyService.Get<IFSocket>().SendMessage("'" + uiRes.queueNumber + "','" + counterNumber + "',<EOF>","192.168.1.38",11111);
                        //DependencyService.Get<IFiOSSocket>().SendMessage("I001,9,<EOF>", "192.168.1.38", 11111);
                        break;
                    default:
                        DependencyService.Get<IFSocket>().SendMessage("'" + uiRes.queueNumber + "','" + counterNumber + "',<EOF>", "192.168.1.38", 11111);
                        //DependencyService.Get<IFiOSSocket>().SendMessage("I002,8,<EOF>", "192.168.1.38", 11111);
                        break;
                }
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
                CallBtn.IsVisible = false;
				AcceptBtn.IsVisible = false;
				SkipBtn.IsVisible = false;
                FinishBtn.IsVisible = true;
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
				CallBtn.IsVisible = true;
				AcceptBtn.IsVisible = false;
				SkipBtn.IsVisible = false;
				FinishBtn.IsVisible = false;
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
				CallBtn.IsVisible = true;
				AcceptBtn.IsVisible = false;
				SkipBtn.IsVisible = false;
				FinishBtn.IsVisible = false;
            }
            else
            {
                DisplayAlert("Error", uiReturn.getDescription(), "cancel");
            }
        }
    }
}
