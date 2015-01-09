using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using XamaRing.DependencyServices;
using XamaRing.Utility.Droid;
using XamaRing.DependencyServices.Configs;


[assembly: Xamarin.Forms.Dependency(typeof(ThemeUtils))]
namespace XamaRing.Utility.Droid
{
    public class ThemeUtils : IApplyTheme
    {
        public void ApplyTheme(StyleConfig config)
        {

        }
    }
}