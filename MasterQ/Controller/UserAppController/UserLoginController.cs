using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MasterQ
{
	public class UserLoginController
	{
		private static UserLoginController instance = new UserLoginController();
		UserLoginController()
		{

		}
		public static UserLoginController getInstance()
		{
			return instance;
		}
		public UIReturn LoginUser(Login input)
		{
			if (String.IsNullOrEmpty(input.username)) return Constants.uiErrorEmptyUserName;
			if (String.IsNullOrEmpty(input.password)) return Constants.uiErrorEmptyPassword;

			UserLoginRq req = UserLoginService.getInstance().getUserLoginRq(input);
			UserLoginRs res = UserLoginService.getInstance().CallLogin(req);
			TempDB.loginUser = res.user;

			UIReturn ret = new UIReturn(res.header);
			return ret;
		}
	}
}
