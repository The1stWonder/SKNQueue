using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MasterQ
{
    public class LoginController
    {
        public static async Task<Login> AuthenuserAsync(Login input)
        {
            if (isEmptyUserName(input)) return input;
            if (isEmptyPassword(input)) return input;
            if (!isValidEmail(input)) return input;

            List<SampleJSONService> result = await SampleService.CallGetAsync();

            if (authen(input, result))
            {
                input.isLogin = true;
                MCust.login = input;
            }
            return input;
        }
        public static UIReturn Authenuser(Login input)
        {
            if (isEmptyUserName(input)) return new UIReturn(input, false, "", Constants.emptyUserName);
            if (isEmptyPassword(input)) return new UIReturn(input, false, "", Constants.emptyPassword);
            if (!isValidEmail(input)) return new UIReturn(input, false, "", Constants.invalidEmail);

            List<SampleJSONService> result = SampleService.CallGet();


			UIReturn ret = new UIReturn(input);
            if (authen(input, result))
            {
                input.isLogin = true;
                MCust.login = input;
                ret.setSuccess();
            }else{
                ret.setFail("",Constants.authenFail);
            }
            return ret;
        }

        private static bool isEmptyUserName(Login input)
        {
            return String.IsNullOrEmpty(input.username);
        }
        private static bool isEmptyPassword(Login input)
        {
            return String.IsNullOrEmpty(input.password);
        }
        private static bool isValidEmail(Login input)
        {
            return Validate.validateEmail(new Validation(input.username));
        }
        private static bool authen(Login input, List<SampleJSONService> list)
        {
            return  input.username.ToUpper().Equals(list.ToArray()[0].MemberEmail.ToUpper()) && input.password.Equals(list.ToArray()[0].MemberID);
        }

    }
}
