using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamaRing.Utility.iOS;


[assembly: Dependency(typeof(NumberCaller))]


namespace XamaRing.Utility.iOS
{
    [Preserve]
    public class NumberCaller : DS.ICallNumber
    {
        public NumberCaller()
        {

        }
        public void CallNumber(string number)
        {
#warning DA TESTARE!!!!
            //Makes a new NSUrl
            using (var callURL = new NSUrl("tel:" + number.Replace(" ","").Trim()))
            {
                if (UIApplication.SharedApplication.CanOpenUrl(callURL))
                {
                    UIApplication.SharedApplication.OpenUrl(callURL);
                }
            }
        }
    }
}
