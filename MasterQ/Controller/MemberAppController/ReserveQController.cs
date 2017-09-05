using System;
namespace MasterQ
{
	public class ReserveQController
	{
		private static ReserveQController instance = new ReserveQController();


		ReserveQController()
		{ }
		public static ReserveQController getInstance()
		{
			return instance;
		}
		public UIReturn reserveQueue(Service input)
		{
            Service inputService = TempDB.services.Find(s => s.serviceID == input.serviceID && s.branchID==input.branchID);
            ReserveQueueRq req = ReserveQueueService.getInstance().getReserveQueueRq(inputService); 
            ReserveQueueRs res = ReserveQueueService.getInstance().CallReserveQueue(req);

			UIReturn ret = new UIReturn(res.header);
            ret.returnObject = res.queue;
			return ret;
		}
        public UIReturn cancelQueue(Queue input)
		{
            CancelQueueRq req = ReserveQueueService.getInstance().getCancelQueueRq(input);
            CancelQueueRs res = ReserveQueueService.getInstance().cancelQueue(req);

			UIReturn ret = new UIReturn(res.header);
			return ret;
		}
	}
}
