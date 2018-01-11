using System;
using Newtonsoft.Json;
using Xamarin.Forms.Internals;

namespace MasterQ
{
    [Preserve(AllMembers = true)] //alexpook link all
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
            if (String.IsNullOrEmpty(input.email)) return Constants.uiErrorEmptyEmail;
            if (String.IsNullOrEmpty(input.firstName)) return Constants.uiErrorEmptyFirstName;
            if (String.IsNullOrEmpty(input.lastName)) return Constants.uiErrorEmptyLastName;
            if (String.IsNullOrEmpty(input.birthDate)) return Constants.uiErrorEmptyBirthdate;
            if (!Validate.isDateFormat(input.birthDate)) return Constants.uiErrorInvalidDateFormat;
            if (!String.IsNullOrEmpty(input.tel) && !Validate.isPhoneNumber(input.tel)) return Constants.uiErrorInvalidPhoneNumber;
            if (!Validate.isEmailFormat(input.email)) return Constants.uiErrorInvalidEmail;

            EditProfileRq req = MemberService.getInstance().getEditProfileRq(input);
            EditProfileRs res = MemberService.getInstance().CallEditProfile(req);

            if (res.header.isSuccess)
            {
                SessionModel.loginMember = res.member;
                App.Database.SaveItem(DBConstants.ID_LOGIN_MEMBER, JsonConvert.SerializeObject(SessionModel.loginMember));
            }

            UIReturn ret = new UIReturn(res.header);
            return ret;
        }
        private bool isSamePassword(Member input)
        {
            return input.password.Equals(input.confirmPassword);
        }
        public UIReturn changePassword(Member input)
        {
            if (String.IsNullOrEmpty(input.password)) return Constants.uiErrorEmptyPassword;
            if (String.IsNullOrEmpty(input.confirmPassword)) return Constants.uiErrorEmptyConfirmPassword;
            if (!isSamePassword(input)) return Constants.uiErrorPasswordNotMatch;

            EditProfileRq req = MemberService.getInstance().getEditProfileRq(input);
            EditProfileRs res = MemberService.getInstance().CallEditProfile(req);

            if (res.header.isSuccess)
            {
                SessionModel.loginMember = res.member;
                App.Database.SaveItem(DBConstants.ID_LOGIN_MEMBER, JsonConvert.SerializeObject(SessionModel.loginMember));
            }

            UIReturn ret = new UIReturn(res.header);
            return ret;
        }

    }
}
