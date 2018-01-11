using System;
using Xamarin.Forms.Internals;

namespace MasterQ
{
    [Preserve(AllMembers = true)] //alexpook link all
    public class LoginRq
    {
        public string password { get; set; }
        public string username { get; set; }
    }
}
