using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MasterQ
{
    public class BranchActionService
    {
		private static BranchActionService instance = new BranchActionService();
        BranchActionService(){}
		public static BranchActionService getInstance()
		{
			return instance;
		}
        public BranchGetServicesRs getBranchServices(BranchGetServicesRq request)
		{
			string serviceUrl = ServiceURL.ipServer + ServiceURL.branchGetServiceUrl;
			String resJSON = CallServices.callPost(serviceUrl, request);
			return JObject.Parse(resJSON).ToObject<BranchGetServicesRs>();

		}
        public BranchGetServicesRq getBranchGetServicesRq(Branch input)
		{
			BranchGetServicesRq ret = JObject.Parse(JsonConvert.SerializeObject(input)).ToObject<BranchGetServicesRq>();
			return ret;
		}
        public BranchReserveQueueRs reserveQueue(BranchReserveQueueRq request)
		{
            string serviceUrl = ServiceURL.ipServer + ServiceURL.branchReserveQueueUrl;
			String resJSON = CallServices.callPost(serviceUrl, request);
			return JObject.Parse(resJSON).ToObject<BranchReserveQueueRs>();

		}
		public BranchReserveQueueRq getBranchReserveQueueRq(Service input)
		{
			BranchReserveQueueRq ret = JObject.Parse(JsonConvert.SerializeObject(input)).ToObject<BranchReserveQueueRq>();
            ret.queueType = Utils.getQueueType();
			return ret;
		}

	}
}
