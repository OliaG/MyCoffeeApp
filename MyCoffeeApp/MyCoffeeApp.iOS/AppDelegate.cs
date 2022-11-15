using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Hosting;
using MyCoffeeApp.Helpers;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using Platform = Microsoft.Maui.ApplicationModel.Platform;

// [assembly:Dependency(typeof(MyCoffeeApp.iOS.Environment))]

namespace MyCoffeeApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : MauiUIApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        // public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        // {
        //     global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
        //     global::Xamarin.Forms.Forms.Init();
        //     LoadApplication(new App());

        //     return base.FinishedLaunching(app, options);
        // }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }

    public class Environment : IEnvironment
    {
        public void SetStatusBarColor(Color color, bool darkStatusBarTint)
        {
            if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
            {
                var statusBar = new UIView(UIApplication.SharedApplication.KeyWindow.WindowScene.StatusBarManager.StatusBarFrame);
                statusBar.BackgroundColor = color.ToUIColor();
                UIApplication.SharedApplication.KeyWindow.AddSubview(statusBar);
            }
            else
            {
                var statusBar = UIApplication.SharedApplication.ValueForKey(new NSString("statusBar")) as UIView;
                if (statusBar.RespondsToSelector(new ObjCRuntime.Selector("setBackgroundColor:")))
                {
                    statusBar.BackgroundColor = color.ToUIColor();
                }
            }
            var style = darkStatusBarTint ? UIStatusBarStyle.DarkContent : UIStatusBarStyle.LightContent;
            UIApplication.SharedApplication.SetStatusBarStyle(style, false);

            // Xamarin.Essentials.Platform.GetCurrentUIViewController()?.SetNeedsStatusBarAppearanceUpdate();
        }
    }
}
