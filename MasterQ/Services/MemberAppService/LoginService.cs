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
        public LoginRs CallLogin(LoginRq request)
        {
            string serviceUrl = ServiceURL.ipServer + ServiceURL.loginUrl;
            String resJSON = CallServices.callPost(serviceUrl, request);
            return JObject.Parse(resJSON).ToObject<LoginRs>();

        }
        public LoginRq getLoginRq(Login input)
        {
            LoginRq ret = JObject.Parse(JsonConvert.SerializeObject(input)).ToObject<LoginRq>();
            return ret;

        }
        public ForgetPasswordRs CallForgetPassword(ForgetPasswordRq request)
        {
            string serviceUrl = ServiceURL.ipServer + ServiceURL.forgetPasswordUrl;
            String resJSON = CallServices.callPost(serviceUrl, request);
            return JObject.Parse(resJSON).ToObject<ForgetPasswordRs>();

        }
        public ForgetPasswordRq getForgetPasswordRq(String email)
        {
            ForgetPasswordRq ret = new ForgetPasswordRq();
            ret.email = email;
            return ret;

		}
    }
}
