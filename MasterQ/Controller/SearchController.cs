using System;
using System.Collections.Generic;

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
        public UIReturn getProvinces()
        {
            //GetProvincesRs res = MetaDataService.getInstance().CallGetProvices();
            List<Province> provinces = TempDB.provinces;

            UIReturn ret = new UIReturn();
            ret.returnObject = provinces;
            ret.isSuccess = true;
            return ret;
        }
        public UIReturn getDistricts(String provinceId)
        {
            //GetDistrictsRs res = MetaDataService.getInstance().CallGetDistricts();
            List<District> districts = new List<District>();
            if (String.IsNullOrEmpty(provinceId))
            {
                districts = TempDB.districts;
            }
            else
            {
                districts = TempDB.districts.FindAll(s => s.provinceID == provinceId);
            }

            UIReturn ret = new UIReturn();
            ret.returnObject = districts;
            ret.isSuccess = true;
            return ret;
        }
        public UIReturn getBranches(String provinceId, String districtId)
        {
            //GetBranchesRs res = MetaDataService.getInstance().CallGetBranches();
            List<Branch> branches = new List<Branch>();
            if (String.IsNullOrEmpty(provinceId) && String.IsNullOrEmpty(districtId))
            {
                branches = TempDB.branches;
            }
            else if (!String.IsNullOrEmpty(provinceId))
            {
                branches = TempDB.branches.FindAll(s => s.provinceID == provinceId);
            }
            else
            {
                branches = TempDB.branches.FindAll(s => s.provinceID == provinceId && s.districtID == districtId);
            }

            UIReturn ret = new UIReturn();
            ret.returnObject = branches;
            ret.isSuccess = true;
            return ret;
		}
		public UIReturn getBranches(String textSearch)
		{
			//GetBranchesRs res = MetaDataService.getInstance().CallGetBranches();
            List<Branch> branches = TempDB.branches.FindAll(s => s.branchName.Contains(textSearch));
			

			UIReturn ret = new UIReturn();
			ret.returnObject = branches;
			ret.isSuccess = true;
			return ret;
		}
        public UIReturn getBranchDetail(String branchId)
        {
            Branch branch = TempDB.branches.Find(s => s.branchID == branchId);
            UIReturn ret = new UIReturn();
            ret.returnObject = branch;
            ret.isSuccess = true;
            return ret;
        }
        public UIReturn getBranchQueue(String branchId)
        {
            Branch inputBranch = TempDB.branches.Find(s => s.branchID == branchId);
            GetServicesRs res = ReserveQueueService.getInstance().CallGetBranchServices(inputBranch);
            TempDB.services = res.services;
            UIReturn ret = new UIReturn(res.header);
            ret.returnObject = res.services;
            return ret;
        }
    }
}
