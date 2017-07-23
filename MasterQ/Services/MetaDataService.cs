using System;
using Newtonsoft.Json.Linq;

namespace MasterQ
{
    public class MetaDataService
    {

        private static MetaDataService instance = new MetaDataService();
        MetaDataService() { }
        public static MetaDataService getInstance()
        {
            return instance;
        }
        public GetProvincesRs CallGetProvices()
		{
            string serviceUrl = ServiceURL.ipServer + ServiceURL.getProvicesUrl;

			GetProvincesRq postData = new GetProvincesRq();

			String resJSON = CallServices.callPost(serviceUrl, postData);
			return JObject.Parse(resJSON).ToObject<GetProvincesRs>();

		}
        public GetBranchesRs CallGetBranches()
		{
            string serviceUrl = ServiceURL.ipServer + ServiceURL.getBranchesUrl;

			GetBranchesRq postData = new GetBranchesRq();

			String resJSON = CallServices.callPost(serviceUrl, postData);
			return JObject.Parse(resJSON).ToObject<GetBranchesRs>();

		}
        public GetDistrictsRs CallGetDistricts()
		{
            string serviceUrl = ServiceURL.ipServer + ServiceURL.getDistrictsUrl;

			GetDistrictsRq postData = new GetDistrictsRq();

			String resJSON = CallServices.callPost(serviceUrl, postData);
			return JObject.Parse(resJSON).ToObject<GetDistrictsRs>();

		}
    }
}
