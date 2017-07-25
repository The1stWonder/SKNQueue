using System;
namespace MasterQ
{
	public class ForgetPasswordController
	{
		private static ForgetPasswordController instance = new ForgetPasswordController();


		ForgetPasswordController()
		{

		}
		public static ForgetPasswordController getInstance()
		{
			return instance;
		}
        public UIReturn getPassword(Login input)
		{
            if (String.IsNullOrEmpty(input.username)) return new UIReturn(input, false, Constants.GROUPS_VALIDATE, Constants.FUNCTIONS_EMAIL, Constants.CODE_INVALID_EMAIL);
                if (!Validate.email(input.username)) return new UIReturn(input, false, Constants.GROUPS_VALIDATE, Constants.FUNCTIONS_EMAIL, Constants.CODE_INVALID_EMAIL);

            ForgetPasswordRs res = LoginService.getInstance().CallForgetPassword(input.username);

            UIReturn ret = new UIReturn(input,res.header);
            return ret;
		}
		private bool isExistEmail(Login input)
		{
			return input.username.ToUpper().Equals("ADMIN@MASTERQ.COM"); ;
		}
		private void sendEmail(Login input)
		{

		}
	}
}
