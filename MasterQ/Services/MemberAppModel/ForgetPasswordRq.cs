﻿using System;
using Xamarin.Forms.Internals;

namespace MasterQ
{
    [Preserve(AllMembers = true)] //alexpook link all
    public class ForgetPasswordRq
    {
        public string email { get; set; }
    }
}
