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
        public LoginRs CallLogin(Login input)
        {
            string serviceUrl = ServiceURL.ipServer + ServiceURL.loginUrl;

			LoginRq postData = new LoginRq();
			postData.UserName = input.username;
			postData.Password = input.password;

            String resJSON = CallServices.callPost(serviceUrl, postData);
            return JObject.Parse(resJSON).ToObject<LoginRs>();

		}
        public ForgetPasswordRs CallForgetPassword(String email)
		{
            string serviceUrl = ServiceURL.ipServer + ServiceURL.forgetPasswordUrl;

            ForgetPasswordRq postData = new ForgetPasswordRq();

			String resJSON = CallServices.callPost(serviceUrl, postData);
			return JObject.Parse(resJSON).ToObject<ForgetPasswordRs>();

		}
    }
}
