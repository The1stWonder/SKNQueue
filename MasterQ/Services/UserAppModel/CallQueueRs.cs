using System;
namespace MasterQ
{
    public class CallQueueRs
	{
		public HeaderResponse header { get; set; }
        public int queueNumber { get; set; }
        public String tranID { get; set; }
    }
}
