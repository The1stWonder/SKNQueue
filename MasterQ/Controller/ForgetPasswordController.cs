using System;
namespace MasterQ.Controller
{
	public static class ForgetPasswordController
	{
		public static void getPassword(Login input)
		{
			if (isEmptyEmail(input)) return;
			if (isValidEmail(input)) return;

			if (isExistEmail(input))
			{
				sendEmail(input);
			}
		}
		private static bool isEmptyEmail(Login input)
		{
			bool ret = String.IsNullOrEmpty(input.username);
			input.callBack.setReturn(!ret, String.Empty, Constants.emptyEmail);
			return ret;
		}
		private static bool isValidEmail(Login input)
		{
			Validation varEmail = new Validation(input.username);
			Validate.validateEmail(varEmail);
			bool ret = varEmail.callBack.isSuccess;
			input.callBack.setReturn(ret, String.Empty, varEmail.callBack.message);
			return ret;
		}
		private static bool isExistEmail(Login input)
		{
			bool ret = input.username.ToUpper().Equals("ADMIN@MASTERQ.COM");
			input.callBack.setReturn(ret, String.Empty, Constants.notExistingEmail);
			return ret;
		}
		private static void sendEmail(Login input)
		{

		}
	}
}
