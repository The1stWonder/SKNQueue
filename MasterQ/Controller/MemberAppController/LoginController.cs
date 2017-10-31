using System;
using Newtonsoft.Json;

namespace MasterQ
{
    public class LoginController
    {
        private static LoginController instance = new LoginController();
        LoginController()
        {

        }
        public static LoginController getInstance()
        {
            return instance;
        }
        //public async Task<UIReturn> AuthenuserAsync(Login input)
        //{
        //    if (isEmptyUserName(input)) return new UIReturn(input, false, "", Constants.emptyUserName);
        //    if (isEmptyPassword(input)) return new UIReturn(input, false, "", Constants.emptyPassword);
        //    if (!isValidEmail(input)) return new UIReturn(input, false, "", Constants.invalidEmail);

        //    //List<SampleJSONService> result = await SampleService.CallGetAsync();
        //    SampleJSONService result = await SampleService.CallPostAsync();

        //    UIReturn ret = new UIReturn(input);
        //    if (authen(input, result))
        //    {
        //        input.isLogin = true;
        //        MCust.login = input;
        //    }
        //    else
        //    {
        //        ret.setFail("", Constants.authenFail);
        //    }
        //    return ret;
        //}
        public UIReturn LoginMember(Login input)
        {
            if (String.IsNullOrEmpty(input.username)) return Constants.uiErrorEmptyUserName;
            if (String.IsNullOrEmpty(input.password)) return Constants.uiErrorEmptyPassword;
            if (!Validate.isEmailFormat(input.username)) return Constants.uiErrorInvalidEmail;

            LoginRq req = LoginService.getInstance().getLoginRq(input);
            LoginRs res = LoginService.getInstance().CallLogin(req);
            SessionModel.loginMember = res.member;

            if(res.header.isSuccess){
                SessionTable loginMember = new SessionTable();
                loginMember.ID = DBConstants.ID_LOGIN_MEMBER;
                loginMember.JSON_DATA = JsonConvert.SerializeObject(SessionModel.loginMember);
                App.Database.SaveItem(loginMember);
            }

            UIReturn ret = new UIReturn(res.header);
            return ret;
		}
		public UIReturn LogutMember()
		{
            LogoutRq req = LoginService.getInstance().getLogoutRq(SessionModel.loginMember);
            LogoutRs res = LoginService.getInstance().callLogout(req);
            SessionModel.loginMember = null;

            if (res.header.isSuccess)
            {
                App.Database.DeleteItem(DBConstants.ID_LOGIN_MEMBER);
            }

			UIReturn ret = new UIReturn(res.header);
			return ret;
		}
    }
}
