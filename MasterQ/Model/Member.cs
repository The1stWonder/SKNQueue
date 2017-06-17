using System;
using System.Collections.Generic;

namespace MasterQ
{
	public class Member
	{
        public String email { get; set; }
		public String password { get; set; }
        public String confirmPassword { get; set; }
		public String memberName { get; set; }
		public Return callBack = new Return(); 

		public Member()
        {
		}
	}
}
