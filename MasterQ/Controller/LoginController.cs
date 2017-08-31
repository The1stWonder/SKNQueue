using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

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
        public UIReturn Login(Login input)
        {
            if (Constants.isAppForMember())
            {
                return LoginMember(input);
            }
            else if (Constants.isAppForUser())
            {
                return LoginUser(input);
            }
            return new UIReturn();
        }
        public UIReturn LoginMember(Login input)
        {
            if (String.IsNullOrEmpty(input.username)) return Constants.uiErrorEmptyUserName;
            if (String.IsNullOrEmpty(input.password)) return Constants.uiErrorEmptyPassword;
            if (!Validate.email(input.username)) return Constants.uiErrorInvalidEmail;

            LoginRq req = LoginService.getInstance().getLoginRq(input);
            LoginRs res = LoginService.getInstance().CallLogin(req);
            TempDB.loginMember = res.member;

            UIReturn ret = new UIReturn(res.header);
            return ret;
        }
        public UIReturn LoginUser(Login input)
        {
            if (String.IsNullOrEmpty(input.username)) return Constants.uiErrorEmptyUserName;
            if (String.IsNullOrEmpty(input.password)) return Constants.uiErrorEmptyPassword;

            UserLoginRq req = LoginService.getInstance().getUserLoginRq(input);
            UserLoginRs res = LoginService.getInstance().CallLogin(req);
            TempDB.loginUser = res.user;

            UIReturn ret = new UIReturn(res.header);
            return ret;
        }
    }
}
