using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamaRing.Core.Base;
using XamaRing.DependencyServices.Configs;

namespace Samples
{
    public class App
    {
        public static Page GetMainPage()
        {
            XamaRing.Core.Base.AppBase.Init();
            manageTheme();
            AppBase.AppNavigator = new NavigationPage(new Samples.Views.MainView());
            return AppBase.AppNavigator;
        }
        private static void manageTheme()
        {
            StyleConfig cfg = new StyleConfig();
            if (Device.OS == TargetPlatform.WinPhone)
            {
                cfg.BgColor = Color.White;
                cfg.WPPhoneChromeColor = Color.FromHex("#2faeb5");
                cfg.WPPhoneForegroundColor = Color.White;
                cfg.EntryBackgroundColor = Color.Silver;
                cfg.WPLightTheme = true;
                //cfg.AccentColor = Color.FromHex("#dd3f18");
            }
            else if (Device.OS == TargetPlatform.Android)
            {
                cfg.BgColor = Color.White;
            }
            AppBase.SetCrossStyle(cfg);
        }
    }
}
