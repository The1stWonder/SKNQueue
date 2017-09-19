using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MasterQ
{
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
    }
}
