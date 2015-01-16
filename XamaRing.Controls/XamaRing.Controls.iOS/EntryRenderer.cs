using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using XamaRing.Controls;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(XamaRing.Controls.iOS.CustomRenderer.LoginEntryRenderer))]
namespace XamaRing.Controls.iOS.CustomRenderer
{
    public class LoginEntryRenderer : Xamarin.Forms.Platform.iOS.EntryRenderer
    {

    }
}