using System;
using Xamarin.Forms.Internals;

namespace MasterQ
{
    [Preserve(AllMembers = true)] //alexpook link all
    public class GetAppVersionRs
    {
        public HeaderResponse header { get; set; }
        public AppVersion appVersion { get; set; }
    }
}
