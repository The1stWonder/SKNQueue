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
		public UIReturn reserveQueue(String branchId,String serviceId)
		{
            Service inputService = TempDB.services.Find(s => s.serviceID == serviceId && s.branchID==branchId);
            ReserveQueueRs res = ReserveQueueService.getInstance().CallReserveQueue(inputService);

			UIReturn ret = new UIReturn(res.header);
            ret.returnObject = res.queue;
			return ret;
		}
	}
}
