using System;
using Xamarin.Forms.Internals;

namespace MasterQ
{
    [Preserve(AllMembers = true)] //alexpook link all
    public class Service
    {
        public String branchType { get; set; }
        public String closeTime { get; set; }
        public long counterNumber { get; set; }
        public String day { get; set; }
        public long estimateTime { get; set; }
        public String openTime { get; set; }
        public String provinceID { get; set; }
        public long queueNumber { get; set; }
        public String serviceDesc { get; set; }
        public String serviceID { get; set; }
        public String groupID { get; set; }
        public String groupName { get; set; }
        public String serviceName { get; set; }
        public String branchID { get; set; }
        public String memberID { get; set; }
        public String image { get; set; }
    }
}
