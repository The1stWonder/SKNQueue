using System;

using MasterQ.Helpers;
using MasterQ.Droid.Resources;
using Android.App;

[assembly: Xamarin.Forms.Dependency(typeof(Noti))]
namespace MasterQ.Droid.Resources
{
    public class Noti : IFNotification
    {
        public Noti()
        {
        }

        public void SendNotification(string act, string body)
        {


            MainActivity.builder.SetContentTitle(act)
                .SetContentText(body)
                .SetSmallIcon(Resource.Drawable.icon);
            Notification notification = MainActivity.builder.Build();

            MainActivity.notificationManager.Notify(1,notification);

        }


    }
}
