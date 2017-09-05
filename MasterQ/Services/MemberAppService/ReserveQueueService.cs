using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MasterQ
{
    public class ReserveQueueService
    {
        private static ReserveQueueService instance = new ReserveQueueService();

        ReserveQueueService()
        { }
        public static ReserveQueueService getInstance()
        {
            return instance;
        }
        public ReserveQueueRs CallReserveQueue(ReserveQueueRq request)
        {
            string serviceUrl = ServiceURL.ipServer + ServiceURL.reserveQueueUrl;
            String resJSON = CallServices.callPost(serviceUrl, request);
            return JObject.Parse(resJSON).ToObject<ReserveQueueRs>();

        }
        public GetBranchServicesRs CallGetBranchServices(GetBranchServicesRq request)
        {
            string serviceUrl = ServiceURL.ipServer + ServiceURL.getBranchServicesUrl;
            String resJSON = CallServices.callPost(serviceUrl, request);
            return JObject.Parse(resJSON).ToObject<GetBranchServicesRs>();

        }

        private String getQueueType()
        {
            String ret = String.Empty;
            if (Constants.isAppForMember())
            {
                ret = Constants.QUEUE_TYPE_MEMBER;
            }
            else if (Constants.isAppForBranch())
            {
                ret = Constants.QUEUE_TYPE_BRANCH;
            }
            return ret;
        }

        public ReserveQueueRq getReserveQueueRq(Service input)
        {
            ReserveQueueRq ret = JObject.Parse(JsonConvert.SerializeObject(input)).ToObject<ReserveQueueRq>();
            ret.memberID = TempDB.loginMember.memberID;
            ret.queueType = getQueueType();
            return ret;
        }
		public ReserveQueueRq getReserveQueueRq(Queue input)
		{
			ReserveQueueRq ret = JObject.Parse(JsonConvert.SerializeObject(input)).ToObject<ReserveQueueRq>();
			ret.memberID = TempDB.loginMember.memberID;
			ret.queueType = getQueueType();
			return ret;
		}
        public GetBranchServicesRq getBranchServicesRq(Branch input)
		{
			GetBranchServicesRq ret = JObject.Parse(JsonConvert.SerializeObject(input)).ToObject<GetBranchServicesRq>();
			return ret;
		}
        public CancelQueueRs cancelQueue(CancelQueueRq request)
		{
            string serviceUrl = ServiceURL.ipServer + ServiceURL.cancelQueueUrl;
			String resJSON = CallServices.callPost(serviceUrl, request);
			return JObject.Parse(resJSON).ToObject<CancelQueueRs>();

		}
        public CancelQueueRq getCancelQueueRq(Queue input)
		{
			CancelQueueRq ret = JObject.Parse(JsonConvert.SerializeObject(input)).ToObject<CancelQueueRq>();
			return ret;
		}
    }
}
