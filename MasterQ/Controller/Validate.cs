using System;
using System.Text.RegularExpressions;

namespace MasterQ
{
	public static class Validate
	{
		private static String invalidEmail = "Invalid Email Format. For Example aaa@bbb.com";

		public static Validation email(Validation input)
		{
			Validation ret = new Validation(input.textInput);
			if (Regex.Match(input.textInput, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
			{
				ret.validateResult = true;
			}
			ret.setReturnMessage(String.Empty, invalidEmail);
			return ret;
		}
	}
}
