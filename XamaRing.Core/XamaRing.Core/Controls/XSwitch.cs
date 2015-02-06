using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamaRing.Controls
{

    public class XSwitch : Xamarin.Forms.Switch
    {
        public static readonly BindableProperty OnTextProperty =
        BindableProperty.Create<XSwitch, String>(
            p => p.OnText, "ON");

        public String OnText
        {
            get { return (String)GetValue(OnTextProperty); }
            set { SetValue(OnTextProperty, value); }
        }


        public static readonly BindableProperty OffTextProperty =
       BindableProperty.Create<XSwitch, String>(
           p => p.OffText, "OFF");

        public String OffText
        {
            get { return (String)GetValue(OffTextProperty); }
            set { SetValue(OffTextProperty, value); }
        }
       

       

    }
}
