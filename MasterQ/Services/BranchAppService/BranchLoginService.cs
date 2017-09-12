using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MasterQ
{
    public class BranchLoginService
    {
		private static BranchLoginService instance = new BranchLoginService();

		BranchLoginService()
		{
		}
		public static BranchLoginService getInstance()
		{
			return instance;
		}
        public BranchLoginRs CallLogin(BranchLoginRq request)
		{
            string serviceUrl = ServiceURL.ipServer + ServiceURL.branchLoginUrl;
			String resJSON = CallServices.callPost(serviceUrl, request);
			return JObject.Parse(resJSON).ToObject<BranchLoginRs>();

		}
        public BranchLoginRq getBranchLoginRq(Login input)
		{
			BranchLoginRq ret = JObject.Parse(JsonConvert.SerializeObject(input)).ToObject<BranchLoginRq>();
			return ret;

		}
        public BranchLogoutRs callLogout(BranchLogoutRq request)
		{
            string serviceUrl = ServiceURL.ipServer + ServiceURL.branchLogoutUrl;
			String resJSON = CallServices.callPost(serviceUrl, request);
			return JObject.Parse(resJSON).ToObject<BranchLogoutRs>();

		}
        public BranchLogoutRq getBranchLogoutRq(Branch input)
		{
			BranchLogoutRq ret = JObject.Parse(JsonConvert.SerializeObject(input)).ToObject<BranchLogoutRq>();
			return ret;

		}
    }
}
