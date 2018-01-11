using System;
using Xamarin.Forms.Internals;

namespace MasterQ
{
    [Preserve(AllMembers = true)] //alexpook link all
    public class AppVersion
    {
        public string dbVersion { get; set; }
        public string appVersion { get; set; }
    }
}
