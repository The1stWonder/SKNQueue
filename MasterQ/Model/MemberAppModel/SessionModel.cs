using System;
using System.Collections.Generic;

namespace MasterQ
{
    public class SessionModel
    {
        public static List<Service> services = new List<Service>();
        public static Member loginMember = new Member();
        public static Queue bookingQ = new Queue();

        public static Service getServiceFromBookingQ()
        {
            return TempDB.services.Find(s => s.serviceID.Equals(bookingQ.serviceID) && s.branchID.Equals(bookingQ.branchID));
        }
        public static void clearQueue()
        {
            SessionModel.bookingQ = null;
        }
    }
}
