﻿using System;
namespace MasterQ
{
    public static class LoginController
    {
        private static String authenFail = "Login Failed. Username Or Password incorrect!!!";
        private static String emptyUserName = "Please input username";
        private static String emptyPassword = "Please input password";

        public static void login(Login input)
        {
            if (isEmptyUserName(input)) return;
            if (isEmptyPassword(input)) return;
            if (!isValidEmail(input)) return;

            if (authen(input))
            {
                input.isLogin = true;
                MCust.login = input;
            }
        }

        private static bool isEmptyUserName(Login input)
        {
            bool ret = String.IsNullOrEmpty(input.username);
            input.callBack.setReturn(!ret, String.Empty, emptyUserName);
            return ret;
        }
        private static bool isEmptyPassword(Login input)
        {
            bool ret = String.IsNullOrEmpty(input.password);
            input.callBack.setReturn(!ret, String.Empty, emptyPassword);
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
        private static bool authen(Login input)
        {
            bool ret = input.username.ToUpper().Equals("ADMIN@MASTERQ.COM") && input.password.Equals("admin");
            input.callBack.setReturn(ret, String.Empty, authenFail);
            return ret;
        }
    }
}
