using System;
using System.Collections.Generic;
using MasterQ.Helpers;

using Xamarin.Forms;

namespace MasterQ
{
    public partial class BranchChooseServiceQueuePage : ContentPage
    {
        //string counterNumber;
        //int ChkTime = 0;

        public BranchChooseServiceQueuePage()
        {
            InitializeComponent();
            getService();
        }
		public void getService()
		{
            List<Service> Service = (List<Service>)BranchActionsController.getInstance().getBranchServices().returnObject;
			ServiceListview.ItemsSource = Service;
		}

		public void itemTapped(object sender, System.EventArgs args)
		{
            //Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            //{
                //ChkTime = ChkTime + 1;

                //if (ChkTime == 2)
                //{
                    //ChkTime = 0;
                    Service service = (Service)ServiceListview.SelectedItem;
                    string servicename = service.serviceName;
                    UIReturn uiReturn = BranchActionsController.getInstance().reserveQueueBranch(service);
                    if (uiReturn.isSuccess)
                    {
                        BranchSessionModel.bookingQ = (Queue)uiReturn.returnObject;
                        if (BranchSessionModel.bookingQ != null)
                        {
                            NumberQ.Text = BranchSessionModel.bookingQ.queueNumber;
                            TimeSpan time = TimeSpan.FromSeconds(BranchSessionModel.bookingQ.estimateTime * 60);
                            TimesQ.Text = time.ToString(@"hh\:mm\:ss");

                            switch (Device.RuntimePlatform)
                            {
                                case Device.iOS:
                            DependencyService.Get<IFSocket>().SendMessage("P," + BranchSessionModel.bookingQ.queueNumber + "," + BranchSessionModel.bookingQ.queueBefore + "," + servicename + "," + TimesQ.Text + "<EOF>", App.IPAdress, 11111);
                                    break;
                                default:
                            DependencyService.Get<IFSocket>().SendMessage("P," + BranchSessionModel.bookingQ.queueNumber + "," + BranchSessionModel.bookingQ.queueBefore + "," + servicename + "," + TimesQ.Text + "<EOF>", App.IPAdress, 11111);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        DisplayAlert("Error", uiReturn.getDescription(), "Cancel");
                    }

            //        return false;
            //    }
            //    return true;
            //});
		}

        public void OnImageMainExit(object sender, System.EventArgs args)
        {
            UIReturn Chklogout = BranchLoginController.getInstance().LogutBranch();
            if (!Chklogout.isSuccess)
            {
                DisplayAlert("", Chklogout.getDescription(), "Close");
            }
            else
            {
                Navigation.InsertPageBefore(new BranchLoginPage(), this);
                Navigation.PopAsync();
            }
        }
    }
}
