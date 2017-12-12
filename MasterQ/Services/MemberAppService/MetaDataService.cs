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
        public GetCodeDescriptionRs CallGetCodeDescription()
		{
            string serviceUrl = ServiceURL.ipServer + ServiceURL.getCodeDescriptionUrl;

			GetCodeDescriptionRq postData = new GetCodeDescriptionRq();

			String resJSON = CallServices.callPost(serviceUrl, postData);
			return JObject.Parse(resJSON).ToObject<GetCodeDescriptionRs>();

		}
		public GetCodeDescriptionRs CallGetCodeDescription(GetCodeDescriptionRq request) 
		{
            string serviceUrl = ServiceURL.ipServer + ServiceURL.getCodeDescriptionUrl;
            String resJSON = CallServices.callPost(serviceUrl, request);
			return JObject.Parse(resJSON).ToObject<GetCodeDescriptionRs>();

		}
		public GetCodeDescriptionRq getGetCodeDescriptionRq(String groups, String functions, String code)
		{
			GetCodeDescriptionRq ret = new GetCodeDescriptionRq();
			ret.groups = groups;
			ret.functions = functions;
			ret.code = code;
            return ret;

		}

        public GetBranchServicesRs CallGetBranchServices()
        {
            string serviceUrl = ServiceURL.ipServer + ServiceURL.getBranchServicesUrl;

            GetBranchServicesRq postData = new GetBranchServicesRq();
            postData.branchID = "";

            String resJSON = CallServices.callPost(serviceUrl, postData);
            return JObject.Parse(resJSON).ToObject<GetBranchServicesRs>();
        }

        public GetAppVersionRs CallGetAppVersion()
        {
            string serviceUrl = ServiceURL.ipServer + ServiceURL.getAppVersionUrl;

            GetAppVersionRq postData = new GetAppVersionRq();

            String resJSON = CallServices.callPost(serviceUrl, postData);
            return JObject.Parse(resJSON).ToObject<GetAppVersionRs>();
        }
    }

}
