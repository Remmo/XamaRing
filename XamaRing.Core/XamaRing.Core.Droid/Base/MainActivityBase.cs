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
using XLabs.Ioc;
using XLabs.Platform.Device;

namespace XamaRing.Core.Droid.Base
{
    public class MainActivityBase : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        public void SetIoc()
        {
            if (!Resolver.IsSet)
            {
                var resolverContainer = new SimpleContainer();
                resolverContainer.Register<IDevice>(t => AndroidDevice.CurrentDevice);
                Acr.UserDialogs.UserDialogs.Init(() => { return this; });
                Resolver.SetResolver(resolverContainer.GetResolver());
            }
        }
    }
}