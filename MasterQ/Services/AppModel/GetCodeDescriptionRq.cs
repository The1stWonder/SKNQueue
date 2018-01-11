using System;
using Xamarin.Forms.Internals;

namespace MasterQ
{
    [Preserve(AllMembers = true)] //alexpook link all
    public class GetCodeDescriptionRq
    {
		public string groups { get; set; }
        public string functions { get; set; }
        public string code { get; set; }
    }
}
