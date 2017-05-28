using System;
namespace MasterQ
{
	public static class LoginController
	{
		private static String authenFail = "Login Failed. Username Or Password incorrect!!!";

		public static void authen(Login input)
		{
			if (input.username.ToUpper().Equals("Admin") && input.password.ToUpper().Equals("Admin"))
			{
				input.callBack.isSuccess = true;
				input.isLogin = true;
				MCust.login = input;
			}
			input.callBack.setReturnMessage(String.Empty, authenFail);
		}
	}
}
