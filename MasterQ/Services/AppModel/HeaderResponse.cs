using System;
using Xamarin.Forms.Internals;

namespace MasterQ
{
    [Preserve(AllMembers = true)] //alexpook link all
    public class HeaderResponse
    {
		public string code { get; set; }
		public bool isSuccess { get; set; }
		public string groups { get; set; }
		public string functions { get; set; }
        public int id { get; set; }
        public string message { get; set; }
    }
}
