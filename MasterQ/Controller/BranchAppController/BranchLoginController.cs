using System;

using Xamarin.Forms;

namespace MasterQ
{
    public class BranchLoginController : ContentPage
    {
		private static BranchLoginController instance = new BranchLoginController();

		BranchLoginController()
		{

		}
		public static BranchLoginController getInstance()
		{
			return instance;
		}
		public UIReturn LoginBranch(Login input)
		{
			if (String.IsNullOrEmpty(input.username)) return Constants.uiErrorEmptyUserName;
			if (String.IsNullOrEmpty(input.password)) return Constants.uiErrorEmptyPassword;

            BranchLoginRq req = BranchLoginService.getInstance().getBranchLoginRq(input);
            BranchLoginRs res = BranchLoginService.getInstance().CallLogin(req);
            BranchSessionModel.loginBranch = res.branch;

			UIReturn ret = new UIReturn(res.header);
			return ret;
		}
		public UIReturn LogutBranch()
		{
            BranchLogoutRq req = BranchLoginService.getInstance().getBranchLogoutRq(BranchSessionModel.loginBranch);
            BranchLogoutRs res = BranchLoginService.getInstance().callLogout(req);
            BranchSessionModel.loginBranch = null;

			UIReturn ret = new UIReturn(res.header);
			return ret;
		}
    }
}

