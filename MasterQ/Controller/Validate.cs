using System;
using System.Text.RegularExpressions;

namespace MasterQ
{
    public static class Validate
    {

        public static void validateEmail(Validation input)
        {
            bool result = Regex.Match(input.textInput, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success;
            input.callBack.setReturn(result, String.Empty, Constants.invalidEmail);
        }
    }
}
