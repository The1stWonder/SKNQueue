using System;
using System.Collections.Generic;

namespace MasterQ
{
    public class GetBranchServicesRs
    {
		public HeaderResponse header { get; set; }
		public List<Service> services { get; set; }
    }
}
