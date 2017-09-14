using System;
using System.Collections.Generic;

namespace MasterQ
{
    public class Initial
    {
        public static void init()
        {
            List<CodeDescription> tempCodeDesc = MetaDataService.getInstance().CallGetCodeDescription().codeDescriptions;
            TempDB.codeDescriptions = (tempCodeDesc == null) ? new List<CodeDescription>() : tempCodeDesc;
            if (Constants.isAppForMember())
            {
                List<Province> tempProvince = MetaDataService.getInstance().CallGetProvices().provinces;
                TempDB.provinces = (tempProvince == null) ? new List<Province>() : tempProvince;
                List<District> tempDistrict = MetaDataService.getInstance().CallGetDistricts().districts;
                TempDB.districts = (tempDistrict == null) ? new List<District>() : tempDistrict;
                List<Branch> tempBranch = MetaDataService.getInstance().CallGetBranches().branches;
                TempDB.branches = (tempBranch == null) ? new List<Branch>() : tempBranch;
            }
        }
    }
}
