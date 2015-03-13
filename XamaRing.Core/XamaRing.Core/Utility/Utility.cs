
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamaRing.DS;
using XamaRing.DS.Configs;
using XLabs.Platform.Device;


namespace XamaRing
{
    public static class CrossTools
    {

        public static void InitializeUtility(IDevice net)
        {
            NetworkSvc = net;
        }

        public static IDevice NetworkSvc;

        //private static IBarCodeScanner barcodeScanner;
        private static IMailSender mailSender;
        private static IAddContact addContact;
        private static ICallNumber callNumber;
        private static IImageResizer imageResizer;
        private static IApplyTheme applyTheme;
        public static void SendMail(List<String> recipientsTO, List<String> recipientsCC, String subject, String body)
        {
            if (mailSender == null)
            {
                mailSender = DependencyService.Get<IMailSender>();
            }
            mailSender.SendMail(recipientsTO, recipientsCC, subject, body);
        }

        public static void AddContact(String firstName, String lastName, String mobilePhone, String workPhone = "", String homePhone = "", String fax = "", String mail = "")
        {
            if (addContact == null)
            {
                addContact = DependencyService.Get<IAddContact>();
            }
            addContact.AddContact(firstName, lastName, mobilePhone, workPhone, homePhone, fax, mail);
        }

        public static void CallNumber(String number)
        {
            if (callNumber == null)
            {
                callNumber = DependencyService.Get<ICallNumber>();

            }
            callNumber.CallNumber(number);
        }





        public static byte[] ResizeImageFromWidth(byte[] imageData, float width)
        {
            if (imageResizer == null)
            {
                imageResizer = DependencyService.Get<IImageResizer>();
            }
            return imageResizer.ResizeImageFromWidth(imageData, width);
        }

        public static byte[] ResizeImageFromHeight(byte[] imageData, float height)
        {
            if (imageResizer == null)
            {
                imageResizer = DependencyService.Get<IImageResizer>();
            }
            return imageResizer.ResizeImageFromHeight(imageData, height);
        }

        public static byte[] ResizeImage(byte[] imageData, Int32 frazione)
        {
            if (imageResizer == null)
            {
                imageResizer = DependencyService.Get<IImageResizer>();
            }
            return imageResizer.ResizeImage(imageData, frazione);
        }





        #region Themes
        public static void ApplyCrossTheme(StyleConfig config)
        {

            if (applyTheme == null)
            {
                applyTheme = DependencyService.Get<IApplyTheme>();
            }
            applyTheme.ApplyTheme(config);

        }
        #endregion


    }
}
