using System;
namespace MasterQ
{
	public class Validation
	{
		public String textInput { get; set; }
		public Return callBack { get; set; }

		public Validation()
		{
			this.textInput = String.Empty;
			this.callBack = new Return();
		}

		public Validation(String input)
		{
            this.callBack = new Return();
			this.textInput = input;
		}
	}
}
