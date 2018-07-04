using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Push;
using Foundation;
using UIKit;
using UserNotifications;

namespace MasterQ.iOS
{
	[Register("AppDelegate")]

	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
        
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
            UNUserNotificationCenter.Current.Delegate = new MyNotificationDelegate();
			global::Xamarin.Forms.Forms.Init();
            global::ZXing.Net.Mobile.Forms.iOS.Platform.Init();

            Xamarin.FormsMaps.Init();

            var thai = new System.Globalization.ThaiBuddhistCalendar();

            var en = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentCulture = en;

            //if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            //{
            //    var notificationSettings = UIUserNotificationSettings.GetSettingsForTypes(
            //        UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null
            //    );

            //    UIApplication.SharedApplication.RegisterUserNotificationSettings(notificationSettings);
            //}

            //UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;

            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                UIUserNotificationType userNotificationTypes = UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound;
                UIUserNotificationSettings notificationSettings = UIUserNotificationSettings.GetSettingsForTypes(userNotificationTypes, null);
                UIApplication.SharedApplication.RegisterUserNotificationSettings(notificationSettings);
                UIApplication.SharedApplication.RegisterForRemoteNotifications();
            }
            else
            {
                UIRemoteNotificationType notificationTypes = UIRemoteNotificationType.Alert | UIRemoteNotificationType.Badge | UIRemoteNotificationType.Sound;
                UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(notificationTypes);
            }

            AppCenter.Start("a828ac3f-e02b-43b0-994e-2c8a1578659a", typeof(Analytics), typeof(Crashes));
            AppCenter.Start("a828ac3f-e02b-43b0-994e-2c8a1578659a", typeof(Push));

			LoadApplication(new App());

            UIApplication.SharedApplication.BeginBackgroundTask(() => {});

            UIApplication.SharedApplication.IdleTimerDisabled = true;

			return base.FinishedLaunching(app, options);
		}

        public class MyNotificationDelegate : UNUserNotificationCenterDelegate
        {
            public override void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)
            {
                completionHandler(UNNotificationPresentationOptions.Alert | UNNotificationPresentationOptions.Sound);
                Console.WriteLine(notification);
            }
        }

        public override void OnActivated(UIApplication uiApplication) 
        { 
            UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0; 
            base.OnActivated(uiApplication);

            UIApplication.Notifications.ObserveBackgroundRefreshStatusDidChange((sender, args) => {
                Console.WriteLine("Background refresh status changed");
            });
        }
	}
}
