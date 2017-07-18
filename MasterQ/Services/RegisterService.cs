using System;
using Newtonsoft.Json.Linq;

namespace MasterQ
{
    public class RegisterService
    {
		private static RegisterService instance = new RegisterService();

		RegisterService()
		{
		}
		public static RegisterService getInstance()
		{
			return instance;
		}
        public RegisterServiceRs CallRegister(Member input)
		{
			RegisterServiceRs ret = new RegisterServiceRs();
            string kUrl = ServiceURL.ipServer + ServiceURL.registerUrl;

			RegisterServiceRq postData = new RegisterServiceRq();
            postData.RegisterFirstName = input.firstname;
            postData.RegisterLastName = input.lastname;
            postData.RegisterPassword = input.password;
            postData.RegisterEMail = input.email;

			String resJSON = CallServices.callPost(kUrl, postData);
			ret = JObject.Parse(resJSON).ToObject<RegisterServiceRs>();
			return ret;

		}
    }
}
