using System;
namespace MasterQ
{
	public class Constants
	{
        public static String GROUPS_VALIDATE = "VALIDATE";
		public static String FUNCTIONS_EMAIL = "EMAIL";
		public static String CODE_VALID_EMAIL = "00";
        public static String CODE_INVALID_EMAIL = "01";
		public static String FUNCTIONS_EMPTY_INPUT = "EMPTYINPUT";
		public static String CODE_EMPTY_USERNAME = "01";
		public static String CODE_EMPTY_PASSWORD = "02";
        public static String CODE_EMPTY_EMAIL = "03";
        public static String CODE_EMPTY_FIRSTNAME = "04";
		public static String CODE_EMPTY_LASTNAME = "05";
		public static String CODE_EMPTY_BIRTHDATE = "06";
        public static String CODE_EMPTY_CONFIRMPASSWORD = "07";
        public static String FUNCTIONS_PASSWORD = "PASSWORD";
        public static String CODE_PASSWORD_NOTMATCH = "01";

		public static String GROUPS_DEFAULT = "DEFAULT";
		public static String FUNCTIONS_SUCCESS = "SUCCESS";
		public static String CODE_DEFAULT_SUCCESS = "00";
		public static String FUNCTIONS_ERROR = "ERROR";
        public static String CODE_DEFAULT_ERROR = "00";

        public static UIReturn uiErrorDefault = new UIReturn(false, GROUPS_DEFAULT, FUNCTIONS_ERROR, CODE_DEFAULT_ERROR);
        public static UIReturn uiSuccessDefault = new UIReturn(true, GROUPS_DEFAULT, FUNCTIONS_SUCCESS, CODE_DEFAULT_SUCCESS);

        public static UIReturn uiPassValidEmail = new UIReturn(true, GROUPS_VALIDATE, FUNCTIONS_EMAIL, CODE_VALID_EMAIL);

        public static UIReturn uiErrorInvalidEmail = new UIReturn(false, GROUPS_VALIDATE, FUNCTIONS_EMAIL, CODE_INVALID_EMAIL);
        public static UIReturn uiErrorPasswordNotMatch = new UIReturn(false, GROUPS_VALIDATE, FUNCTIONS_PASSWORD, CODE_PASSWORD_NOTMATCH);
        public static UIReturn uiErrorEmptyUserName = new UIReturn(false, GROUPS_VALIDATE, FUNCTIONS_EMPTY_INPUT, CODE_EMPTY_USERNAME);
        public static UIReturn uiErrorEmptyPassword = new UIReturn(false, GROUPS_VALIDATE, FUNCTIONS_EMPTY_INPUT, CODE_EMPTY_PASSWORD);
        public static UIReturn uiErrorEmptyEmail = new UIReturn(false, GROUPS_VALIDATE, FUNCTIONS_EMPTY_INPUT, CODE_EMPTY_EMAIL);
		public static UIReturn uiErrorEmptyFirstName = new UIReturn(false, GROUPS_VALIDATE, FUNCTIONS_EMPTY_INPUT, CODE_EMPTY_FIRSTNAME);
        public static UIReturn uiErrorEmptyLastName = new UIReturn(false, GROUPS_VALIDATE, FUNCTIONS_EMPTY_INPUT, CODE_EMPTY_LASTNAME);
		public static UIReturn uiErrorEmptyBirthdate = new UIReturn(false, GROUPS_VALIDATE, FUNCTIONS_EMPTY_INPUT, CODE_EMPTY_BIRTHDATE);
        public static UIReturn uiErrorEmptyConfirmPassword = new UIReturn(false, GROUPS_VALIDATE, FUNCTIONS_EMPTY_INPUT, CODE_EMPTY_CONFIRMPASSWORD);

	}
}
