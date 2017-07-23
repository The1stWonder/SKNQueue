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
			if (String.IsNullOrEmpty(input.email)) return new UIReturn(input, false, "", Constants.emptyEmail);
			if (String.IsNullOrEmpty(input.password)) return new UIReturn(input, false, "", Constants.emptyPassword);
			if (String.IsNullOrEmpty(input.confirmPassword)) return new UIReturn(input, false, "", Constants.emptyPassword);
			if (String.IsNullOrEmpty(input.firstname)) return new UIReturn(input, false, "", Constants.emptyUserName);
			//if ( String.IsNullOrEmpty(input.lastname)) return new UIReturn(input, false, "", Constants.emptyUserName);
			if (!Validate.email(input.email)) return new UIReturn(input, false, "", Constants.invalidEmail);
			if (!isSamePassword(input)) return new UIReturn(input, false, "", Constants.notSamePassword);

            EditProfileRs res = MemberService.getInstance().CallEditProfile(input);

            UIReturn ret = new UIReturn(input);
            return ret;
        }
        private bool isSamePassword(Member input)
        {
            return input.password.Equals(input.confirmPassword);
        }

    }
}
