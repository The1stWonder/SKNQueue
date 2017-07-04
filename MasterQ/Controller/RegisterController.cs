using System;
namespace MasterQ
{
    public static class RegisterController
    {
        public static UIReturn register(Member input)
        {
            if (isEmptyEmail(input)) return new UIReturn(input,false,"",Constants.emptyEmail);
            if (isEmptyPassword(input))return new UIReturn(input, false, "", Constants.emptyPassword);
            if (isEmptyConfirmPassword(input)) return new UIReturn(input, false, "", Constants.emptyPassword);
            if (isEmptyMemberName(input)) return new UIReturn(input, false, "", Constants.emptyUserName);
            if (isValidEmail(input)) return new UIReturn(input, false, "", Constants.invalidEmail);
            if (isSamePassword(input)) return new UIReturn(input, false, "", Constants.notSamePassword);

            UIReturn ret = new UIReturn(input);
            if (registerToDB(input))
            {
                Login memberLogin = new Login(input.memberName, input.password);
                memberLogin.isLogin = true;
                MCust.login = memberLogin;
                MCust.member = input;
                ret.setSuccess();
            }
            return ret;
        }
        private static bool isEmptyEmail(Member input)
        {
            return String.IsNullOrEmpty(input.email);
        }
        private static bool isEmptyPassword(Member input)
        {
            return String.IsNullOrEmpty(input.password);
        }
        private static bool isEmptyConfirmPassword(Member input)
        {
            return String.IsNullOrEmpty(input.password);
        }
        private static bool isEmptyMemberName(Member input)
        {
            return String.IsNullOrEmpty(input.memberName); ;
        }
        private static bool isValidEmail(Member input)
        {
            return Validate.validateEmail(new Validation(input.email));
        }
        private static bool isSamePassword(Member input)
        {
            return input.password.Equals(input.confirmPassword); ;
        }

        private static bool registerToDB(Member input)
        {
            return true;
        }
    }
}
