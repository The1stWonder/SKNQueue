using System;
using Xamarin.Forms.Internals;

namespace MasterQ
{
    [Preserve(AllMembers = true)] //alexpook link all
    public class District
	{
		public string districtID { get; set; }
		public string districtNameEn { get; set; }
		public string districtNameTh { get; set; }
		public string provinceID { get; set; }
    }
}
