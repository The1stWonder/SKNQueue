using System;
namespace MasterQ
{
	public static class LoginController
	{
		private static String authenFail = "Login Failed. Username Or Password incorrect!!!";

		public static Validation authen(Login input)
		{
			Validation ret = new Validation(MCust.login.username + "|" + MCust.login.password);
			if (input.username.ToUpper().Equals("Admin") && input.password.ToUpper().Equals("Admin"))
			{
				ret.validateResult = true;
				MCust.login = input;
				MCust.login.isLogin = true;
			}
			ret.setReturnMessage(String.Empty, authenFail);
			return ret;
		}
	}
}
