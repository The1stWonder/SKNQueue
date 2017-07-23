using System;
namespace MasterQ.Controller
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
            if (String.IsNullOrEmpty(input.username)) return new UIReturn(input,false,"",Constants.emptyEmail);
            if (!Validate.email(input.username)) return new UIReturn(input, false, "", Constants.invalidEmail);

            UIReturn ret = new UIReturn(input);
			if (isExistEmail(input))
			{
				sendEmail(input);
                ret.setSuccess();
            }else{
                return new UIReturn(input, false, "", Constants.notExistingEmail);
            }
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
