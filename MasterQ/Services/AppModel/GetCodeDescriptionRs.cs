using System;
using System.Collections.Generic;
using Xamarin.Forms.Internals;

namespace MasterQ
{
    [Preserve(AllMembers = true)] //alexpook link all
    public class GetCodeDescriptionRs
    {
		public HeaderResponse header { get; set; }
        public CodeDescription codeDescription { get; set; }
        public List<CodeDescription> codeDescriptions { get; set; }
    }
}
