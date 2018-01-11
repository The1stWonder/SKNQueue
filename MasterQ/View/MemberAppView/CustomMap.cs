using System.Collections.Generic;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Maps;

namespace MasterQ
{
    [Preserve(AllMembers = true)] //alexpook link all
    public class CustomMap : Map
    {
        public List<CustomPin> CustomPins { get; set; }
    }
}

