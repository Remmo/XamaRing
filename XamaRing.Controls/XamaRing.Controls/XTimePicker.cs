using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamaRing.Controls
{
    public class XTimePicker : TimePicker
    {
        public enTimeFormat TimeFormat { get; set; }
    }
    public enum enTimeFormat
    { 
        H24,
        AP_PM

    }
}
