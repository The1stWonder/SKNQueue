using System;
namespace MasterQ
{
    public class History
    {
		public string branchID { get; set; }
		public string memberID { get; set; }
		public DateTime queueDate { get; set; }
        public string queueNumber { get; set; }
		public string queueType { get; set; }
		public long ranking { get; set; }
		public string serviceID { get; set; }
		public string timeAccept { get; set; }
		public string timeCall { get; set; }
		public string timeFinish { get; set; }
    }
}
