using System;
using System.Collections.Generic;
using Xamarin.Forms.Internals;

namespace MasterQ
{
    [Preserve(AllMembers = true)] //alexpook link all
    public class GroupService
    {
        public String groupID { get; set; }
        public String groupName { get; set; }
        public List<Service> services { get; set; }
    }
}
