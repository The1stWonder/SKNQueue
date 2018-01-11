using System;
using Xamarin.Forms.Internals;

namespace MasterQ
{
    [Preserve(AllMembers = true)] //alexpook link all
    public class GetSessionRs
    {
        public HeaderResponse header { get; set; }
        public Queue queue { get; set; }
    }
}
