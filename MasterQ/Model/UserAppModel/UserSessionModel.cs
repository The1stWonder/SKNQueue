﻿using System;
using System.Collections.Generic;

namespace MasterQ
{
    public class UserSessionModel
	{
        public static Member loginMember=new Member();
        public static Branch choosedBranch=new Branch();
        public static Service choosedService=new Service();
        public static Queue choosedQueue = new Queue();
        public static GroupService choosedGroup = new GroupService();
		public static List<GroupService> groupServices = new List<GroupService>();
    }
}

