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
using Android.Net;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(XamaRing.Utility.Droid.NumberCaller))]
namespace XamaRing.Utility.Droid
{
    public class NumberCaller : Java.Lang.Object, DependencyServices.ICallNumber
    {


        public void CallNumber(string number)
        {
            var uri = Android.Net.Uri.Parse (String.Format("tel:{0}",number));            
            var intent = new Intent(Intent.ActionView,uri) ;
            Forms.Context.StartActivity(intent);

        }
    }
}