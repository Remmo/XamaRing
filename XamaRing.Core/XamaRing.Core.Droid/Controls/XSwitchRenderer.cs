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
using Android.Content.Res;
using Xamarin.Forms;
using XamaRing.Controls.Droid.CustomRenderer;
using XamaRing.Controls;
using Android.Graphics.Drawables;


[assembly: ExportRenderer(typeof(XSwitch), typeof(XSwitchRenderer))]
namespace XamaRing.Controls.Droid.CustomRenderer
{

    public class XSwitchRenderer : SwitchRenderer
    {
        // Override the OnElementChanged method so we can tweak this renderer post-initial setup
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Switch> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                XSwitch el = (XSwitch)this.Element;
                // do whatever you want to the textField here!
                Control.TextOn = el.OnText;//= (global::Android.Graphics.Color.DarkGray);
                Control.TextOff = el.OffText; ;//= (global::Android.Graphics.Color.DarkGray);
                Control.SetTextColor(Android.Graphics.Color.White);




            }
        }
    }
}