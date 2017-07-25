using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MasterQ
{
	public class Utils
	{
        public static CodeDescription getCodeDesc(String groups, String functions, String code){
            GetCodeDescriptionRs res = MetaDataService.getInstance().CallGetCodeDescription(groups, functions, code);
            return res.codeDescription;
        }
	}
}
