using System;
namespace MasterQ
{
    public class Constants
    {
        // Application Type
        public static String APPLICATION_TYPE_MEMBER = "MEMBER";
        public static String APPLICATION_TYPE_USER = "USER";
        public static String APPLICATION_TYPE_BRANCH = "BRANCH";
        public static String APPLICATION_TYPE = APPLICATION_TYPE_MEMBER;
        //public static String APPLICATION_TYPE = APPLICATION_TYPE_USER;
        //public static String APPLICATION_TYPE = APPLICATION_TYPE_BRANCH;

        public static String QUEUE_TYPE_MEMBER = "O";
        public static String QUEUE_TYPE_BRANCH = "K";

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


        public static UIReturn uiErrorDefault = new UIReturn(false, ERROR_DEFAULT_ID);
        public static UIReturn uiSuccessDefault = new UIReturn(true, SUCCESS_DEFAULT_ID);

        public static UIReturn uiPassValidEmail = new UIReturn(true, SUCCESS_DEFAULT_ID);
        public static UIReturn uiErrorInvalidEmail = new UIReturn(false, ERROR_INVALID_EMAIL_ID);
        public static UIReturn uiErrorInvalidPhoneNumber = new UIReturn(false, ERROR_INVALID_PHONE_NUMBER);
        public static UIReturn uiErrorInvalidDateFormat = new UIReturn(false, ERROR_INVALID_DATE_FORMAT);
        public static UIReturn uiErrorPasswordNotMatch = new UIReturn(false, ERROR_PASSWORD_NOT_MATCH_ID);
        public static UIReturn uiErrorEmptyUserName = new UIReturn(false, ERROR_EMPTY_USERNAME_ID);
        public static UIReturn uiErrorEmptyPassword = new UIReturn(false, ERROR_EMPTY_PASSWORD_ID);
        public static UIReturn uiErrorEmptyEmail = new UIReturn(false, ERROR_EMPTY_EMAIL_ID);
        public static UIReturn uiErrorEmptyFirstName = new UIReturn(false, ERROR_EMPTY_FIRSTNAME_ID);
        public static UIReturn uiErrorEmptyLastName = new UIReturn(false, ERROR_EMPTY_LASTNAME_ID);
        public static UIReturn uiErrorEmptyBirthdate = new UIReturn(false, ERROR_EMPTY_BIRTHDATE_ID);
        public static UIReturn uiErrorEmptyConfirmPassword = new UIReturn(false, ERROR_EMPTY_CONFIRM_PASSWORD_ID);
        public static UIReturn uiErrorEmptyCounterNumber = new UIReturn(false, ERROR_EMPTY_COUNTER_NUMBER);

        // Commom Error
        public static int ERROR_NO_BRANCH = 8;
        public static int ERROR_NO_SERVICE = 11;

        public static UIReturn uiErrorNoBranch = new UIReturn(false, ERROR_NO_BRANCH);
        public static UIReturn uiErrorNoService = new UIReturn(false, ERROR_NO_SERVICE);

        public static bool isAppForMember()
        {
            return Constants.APPLICATION_TYPE.Equals(Constants.APPLICATION_TYPE_MEMBER);
        }
        public static bool isAppForUser()
        {
            return Constants.APPLICATION_TYPE.Equals(Constants.APPLICATION_TYPE_USER);
        }
        public static bool isAppForBranch()
        {
            return Constants.APPLICATION_TYPE.Equals(Constants.APPLICATION_TYPE_BRANCH);
        }

    }
}
