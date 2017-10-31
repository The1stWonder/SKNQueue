using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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
        public UIReturn getDistricts(Province input)
        {
            //GetDistrictsRs res = MetaDataService.getInstance().CallGetDistricts();
            List<District> districts = new List<District>();
            if (String.IsNullOrEmpty(input.provinceID))
            {
                districts = TempDB.districts;
            }
            else
            {
                districts = TempDB.districts.FindAll(s => s.provinceID == input.provinceID);
            }

            UIReturn ret = new UIReturn();
            ret.returnObject = districts;
            ret.isSuccess = true;
            return ret;
        }
        public UIReturn getBranches(Province inputP, District inputD)
        {
            //GetBranchesRs res = MetaDataService.getInstance().CallGetBranches();
            List<Branch> branches = new List<Branch>();
            if (String.IsNullOrEmpty(inputP.provinceID) && String.IsNullOrEmpty(inputD.districtID))
            {
                branches = TempDB.branches;
            }
            else if (!String.IsNullOrEmpty(inputP.provinceID) && String.IsNullOrEmpty(inputD.districtID))
            {
                branches = TempDB.branches.FindAll(s => s.provinceID == inputP.provinceID);
            }
            else
            {
                branches = TempDB.branches.FindAll(s => s.provinceID == inputP.provinceID && s.districtID == inputD.districtID);
            }

            return getUIReturnBranchs(branches);
        }
        public UIReturn getBranches(String textSearch)
        {
            //GetBranchesRs res = MetaDataService.getInstance().CallGetBranches();
            List<Branch> branches = TempDB.branches.FindAll(s => s.branchName.Contains(textSearch));

            return getUIReturnBranchs(branches);
        }
        public UIReturn getBranchDetail(Branch input)
        {
            Branch branch = TempDB.branches.Find(s => s.branchID == input.branchID);
            UIReturn ret = new UIReturn();
            ret.returnObject = branch;
            ret.isSuccess = true;
            return ret;
        }
        public UIReturn getBranchQueue(Branch input)
        {
            Branch inputBranch = TempDB.branches.Find(s => s.branchID == input.branchID);
            GetBranchServicesRq req = ReserveQueueService.getInstance().getBranchServicesRq(inputBranch);
            GetBranchServicesRs res = ReserveQueueService.getInstance().CallGetBranchServices(req);
            SessionModel.services = res.services;

            return getUIReturnServices(res.services);
        }

        public UIReturn getUIReturnBranchs(List<Branch> branchs)
        {
            if (branchs.ToArray().Length <= 0)
            {
                return Constants.uiErrorNoBranch;
            }
            else
            {
                UIReturn ret = new UIReturn();
                ret.returnObject = branchs;
                ret.isSuccess = true;
                return ret;
            }
        }
        public UIReturn getUIReturnServices(List<Service> services)
        {
            if (services.ToArray().Length <= 0)
            {
                return Constants.uiErrorNoService;
            }
            else
            {
                UIReturn ret = new UIReturn();
                ret.returnObject = services;
                ret.isSuccess = true;
                return ret;
            }
        }
    }
}
