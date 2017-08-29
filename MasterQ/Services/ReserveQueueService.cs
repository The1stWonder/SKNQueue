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
        public ReserveQueueRs CallReserveQueue(Service input)
        {
            string serviceUrl = ServiceURL.ipServer + ServiceURL.reserveQueueUrl;

            ReserveQueueRq postData = new ReserveQueueRq();
            postData.branchID = input.branchID;
            postData.serviceID = input.serviceID;
            postData.memberID = TempDB.loginMember.memberID;
            postData.queueType = getQueueType(Constants.APPLICATION_TYPE);

            String resJSON = CallServices.callPost(serviceUrl, postData);
            return JObject.Parse(resJSON).ToObject<ReserveQueueRs>();

        }
        public ReserveQueueRs CallReserveQueue(Queue input)
        {
            string serviceUrl = ServiceURL.ipServer + ServiceURL.reserveQueueUrl;

            ReserveQueueRq postData = new ReserveQueueRq();

            String resJSON = CallServices.callPost(serviceUrl, postData);
            return JObject.Parse(resJSON).ToObject<ReserveQueueRs>();

        }
        public GetBranchServicesRs CallGetBranchServices(Branch input)
        {
            string serviceUrl = ServiceURL.ipServer + ServiceURL.getBranchServicesUrl;

            GetBranchServicesRq postData = new GetBranchServicesRq();
            postData.branchID = input.branchID;

            String resJSON = CallServices.callPost(serviceUrl, postData);
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
    }
}
