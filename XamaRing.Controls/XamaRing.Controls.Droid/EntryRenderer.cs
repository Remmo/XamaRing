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
using Xamarin.Forms.Platform.Android;

using Xamarin.Forms;

using XamaRing.Controls;


[assembly: ExportRenderer(typeof(CustomEntry), typeof(XamaRing.Controls.Droid.CustomRenderer.LoginEntryRenderer))]
namespace XamaRing.Controls.Droid.CustomRenderer
{
    public class LoginEntryRenderer : EntryRenderer
    {
        // Override the OnElementChanged method so we can tweak this renderer post-initial setup
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {   // perform initial setup
                // lets get a reference to the native control
                var nativeEditText = (global::Android.Widget.EditText)Control;
                // do whatever you want to the textField here!
                //nativeEditText.SetHintTextColor(global::Android.Graphics.Color.White);
                //nativeEditText.SetTextColor(global::Android.Graphics.Color.LightGray);
                nativeEditText.SetBackgroundColor(global::Android.Graphics.Color.White);
            }
        }
    }
}