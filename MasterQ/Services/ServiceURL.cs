using System;
namespace MasterQ
{
    public class ServiceURL
    {
        public static String ipDev = "http://192.1.1.206";
        public static String ipPro = "http://202.129.59.21";
        public static String ipServer = ipPro;
        public static String serviceName = "/QueueService.svc/";
        public static String sampleUrlGet = serviceName+"Member/";
        public static String sampleUrlPost = serviceName + "Login/";
		public static String loginUrl = serviceName + "Login/";
        public static String registerUrl = serviceName + "Register/";
		public static String editProfileUrl = serviceName + "EditProfile/";
		public static String forgetPasswordUrl = serviceName + "ForgetPassword/";
        public static String getProvicesUrl = serviceName + "GetProvinces/";
        public static String getDistrictsUrl = serviceName + "GetDistricts/";
        public static String getBranchesUrl = serviceName + "GetBranches/";
        public static String getBranchServicesUrl = serviceName + "GetBranchServices/";
        public static String reserveQueueUrl = serviceName + "ReserveQueue/";
        public static String getCodeDescriptionUrl = serviceName + "GetCodeDescription/";
    }
}
