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
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(XamaRing.Controls.XTimePicker), typeof(XamaRing.Controls.Droid.CustomRenderer.XTimePickerRenderer))]
namespace XamaRing.Controls.Droid.CustomRenderer
{
    public class XTimePickerRenderer : XamaRing.Controls.XTimePicker
    {
        public XTimePickerRenderer()
        {
          

        }
       
    }
}