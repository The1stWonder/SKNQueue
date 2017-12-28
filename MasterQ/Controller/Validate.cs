using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MasterQ
{
    public class Validate
    {

        public static bool isEmailFormat(String input)
        {
            return Regex.Match(input, @"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$", RegexOptions.IgnoreCase).Success;
        }
        public static bool isPhoneNumber(string number)
        {
            int num;
            return number.Length == 10 && int.TryParse(number, out num) && number.StartsWith("0");
        }
        public static bool isDateFormat(String input)
        {
            DateTime Test;
            return DateTime.TryParseExact(input, "dd/MM/yyyy", null, DateTimeStyles.None, out Test);
        }
    }
}
