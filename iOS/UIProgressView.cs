using System;
using System.Threading;
using System.Timers;
using Foundation;
using UIKit;

namespace MasterQ
{
    public partial class UIProgressView : UIViewController
    {
        public UIProgressView() : base("UIProgressView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            Timer = NSTimer.CreateRepeatingScheduledTimer(TimeSpan.FromSeconds(15.0), delegate
            {
                DismissViewController(true, null);
            });

            UIView.Animate(8, () => {
                progressView.SetProgress(1.0f, true);
            });
        }
    }
}

