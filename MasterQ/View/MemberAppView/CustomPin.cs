using Xamarin.Forms.Internals;
using Xamarin.Forms.Maps;

namespace MasterQ
{
    [Preserve(AllMembers = true)] //alexpook link all
    public class CustomPin
    {
		public Pin Pin { get; set; }

		public string Id { get; set; }

		public string Url { get; set; }
    }
}

