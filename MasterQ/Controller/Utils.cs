using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MasterQ
{
	public class Utils
	{
		public static CodeDescription getCodeDesc(int id)
		{
			CodeDescription ret = new CodeDescription();
			CodeDescription temp = TempDB.codeDescriptions.Find(s => s.id == id);
			if (temp == null)
			{
                temp = TempDB.codeDescriptions.Find(s => s.id == Constants.ERROR_DEFAULT_ID);
			}
			return ret;
		}
	}
}
