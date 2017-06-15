using System;
namespace MasterQ
{
	public static class LoginController
	{
		private static String authenFail = "Login Failed. Username Or Password incorrect!!!";

		public static void authen(Login input)
		{
			if (String.IsNullOrEmpty(input.username))
			{
				input.callBack.isSuccess = false;
				input.callBack.setReturnMessage(String.Empty, "Please input username");
				return;
			}
			if (String.IsNullOrEmpty(input.password))
			{
				input.callBack.isSuccess = false;
				input.callBack.setReturnMessage(String.Empty, "Please input password");
				return;
			}
			Validation varEmail = new Validation(input.username);
			Validate.validateEmail(varEmail);
			if (!varEmail.callBack.isSuccess)
			{
				input.callBack.isSuccess = false;
				input.callBack.setReturnMessage(String.Empty, varEmail.callBack.message);
				return;
			}
			if (input.username.ToUpper().Equals("ADMIN@MASTERQ.COM") && input.password.Equals("admin"))
			{
				input.callBack.isSuccess = true;
				input.isLogin = true;
				MCust.login = input;
			}
			input.callBack.setReturnMessage(String.Empty, authenFail);
		}
	}
}
