using System;
namespace MasterQ
{
	public static class RegisterController
	{
        public static void register(Member input)
        {




            Login memberLogin = new Login(input.memberName,input.password);
			memberLogin.isLogin = true;

            MCust.login = memberLogin;
            MCust.member = input;
        }
	}
}
