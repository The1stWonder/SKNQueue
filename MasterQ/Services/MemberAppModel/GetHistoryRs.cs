using System;
using System.Collections.Generic;
using Xamarin.Forms.Internals;

namespace MasterQ
{
    [Preserve(AllMembers = true)] //alexpook link all
    public class GetHistoryRs
    {
        public HeaderResponse header { get; set; }
        public List<History> histories { get; set; }
    }
}
