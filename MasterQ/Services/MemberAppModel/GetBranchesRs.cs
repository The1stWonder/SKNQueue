using System;
using System.Collections.Generic;
using Xamarin.Forms.Internals;

namespace MasterQ
{
    [Preserve(AllMembers = true)] //alexpook link all
    public class GetBranchesRs
    {
        public HeaderResponse header { get; set; }
        public List<Branch> branches { get; set; }
    }
}
