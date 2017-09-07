using System;

using Xamarin.Forms;

namespace MasterQ
{
    public class UserSessionModel : ContentPage
	{
        public static Member loginMember=new Member();
        public static Branch choosedBranch=new Branch();
        public static Service choosedService=new Service();
        public static Queue choosedQueue = new Queue();
    }
}

