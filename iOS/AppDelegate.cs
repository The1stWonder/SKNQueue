using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace MasterQ.iOS
{
	[Register("AppDelegate")]

	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
        
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();
            global::ZXing.Net.Mobile.Forms.iOS.Platform.Init();

            Xamarin.FormsMaps.Init();

            //var settings = UIUserNotificationSettings.GetSettingsForTypes(
            //UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound
            //, null);
            //UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);

            var thai = new System.Globalization.ThaiBuddhistCalendar();

            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                var notificationSettings = UIUserNotificationSettings.GetSettingsForTypes(
                    UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null
                );

                UIApplication.SharedApplication.RegisterUserNotificationSettings(notificationSettings);
            }

			LoadApplication(new App());


			return base.FinishedLaunching(app, options);
		}

        public override void ReceivedLocalNotification(UIApplication application, UILocalNotification notification)
        {
            // show an alert
            UIAlertController okayAlertController = UIAlertController.Create(notification.AlertAction, notification.AlertBody, UIAlertControllerStyle.Alert);
            okayAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

            //Window.RootViewController.PresentViewController(okayAlertController, true, null);

            // reset our badge
            UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
        }

	}
}
