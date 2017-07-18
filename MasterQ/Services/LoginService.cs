using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MasterQ
{
    public class LoginService
    {
        private static LoginService instance = new LoginService();
        LoginService()
        {
        }
        public static LoginService getInstance()
        {
            return instance;
        }
        public LoginServiceRs CallLogin(Login input)
		{
            LoginServiceRs ret = new LoginServiceRs();
			string kUrl = ServiceURL.ipServer + ServiceURL.sampleUrlPost;

			LoginServiceRq postData = new LoginServiceRq();
			postData.UserName = input.username;
			postData.Password = input.password;

            String resJSON = CallServices.callPost(kUrl, postData);
            ret = JObject.Parse(resJSON).ToObject<LoginServiceRs>();
            return ret;

		}
    }
}
