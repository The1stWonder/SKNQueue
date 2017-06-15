using System;
using System.Text.RegularExpressions;

namespace MasterQ
{
	public static class Validate
	{
		private static String invalidEmail = "Invalid Email Format. For Example aaa@bbb.com";

		public static void validateEmail(Validation input)
		{
			if (Regex.Match(input.textInput, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
			{
				input.callBack.isSuccess = true;
			}
			input.callBack.setReturnMessage(String.Empty, invalidEmail);
		}
	}
}
