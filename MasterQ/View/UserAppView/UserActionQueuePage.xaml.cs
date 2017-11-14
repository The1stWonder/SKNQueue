using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MasterQ.Helpers;
using Xamarin.Forms;

namespace MasterQ
{
    public partial class UserActionQueuePage : ContentPage
    {
        string counterNumber;
        int ChkTime = 0;

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
            CallBtn.IsEnabled = false;
            CallBtn.IsVisible = false;

            //if (CallBtn.IsVisible == false)
            //{
                UIReturn uiReturn = UserActionQueueController.getInstance().callQueue(UserSessionModel.choosedBranch, UserSessionModel.choosedGroup);
                if (uiReturn.isSuccess)
                {
                    CallQueueRs uiRes = (CallQueueRs)uiReturn.returnObject;
                    UserSessionModel.choosedQueue.tranID = uiRes.tranID;
                    qNumber.Text = uiRes.queueNumber + "";
                    AcceptBtn.IsVisible = true;
                    SkipBtn.IsVisible = true;
                    FinishBtn.IsVisible = false;
                    CallBtn.IsVisible = false;

                    switch (Device.RuntimePlatform)
                    {
                        case Device.iOS:
                        DependencyService.Get<IFSocket>().SendMessage(uiRes.queueNumber + "," + counterNumber + "<EOF>", App.IPAdress, 11111);
                            //DependencyService.Get<IFiOSSocket>().SendMessage("I001,9,<EOF>", "192.168.1.38", 11111);
                            break;
                        default:
                        DependencyService.Get<IFSocket>().SendMessage(uiRes.queueNumber + "," + counterNumber + "<EOF>", App.IPAdress, 11111);
                            //DependencyService.Get<IFiOSSocket>().SendMessage("I002,8,<EOF>", "192.168.1.38", 11111);
                            break;
                    }

                    Device.StartTimer(new TimeSpan(0, 0, 1), () =>
                    {
                        ChkTime = ChkTime + 1;

                        if (ChkTime == 2)
                        {
                            ChkTime = 0;
                            CallBtn.IsEnabled = true;
                            CallBtn.IsVisible = true;
                            return false;
                        }

                        return true;
                    });
                    //Task.Delay(TimeSpan.FromSeconds(3)).Wait();

                }
                else
                {
                    DisplayAlert("Error", uiReturn.getDescription(), "cancel");
                }
            //}
        }
        public void OnAcceptTap(object sender, System.EventArgs args)
        {
            UIReturn uiReturn = UserActionQueueController.getInstance().acceptQueue(UserSessionModel.choosedQueue);
            if (uiReturn.isSuccess)
            {
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
