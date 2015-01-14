using Microsoft.Phone.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


[assembly:  Xamarin.Forms.Dependency(typeof(XamaRing.Utility.WinPhone.MailSender))]
namespace XamaRing.Utility.WinPhone
{
    public class MailSender : DS.IMailSender
    {
        public MailSender() { }


        public void SendMail(List<string> to, List<string> cc, string subject, string body)
        {
            if (to == null)
                throw new Exception("inserire almeno un destinatario in TO");
            EmailComposeTask emailComposeTask = new EmailComposeTask();
            foreach (var tos in to)
            {
                emailComposeTask.To += (tos + ";");
            }
            if (cc != null)
            {
                foreach (var ccs in cc)
                {
                    emailComposeTask.Cc += (ccs + ";");
                }
            }
            emailComposeTask.Subject = subject;
            emailComposeTask.Body = body;
            emailComposeTask.Show();
        }
    }
}