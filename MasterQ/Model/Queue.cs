using System;
namespace MasterQ
{
	public class Queue
	{
		public String branchID { get; set; }
		public long estimateTime { get; set; }
        public DateTime startTime { get; set; }
		public long queueNumber { get; set; }
		public String serviceID { get; set; }
		public String tranID { get; set; }
        public String rank { get; set; }
	}
}
