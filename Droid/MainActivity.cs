﻿using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Support.V7.App;
using Android.Util;
using Android.Widget;
using Android.OS;

namespace MasterQ.Droid
{
    [Activity(Label = "MasterQ", Theme = "@style/MyTheme")]

	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
        public static Notification.Builder builder;
        public static NotificationManager notificationManager;

		protected override void OnCreate(Bundle bundle)
		{
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
