using System;
using Newtonsoft.Json.Linq;

namespace MasterQ
{
    public class MemberService
    {
		private static MemberService instance = new MemberService();

		MemberService()
		{
		}
		public static MemberService getInstance()
		{
			return instance;
		}
        public RegisterRs CallRegister(RegisterRq request)
		{
            string serviceUrl = ServiceURL.ipServer + ServiceURL.registerUrl;
            String resJSON = CallServices.callPost(serviceUrl, request);
			return JObject.Parse(resJSON).ToObject<RegisterRs>();

		}
		public RegisterRq getRegisterRq(Member input)
		{
			RegisterRq ret = new RegisterRq();
			ret.firstName = input.firstName;
			ret.lastName = input.lastName;
			ret.password = input.password;
			ret.email = input.email;
			ret.birthDate = input.birthDate;
            return ret;

		}
        public EditProfileRs CallEditProfile(EditProfileRq request)
		{
			string serviceUrl = ServiceURL.ipServer + ServiceURL.editProfileUrl;
            String resJSON = CallServices.callPost(serviceUrl, request);
			return JObject.Parse(resJSON).ToObject<EditProfileRs>();

		}
		public EditProfileRq getEditProfileRq(Member input)
		{
			EditProfileRq ret = new EditProfileRq();
			ret.firstName = input.firstName;
			ret.lastName = input.lastName;
			ret.password = input.password;
			ret.email = input.email;
			ret.birthDate = input.birthDate;
            return ret;

		}
        public GetHistoryRs CallGetHistory(GetHistoryRq request)
		{
            string serviceUrl = ServiceURL.ipServer + ServiceURL.getHistoryUrl;
            String resJSON = CallServices.callPost(serviceUrl, request);
			return JObject.Parse(resJSON).ToObject<GetHistoryRs>();

		}
		public GetHistoryRq getGetHistoryRq(Member input)
		{
			GetHistoryRq ret = new GetHistoryRq();
			ret.memberID = input.memberID;
            return ret;

		}
    }
}
