using System;
namespace MasterQ
{
    public class UIReturn
    {
        public Boolean isSuccess { get; set; }
        public String code { get; set; }
		public String codeValue { get; set; }
        public String descriptionTH { get; set; }
        public String descriptionEN { get; set; }
        public Object returnObject { get; set; }

        public UIReturn()
        {
            this.isSuccess = false;
        }
        public String getDescription(){
            return (true)?descriptionTH:descriptionEN;
        }
        public UIReturn(bool isSuccess, string code, string codeValue, string descriptionTH, string descriptionEN, object returnObject)
        {
            this.isSuccess = isSuccess;
            this.code = code;
            this.codeValue = codeValue;
            this.descriptionTH = descriptionTH;
            this.descriptionEN = descriptionEN;
            this.returnObject = returnObject;
        }
		public UIReturn(Object returnObject,bool isSuccess, String groups,String functions,String code)
		{
			this.isSuccess = isSuccess;
            CodeDescription codeDesc = Utils.getCodeDesc(groups, functions, code);
            this.code = codeDesc.code;
			this.codeValue = codeDesc.codeValue;
			this.descriptionTH = codeDesc.descriptionTH;
			this.descriptionEN = codeDesc.descriptionEN;
			this.returnObject = returnObject;
		}
        public UIReturn(Object returnObject,HeaderResponse header)
		{
			this.isSuccess = header.isSuccess;
			CodeDescription codeDesc = Utils.getCodeDesc(header.groups, header.functions, header.code);
            this.code = codeDesc.code;
			this.codeValue = codeDesc.codeValue;
			this.descriptionTH = codeDesc.descriptionTH;
			this.descriptionEN = codeDesc.descriptionEN;
			this.returnObject = returnObject;
		}
    }
}
