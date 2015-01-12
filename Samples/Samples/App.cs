using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamaRing.Core.Base;

namespace Samples
{
    public class App
    {
        public static Page GetMainPage()
        {
            Init();
            AppBase.AppNavigator = new NavigationPage(new Samples.Views.MainView());
            return AppBase.AppNavigator;
        }
        public static void Init()
        {
            XamaRing.Core.Base.AppBase.Init();
        }
    }
}
