using System;
namespace MasterQ
{
	public class Login
	{
		public String username { get; set; }
		public String password { get; set; }
		public Boolean isLogin { get; set; }

		public Login()
		{
			this.username = String.Empty;
			this.password = String.Empty;
			this.isLogin = false;
		}
		public Login(String username, String password)
		{
			this.username = username;
			this.password = password;
			this.isLogin = false;
		}

	}
}
