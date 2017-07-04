using System;
using System.Text.RegularExpressions;

namespace MasterQ
{
    public static class Validate
    {

        public static bool validateEmail(Validation input)
        {
            return Regex.Match(input.textInput, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success;
        }
    }
}
