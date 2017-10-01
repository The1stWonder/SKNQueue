using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class SearchPage : ContentPage
	{
		bool timercheck = true;
		public Province searchProvince = new Province();
		public District searchDistrict = new District();
		int Recount = 0;
		int ChkTime = 0;
		int ChkTime2 = 0;

		public SearchPage()
		{
            
			InitializeComponent();
			gennaratepicker();

			if (SessionModel.bookingQ != null)
			{
				if (timercheck == true)
				{
                    if (SessionModel.bookingQ.queueNumber != 0)
                    {
                        ChkTime = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;
                        timerStart();
                    }
				}
			}
		}

        public void timerStart()
        {
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
                {
                    Recount = Recount + 1;
                    // do something every 60 seconds
                    // ItemsPage i = new ItemsPage();
                    if (timercheck == true && QueuePage.timercount != 0)
                    {
                        QueuePage.timercount--;
                        QueuePage.timercount.ToString();

						if (QueuePage.timercount.ToString() == "0")
						{
							return false;
						}

                        if (Recount == 10)
                        {
                            Recount = 0;
                            Service s = new Service();
                            s.serviceID = SessionModel.bookingQ.serviceID;
                            s.branchID = SessionModel.bookingQ.branchID;
                            Queue Queue = (Queue)ReserveQController.getInstance().reserveQueue(s).returnObject;
                            ChkTime2 = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;
                            if (ChkTime != ChkTime2)
                            {
                                ChkTime = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;
                                QueuePage.timercount = SessionModel.bookingQ.estimateTime.GetHashCode() * 60;
                            }
                        }
                        return true; // runs again, or false to stop
                    }
                    else
                    {
                        return false;
                    }
                });
        }

		public void gennaratepicker()
		{
			List<Province> provinces = (List<Province>)SearchController.getInstance().getProvinces().returnObject;
			foreach (Province p in provinces)
			{
				ColumnPicker.Items.Add(p.provinceNameTh);

			}
			ColumnPicker.Unfocused += (sender, args) =>
			{
				if (ColumnPicker.SelectedIndex >= 0)
				{
					Province p = provinces.ToArray()[ColumnPicker.SelectedIndex];
					List<District> districts = (List<District>)SearchController.getInstance().getDistricts(p).returnObject;
					ColumnPicker2.Items.Clear();
					searchDistrict = new District();
					foreach (District d in districts)
					{
						ColumnPicker2.Items.Add(d.districtNameTh);
					}
					searchProvince = p;
					ColumnPicker2.Unfocused += (sender2, args2) =>
					{
						if (ColumnPicker2.SelectedIndex >= 0)
						{
							District d = districts.ToArray()[ColumnPicker2.SelectedIndex];
							searchDistrict = d;
						}
					};
				}
			};
		}

		public void OnImageSearch(object sender, System.EventArgs args)
		{
			
			if (ColumnPicker.SelectedIndex >= 0)
			{
				UIReturn uiR = SearchController.getInstance().getBranches(searchProvince, searchDistrict);
				List<Branch> Branch = (List<Branch>)uiR.returnObject;
				BranchView.ItemsSource = Branch;
				if (!uiR.isSuccess)
				{
					DisplayAlert("Error", uiR.getDescription(), "Cancel");
				}
			}
            else if (mSearchEntry.Text != null)
            {
                var searchtxt = mSearchEntry.Text;
                UIReturn uiR = SearchController.getInstance().getBranches(searchtxt);
				List<Branch> Branch = (List<Branch>)uiR.returnObject;
				BranchView.ItemsSource = Branch;
				if (!uiR.isSuccess)
				{
					DisplayAlert("Error", uiR.getDescription(), "Cancel");
				}
            }
		}

        public void itemTapped(object sender, System.EventArgs args)
        {
            timercheck = false;
            Branch BranchID = (Branch)BranchView.SelectedItem;
            Navigation.PushAsync(new ServicePage(BranchID));
        }

		public void OnImageBack(object sender, System.EventArgs args)
		{
			timercheck = false;
            Navigation.PushAsync(new MainPage());
		}


	}
}
