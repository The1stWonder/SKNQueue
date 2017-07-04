using System;
namespace MasterQ
{
    public class UIReturn
    {
        public Boolean isSuccess { get; set; }
        public String code { get; set; }
        public String description { get; set; }
        public Object returnObject { get; set; }

        public UIReturn()
        {
            this.isSuccess = false;
        }
        public UIReturn(Object o)
        {
            this.isSuccess = false;
            this.returnObject = o;
        }
        public UIReturn(Object o, Boolean isSuccess, String code, String description)
        {
            this.isSuccess = isSuccess;
            this.code = code;
            this.description = description;
            this.returnObject = o;
        }

        public void setFail(String code, String description)
        {
            this.isSuccess = false;
            this.code = code;
            this.description = description;
        }
        public void setSuccess()
        {
            this.isSuccess = true;
            this.code = String.Empty;
            this.description = String.Empty;
        }
        public void setSuccess(String code, String description)
        {
            this.isSuccess = true;
            this.code = code;
            this.description = description;
        }
    }
}
