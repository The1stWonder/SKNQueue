using System;
using Xamarin.Forms.Internals;

namespace MasterQ
{
    [Preserve(AllMembers = true)] //alexpook link all
    public class RatingRq
    {
        public String tranID { get; set; }
        public String rank { get; set; }
    }
}
