using System;
namespace MasterQ
{
    public class EditProfileController
    {
        public static UIReturn editProfile(Member input)
        {
            if (isEmptyEmail(input)) return new UIReturn(input, false, "", Constants.emptyEmail); 
            if (isEmptyPassword(input)) return new UIReturn(input, false, "", Constants.emptyEmail); 
            if (isEmptyConfirmPassword(input)) return new UIReturn(input, false, "", Constants.emptyEmail); 
            if (isEmptyMemberName(input)) return new UIReturn(input, false, "", Constants.emptyEmail); 
            if (isValidEmail(input)) return new UIReturn(input, false, "", Constants.emptyEmail); 
            if (isSamePassword(input)) return new UIReturn(input, false, "", Constants.emptyEmail); 
            UIReturn ret = new UIReturn(input);
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
            return String.IsNullOrEmpty(input.memberName);
        }
        private static bool isValidEmail(Member input)
        {
            return Validate.validateEmail(new Validation(input.email));
        }
        private static bool isSamePassword(Member input)
        {
            return input.password.Equals(input.confirmPassword);
        }

    }
}
