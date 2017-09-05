using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MasterQ
{
	public class UserLoginService
	{
		private static UserLoginService instance = new UserLoginService();
		UserLoginService()
		{
		}
		public static UserLoginService getInstance()
		{
			return instance;
		}
		public UserLoginRs CallLogin(UserLoginRq request)
		{
			string serviceUrl = ServiceURL.ipServer + ServiceURL.userLoginUrl;
			String resJSON = CallServices.callPost(serviceUrl, request);
			return JObject.Parse(resJSON).ToObject<UserLoginRs>();

		}
		public UserLoginRq getUserLoginRq(Login input)
		{
			UserLoginRq ret = JObject.Parse(JsonConvert.SerializeObject(input)).ToObject<UserLoginRq>();
			return ret;

		}
	}
}
