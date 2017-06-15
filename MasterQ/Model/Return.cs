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
			this.status = String.Empty;
		}
		public void setReturnMessage(String textTrue, String textFalse)
		{
			this.message = (this.isSuccess) ? textTrue : textFalse;
		}
		public void setIsSuccess(Boolean isSuccess)
		{
			this.isSuccess = isSuccess;
		}
	}
}
