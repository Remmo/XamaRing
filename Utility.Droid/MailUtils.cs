
using Android.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;




[assembly: Xamarin.Forms.Dependency(typeof(XamaRing.Utility.Droid.MailSender))]
namespace XamaRing.Utility.Droid
{
    public class MailSender : Java.Lang.Object, XamaRing.DS.IMailSender
    {
        public MailSender() { }
        public void SendMail(List<string> to, List<string> cc, string subject, string body)
        {
            if (to == null)
                throw new Exception("inserire almeno un destinatario in TO");
            var email = new Intent(Intent.ActionSend);
            email.PutExtra(Intent.ExtraEmail, to.ToArray());
            if (cc != null)
                email.PutExtra(Intent.ExtraCc, cc.ToArray());
            email.PutExtra(Intent.ExtraSubject, subject);
            email.PutExtra(Intent.ExtraText, body);
            email.PutExtra(Intent.ExtraHtmlText, true);
            email.SetType("message/rfc822");
            Forms.Context.StartActivity(email);
        }
    }  
}



//ActivationContext.ContextForm
//       var activity2 = new Intent (this, typeof(controlToPresent));
//      Context.UiModeService. (controlToPresent as AndroidActivity).StartActivity(email);