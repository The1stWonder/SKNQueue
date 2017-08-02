using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MasterQ
{
	public class Utils
	{
        public static CodeDescription getCodeDesc(String groups, String functions, String code){
            //GetCodeDescriptionRs res = MetaDataService.getInstance().CallGetCodeDescription(groups, functions, code);
            CodeDescription ret = new CodeDescription();
            CodeDescription temp = TempDB.codeDescriptions.Find(s => s.groups == groups && s.functions == functions && s.code == code);
            if (temp==null){
                temp = TempDB.codeDescriptions.Find(s => s.groups == Constants.GROUPS_DEFAULT 
                                                   && s.functions == Constants.FUNCTIONS_ERROR 
                                                   && s.code == Constants.CODE_DEFAULT_ERROR);
            }else{
                ret = temp;
            }
            return ret;
        }
	}
}
