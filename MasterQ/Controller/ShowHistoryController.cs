using System;
namespace MasterQ
{
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
            GetHistoryRs res = MemberService.getInstance().CallGetHistory(input);

			UIReturn ret = new UIReturn(res.header);
            ret.returnObject = res.histories;
			return ret;
		}
    }
}
