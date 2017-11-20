using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace MasterQ.Droid
{
	[Activity(Label = "MasterQ.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, 
              ScreenOrientation = ScreenOrientation.Portrait)]
              //ScreenOrientation = ScreenOrientation.Landscape)]

	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
        public static Notification.Builder builder;
        public static NotificationManager notificationManager;

		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

            notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;

            builder = new Notification.Builder(this)
                                 .SetContentTitle("")
                                 .SetContentText("")
                                 .SetSmallIcon(Resource.Drawable.icon);


			global::Xamarin.Forms.Forms.Init(this, bundle);
			global::ZXing.Net.Mobile.Forms.Android.Platform.Init();
            Xamarin.FormsMaps.Init(this, bundle);

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
