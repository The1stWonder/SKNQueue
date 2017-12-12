using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MasterQ
{
    public class Initial
    {
        public static void init()
        {
            Constants.oldVersion = Constants.getDefaultVersion();
            Constants.newVersion = Constants.getDefaultNewVersion();

            SessionTable version = App.Database.GetItem(DBConstants.ID_APP_VERSION);
            if (version != null)
            {
                Constants.oldVersion = JObject.Parse(version.JSON_DATA).ToObject<AppVersion>();
            }

            TempDB.setCodeDescriptions();
            init_Member();
            init_User();
            init_Branch();
            Constants.APPLICATION_LANGUAGE = getLanguageFromDB();

            if (TempDB.flagUpdateAppVersion)
            {
                App.Database.SaveItem(DBConstants.ID_APP_VERSION, JsonConvert.SerializeObject(Constants.newVersion));

            }
            Constants.setUIReturn();
        }

        public static void init_User()
        {
            if (Constants.isAppForUser())
            {
                UserSessionModel.loginUser = getUserFormDB();
                App.IPAdress = getUserAppIP();
            }
        }
        public static void init_Branch()
        {
            if (Constants.isAppForBranch())
            {
                BranchSessionModel.loginBranch = getBranchLoginFormDB();
                App.IPAdress = getBranchAppIP();
            }
        }

        public static void init_Member()
        {
            if (Constants.isAppForMember())
            {
                TempDB.setProvinces();
                TempDB.setDistrict();
                TempDB.setBranches();
                TempDB.setServices();

                SessionModel.loginMember = getMemberFormDB();
                if (SessionModel.loginMember != null)
                {
                    UIReturn uiReturn = ReserveQController.getInstance().getMemberSession(SessionModel.loginMember);
                }
            }
        }

        private static Member getMemberFormDB()
        {
            SessionTable temp = App.Database.GetItem(DBConstants.ID_LOGIN_MEMBER);
            return (temp == null) ? null : JObject.Parse(temp.JSON_DATA).ToObject<Member>();
        }
        private static User getUserFormDB()
        {
            SessionTable temp = App.Database.GetItem(DBConstants.ID_LOGIN_USER);
            return (temp == null) ? null : JObject.Parse(temp.JSON_DATA).ToObject<User>();
        }
        private static Branch getBranchLoginFormDB()
        {
            SessionTable temp = App.Database.GetItem(DBConstants.ID_LOGIN_BRANCH);
            return (temp == null) ? null : JObject.Parse(temp.JSON_DATA).ToObject<Branch>();
        }
        private static String getUserAppIP()
        {
            SessionTable temp = App.Database.GetItem(DBConstants.ID_IP_USER);
            return (temp == null) ? "" : temp.JSON_DATA;
        }
        private static String getBranchAppIP()
        {
            SessionTable temp = App.Database.GetItem(DBConstants.ID_IP_BRANCH);
            return (temp == null) ? "" : temp.JSON_DATA;
        }
        private static String getLanguageFromDB()
        {
            String ID = "";
            if (Constants.isAppForMember())
            {
                ID = DBConstants.ID_LANGUAGE_MEMBER;
            }
            else if (Constants.isAppForUser())
            {
                ID = DBConstants.ID_LANGUAGE_USER;
            }
            else if (Constants.isAppForBranch())
            {
                ID = DBConstants.ID_LANGUAGE_BRANCH;
            }
            SessionTable temp = App.Database.GetItem(ID);
            return (temp == null) ? Constants.APPLICATION_LANGUAGE_DEFAULT : temp.JSON_DATA;
        }
    }
}
