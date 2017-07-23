using System;
using System.Collections.Generic;

namespace MasterQ
{
    public class GetBranchesRs
    {
        public HeaderResponse header { get; set; }
        public List<Branch> branches { get; set; }
    }
}
