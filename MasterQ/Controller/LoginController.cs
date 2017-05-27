using System;
namespace MasterQ
{
	public static class LoginController
	{
		private static String authenFail = "Login Failed. Username Or Password incorrect!!!";

		public static Validation authen()
		{
			Validation ret = new Validation(MCust.login.username + "|" + MCust.login.password);
			ret.validateResult = false;
			if (MCust.login.username.ToUpper().Equals("Admin") && MCust.login.password.ToUpper().Equals("Admin"))
			{
				ret.validateResult = true;
			}
			ret.setReturn(ret.validateResult, String.Empty, authenFail);
			return ret;
		}
	}
}
