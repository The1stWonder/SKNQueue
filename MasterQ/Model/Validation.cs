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
		}

		public Validation(String input)
		{
			this.textInput = input;
			this.validateResult = new Boolean();
			this.returnMessage = null;
		}
		public void setReturn(Boolean result, String textTrue, String TextFalse)
		{
			this.validateResult = result;
			this.returnMessage = (result) ? textTrue : TextFalse;
		}
	}
}
