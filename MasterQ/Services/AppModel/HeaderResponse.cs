using System;
namespace MasterQ
{
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
