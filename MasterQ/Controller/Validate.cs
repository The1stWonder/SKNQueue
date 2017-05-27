using System;
using System.Text.RegularExpressions;

namespace MasterQ
{
	public static class Validate
	{
		private static String invalidEmail = "Invalid Email Format. For Example aaa@bbb.com";

		public static Validation email(Validation input)
		{
			Boolean ret = false;
			if (Regex.Match(input.textInput, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
			{
				ret = true;
			}
			input.setReturn(ret, String.Empty, invalidEmail);
			return input;
		}
	}
}
