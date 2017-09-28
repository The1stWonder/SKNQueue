using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MasterQ
{
    public class UserActionQueueService
    {
        private static UserActionQueueService instance = new UserActionQueueService();
        UserActionQueueService() { }
        public static UserActionQueueService getInstance()
        {
            return instance;
        }
        public CallQueueRs callQueue(CallQueueRq request)
        {
            string serviceUrl = ServiceURL.ipServer + ServiceURL.userCallQueueUrl;
            String resJSON = CallServices.callPost(serviceUrl, request);
            return JObject.Parse(resJSON).ToObject<CallQueueRs>();

        }
        public CallQueueRq getCallQueueRq(Branch branch, GroupService g)
        {
            CallQueueRq ret = new CallQueueRq();
            ret.branchID = branch.branchID;
            ret.userCode = UserSessionModel.loginUser.userCode;
            ret.groupID = g.groupID;
            return ret;

        }
        public AcceptQueueRs acceptQueue(AcceptQueueRq request)
        {
            string serviceUrl = ServiceURL.ipServer + ServiceURL.userAcceptQueueUrl;
            String resJSON = CallServices.callPost(serviceUrl, request);
            return JObject.Parse(resJSON).ToObject<AcceptQueueRs>();

        }
        public AcceptQueueRq getAcceptQueueRq(Queue input)
        {
            AcceptQueueRq ret = JObject.Parse(JsonConvert.SerializeObject(input)).ToObject<AcceptQueueRq>();
            return ret;

        }
        public FinishQueueRs finishQueue(FinishQueueRq request)
		{
            string serviceUrl = ServiceURL.ipServer + ServiceURL.userFinishQueueUrl;
			String resJSON = CallServices.callPost(serviceUrl, request);
			return JObject.Parse(resJSON).ToObject<FinishQueueRs>();

		}
		public FinishQueueRq getFinishQueueRq(Queue input)
		{
			FinishQueueRq ret = JObject.Parse(JsonConvert.SerializeObject(input)).ToObject<FinishQueueRq>();
			return ret;

		}
        public SkipQueueRs skipQueue(SkipQueueRq request)
		{
            string serviceUrl = ServiceURL.ipServer + ServiceURL.userSkipQueueUrl;
			String resJSON = CallServices.callPost(serviceUrl, request);
			return JObject.Parse(resJSON).ToObject<SkipQueueRs>();

		}
		public SkipQueueRq getSkipQueueRq(Queue input)
		{
			SkipQueueRq ret = JObject.Parse(JsonConvert.SerializeObject(input)).ToObject<SkipQueueRq>();
			return ret;

		}
    }
}
