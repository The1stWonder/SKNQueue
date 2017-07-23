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
        public RegisterRs CallRegister(Member input)
		{
            string serviceUrl = ServiceURL.ipServer + ServiceURL.registerUrl;

			RegisterRq postData = new RegisterRq();
            postData.firstName = input.firstName;
            postData.lastName = input.lastName;
            postData.password = input.password;
            postData.eMail = input.email;
            postData.birthDate = input.birthDate;

			String resJSON = CallServices.callPost(serviceUrl, postData);
			return JObject.Parse(resJSON).ToObject<RegisterRs>();

		}
        public EditProfileRs CallEditProfile(Member input)
		{
			string serviceUrl = ServiceURL.ipServer + ServiceURL.editProfileUrl;

			EditProfileRq postData = new EditProfileRq();
            postData.firstName = input.firstName;
            postData.lastName = input.lastName;
			postData.password = input.password;
			postData.eMail = input.email;
            postData.birthDate = input.birthDate;

			String resJSON = CallServices.callPost(serviceUrl, postData);
			return JObject.Parse(resJSON).ToObject<EditProfileRs>();

		}
    }
}
