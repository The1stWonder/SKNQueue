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
            ret.returnObject = res.services;
            return ret;
        }
        public UIReturn openService(Branch b, Service s, String counterNumber)
        {
            if (String.IsNullOrEmpty(counterNumber)) return Constants.uiErrorEmptyCounterNumber;

            OpenServiceRq req = UserActionService.getInstance().getOpenServiceRq(b, s, counterNumber);
            OpenServiceRs res = UserActionService.getInstance().openService(req);
            UIReturn ret = new UIReturn(res.header);
            return ret;
        }
    }

}
