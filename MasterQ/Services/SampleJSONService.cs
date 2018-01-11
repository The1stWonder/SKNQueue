using System;
using Xamarin.Forms.Internals;

namespace MasterQ
{
    [Preserve(AllMembers = true)] //alexpook link all
    public class SampleJSONService
    {
		public string MemberEmail { get; set; }
		public string MemberID { get; set; }
		public string MemberName { get; set; }
		public string MemberSurName { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
		public string Password { get; set; }
		public string UserName { get; set; }
    }
}

