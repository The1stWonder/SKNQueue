﻿using System;
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
        public static Login Authenuser(Login input)
		{
            if (isEmptyUserName(input)) return input;
            if (isEmptyPassword(input)) return input;
			if (!isValidEmail(input)) return input;

			List<SampleJSONService> result = SampleService.CallGet();

			if (authen(input,result))
			{
				input.isLogin = true;
				MCust.login = input;
			}
			return input;
		}

        private static bool isEmptyUserName(Login input)
        {
            bool ret = String.IsNullOrEmpty(input.username);
            input.callBack.setReturn(!ret, String.Empty, Constants.emptyUserName);
            return ret;
        }
        private static bool isEmptyPassword(Login input)
        {
            bool ret = String.IsNullOrEmpty(input.password);
            input.callBack.setReturn(!ret, String.Empty, Constants.emptyPassword);
            return ret;
        }
        private static bool isValidEmail(Login input)
        {
            Validation varEmail = new Validation(input.username);
            Validate.validateEmail(varEmail);
            bool ret = varEmail.callBack.isSuccess;
            input.callBack.setReturn(ret, String.Empty, varEmail.callBack.message);
            return ret;
        }
		private static bool authen(Login input,List<SampleJSONService> list)
		{
            bool ret = input.username.ToUpper().Equals(list.ToArray()[0].MemberEmail.ToUpper()) && input.password.Equals(list.ToArray()[0].MemberID);
			input.callBack.setReturn(ret, String.Empty, Constants.authenFail);
			return ret;
		}
		
    }
}
