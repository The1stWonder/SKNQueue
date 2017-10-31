using System;
using Newtonsoft.Json;
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
			RegisterRq ret = JObject.Parse(JsonConvert.SerializeObject(input)).ToObject<RegisterRq>();
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
			EditProfileRq ret = JObject.Parse(JsonConvert.SerializeObject(input)).ToObject<EditProfileRq>();
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
			GetHistoryRq ret = JObject.Parse(JsonConvert.SerializeObject(input)).ToObject<GetHistoryRq>();
            return ret;

		}
        public GetSessionRs CallGetSession(GetSessionRq request)
        {
            string serviceUrl = ServiceURL.ipServer + ServiceURL.getSessionUrl;
            String resJSON = CallServices.callPost(serviceUrl, request);
            return JObject.Parse(resJSON).ToObject<GetSessionRs>();

        }
        public GetSessionRq getGetSessionRq(Member input)
        {
            GetSessionRq ret = JObject.Parse(JsonConvert.SerializeObject(input)).ToObject<GetSessionRq>();
            return ret;
        }
    }
}
