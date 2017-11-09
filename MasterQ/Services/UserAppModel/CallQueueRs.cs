using System;
namespace MasterQ
{
    public class CallQueueRs
	{
		public HeaderResponse header { get; set; }
        public string queueNumber { get; set; }
        public String tranID { get; set; }
    }
}
