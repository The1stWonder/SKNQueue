using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MasterQ
{
    public class Validate
    {

        public static bool isEmailFormat(String input)
        {
            return Regex.Match(input, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success;
        }
		public static bool isPhoneNumber(string number)
		{
			return Regex.Match(number, @"^(\+[0-9]{10})$").Success;
		}
		public static bool isDateFormat(String input)
		{
            DateTime Test;
            return DateTime.TryParseExact(input, "dd/MM/yyyy", null, DateTimeStyles.None, out Test);
		}
    }
}
