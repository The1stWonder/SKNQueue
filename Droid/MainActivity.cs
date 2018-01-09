using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Support.V7.App;
using Android.Util;
using Android.Widget;
using Android.OS;
using Android.Views;

namespace MasterQ.Droid
{
    [Activity(Label = "MasterQ", Theme = "@style/MyTheme", 
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
              ScreenOrientation = ScreenOrientation.Portrait)]
            //ScreenOrientation = ScreenOrientation.Landscape)])]

	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
        public static Notification.Builder builder;
        public static NotificationManager notificationManager;

		protected override void OnCreate(Bundle bundle)
		{
        			base.OnCreate(bundle);

            var thai = new System.Globalization.ThaiBuddhistCalendar();

            var en = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentCulture = en;

            notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;

            this.Window.SetFlags(WindowManagerFlags.KeepScreenOn, WindowManagerFlags.KeepScreenOn);

            builder = new Notification.Builder(this)
                                 .SetContentTitle("")
                                 .SetContentText("")
                                 .SetSmallIcon(Resource.Drawable.icon);


			global::Xamarin.Forms.Forms.Init(this, bundle);
			global::ZXing.Net.Mobile.Forms.Android.Platform.Init();
            Xamarin.FormsMaps.Init(this, bundle);

            //PowerManager pm = (PowerManager)GetSystemService(Context.PowerService);
            //PowerManager.WakeLock wl = pm.NewWakeLock(WakeLockFlags.ScreenDim, "My Tag");
            //wl.Acquire();

			LoadApplication(new App());
		}

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
		{
			global::ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}

        public override void OnBackPressed()
        {
            
        }
	}
}
