using System;
using Xamarin.Forms.Internals;

namespace MasterQ
{
    [Preserve(AllMembers = true)] //alexpook link all
    public class ShowHistoryController
    {
		private static ShowHistoryController instance = new ShowHistoryController();
        ShowHistoryController(){ }
		public static ShowHistoryController getInstance()
		{
			return instance;
		}
        public UIReturn getHistory(Member input)
		{
            GetHistoryRq req = MemberService.getInstance().getGetHistoryRq(input);
            GetHistoryRs res = MemberService.getInstance().CallGetHistory(req);

			UIReturn ret = new UIReturn(res.header);
            ret.returnObject = res.histories;
			return ret;
		}
    }
}
