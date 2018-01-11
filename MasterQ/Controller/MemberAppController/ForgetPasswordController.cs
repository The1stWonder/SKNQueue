using System;
using Xamarin.Forms.Internals;

namespace MasterQ
{
    [Preserve(AllMembers = true)] //alexpook link all
    public class ForgetPasswordController
    {
        private static ForgetPasswordController instance = new ForgetPasswordController();

        ForgetPasswordController() { }
    
		public static ForgetPasswordController getInstance()
		{
			return instance;
		}
        public UIReturn getPassword(Login input)
		{
            if (String.IsNullOrEmpty(input.username)) return Constants.uiErrorEmptyEmail;
            if (!Validate.isEmailFormat(input.username)) return Constants.uiErrorInvalidEmail;

            ForgetPasswordRq req = LoginService.getInstance().getForgetPasswordRq(input.username);
            ForgetPasswordRs res = LoginService.getInstance().CallForgetPassword(req);

            UIReturn ret = new UIReturn(res.header);
            return ret;
		}
	}
}
