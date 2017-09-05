using System;
using System.Collections.Generic;

namespace MasterQ
{
    public class GetDistrictsRs
    {
		public HeaderResponse header { get; set; }
        public List<District> districts { get; set; }
    }
}
