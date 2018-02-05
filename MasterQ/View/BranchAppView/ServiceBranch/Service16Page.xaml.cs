using System;
using System.Collections.Generic;
using MasterQ.Helpers;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace MasterQ
{
    public partial class Service16Page : ContentPage
    {
        public Service service1 = new Service();
        public Service service2 = new Service();
        public Service service3 = new Service();
        public Service service4 = new Service();
        public Service service5 = new Service();
        public Service service6 = new Service();
        public Service service7 = new Service();
        public Service service8 = new Service();
        public Service service9 = new Service();
        public Service service10 = new Service();
        public Service service11 = new Service();
        public Service service12 = new Service();
        public Service service13 = new Service();
        public Service service14 = new Service();
        public Service service15 = new Service();
        public Service service16 = new Service();

        public Service16Page()
        {
            InitializeComponent();
            HeaderService.Text = Utils.getLabel(LabelConstants.BRANCHSERVICE_PAGE_SERVICE);
            getService();
        }

        public void getService()
        {
            List<Service> Service = (List<Service>)BranchActionsController.getInstance().getBranchServices().returnObject;

            service1 = Service[0];
            service2 = Service[1];
            service3 = Service[2];
            service4 = Service[3];
            service5 = Service[4];
            service6 = Service[5];
            service7 = Service[6];
            service8 = Service[7];
            service9 = Service[8];
            service10 = Service[9];
            service11 = Service[10];
            service12 = Service[11];
            service13 = Service[12];
            service14 = Service[13];
            service15 = Service[14];
            service16 = Service[15];

            text_service1.Text = service1.serviceName;
            text_service2.Text = service2.serviceName;
            text_service3.Text = service3.serviceName;
            text_service4.Text = service4.serviceName;
            text_service5.Text = service5.serviceName;
            text_service6.Text = service6.serviceName;
            text_service7.Text = service7.serviceName;
            text_service8.Text = service8.serviceName;
            text_service9.Text = service9.serviceName;
            text_service10.Text = service10.serviceName;
            text_service11.Text = service11.serviceName;
            text_service12.Text = service12.serviceName;
            text_service13.Text = service13.serviceName;
            text_service14.Text = service14.serviceName;
            text_service15.Text = service15.serviceName;
            text_service16.Text = service16.serviceName;

            btn_service1.IsEnabled = true;
            text_service1.IsEnabled = true;
            btn_service2.IsEnabled = true;
            text_service2.IsEnabled = true;
            btn_service3.IsEnabled = true;
            text_service3.IsEnabled = true;
            btn_service4.IsEnabled = true;
            text_service4.IsEnabled = true;
            btn_service5.IsEnabled = true;
            text_service5.IsEnabled = true;
            btn_service6.IsEnabled = true;
            text_service6.IsEnabled = true;
            btn_service7.IsEnabled = true;
            text_service7.IsEnabled = true;
            btn_service8.IsEnabled = true;
            text_service8.IsEnabled = true;
            btn_service9.IsEnabled = true;
            text_service9.IsEnabled = true;
            btn_service10.IsEnabled = true;
            text_service10.IsEnabled = true;
            btn_service11.IsEnabled = true;
            text_service11.IsEnabled = true;
            btn_service12.IsEnabled = true;
            text_service12.IsEnabled = true;
            btn_service13.IsEnabled = true;
            text_service13.IsEnabled = true;
            btn_service14.IsEnabled = true;
            text_service14.IsEnabled = true;
            btn_service15.IsEnabled = true;
            text_service15.IsEnabled = true;
            btn_service16.IsEnabled = true;
            text_service16.IsEnabled = true;
        }

        public void OnService1(object sender, System.EventArgs args)
        {
            btn_service1.IsEnabled = false;
            text_service1.IsEnabled = false;

            Image image = sender as Image;
            if (image != null)
            {
                string source = image.Source as FileImageSource;
                if (String.Equals(source, "bluebutton.png"))
                {
                    image.Source = "bluebutton2.png";
                }
                else
                {
                    image.Source = "bluebutton.png";
                }
            }

            UIReturn uiReturn = BranchActionsController.getInstance().reserveQueueBranch(service1);
            if (uiReturn.isSuccess)
            {
                BranchSessionModel.bookingQ = (Queue)uiReturn.returnObject;
                if (BranchSessionModel.bookingQ != null)
                {
                    //TimeSpan time = TimeSpan.FromSeconds(BranchSessionModel.bookingQ.estimateTime * 60);
                    //string TimesQ = time.ToString(@"hh\:mm\:ss");

                    Navigation.PushAsync(new BranchSummaryQueuePage());

                    //switch (Device.RuntimePlatform)
                    //{
                    //    case Device.iOS:
                    //        DependencyService.Get<IFSocket>().SendMessage("P," + BranchSessionModel.bookingQ.queueNumber + "," + BranchSessionModel.bookingQ.queueBefore + "," + servicename + "," + TimesQ + "<EOF>", App.IPAdress, 11111);
                    //        break;
                    //    default:
                    //        DependencyService.Get<IFSocket>().SendMessage("P," + BranchSessionModel.bookingQ.queueNumber + "," + BranchSessionModel.bookingQ.queueBefore + "," + servicename + "," + TimesQ + "<EOF>", App.IPAdress, 11111);
                    //        break;
                    //}

                    //if (App.CheckSocket == true)
                    //{
                    //    Navigation.PushAsync(new BranchSummaryQueuePage());
                    //}
                    //else
                    //{
                    //    App.SetIPPage = 1;
                    //    DisplayAlert(App.AppicationName, App.NoSocket, "Close");
                    //    Navigation.PushAsync(new BranchSetIPAddress());
                    //}
                }
            }
            else
            {
                DisplayAlert("Error", uiReturn.getDescription(), "Cancel");
            }
        }

        public void OnService2(object sender, System.EventArgs args)
        {
            btn_service2.IsEnabled = false;
            text_service2.IsEnabled = false;

            Image image = sender as Image;
            if (image != null)
            {
                string source = image.Source as FileImageSource;
                if (String.Equals(source, "bluebutton.png"))
                {
                    image.Source = "bluebutton2.png";
                }
                else
                {
                    image.Source = "bluebutton.png";
                }
            }

            UIReturn uiReturn = BranchActionsController.getInstance().reserveQueueBranch(service2);
            if (uiReturn.isSuccess)
            {
                BranchSessionModel.bookingQ = (Queue)uiReturn.returnObject;
                if (BranchSessionModel.bookingQ != null)
                {
                    Navigation.PushAsync(new BranchSummaryQueuePage());
                }
            }
            else
            {
                DisplayAlert("Error", uiReturn.getDescription(), "Cancel");
            }
        }

        public void OnService3(object sender, System.EventArgs args)
        {
            btn_service3.IsEnabled = false;
            text_service3.IsEnabled = false;

            Image image = sender as Image;
            if (image != null)
            {
                string source = image.Source as FileImageSource;
                if (String.Equals(source, "bluebutton.png"))
                {
                    image.Source = "bluebutton2.png";
                }
                else
                {
                    image.Source = "bluebutton.png";
                }
            }

            UIReturn uiReturn = BranchActionsController.getInstance().reserveQueueBranch(service3);
            if (uiReturn.isSuccess)
            {
                BranchSessionModel.bookingQ = (Queue)uiReturn.returnObject;
                if (BranchSessionModel.bookingQ != null)
                {
                    Navigation.PushAsync(new BranchSummaryQueuePage());
                }
            }
            else
            {
                DisplayAlert("Error", uiReturn.getDescription(), "Cancel");
            }
        }

        public void OnService4(object sender, System.EventArgs args)
        {
            btn_service4.IsEnabled = false;
            text_service4.IsEnabled = false;

            Image image = sender as Image;
            if (image != null)
            {
                string source = image.Source as FileImageSource;
                if (String.Equals(source, "bluebutton.png"))
                {
                    image.Source = "bluebutton2.png";
                }
                else
                {
                    image.Source = "bluebutton.png";
                }
            }

            UIReturn uiReturn = BranchActionsController.getInstance().reserveQueueBranch(service4);
            if (uiReturn.isSuccess)
            {
                BranchSessionModel.bookingQ = (Queue)uiReturn.returnObject;
                if (BranchSessionModel.bookingQ != null)
                {
                    Navigation.PushAsync(new BranchSummaryQueuePage());
                }
            }
            else
            {
                DisplayAlert("Error", uiReturn.getDescription(), "Cancel");
            }
        }

        public void OnService5(object sender, System.EventArgs args)
        {
            btn_service5.IsEnabled = false;
            text_service5.IsEnabled = false;

            Image image = sender as Image;
            if (image != null)
            {
                string source = image.Source as FileImageSource;
                if (String.Equals(source, "bluebutton.png"))
                {
                    image.Source = "bluebutton2.png";
                }
                else
                {
                    image.Source = "bluebutton.png";
                }
            }

            UIReturn uiReturn = BranchActionsController.getInstance().reserveQueueBranch(service5);
            if (uiReturn.isSuccess)
            {
                BranchSessionModel.bookingQ = (Queue)uiReturn.returnObject;
                if (BranchSessionModel.bookingQ != null)
                {
                    Navigation.PushAsync(new BranchSummaryQueuePage());
                }
            }
            else
            {
                DisplayAlert("Error", uiReturn.getDescription(), "Cancel");
            }
        }

        public void OnService6(object sender, System.EventArgs args)
        {
            btn_service6.IsEnabled = false;
            text_service6.IsEnabled = false;

            Image image = sender as Image;
            if (image != null)
            {
                string source = image.Source as FileImageSource;
                if (String.Equals(source, "bluebutton.png"))
                {
                    image.Source = "bluebutton2.png";
                }
                else
                {
                    image.Source = "bluebutton.png";
                }
            }

            UIReturn uiReturn = BranchActionsController.getInstance().reserveQueueBranch(service6);
            if (uiReturn.isSuccess)
            {
                BranchSessionModel.bookingQ = (Queue)uiReturn.returnObject;
                if (BranchSessionModel.bookingQ != null)
                {
                    Navigation.PushAsync(new BranchSummaryQueuePage());
                }
            }
            else
            {
                DisplayAlert("Error", uiReturn.getDescription(), "Cancel");
            }
        }

        public void OnService7(object sender, System.EventArgs args)
        {
            btn_service7.IsEnabled = false;
            text_service7.IsEnabled = false;

            Image image = sender as Image;
            if (image != null)
            {
                string source = image.Source as FileImageSource;
                if (String.Equals(source, "bluebutton.png"))
                {
                    image.Source = "bluebutton2.png";
                }
                else
                {
                    image.Source = "bluebutton.png";
                }
            }

            UIReturn uiReturn = BranchActionsController.getInstance().reserveQueueBranch(service7);
            if (uiReturn.isSuccess)
            {
                BranchSessionModel.bookingQ = (Queue)uiReturn.returnObject;
                if (BranchSessionModel.bookingQ != null)
                {
                    Navigation.PushAsync(new BranchSummaryQueuePage());
                }
            }
            else
            {
                DisplayAlert("Error", uiReturn.getDescription(), "Cancel");
            }
        }

        public void OnService8(object sender, System.EventArgs args)
        {
            btn_service8.IsEnabled = false;
            text_service8.IsEnabled = false;

            Image image = sender as Image;
            if (image != null)
            {
                string source = image.Source as FileImageSource;
                if (String.Equals(source, "bluebutton.png"))
                {
                    image.Source = "bluebutton2.png";
                }
                else
                {
                    image.Source = "bluebutton.png";
                }
            }

            UIReturn uiReturn = BranchActionsController.getInstance().reserveQueueBranch(service8);
            if (uiReturn.isSuccess)
            {
                BranchSessionModel.bookingQ = (Queue)uiReturn.returnObject;
                if (BranchSessionModel.bookingQ != null)
                {
                    Navigation.PushAsync(new BranchSummaryQueuePage());
                }
            }
            else
            {
                DisplayAlert("Error", uiReturn.getDescription(), "Cancel");
            }
        }

        public void OnService9(object sender, System.EventArgs args)
        {
            btn_service9.IsEnabled = false;
            text_service9.IsEnabled = false;

            Image image = sender as Image;
            if (image != null)
            {
                string source = image.Source as FileImageSource;
                if (String.Equals(source, "bluebutton.png"))
                {
                    image.Source = "bluebutton2.png";
                }
                else
                {
                    image.Source = "bluebutton.png";
                }
            }

            UIReturn uiReturn = BranchActionsController.getInstance().reserveQueueBranch(service9);
            if (uiReturn.isSuccess)
            {
                BranchSessionModel.bookingQ = (Queue)uiReturn.returnObject;
                if (BranchSessionModel.bookingQ != null)
                {
                    Navigation.PushAsync(new BranchSummaryQueuePage());
                }
            }
            else
            {
                DisplayAlert("Error", uiReturn.getDescription(), "Cancel");
            }
        }

        public void OnService10(object sender, System.EventArgs args)
        {
            btn_service10.IsEnabled = false;
            text_service10.IsEnabled = false;

            Image image = sender as Image;
            if (image != null)
            {
                string source = image.Source as FileImageSource;
                if (String.Equals(source, "bluebutton.png"))
                {
                    image.Source = "bluebutton2.png";
                }
                else
                {
                    image.Source = "bluebutton.png";
                }
            }

            UIReturn uiReturn = BranchActionsController.getInstance().reserveQueueBranch(service10);
            if (uiReturn.isSuccess)
            {
                BranchSessionModel.bookingQ = (Queue)uiReturn.returnObject;
                if (BranchSessionModel.bookingQ != null)
                {
                    Navigation.PushAsync(new BranchSummaryQueuePage());
                }
            }
            else
            {
                DisplayAlert("Error", uiReturn.getDescription(), "Cancel");
            }
        }

        public void OnService11(object sender, System.EventArgs args)
        {
            btn_service11.IsEnabled = false;
            text_service11.IsEnabled = false;

            Image image = sender as Image;
            if (image != null)
            {
                string source = image.Source as FileImageSource;
                if (String.Equals(source, "bluebutton.png"))
                {
                    image.Source = "bluebutton2.png";
                }
                else
                {
                    image.Source = "bluebutton.png";
                }
            }

            UIReturn uiReturn = BranchActionsController.getInstance().reserveQueueBranch(service11);
            if (uiReturn.isSuccess)
            {
                BranchSessionModel.bookingQ = (Queue)uiReturn.returnObject;
                if (BranchSessionModel.bookingQ != null)
                {
                    Navigation.PushAsync(new BranchSummaryQueuePage());
                }
            }
            else
            {
                DisplayAlert("Error", uiReturn.getDescription(), "Cancel");
            }
        }

        public void OnService12(object sender, System.EventArgs args)
        {
            btn_service12.IsEnabled = false;
            text_service12.IsEnabled = false;

            Image image = sender as Image;
            if (image != null)
            {
                string source = image.Source as FileImageSource;
                if (String.Equals(source, "bluebutton.png"))
                {
                    image.Source = "bluebutton2.png";
                }
                else
                {
                    image.Source = "bluebutton.png";
                }
            }

            UIReturn uiReturn = BranchActionsController.getInstance().reserveQueueBranch(service12);
            if (uiReturn.isSuccess)
            {
                BranchSessionModel.bookingQ = (Queue)uiReturn.returnObject;
                if (BranchSessionModel.bookingQ != null)
                {
                    Navigation.PushAsync(new BranchSummaryQueuePage());
                }
            }
            else
            {
                DisplayAlert("Error", uiReturn.getDescription(), "Cancel");
            }
        }

        public void OnService13(object sender, System.EventArgs args)
        {
            btn_service13.IsEnabled = false;
            text_service13.IsEnabled = false;

            Image image = sender as Image;
            if (image != null)
            {
                string source = image.Source as FileImageSource;
                if (String.Equals(source, "bluebutton.png"))
                {
                    image.Source = "bluebutton2.png";
                }
                else
                {
                    image.Source = "bluebutton.png";
                }
            }

            UIReturn uiReturn = BranchActionsController.getInstance().reserveQueueBranch(service13);
            if (uiReturn.isSuccess)
            {
                BranchSessionModel.bookingQ = (Queue)uiReturn.returnObject;
                if (BranchSessionModel.bookingQ != null)
                {
                    Navigation.PushAsync(new BranchSummaryQueuePage());
                }
            }
            else
            {
                DisplayAlert("Error", uiReturn.getDescription(), "Cancel");
            }
        }

        public void OnService14(object sender, System.EventArgs args)
        {
            btn_service14.IsEnabled = false;
            text_service14.IsEnabled = false;

            Image image = sender as Image;
            if (image != null)
            {
                string source = image.Source as FileImageSource;
                if (String.Equals(source, "bluebutton.png"))
                {
                    image.Source = "bluebutton2.png";
                }
                else
                {
                    image.Source = "bluebutton.png";
                }
            }

            UIReturn uiReturn = BranchActionsController.getInstance().reserveQueueBranch(service14);
            if (uiReturn.isSuccess)
            {
                BranchSessionModel.bookingQ = (Queue)uiReturn.returnObject;
                if (BranchSessionModel.bookingQ != null)
                {
                    Navigation.PushAsync(new BranchSummaryQueuePage());
                }
            }
            else
            {
                DisplayAlert("Error", uiReturn.getDescription(), "Cancel");
            }
        }

        public void OnService15(object sender, System.EventArgs args)
        {
            btn_service15.IsEnabled = false;
            text_service15.IsEnabled = false;

            Image image = sender as Image;
            if (image != null)
            {
                string source = image.Source as FileImageSource;
                if (String.Equals(source, "bluebutton.png"))
                {
                    image.Source = "bluebutton2.png";
                }
                else
                {
                    image.Source = "bluebutton.png";
                }
            }

            UIReturn uiReturn = BranchActionsController.getInstance().reserveQueueBranch(service15);
            if (uiReturn.isSuccess)
            {
                BranchSessionModel.bookingQ = (Queue)uiReturn.returnObject;
                if (BranchSessionModel.bookingQ != null)
                {
                    Navigation.PushAsync(new BranchSummaryQueuePage());
                }
            }
            else
            {
                DisplayAlert("Error", uiReturn.getDescription(), "Cancel");
            }
        }

        public void OnService16(object sender, System.EventArgs args)
        {
            btn_service16.IsEnabled = false;
            text_service16.IsEnabled = false;

            Image image = sender as Image;
            if (image != null)
            {
                string source = image.Source as FileImageSource;
                if (String.Equals(source, "bluebutton.png"))
                {
                    image.Source = "bluebutton2.png";
                }
                else
                {
                    image.Source = "bluebutton.png";
                }
            }

            UIReturn uiReturn = BranchActionsController.getInstance().reserveQueueBranch(service16);
            if (uiReturn.isSuccess)
            {
                BranchSessionModel.bookingQ = (Queue)uiReturn.returnObject;
                if (BranchSessionModel.bookingQ != null)
                {
                    Navigation.PushAsync(new BranchSummaryQueuePage());
                }
            }
            else
            {
                DisplayAlert("Error", uiReturn.getDescription(), "Cancel");
            }
        }

        async void OnImageMainExit(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var answer = await DisplayAlert(Utils.getLabel(LabelConstants.MAIN_PAGE_LOGOUT), Utils.getLabel(LabelConstants.MAIN_PAGE_CONFIRMLOGOUT), "Yes", "No");
                if (answer == true)
                {
                    UIReturn Chklogout = BranchLoginController.getInstance().LogutBranch();
                    if (!Chklogout.isSuccess)
                    {
                        await DisplayAlert(App.AppicationName, Chklogout.getDescription(), "Close");
                    }
                    else
                    {
                        Navigation.InsertPageBefore(new BranchLoginPage(), this);
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
