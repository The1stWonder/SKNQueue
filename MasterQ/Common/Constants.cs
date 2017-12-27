using System;
namespace MasterQ
{
    public class Constants
    {
        // Application Type
        public static String APPLICATION_TYPE_MEMBER = "MEMBER";
        public static String APPLICATION_TYPE_USER = "USER";
        public static String APPLICATION_TYPE_BRANCH = "BRANCH";
        //public static String APPLICATION_TYPE = APPLICATION_TYPE_MEMBER;
        public static String APPLICATION_TYPE = APPLICATION_TYPE_USER;
        //public static String APPLICATION_TYPE = APPLICATION_TYPE_BRANCH;

        public static AppVersion oldVersion;
        public static AppVersion newVersion;
        public static String DB_DEFAULT_VERSION = "0";
        public static String APP_DEFAULT_VERSION = "0";
        public static String DB_DEFAULT_NEW_VERSION = "1";
        public static String APP_DEFAULT_NEW_VERSION = "1";

        public static String APPLICATION_LANGUAGE_THAI = "TH";
        public static String APPLICATION_LANGUAGE_ENG = "EN";
        public static String APPLICATION_LANGUAGE_DEFAULT = APPLICATION_LANGUAGE_THAI;
        public static String APPLICATION_LANGUAGE = APPLICATION_LANGUAGE_DEFAULT;

        public static String QUEUE_TYPE_MEMBER = "O";
        public static String QUEUE_TYPE_BRANCH = "K";
        public static String QUEUE_TYPE_RECHECK = "R";

        // Validation
        public static int ERROR_DEFAULT_ID = 1;
        public static int SUCCESS_DEFAULT_ID = 2;
        public static int ERROR_INVALID_EMAIL_ID = 16;
        public static int ERROR_INVALID_PHONE_NUMBER = 47;
        public static int ERROR_INVALID_DATE_FORMAT = 48;
        public static int ERROR_PASSWORD_NOT_MATCH_ID = 24;
        public static int ERROR_EMPTY_USERNAME_ID = 17;
        public static int ERROR_EMPTY_PASSWORD_ID = 18;
        public static int ERROR_EMPTY_EMAIL_ID = 19;
        public static int ERROR_EMPTY_FIRSTNAME_ID = 20;
        public static int ERROR_EMPTY_LASTNAME_ID = 21;
        public static int ERROR_EMPTY_BIRTHDATE_ID = 22;
        public static int ERROR_EMPTY_CONFIRM_PASSWORD_ID = 23;
        public static int ERROR_EMPTY_COUNTER_NUMBER = 50;


        public static UIReturn uiErrorDefault;
        public static UIReturn uiSuccessDefault;

        public static UIReturn uiPassValidEmail;
        public static UIReturn uiErrorInvalidEmail;
        public static UIReturn uiErrorInvalidPhoneNumber;
        public static UIReturn uiErrorInvalidDateFormat;
        public static UIReturn uiErrorPasswordNotMatch;
        public static UIReturn uiErrorEmptyUserName;
        public static UIReturn uiErrorEmptyPassword;
        public static UIReturn uiErrorEmptyEmail;
        public static UIReturn uiErrorEmptyFirstName;
        public static UIReturn uiErrorEmptyLastName;
        public static UIReturn uiErrorEmptyBirthdate;
        public static UIReturn uiErrorEmptyConfirmPassword;
        public static UIReturn uiErrorEmptyCounterNumber;

        // Commom Error
        public static int ERROR_NO_BRANCH = 8;
        public static int ERROR_NO_SERVICE = 11;
        public static int ERROR_SERVER_DOWN = 101;

        public static UIReturn uiErrorNoBranch;
        public static UIReturn uiErrorNoService;

        public static bool isAppForMember()
        {
            return APPLICATION_TYPE.Equals(APPLICATION_TYPE_MEMBER);
        }
        public static bool isAppForUser()
        {
            return APPLICATION_TYPE.Equals(APPLICATION_TYPE_USER);
        }
        public static bool isAppForBranch()
        {
            return APPLICATION_TYPE.Equals(APPLICATION_TYPE_BRANCH);
        }
        public static bool isThaiLanguage()
        {
            return APPLICATION_LANGUAGE.Equals(APPLICATION_LANGUAGE_THAI);
        }
        public static bool isEnglishLanguage()
        {
            return APPLICATION_LANGUAGE.Equals(APPLICATION_LANGUAGE_ENG);
        }

        public static bool isSameDBVersion()
        {
            return oldVersion.dbVersion.Equals(newVersion.dbVersion);
        }

        public static AppVersion getDefaultVersion()
        {
            AppVersion ret = new AppVersion();
            ret.appVersion = APP_DEFAULT_VERSION;
            ret.dbVersion = DB_DEFAULT_VERSION;
            return ret;
        }
        public static AppVersion getDefaultNewVersion()
        {
            AppVersion ret = new AppVersion();
            ret.appVersion = APP_DEFAULT_NEW_VERSION;
            ret.dbVersion = DB_DEFAULT_NEW_VERSION;
            return ret;
        }

        public static void setUIReturn()
        {
            uiErrorDefault = new UIReturn(false, ERROR_DEFAULT_ID);
            uiSuccessDefault = new UIReturn(true, SUCCESS_DEFAULT_ID);
            uiPassValidEmail = new UIReturn(true, SUCCESS_DEFAULT_ID);
            uiErrorInvalidEmail = new UIReturn(false, ERROR_INVALID_EMAIL_ID);
            uiErrorInvalidPhoneNumber = new UIReturn(false, ERROR_INVALID_PHONE_NUMBER);
            uiErrorInvalidDateFormat = new UIReturn(false, ERROR_INVALID_DATE_FORMAT);
            uiErrorPasswordNotMatch = new UIReturn(false, ERROR_PASSWORD_NOT_MATCH_ID);
            uiErrorEmptyUserName = new UIReturn(false, ERROR_EMPTY_USERNAME_ID);
            uiErrorEmptyPassword = new UIReturn(false, ERROR_EMPTY_PASSWORD_ID);
            uiErrorEmptyEmail = new UIReturn(false, ERROR_EMPTY_EMAIL_ID);
            uiErrorEmptyFirstName = new UIReturn(false, ERROR_EMPTY_FIRSTNAME_ID);
            uiErrorEmptyLastName = new UIReturn(false, ERROR_EMPTY_LASTNAME_ID);
            uiErrorEmptyBirthdate = new UIReturn(false, ERROR_EMPTY_BIRTHDATE_ID);
            uiErrorEmptyConfirmPassword = new UIReturn(false, ERROR_EMPTY_CONFIRM_PASSWORD_ID);
            uiErrorEmptyCounterNumber = new UIReturn(false, ERROR_EMPTY_COUNTER_NUMBER);
            uiErrorNoBranch = new UIReturn(false, ERROR_NO_BRANCH);
            uiErrorNoService = new UIReturn(false, ERROR_NO_SERVICE);
        }
    }

}
