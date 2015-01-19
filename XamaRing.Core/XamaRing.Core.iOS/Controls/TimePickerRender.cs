using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(XamaRing.Controls.XTimePicker), typeof(XamaRing.Controls.iOS.CustomRenderer.XTimePickerRenderer))]
namespace XamaRing.Controls.iOS.CustomRenderer
{
    public class XTimePickerRenderer : XamaRing.Controls.XTimePicker
    {
        public XTimePickerRenderer()
        {

        }

    }
}