using System;
namespace MasterQ
{
    public class UIReturn
    {
        public Boolean isSuccess { get; set; }
		public int id { get; set; }
        public String code { get; set; }
        public String codeValue { get; set; }
        public String descriptionTH { get; set; }
        public String descriptionEN { get; set; }
        public Object returnObject { get; set; }

        public UIReturn()
        {
            this.isSuccess = false;
        }
        public String getDescription()
        {
            return (Constants.isThaiLanguage()) ? descriptionTH : descriptionEN;
        }
        public UIReturn(HeaderResponse header)
        {
            this.id = header.id;
            this.isSuccess = header.isSuccess;
            CodeDescription codeDesc = Utils.getCodeDesc(header.id);
            this.code = codeDesc.code;
            this.codeValue = codeDesc.codeValue;
            this.descriptionTH = codeDesc.descriptionTH;
            this.descriptionEN = codeDesc.descriptionEN;
        }
        public UIReturn(bool isSuccess, int id)
        {
            this.id = id;
            this.isSuccess = isSuccess;
            CodeDescription codeDesc = Utils.getCodeDesc(id);
            this.code = codeDesc.code;
            this.codeValue = codeDesc.codeValue;
            this.descriptionTH = codeDesc.descriptionTH;
            this.descriptionEN = codeDesc.descriptionEN;
        }
    }
}
