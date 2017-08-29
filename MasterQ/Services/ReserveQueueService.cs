using System;
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

        private String getQueueType(String input)
        {
            String ret = "";
            if (Constants.APPLICATION_TYPE_USER.Equals(input))
            {
                ret = Constants.QUEUE_TYPE_USER;
            }
            else if (Constants.APPLICATION_TYPE_BRANCH.Equals(input))
            {
                ret = Constants.QUEUE_TYPE_BRANCH;
            }
            return ret;
        }

        public ReserveQueueRq getReserveQueueRq(Service input)
        {
            ReserveQueueRq ret = new ReserveQueueRq();
            ret.branchID = input.branchID;
            ret.serviceID = input.serviceID;
            ret.memberID = TempDB.loginMember.memberID;
            ret.queueType = getQueueType(Constants.APPLICATION_TYPE);
            return ret;
        }
		public ReserveQueueRq getReserveQueueRq(Queue input)
		{
			ReserveQueueRq ret = new ReserveQueueRq();
			ret.branchID = input.branchID;
			ret.serviceID = input.serviceID;
			ret.memberID = TempDB.loginMember.memberID;
			ret.queueType = getQueueType(Constants.APPLICATION_TYPE);
			return ret;
		}
        public GetBranchServicesRq getBranchServicesRq(Branch input)
		{
			GetBranchServicesRq ret = new GetBranchServicesRq();
			ret.branchID = input.branchID;
			return ret;
		}
    }
}
