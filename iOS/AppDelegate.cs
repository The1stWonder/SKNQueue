using System;
using System.Collections.Generic;
using System.Linq;
using Google.Maps;

using Foundation;
using UIKit;

namespace MasterQ.iOS
{
	[Register("AppDelegate")]

	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
        const string MapsApiKey = "AIzaSyCi_Xhq9rN_rizxpUG9V029-6r1ENP3dkY";

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();
            Xamarin.FormsMaps.Init();

			LoadApplication(new App());
            MapServices.ProvideAPIKey(MapsApiKey);

			return base.FinishedLaunching(app, options);
		}
	}
}
