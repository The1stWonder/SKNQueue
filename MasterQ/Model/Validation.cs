using System;
namespace MasterQ
{
	public class Validation
	{
		public String textInput { get; set; }

		public Validation()
		{
			this.textInput = String.Empty;
		}

		public Validation(String input)
		{
			this.textInput = input;
		}
	}
}
