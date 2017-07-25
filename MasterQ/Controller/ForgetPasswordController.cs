using System;
namespace MasterQ
{
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
            if (!Validate.email(input.username)) return Constants.uiErrorInvalidEmail;

            ForgetPasswordRs res = LoginService.getInstance().CallForgetPassword(input.username);

            UIReturn ret = new UIReturn(res.header);
            return ret;
		}
	}
}
