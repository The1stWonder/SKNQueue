using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
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

            if(res.header.isSuccess){
                UserSessionModel.loginUser = res.user;
                App.Database.SaveItem(DBConstants.ID_LOGIN_USER, JsonConvert.SerializeObject(UserSessionModel.loginUser));
            }

			UIReturn ret = new UIReturn(res.header);
			return ret;
		}
        public UIReturn LogutUser()
		{
            UserLogoutRq req = UserLoginService.getInstance().getUserLogoutRq(UserSessionModel.loginUser);
            UserLogoutRs res = UserLoginService.getInstance().callLogout(req);

            if (res.header.isSuccess)
            {
                UserSessionModel.loginUser = null;
                App.Database.DeleteItem(DBConstants.ID_LOGIN_USER);
            }

			UIReturn ret = new UIReturn(res.header);
			return ret;
		}
	}
	
}
