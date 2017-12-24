using System;
using Foundation;
using MasterQ.Helpers;
using MasterQ.iOS;
using UIKit;

[assembly: Xamarin.Forms.Dependency(implementorType: typeof(iOSNotification))]
namespace MasterQ.iOS
{
    public class iOSNotification : IFNotification
    {
        public iOSNotification()
        {
        }

        public void SendNotification(string act, string body)
        {
            UILocalNotification notification = new UILocalNotification();
            NSDate.FromTimeIntervalSinceNow(15);
            notification.AlertTitle = act; // required for Apple Watch notifications
            notification.AlertAction = act;
            notification.AlertBody = body;
            notification.ApplicationIconBadgeNumber = 1;
            notification.SoundName = UILocalNotification.DefaultSoundName;
            UIApplication.SharedApplication.ScheduleLocalNotification(notification);   
        }
    }
}
