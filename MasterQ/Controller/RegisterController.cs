using System;
namespace MasterQ
{
    public class RegisterController
    {
        private static RegisterController instance = new RegisterController();

        RegisterController()
        {

        }
        public static RegisterController getInstance()
        {
            return instance;
        }
        public UIReturn register(Member input)
        {
            if (String.IsNullOrEmpty(input.email)) return new UIReturn(input, false, "", Constants.emptyEmail);
            if (String.IsNullOrEmpty(input.password)) return new UIReturn(input, false, "", Constants.emptyPassword);
            if (String.IsNullOrEmpty(input.confirmPassword)) return new UIReturn(input, false, "", Constants.emptyPassword);
            if (String.IsNullOrEmpty(input.firstname)) return new UIReturn(input, false, "", Constants.emptyUserName);
			if ( String.IsNullOrEmpty(input.lastname)) return new UIReturn(input, false, "", Constants.emptyUserName);
			if (!Validate.email(input.email)) return new UIReturn(input, false, "", Constants.invalidEmail);
            if (!isSamePassword(input)) return new UIReturn(input, false, "", Constants.notSamePassword);

            RegisterRs result = MemberService.getInstance().CallRegister(input);

            UIReturn ret = new UIReturn(input);
            if (result.header.isSuccess)
            {
                Login memberLogin = new Login(input.memberName, input.password);
                memberLogin.isLogin = true;
                MCust.login = memberLogin;
                MCust.member = input;
                ret.setSuccess();
            }
            else
            {
                ret.setFail("", "Error Message");
            }
            return ret;
        }
        private bool isSamePassword(Member input)
        {
            return input.password.Equals(input.confirmPassword); ;
        }

        private bool registerToDB(Member input)
        {
            return true;
        }
    }
}
