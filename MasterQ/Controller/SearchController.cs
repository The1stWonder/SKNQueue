using System;
namespace MasterQ
{
    public class SearchController
    {
        private static SearchController instance = new SearchController();

        SearchController() { }
        public static SearchController getInstance()
        {
            return instance;
        }
        public UIReturn getProvinces(){
            GetProvincesRs res = MetaDataService.getInstance().CallGetProvices();

            UIReturn ret = new UIReturn();
            return ret;
        }
		public UIReturn getDistricts(String provinceId)
		{
            GetDistrictsRs res = MetaDataService.getInstance().CallGetDistricts();
			UIReturn ret = new UIReturn();
			return ret;
		}
		public UIReturn getBranches(String provinceId,String districtId)
		{
            GetBranchesRs res = MetaDataService.getInstance().CallGetBranches();
			UIReturn ret = new UIReturn();
			return ret;
		}
		public UIReturn getBranchDetail(String branchId)
		{
			UIReturn ret = new UIReturn();
			return ret;
		}
		public UIReturn getBranchQueue(String branchId)
		{
			UIReturn ret = new UIReturn();
			return ret;
		}
    }
}
