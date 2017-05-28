using System;
namespace MasterQ
{
	public static class LoginController
	{
		private static String authenFail = "Login Failed. Username Or Password incorrect!!!";

		public static Login authen(Login input)
		{
			Login ret = new Login(input.username , input.password);
			if (input.username.ToUpper().Equals("Admin") && input.password.ToUpper().Equals("Admin"))
			{
				ret.callBack.isSuccess = true;
				ret.isLogin = true;
				MCust.login = ret;
			}
			ret.callBack.setReturnMessage(String.Empty, authenFail);
			return ret;
		}
	}
}
