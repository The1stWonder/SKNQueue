using System;
namespace MasterQ
{
    public class EditProfileController
    {
        private static EditProfileController instance = new EditProfileController();

        EditProfileController()
        {

        }
        public static EditProfileController getInstance()
        {
            return instance;
        }
        public UIReturn editProfile(Member input)
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
            return String.IsNullOrEmpty(input.memberName);
        }
        private bool isValidEmail(Member input)
        {
            return Validate.validateEmail(new Validation(input.email));
        }
        private bool isSamePassword(Member input)
        {
            return input.password.Equals(input.confirmPassword);
        }

    }
}
