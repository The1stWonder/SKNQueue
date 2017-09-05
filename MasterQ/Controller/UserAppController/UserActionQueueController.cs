using System;
namespace MasterQ
{
    public class UserActionQueueController
    {
        private static UserActionQueueController instance = new UserActionQueueController();

        UserActionQueueController() { }
        public static UserActionQueueController getInstance()
        {
            return instance;
        }
        public UIReturn callQueue(Branch b, Service s)
        {
            CallQueueRq req = UserActionQueueService.getInstance().getCallQueueRq(b, s);
            CallQueueRs res = UserActionQueueService.getInstance().callQueue(req);
            UIReturn ret = new UIReturn(res.header);
            return ret;
        }
        public UIReturn acceptQueue(Queue q)
        {
            AcceptQueueRq req = UserActionQueueService.getInstance().getAcceptQueueRq(q);
            AcceptQueueRs res = UserActionQueueService.getInstance().acceptQueue(req);
            UIReturn ret = new UIReturn(res.header);
            return ret;
        }
        public UIReturn skipQueue(Queue q)
        {
            SkipQueueRq req = UserActionQueueService.getInstance().getSkipQueueRq(q);
            SkipQueueRs res = UserActionQueueService.getInstance().skipQueue(req);
            UIReturn ret = new UIReturn(res.header);
            return ret;
        }
        public UIReturn finishQueue(Queue q)
        {
            FinishQueueRq req = UserActionQueueService.getInstance().getFinishQueueRq(q);
            FinishQueueRs res = UserActionQueueService.getInstance().finishQueue(req);
            UIReturn ret = new UIReturn(res.header);
            return ret;
        }
    }
}
