using System;
using System.Collections.Generic;

namespace MasterQ
{
    public class GetHistoryRs
    {
        public HeaderResponse header { get; set; }
        public List<History> histories { get; set; }
    }
}
