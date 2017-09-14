using System;
using System.Collections.Generic;

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
			gennaratepicker();
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
				List<Branch> Branch = (List<Branch>)SearchController.getInstance().getBranches(searchProvince, searchDistrict).returnObject;
				BranchView.ItemsSource = Branch;
			}
            else if (mSearchEntry.Text != null)
            {
                var searchtxt = mSearchEntry.Text;
                List<Branch> Branch = (List<Branch>)SearchController.getInstance().getBranches(searchtxt).returnObject;
				BranchView.ItemsSource = Branch;
            }
		}

		public void itemTapped(object sender, System.EventArgs args)
		{
            Branch BranchID = (Branch)BranchView.SelectedItem;
            Navigation.PushAsync(new ServicePage(BranchID));
		}

		public void OnImageBack(object sender, System.EventArgs args)
		{
            Navigation.PushAsync(new MainPage());
		}


	}
}
