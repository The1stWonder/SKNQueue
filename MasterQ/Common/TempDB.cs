using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MasterQ
{
    public class TempDB
    {
        public static bool flagUpdateAppVersion = true;
        public static List<CodeDescription> codeDescriptions=new List<CodeDescription>();
        public static List<Province> provinces;
        public static List<District> districts;
        public static List<Branch> branches;
        public static List<Service> services;

        public static void saveCodeDescription()
        {
            App.Database.SaveItem(DBConstants.ID_CODE_DESCRIPTIONS, JsonConvert.SerializeObject(codeDescriptions));
        }
        public static void saveProvinces()
        {
            App.Database.SaveItem(DBConstants.ID_PROVINCES, JsonConvert.SerializeObject(provinces));
        }
        public static void saveDistricts()
        {
            App.Database.SaveItem(DBConstants.ID_DISTRICTS, JsonConvert.SerializeObject(districts));
        }
        public static void saveBranches()
        {
            App.Database.SaveItem(DBConstants.ID_BRANCHES, JsonConvert.SerializeObject(branches));
        }
        public static void saveServices()
        {
            App.Database.SaveItem(DBConstants.ID_SERVICES, JsonConvert.SerializeObject(services));
        }

        public static void setCodeDescriptions()
        {
            if (Constants.isSameVersion())
            {
                SessionTable temp = App.Database.GetItem(DBConstants.ID_CODE_DESCRIPTIONS);
                if (temp != null)
                {
                    codeDescriptions = JArray.Parse(temp.JSON_DATA).ToObject<List<CodeDescription>>();
                }
            }
            else
            {
                codeDescriptions = MetaDataService.getInstance().CallGetCodeDescription().codeDescriptions;
                if (codeDescriptions == null)
                {
                    flagUpdateAppVersion = flagUpdateAppVersion & false;
                }
                else
                {
                    saveCodeDescription();
                }
            }
            codeDescriptions = (codeDescriptions == null) ? new List<CodeDescription>() : codeDescriptions;
        }
        public static void setProvinces()
        {
            if (Constants.isSameVersion())
            {
                SessionTable temp = App.Database.GetItem(DBConstants.ID_PROVINCES);
                if (temp != null)
                {
                    provinces = JArray.Parse(temp.JSON_DATA).ToObject<List<Province>>();
                }
            }
            else
            {
                provinces = MetaDataService.getInstance().CallGetProvices().provinces;
                if (provinces == null)
                {
                    flagUpdateAppVersion = flagUpdateAppVersion & false;
                }
                else
                {
                    saveProvinces();
                }
            }
            provinces = (provinces == null) ? new List<Province>() : provinces;
        }
        public static void setDistrict()
        {
            if (Constants.isSameVersion())
            {
                SessionTable temp = App.Database.GetItem(DBConstants.ID_DISTRICTS);
                if (temp != null)
                {
                    districts = JArray.Parse(temp.JSON_DATA).ToObject<List<District>>();
                }
            }
            else
            {
                districts = MetaDataService.getInstance().CallGetDistricts().districts;
                if (districts == null)
                {
                    flagUpdateAppVersion = flagUpdateAppVersion & false;
                }
                else
                {
                    saveDistricts();
                }
            }
            districts = (districts == null) ? new List<District>() : districts;
        }
        public static void setBranches()
        {
            if (Constants.isSameVersion())
            {
                SessionTable temp = App.Database.GetItem(DBConstants.ID_BRANCHES);
                if (temp != null)
                {
                    branches = JArray.Parse(temp.JSON_DATA).ToObject<List<Branch>>();
                }
            }
            else
            {
                branches = MetaDataService.getInstance().CallGetBranches().branches;
                if (branches == null)
                {
                    flagUpdateAppVersion = flagUpdateAppVersion & false;
                }
                else
                {
                    saveBranches();
                }
            }
            branches = (branches == null) ? new List<Branch>() : branches;
        }
        public static void setServices()
        {
            if (Constants.isSameVersion())
            {
                SessionTable temp = App.Database.GetItem(DBConstants.ID_SERVICES);
                if (temp != null)
                {
                    services = JArray.Parse(temp.JSON_DATA).ToObject<List<Service>>();
                }
            }
            else
            {
                services = MetaDataService.getInstance().CallGetBranchServices().services;
                if (services == null)
                {
                    flagUpdateAppVersion = flagUpdateAppVersion & false;
                }
                else
                {
                    saveServices();
                }
            }
            services = (services == null) ? new List<Service>() : services;
        }
    }
}
