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
            Service inputService = SessionModel.services.Find(s => s.serviceID == input.serviceID && s.branchID == input.branchID);
            ReserveQueueRq req = ReserveQueueService.getInstance().getReserveQueueRq(inputService);
            ReserveQueueRs res = ReserveQueueService.getInstance().CallReserveQueue(req);
            SessionModel.bookingQ = res.queue;

            UIReturn ret = new UIReturn(res.header);
            ret.returnObject = res.queue;
            return ret;
        }
        public UIReturn cancelQueue(Queue input)
        {
            CancelQueueRq req = ReserveQueueService.getInstance().getCancelQueueRq(input);
            CancelQueueRs res = ReserveQueueService.getInstance().cancelQueue(req);
            SessionModel.bookingQ = null;

            UIReturn ret = new UIReturn(res.header);
            return ret;
        }
        public UIReturn ratingStaff(Queue input)
        {
            RatingRq req = ReserveQueueService.getInstance().getRatingRq(input);
            RatingRs res = ReserveQueueService.getInstance().rating(req);
            SessionModel.bookingQ = null;

            UIReturn ret = new UIReturn(res.header);
            return ret;
        }
    }
}
