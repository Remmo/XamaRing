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


using System.Net;
using Xamarin.Forms.Platform.Android;

namespace XamaRing.Utility.Droid
{
    public class MainBaseDroid : AndroidActivity
    {
        private static bool _initialized;
        public MainBaseDroid()
        {
        }
        public void SetIoc()
        {
            //ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, ssl) => true;

            //var resolverContainer = new SimpleContainer();

            ////var app = new XFormsAppDroid();

            ////app.Init(this);

            ////var documents = app.AppDataDirectory;
            ////var pathToDatabase = Path.Combine(documents, "xforms.db");

            //resolverContainer.Register<IDevice>(t => AndroidDevice.CurrentDevice)
            //    .Register<IDisplay>(t => t.Resolve<IDevice>().Display)
            //    .Register<IDependencyContainer>(resolverContainer);



            //Resolver.SetResolver(resolverContainer.GetResolver());

            _initialized = true;
        }
    }
   

}