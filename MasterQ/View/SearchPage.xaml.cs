using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
            gennaratepicker();
        }

        public void gennaratepicker()
        {
            List<Province> provinces = (List<Province>)SearchController.getInstance().getProvinces().returnObject;
			foreach (Province p in provinces )
            {
                ColumnPicker.Items.Add(p.provinceNameTh);
            }
            ColumnPicker.SelectedIndexChanged += (sender, args) =>
            {
                Province p = provinces.ToArray()[ColumnPicker.SelectedIndex];
                List<District> districts = (List<District>)SearchController.getInstance().getDistricts(p).returnObject;
                ColumnPicker2.Items.Clear();
                foreach (District d in districts)
				{
                    ColumnPicker2.Items.Add(d.districtNameTh);
				}
			};
            
                //ColumnPicker2.SelectedIndexChanged += (sender2, args2) =>
                //{
                //    District d = districts.ToArray()[ColumnPicker2.SelectedIndex];
                //    UIReturn uiR = SearchController.getInstance().getBranches(p, d);
                //    if (uiR.isSuccess)
                //    {
                //        List<Branch> b = (List<Branch>)uiR.returnObject;
                //        DisplayAlert("Branch", b.ToArray().Length + "", "Cancel");
                //    }
                //    else
                //    {
                //        DisplayAlert("A", uiR.getDescription(), "Cancel");
                //    }

                //};


        }

		void Search_Clicked(object sender, EventArgs e)
		{
			//var Branch = new List<Detail> {
			//	new Person ("Steve", 21, "USA"),
			//	new Person ("John", 37, "USA"),
			//	new Person ("Tom", 42, "UK"),
			//	new Person ("Lucas", 29, "Germany"),
			//	new Person ("Tariq", 39, "UK"),
			//	new Person ("Jane", 30, "USA")
			//};

			//listView.ItemsSource = Detail;
		}

    }
}
