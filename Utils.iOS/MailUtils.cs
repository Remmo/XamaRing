using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using XamaRing.Utility.iOS;
using MessageUI;
using Foundation;


[assembly: Xamarin.Forms.Dependency(typeof(MailSender))]
namespace XamaRing.Utility.iOS
{
    [Preserve]
    public class MailSender : DS.IMailSender
    {
        MFMailComposeViewController _mailController;
        public MailSender()
        {
        }
     

        public void SendMail(List<String> recipients, List<String> recipientsCC, String subject, String body)
        {
            if (MFMailComposeViewController.CanSendMail)
            {
                if (recipients == null)
                    throw new Exception("inserire almeno un destinatario in TO");
                _mailController = new MFMailComposeViewController();

                _mailController.SetToRecipients(recipients.ToArray());
                if (recipientsCC != null)
                    _mailController.SetCcRecipients(recipientsCC.ToArray());
                _mailController.SetSubject(subject);
                _mailController.SetMessageBody(body, false);
                _mailController.Finished += (object s, MFComposeResultEventArgs args) =>
                {
                    Console.WriteLine(args.Result.ToString());
                    args.Controller.DismissViewController(true, null);
                };
                iOSHelpers.GetTopViewController().PresentViewController(_mailController, true, null);
            }
            else 
                throw new Exception("Questo dispositivo non può inviare e-mail, probabilmente non è stato ancora configurato un account.");
            //
        }
    }
}
