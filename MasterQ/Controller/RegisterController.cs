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
            if (String.IsNullOrEmpty(input.email)) return new UIReturn(input, false, Constants.GROUPS_VALIDATE, Constants.FUNCTIONS_EMPTY_INPUT, Constants.CODE_EMPTY_EMAIL);
            if (String.IsNullOrEmpty(input.password)) return new UIReturn(input, false, Constants.GROUPS_VALIDATE, Constants.FUNCTIONS_EMPTY_INPUT, Constants.CODE_EMPTY_PASSWORD);
            if (String.IsNullOrEmpty(input.confirmPassword)) return new UIReturn(input, false, Constants.GROUPS_VALIDATE, Constants.FUNCTIONS_EMPTY_INPUT, Constants.CODE_EMPTY_CONFIRMPASSWORD);
            if (String.IsNullOrEmpty(input.firstName)) return new UIReturn(input, false, Constants.GROUPS_VALIDATE, Constants.FUNCTIONS_EMPTY_INPUT, Constants.CODE_EMPTY_FIRSTNAME);
            if ( String.IsNullOrEmpty(input.lastName)) return new UIReturn(input, false, Constants.GROUPS_VALIDATE, Constants.FUNCTIONS_EMPTY_INPUT, Constants.CODE_EMPTY_LASTNAME);
			if (!Validate.email(input.email)) return new UIReturn(input, false, Constants.GROUPS_VALIDATE, Constants.FUNCTIONS_EMAIL, Constants.CODE_INVALID_EMAIL);
            if (!isSamePassword(input)) return new UIReturn(input, false, Constants.GROUPS_VALIDATE, Constants.FUNCTIONS_PASSWORD, Constants.CODE_PASSWORD_NOTMATCH);

            RegisterRs result = MemberService.getInstance().CallRegister(input);

            UIReturn ret = new UIReturn(input,result.header);
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
