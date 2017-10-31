using System;
using System.Collections.Generic;

namespace MasterQ
{
    public class SessionModel
    {
        public static List<Service> services = new List<Service>();
        public static Member loginMember = new Member();
        public static Queue bookingQ = new Queue();

        public static Service getService(String serviceID)
        {
            return TempDB.services.Find(i => i.serviceID.Equals(serviceID));
        }
    }
}
