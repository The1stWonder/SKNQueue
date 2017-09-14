using System;
using System.Collections.Generic;

namespace MasterQ
{
    public class BranchGetServicesRs
	{
		public HeaderResponse header { get; set; }
		public List<Service> services { get; set; }
    }
}
