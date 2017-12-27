using System;
using System.Collections.Generic;
using Plugin.Connectivity;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class SearchPage : ContentPage
	{
		public Province searchProvince = new Province();
		public District searchDistrict = new District();

		public SearchPage()
		{
			InitializeComponent();

            //App.TextSearch = "สกลนคร";

            if (CrossConnectivity.Current.IsConnected)
            {
                gennaratepicker();
                mSearchEntry.Placeholder = Utils.getLabel(LabelConstants.SEARCH_PAGE_SEARCH);
            }
		}

		public void gennaratepicker()
		{
			//List<Province> provinces = (List<Province>)SearchController.getInstance().getProvinces().returnObject;
			//foreach (Province p in provinces)
			//{
			//	ColumnPicker.Items.Add(p.provinceNameTh);

			//}
			//ColumnPicker.Unfocused += (sender, args) =>
			//{
			//	if (ColumnPicker.SelectedIndex >= 0)
			//	{
			//		Province p = provinces.ToArray()[ColumnPicker.SelectedIndex];
			//		List<District> districts = (List<District>)SearchController.getInstance().getDistricts(p).returnObject;
			//		ColumnPicker2.Items.Clear();
			//		searchDistrict = new District();
			//		foreach (District d in districts)
			//		{
			//			ColumnPicker2.Items.Add(d.districtNameTh);
			//		}
			//		searchProvince = p;
			//		ColumnPicker2.Unfocused += (sender2, args2) =>
			//		{
			//			if (ColumnPicker2.SelectedIndex >= 0)
			//			{
			//				District d = districts.ToArray()[ColumnPicker2.SelectedIndex];
			//				searchDistrict = d;
			//			}
			//		};
			//	}
			//};

            if (App.TextSearch != "")
            {
                var searchtxt = App.TextSearch.Trim();
                mSearchEntry.Text = searchtxt;
                UIReturn uiR = SearchController.getInstance().getBranches(searchtxt);
                List<Branch> Branch = (List<Branch>)uiR.returnObject;
                BranchView.ItemsSource = Branch;
                if (!uiR.isSuccess)
                {
                    DisplayAlert(App.AppicationName, uiR.getDescription(), "Cancel");
                }
            }
            else
            {
                var searchtxt = "";
                UIReturn uiR = SearchController.getInstance().getBranches(searchtxt);
                List<Branch> Branch = (List<Branch>)uiR.returnObject;
                BranchView.ItemsSource = Branch;
                if (!uiR.isSuccess)
                {
                    DisplayAlert(App.AppicationName, uiR.getDescription(), "Cancel");
                }
            }
		}

		public void OnImageSearch(object sender, System.EventArgs args)
		{

            //if (ColumnPicker.SelectedIndex >= 0)
            //{
            //	UIReturn uiR = SearchController.getInstance().getBranches(searchProvince, searchDistrict);
            //	List<Branch> Branch = (List<Branch>)uiR.returnObject;
            //	BranchView.ItemsSource = Branch;
            //	if (!uiR.isSuccess)
            //	{
            //		DisplayAlert("", uiR.getDescription(), "Cancel");
            //	}
            //}
            //        else if (mSearchEntry.Text != null)
            //        {
            //            var searchtxt = mSearchEntry.Text;
            //            UIReturn uiR = SearchController.getInstance().getBranches(searchtxt);
            //List<Branch> Branch = (List<Branch>)uiR.returnObject;
            //BranchView.ItemsSource = Branch;
            //if (!uiR.isSuccess)
            //{
            //	DisplayAlert("", uiR.descriptionEN, "Cancel");
            //}
            //}

            if (CrossConnectivity.Current.IsConnected)
            {
                if (mSearchEntry.Text != null)
                {
                    var searchtxt = mSearchEntry.Text;
                    App.TextSearch = searchtxt;
                    UIReturn uiR = SearchController.getInstance().getBranches(searchtxt);
                    List<Branch> Branch = (List<Branch>)uiR.returnObject;
                    BranchView.ItemsSource = Branch;
                    if (!uiR.isSuccess)
                    {
                        DisplayAlert(App.AppicationName, uiR.getDescription(), "Cancel");
                    }
                }
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
		}

        public void itemTapped(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                Branch BranchID = (Branch)BranchView.SelectedItem;
                Navigation.PushAsync(new ServicePage(BranchID));
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }

        public void OnImageBack(object sender, System.EventArgs args)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                Navigation.PushAsync(new MainPage());
                App.TextSearch = "";
            }
            else
            {
                DisplayAlert(App.AppicationName, App.NoInternet, "Close");
            }
        }
	}
}
