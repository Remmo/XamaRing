using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Xamarin.Forms;

[assembly: ExportRenderer(typeof(XamaRing.Controls.XTimePicker), typeof(XamaRing.Controls.WinPhone.CustomRenderer.XTimePickerRenderer))]
namespace XamaRing.Controls.WinPhone.CustomRenderer
{
    public class XTimePickerRenderer : XamaRing.Controls.XTimePicker
    {
        public XTimePickerRenderer()
        {
           
        }
       
    }
}