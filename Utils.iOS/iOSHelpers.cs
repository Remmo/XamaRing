using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamaRing.Utility.iOS;
using UIKit;

namespace XamaRing.Utility.iOS
{
    public static class iOSHelpers
    {
        public static UIViewController GetTopViewController()
        {
            var root = GetTopWindow().RootViewController;
            var tabs = root as UITabBarController;
            if (tabs != null) 
                return tabs.SelectedViewController;

            var nav = root as UINavigationController;
            if (nav != null)
                return nav.VisibleViewController;

            if (root.PresentedViewController != null)
                return root.PresentedViewController;

            return root;
        }

        public static UIWindow GetTopWindow()
        {
            return UIApplication
                .SharedApplication
                .Windows
                .Reverse()
                .FirstOrDefault(x =>
                    x.WindowLevel == UIWindowLevel.Normal &&
                    !x.Hidden
                );

            //return 
            //    UIApplication.SharedApplication.KeyWindow
            //    ?? UIApplication.SharedApplication.Windows.Last()
            //    ?? UIApplication.SharedApplication.Delegate.Window;
        }
    }
}
