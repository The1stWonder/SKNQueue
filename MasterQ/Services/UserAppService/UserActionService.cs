using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MasterQ
{
    public class UserActionService
    {
        private static UserActionService instance = new UserActionService();

        UserActionService()
        {
        }
        public static UserActionService getInstance()
        {
            return instance;
        }
        public GetServiceRs getServices(GetServiceRq request)
		{
            string serviceUrl = ServiceURL.ipServer + ServiceURL.userGetServiceUrl;
			String resJSON = CallServices.callPost(serviceUrl, request);
			return JObject.Parse(resJSON).ToObject<GetServiceRs>();

		}
        public GetServiceRq getGetServiceRq(Branch input)
		{
			GetServiceRq ret = JObject.Parse(JsonConvert.SerializeObject(input)).ToObject<GetServiceRq>();
			return ret;

		}
        public OpenServiceRs openService(OpenServiceRq request)
		{
            string serviceUrl = ServiceURL.ipServer + ServiceURL.userOpenServiceUrl;
			String resJSON = CallServices.callPost(serviceUrl, request);
			return JObject.Parse(resJSON).ToObject<OpenServiceRs>();

		}
        public OpenServiceRq getOpenServiceRq(Branch branch,GroupService groupS,String counterNumber)
		{
            OpenServiceRq ret = new OpenServiceRq();
            ret.branchID = branch.branchID;
			ret.userCode = UserSessionModel.loginUser.userCode;
            ret.groupID = groupS.groupID;
            ret.counterNumber = counterNumber;
			return ret;

		}
    }
}
