using System;
namespace MasterQ
{
    public class BranchActionsController
    {
        private static BranchActionsController instance = new BranchActionsController();
        BranchActionsController(){}
        public static BranchActionsController getInstance()
        {
            return instance;
        }
		public UIReturn getBranchServices()
		{
            BranchGetServicesRq req = BranchActionService.getInstance().getBranchGetServicesRq(BranchSessionModel.loginBranch);
            BranchGetServicesRs res = BranchActionService.getInstance().getBranchServices(req);
			UIReturn ret = new UIReturn(res.header);
            ret.returnObject = res.services;
			return ret;
		}
        public UIReturn reserveQueueBranch(Service service)
		{
            BranchReserveQueueRq req = BranchActionService.getInstance().getBranchReserveQueueRq(service);
            BranchReserveQueueRs res = BranchActionService.getInstance().reserveQueue(req);

			UIReturn ret = new UIReturn(res.header);
            ret.returnObject = res.queue;
			return ret;
		}
    }
}
