using System;
namespace MasterQ
{
    public class ServiceURL
    {
        public static String ipDev = "http://192.1.1.206";
        public static String ipPro = "http://202.129.59.21";
        public static String ipServer = ipDev;
        public static String serviceName = "/QueueService.svc/";
        public static String memberPrefix = "Member/";
        public static String userPrefix = "User/";
        public static String branchPrefix = "Branch/";

        public static String sampleUrlGet = serviceName + memberPrefix + "Member/";
        public static String sampleUrlPost = serviceName + memberPrefix + "Login/";

        public static String getCodeDescriptionUrl = serviceName + "GetCodeDescription/";
        public static String getProvicesUrl = serviceName + "GetProvinces/";
        public static String getDistrictsUrl = serviceName + "GetDistricts/";

        public static String loginUrl = serviceName + memberPrefix + "Login/";
		public static String logoutUrl = serviceName + memberPrefix + "Logout/";
        public static String registerUrl = serviceName + memberPrefix + "Register/";
        public static String editProfileUrl = serviceName + memberPrefix + "EditProfile/";
        public static String forgetPasswordUrl = serviceName + memberPrefix + "ForgetPassword/";
        public static String getBranchesUrl = serviceName + memberPrefix + "GetBranches/";
        public static String getBranchServicesUrl = serviceName + memberPrefix + "GetBranchServices/";
        public static String reserveQueueUrl = serviceName + memberPrefix + "ReserveQueue/";
        public static String getHistoryUrl = serviceName + memberPrefix + "GetHistory/";
        public static String cancelQueueUrl = serviceName + memberPrefix + "CancelQueue/";

        public static String userLoginUrl = serviceName + userPrefix + "Login/";
        public static String userLogoutUrl = serviceName + userPrefix + "Logout/";
        public static String userOpenServiceUrl = serviceName + userPrefix + "OpenService/";
        public static String userGetServiceUrl = serviceName + userPrefix + "GetService/";
        public static String userAcceptQueueUrl = serviceName + userPrefix + "AcceptQueue/";
        public static String userCallQueueUrl = serviceName + userPrefix + "CallQueue/";
        public static String userFinishQueueUrl = serviceName + userPrefix + "FinishQueue/";
        public static String userSkipQueueUrl = serviceName + userPrefix + "SkipQueue/";
    }
}
