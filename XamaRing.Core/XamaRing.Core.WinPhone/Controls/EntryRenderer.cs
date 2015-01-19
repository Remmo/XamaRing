using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

using XamaRing.Controls;
using XamaRing.Controls.WinPhone.CustomRenderer;


[assembly: ExportRenderer(typeof(CustomEntry), typeof(LoginEntryRenderer))]
namespace XamaRing.Controls.WinPhone.CustomRenderer
{
    public class LoginEntryRenderer : Xamarin.Forms.Platform.WinPhone.EntryRenderer
    {
      
    }
}