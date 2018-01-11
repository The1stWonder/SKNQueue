using System;
using Xamarin.Forms.Internals;

namespace MasterQ
{
    [Preserve(AllMembers = true)] //alexpook link all
    public class EditProfileRq
    {
        public string birthDate { get; set; }
        public string degree { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string job { get; set; }
        public string lastName { get; set; }
        public string memberID { get; set; }
        public string password { get; set; }
        public string tel { get; set; }

    }
}
