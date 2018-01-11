using System;
using System.Collections.Generic;
using Xamarin.Forms.Internals;

namespace MasterQ
{
    [Preserve(AllMembers = true)] //alexpook link all
    public class GetProvincesRs
    {
		public HeaderResponse header { get; set; }
        public List<Province> provinces { get; set; }
    }
}
