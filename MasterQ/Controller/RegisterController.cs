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
            if (isEmptyEmail(input)) return new UIReturn(input, false, "", Constants.emptyEmail);
            if (isEmptyPassword(input)) return new UIReturn(input, false, "", Constants.emptyPassword);
            if (isEmptyConfirmPassword(input)) return new UIReturn(input, false, "", Constants.emptyPassword);
            if (isEmptyFirstName(input)) return new UIReturn(input, false, "", Constants.emptyUserName);
            //if (isEmptyLastName(input)) return new UIReturn(input, false, "", Constants.emptyUserName);
            if (!isValidEmail(input)) return new UIReturn(input, false, "", Constants.invalidEmail);
            if (!isSamePassword(input)) return new UIReturn(input, false, "", Constants.notSamePassword);

            RegisterServiceRs result = RegisterService.getInstance().CallRegister(input);

            UIReturn ret = new UIReturn(input);
            if (result.member.MemberEMail != null || !String.Empty.Equals(result.member.MemberEMail))
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
        private bool isEmptyEmail(Member input)
        {
            return String.IsNullOrEmpty(input.email);
        }
        private bool isEmptyPassword(Member input)
        {
            return String.IsNullOrEmpty(input.password);
        }
        private bool isEmptyConfirmPassword(Member input)
        {
            return String.IsNullOrEmpty(input.password);
        }
        private bool isEmptyMemberName(Member input)
        {
            return String.IsNullOrEmpty(input.memberName); ;
        }
        private bool isEmptyFirstName(Member input)
        {
            return String.IsNullOrEmpty(input.firstname); ;
        }
        private bool isEmptyLastName(Member input)
        {
            return String.IsNullOrEmpty(input.lastname); ;
        }
        private bool isValidEmail(Member input)
        {
            return Validate.validateEmail(new Validation(input.email));
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
