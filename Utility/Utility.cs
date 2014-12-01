using Acr.XamForms.Mobile.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using XamaRing.DependencyServices;


namespace XamaRing.Utility
{
    public static class CrossTools
    {
        public static void InitializeUtility()
        {
            NetworkSvc = DependencyService.Get<INetworkService>();
            mailSender = DependencyService.Get<IMailSender>();
            addContact = DependencyService.Get<IAddContact>();
            callNumber = DependencyService.Get<ICallNumber>();
        }
        public static INetworkService NetworkSvc;

        private static IMailSender mailSender;
        private static IAddContact addContact;
        private static ICallNumber callNumber;
        public static void SendMail(List<String> recipientsTO, List<String> recipientsCC, String subject, String body)
        {
            mailSender.SendMail(recipientsTO, recipientsCC, subject, body);
        }

        public static void AddContact(String firstName, String lastName, String mobilePhone, String workPhone = "", String homePhone = "", String fax = "", String mail = "")
        {
            addContact.AddContact(firstName, lastName, mobilePhone, workPhone, homePhone, fax, mail);
        }

        public static void CallNumber(String number)
        {
            callNumber.CallNumber(number);
        }

    }
}
