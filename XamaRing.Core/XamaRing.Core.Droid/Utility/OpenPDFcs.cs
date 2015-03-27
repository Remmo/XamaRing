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

[assembly: Xamarin.Forms.Dependency(typeof(XamaRing.Utility.Droid.OpenPDF))]
namespace XamaRing.Utility.Droid
{
    public class OpenPDF: Java.Lang.Object, DS.IOpenPdf
    {
        public void OpenPdf(string filePath)
        {
            Android.Net.Uri uri = Android.Net.Uri.Parse("file:///" + filePath);
            Intent intent = new Intent(Intent.ActionView);
            intent.SetDataAndType(uri, "application/pdf");
            intent.SetFlags(ActivityFlags.ClearWhenTaskReset | ActivityFlags.NewTask);
            try
            {
                Xamarin.Forms.Forms.Context.StartActivity(intent);
            }
            catch (Exception)
            {
                Toast.MakeText(Xamarin.Forms.Forms.Context, "No Application Available to View PDF", ToastLength.Short).Show();
            }
        }
    }
}