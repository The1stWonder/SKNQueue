using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms.Internals;

namespace MasterQ
{
    [Preserve(AllMembers = true)] //alexpook link all
    public class Utils
    {
        public static CodeDescription getCodeDesc(int id)
        {
            CodeDescription temp = TempDB.codeDescriptions.Find(s => s.id == id);
            if (temp == null)
            {
                temp = TempDB.codeDescriptions.Find(s => s.id == Constants.ERROR_DEFAULT_ID);
            }
            return temp;
        }
        public static String getQueueType()
        {
            String ret = String.Empty;
            if (Constants.isAppForMember())
            {
                ret = Constants.QUEUE_TYPE_MEMBER;
            }
            else if (Constants.isAppForBranch())
            {
                ret = Constants.QUEUE_TYPE_BRANCH;
            }
            return ret;
        }
        public byte[] getImageBytes(String imageBase64)
        {
            return Convert.FromBase64String(imageBase64);
        }
        private static void changeAppLanguage(String language)
        {
            Constants.APPLICATION_LANGUAGE = language;
            SessionTable temp = new SessionTable();
            temp.ID = DBConstants.ID_LANGUAGE_MEMBER;
            temp.JSON_DATA = language;
            App.Database.SaveItem(temp);
        }
        public static void changeAppLanguageToThai()
        {
            changeAppLanguage(Constants.APPLICATION_LANGUAGE_THAI);
        }
        public static void changeAppLanguageToEng()
        {
            changeAppLanguage(Constants.APPLICATION_LANGUAGE_ENG);
        }

        public static String getLabel(int id)
        {
            CodeDescription temp = getCodeDesc(id);
            if (temp == null)
            {
                return "";
            }
            return (Constants.isThaiLanguage()) ? temp.descriptionTH : temp.descriptionEN;
        }
    }
}
