﻿using System;
using Xamarin.Forms.Internals;

namespace MasterQ
{
    [Preserve(AllMembers = true)] //alexpook link all
    public class EditProfileRs
    {
        public HeaderResponse header { get; set; }
        public Member member { get; set; }
    }
}
