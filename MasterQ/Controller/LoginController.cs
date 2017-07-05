using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MasterQ
{
    public class LoginController
    {
        public static async Task<UIReturn> AuthenuserAsync(Login input)
        {
            if (isEmptyUserName(input)) return new UIReturn(input, false, "", Constants.emptyUserName);
            if (isEmptyPassword(input)) return new UIReturn(input, false, "", Constants.emptyPassword);
            if (!isValidEmail(input)) return new UIReturn(input, false, "", Constants.invalidEmail);

            //List<SampleJSONService> result = await SampleService.CallGetAsync();
            SampleJSONService result = await SampleService.CallPostAsync();

            UIReturn ret = new UIReturn(input);
            if (authen(input, result))
            {
                input.isLogin = true;
                MCust.login = input;
            }
            else
            {
                ret.setFail("", Constants.authenFail);
            }
            return ret;
        }
        public static UIReturn Authenuser(Login input)
        {
            if (isEmptyUserName(input)) return new UIReturn(input, false, "", Constants.emptyUserName);
            if (isEmptyPassword(input)) return new UIReturn(input, false, "", Constants.emptyPassword);
            if (!isValidEmail(input)) return new UIReturn(input, false, "", Constants.invalidEmail);

            //List<SampleJSONService> result = SampleService.CallGet();
            SampleJSONService result = SampleService.CallPost(input);


            UIReturn ret = new UIReturn(input);
            if (authen(input, result))
            {
                input.isLogin = true;
                MCust.login = input;
                ret.setSuccess();
            }
            else
            {
                ret.setFail("", Constants.authenFail);
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
        private static bool authen(Login input, SampleJSONService loginuser)
        {
            return loginuser.MemberID != null;
        }

    }
}
