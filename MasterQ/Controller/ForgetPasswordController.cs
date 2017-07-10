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
            if (isEmptyEmail(input)) return new UIReturn(input,false,"",Constants.emptyEmail);
            if (isValidEmail(input)) return new UIReturn(input, false, "", Constants.invalidEmail);

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
		private bool isEmptyEmail(Login input)
		{
			return String.IsNullOrEmpty(input.username);
		}
		private bool isValidEmail(Login input)
		{
			return Validate.validateEmail(new Validation(input.username));
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
