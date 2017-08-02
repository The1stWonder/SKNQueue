using System;
using System.Collections.Generic;

namespace MasterQ
{
    public class GetServicesRs
    {
		public HeaderResponse header { get; set; }
		public List<Service> services { get; set; }
    }
}
