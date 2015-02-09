using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;
using XLabs.Platform.Mvvm;
using XLabs.Forms;
using Xamarin.Forms;

namespace Samples.Droid
{
    [Activity(Label = "Samples", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : XFormsApp<XFormsApplicationDroid>
    {
        protected override void OnInit(XFormsApplicationDroid app, bool initServices = true)
        {
            this.AppContext.Start += (o, e) => this.OnStartup();
            this.AppContext.Stop += (o, e) => this.OnClosing();
            this.AppContext.Resume += (o, e) => this.OnResumed();
            this.AppDataDirectory = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;

            base.OnInit(app);
            if (initServices)
            {

            }

            base.OnInit(app);
        }
    }
}

