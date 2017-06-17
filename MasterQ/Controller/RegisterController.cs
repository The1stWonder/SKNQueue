using System;
namespace MasterQ
{
    public static class RegisterController
    {
        public static void register(Member input)
        {
            if (isEmptyEmail(input)) return;
            if (isEmptyPassword(input)) return;
            if (isEmptyConfirmPassword(input)) return;
            if (isEmptyMemberName(input)) return;
            if (isValidEmail(input)) return;
            if (isSamePassword(input)) return;

            if (registerToDB(input))
            {
                Login memberLogin = new Login(input.memberName, input.password);
                memberLogin.isLogin = true;
                MCust.login = memberLogin;
                MCust.member = input;
            }
        }
        private static bool isEmptyEmail(Member input)
        {
            bool ret = String.IsNullOrEmpty(input.email);
            input.callBack.setReturn(!ret, String.Empty, Constants.emptyEmail);
            return ret;
        }
        private static bool isEmptyPassword(Member input)
        {
            bool ret = String.IsNullOrEmpty(input.password);
            input.callBack.setReturn(!ret, String.Empty, Constants.emptyPassword);
            return ret;
        }
        private static bool isEmptyConfirmPassword(Member input)
        {
            bool ret = String.IsNullOrEmpty(input.password);
            input.callBack.setReturn(!ret, String.Empty, Constants.emptyPassword);
            return ret;
        }
        private static bool isEmptyMemberName(Member input)
        {
            bool ret = String.IsNullOrEmpty(input.memberName);
            input.callBack.setReturn(!ret, String.Empty, Constants.emptyUserName);
            return ret;
        }
        private static bool isValidEmail(Member input)
        {
            Validation varEmail = new Validation(input.email);
            Validate.validateEmail(varEmail);
            bool ret = varEmail.callBack.isSuccess;
            input.callBack.setReturn(ret, String.Empty, varEmail.callBack.message);
            return ret;
        }
        private static bool isSamePassword(Member input)
        {
            bool ret = input.password.Equals(input.confirmPassword);
            input.callBack.setReturn(ret, String.Empty, Constants.notSamePassword);
            return ret;
        }

        private static bool registerToDB(Member input)
        {
            bool ret = true;
            input.callBack.setReturn(ret, String.Empty, "Cannot Register");
            return ret;
        }
    }
}
