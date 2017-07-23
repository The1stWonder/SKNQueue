using System;
using System.Text.RegularExpressions;

namespace MasterQ
{
    public class Validate
    {

        public static bool email(String input)
        {
            return Regex.Match(input, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success;
        }
    }
}
