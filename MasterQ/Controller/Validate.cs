using System;
using System.Text.RegularExpressions;

namespace MasterQ
{
	public static class Validate
	{
		private static String invalidEmail = "Invalid Email Format. For Example aaa@bbb.com";

		public static void validateEmail(Validation input)
		{
			input.callBack.isSuccess = Regex.Match(input.textInput, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success;
			input.callBack.setReturnMessage(String.Empty, invalidEmail);
		}

		public static void isNullOrEmpty(Validation input)
		{
			input.callBack.isSuccess = String.IsNullOrWhiteSpace(input.textInput);
			input.callBack.setReturnMessage(String.Empty, "This String is not null or empty");
		}
	}
}
