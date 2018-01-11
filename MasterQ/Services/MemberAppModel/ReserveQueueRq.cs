using System;
using Xamarin.Forms.Internals;

namespace MasterQ
{
    [Preserve(AllMembers = true)] //alexpook link all
    public class ReserveQueueRq
    {
        public string branchID { get; set; }
        public string serviceID { get; set; }
        public string queueType { get; set; }
        public string memberID { get; set; }
    }
}
