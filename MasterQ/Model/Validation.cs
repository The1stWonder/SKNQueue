using System;
namespace MasterQ
{
	public class Validation
	{
		public String textInput { get; set; }
		public String returnMessage { get; set; }
		public Boolean validateResult { get; set; }
		public Validation()
		{
            this.textInput = String.Empty;
			this.validateResult = false;
			this.returnMessage = String.Empty;
		}

		public Validation(String input)
		{
			this.textInput = input;
			this.validateResult = false;
			this.returnMessage = String.Empty;
		}
		public void setReturnMessage(String textTrue, String textFalse)
		{
			this.returnMessage = (this.validateResult) ? textTrue : textFalse;
		}
	}
}
