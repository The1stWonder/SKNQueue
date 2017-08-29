using System;
namespace MasterQ
{
    public class ReserveQueueRq
    {
        public string branchID { get; set; }
        public string serviceID { get; set; }
        public string queueType { get; set; }
        public string memberID { get; set; }
    }
}
