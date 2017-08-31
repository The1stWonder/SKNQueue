using System;
using System.Collections.Generic;

namespace MasterQ
{
    public class GetCodeDescriptionRs
    {
		public HeaderResponse header { get; set; }
        public CodeDescription codeDescription { get; set; }
        public List<CodeDescription> codeDescriptions { get; set; }
    }
}
