using System;
namespace MasterQ
{
    public class UserActionServiceController
    {
        private static UserActionServiceController instance = new UserActionServiceController();
        UserActionServiceController() { }
        public static UserActionServiceController getInstance()
        {
            return instance;
        }
        public UIReturn getServices(Branch b)
        {
            GetServiceRq req = UserActionService.getInstance().getGetServiceRq(b);
            GetServiceRs res = UserActionService.getInstance().getServices(req);
            UIReturn ret = new UIReturn(res.header);
            return ret;
        }
        public UIReturn openService(Branch b, Service s, String counterNumber)
        {
            OpenServiceRq req = UserActionService.getInstance().getOpenServiceRq(b, s, counterNumber);
            OpenServiceRs res = UserActionService.getInstance().openService(req);
            UIReturn ret = new UIReturn(res.header);
            return ret;
        }
    }
}
}
