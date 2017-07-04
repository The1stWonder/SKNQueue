using System;
namespace MasterQ.Controller
{
	public static class ForgetPasswordController
	{
        public static UIReturn getPassword(Login input)
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
		private static bool isEmptyEmail(Login input)
		{
			return String.IsNullOrEmpty(input.username);
		}
		private static bool isValidEmail(Login input)
		{
			return Validate.validateEmail(new Validation(input.username));
		}
		private static bool isExistEmail(Login input)
		{
			return input.username.ToUpper().Equals("ADMIN@MASTERQ.COM"); ;
		}
		private static void sendEmail(Login input)
		{

		}
	}
}
