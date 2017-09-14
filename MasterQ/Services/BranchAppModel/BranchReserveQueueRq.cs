using System;
namespace MasterQ
{
    public class BranchReserveQueueRq
	{
		public string branchID { get; set; }
		public string serviceID { get; set; }
		public string queueType { get; set; }
    }
}
