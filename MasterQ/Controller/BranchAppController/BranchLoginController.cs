using System;
using Newtonsoft.Json;
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

            if (res.header.isSuccess)
            {
                BranchSessionModel.loginBranch = res.branch;
                App.Database.SaveItem(DBConstants.ID_LOGIN_BRANCH, JsonConvert.SerializeObject(BranchSessionModel.loginBranch));
            }


			UIReturn ret = new UIReturn(res.header);
			return ret;
		}
		public UIReturn LogutBranch()
		{
            BranchLogoutRq req = BranchLoginService.getInstance().getBranchLogoutRq(BranchSessionModel.loginBranch);
            BranchLogoutRs res = BranchLoginService.getInstance().callLogout(req);

            if (res.header.isSuccess)
            {
                BranchSessionModel.loginBranch = null;
                App.Database.DeleteItem(DBConstants.ID_LOGIN_BRANCH);
            }

			UIReturn ret = new UIReturn(res.header);
			return ret;
		}
    }
}

