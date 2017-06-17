using System;
namespace MasterQ
{
	public class Return
	{
		public String message { get; set; }
		public Boolean isSuccess { get; set; }
		public String status { get; set; }

		public Return()
		{
			this.message = String.Empty;
			this.isSuccess = false;
			this.status = "FAIL";
		}

        public void setReturn(Boolean condition,String textSuccess,String textFail){
            if(condition){
                this.message = textSuccess;
                this.isSuccess = true;
				this.status = "SUCCESS";
            }else{
                this.message = textFail;
                this.isSuccess = false;
                this.status = "FAIL";
            }
        }
	}
}
