using Acr.XamForms.BarCodeScanner;
using Acr.XamForms.Mobile.Media;
using Acr.XamForms.Mobile.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamaRing.DS;
using XamaRing.DS.Configs;


namespace XamaRing
{
    public static class CrossTools
    {
      
        public static void InitializeUtility(INetworkService net, IMediaPicker pick)
        {
            MediaSvc = pick;
            NetworkSvc = net;
        }
        public static IMediaPicker MediaSvc;
        public static INetworkService NetworkSvc;
        private static IBarCodeService barcodeScanner;
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

        public static async Task<String> ReadBarcode()
        {
            if (barcodeScanner == null)
            {
                barcodeScanner = DependencyService.Get<IBarCodeService>();
            }
            var p = await barcodeScanner.Read();
            if (p.Success)
            {
                return p.Code;
            }
            else
                return String.Empty;
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
