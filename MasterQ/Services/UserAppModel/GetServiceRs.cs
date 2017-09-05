using System;
using System.Collections.Generic;

namespace MasterQ
{
    public class GetServiceRs
    {
		public HeaderResponse header { get; set; }
		public List<Service> services { get; set; }
    }
}
