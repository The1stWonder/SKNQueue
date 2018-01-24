using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;

namespace MasterQ.Droid
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true, 
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
              ScreenOrientation = ScreenOrientation.Portrait)]
              //ScreenOrientation = ScreenOrientation.Landscape)]

    public class SplashActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        //public static Notification.Builder builder;
        //public static NotificationManager notificationManager;

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
            //Log.Debug(TAG, "SplashActivity.OnCreate");
        }

        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }

        // Prevent the back button from canceling the startup process
        public override void OnBackPressed() { }

        // Simulates background work that happens behind the splash screen
        public void SimulateStartup ()
        {
            //Log.Debug(TAG, "Performing some startup work that takes a bit of time.");
            //await Task.Delay(5000); // Simulate a bit of startup work.
            //Log.Debug(TAG, "Startup work is finished - starting MainActivity.");
            StartActivity(new Intent(Application.Context, typeof (MainActivity)));
        }

        //protected override void OnCreate(Bundle bundle)
        //{
        //    //TabLayoutResource = Resource.Layout.Tabbar;
        //    //ToolbarResource = Resource.Layout.Toolbar;

        //    base.OnCreate(bundle);

        //    notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;

        //    builder = new Notification.Builder(this)
        //                         .SetContentTitle("")
        //                         .SetContentText("")
        //                         .SetSmallIcon(Resource.Drawable.icon);


        //    global::Xamarin.Forms.Forms.Init(this, bundle);
        //    global::ZXing.Net.Mobile.Forms.Android.Platform.Init();
        //    Xamarin.FormsMaps.Init(this, bundle);

        //    LoadApplication(new App());
        //}

        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        //{
        //    global::ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}
    }
}