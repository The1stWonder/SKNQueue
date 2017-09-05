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
            if (String.IsNullOrEmpty(input.email)) return Constants.uiErrorEmptyEmail;
            if (String.IsNullOrEmpty(input.password)) return Constants.uiErrorEmptyPassword;
            if (String.IsNullOrEmpty(input.confirmPassword)) return Constants.uiErrorEmptyConfirmPassword;
            if (String.IsNullOrEmpty(input.firstName)) return Constants.uiErrorEmptyFirstName;
            if (String.IsNullOrEmpty(input.lastName)) return Constants.uiErrorEmptyLastName;
            if (String.IsNullOrEmpty(input.birthDate)) return Constants.uiErrorEmptyBirthdate;
            if (!Validate.isDateFormat(input.birthDate)) return Constants.uiErrorInvalidDateFormat;
            if (!String.IsNullOrEmpty(input.tel) && !Validate.isPhoneNumber(input.tel)) return Constants.uiErrorInvalidPhoneNumber;
            if (!Validate.isEmailFormat(input.email)) return Constants.uiErrorInvalidEmail;
            if (!isSamePassword(input)) return Constants.uiErrorPasswordNotMatch;

            RegisterRq req = MemberService.getInstance().getRegisterRq(input);
            RegisterRs result = MemberService.getInstance().CallRegister(req);

            UIReturn ret = new UIReturn(result.header);
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
