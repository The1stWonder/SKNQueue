﻿using System;
using System.Collections.Generic;
using System.Linq;

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

            //var settings = UIUserNotificationSettings.GetSettingsForTypes(
            //UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound
            //, null);
            //UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);

            var thai = new System.Globalization.ThaiBuddhistCalendar();

            //if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            //{
            //    var notificationSettings = UIUserNotificationSettings.GetSettingsForTypes(
            //        UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null
            //    );

            //    UIApplication.SharedApplication.RegisterUserNotificationSettings(notificationSettings);
            //}

            //UIApplication.SharedApplication.ApplicationIconBadgeNumber = -1;

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

			LoadApplication(new App());

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

	}
}
