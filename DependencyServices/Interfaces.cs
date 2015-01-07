using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamaRing.DependencyServices.BarCodeScanner;
using XamaRing.DependencyServices.Configs;

namespace XamaRing.DependencyServices
{
    public interface IMailSender
    {
        void SendMail(List<String> recipients, List<String> recipientsCC, String subject, String body);
    }

    public interface IAddContact
    {
        void AddContact(string FirstName, string LastName, string MobilePhone);

        void AddContact(string FirstName, string LastName, string MobilePhone, string WorkPhone, string HomePhone, string Fax, string Mail);
    }

    public interface ICallNumber
    {
        void CallNumber(string number);
    }
    public interface IImageResizer
    {
        byte[] ResizeImage(byte[] imageData, float width, float height);
        byte[] ResizeImage(byte[] imageData, Int32 frazione);
        byte[] ResizeImageFromHeight(byte[] imageData, float height);
        byte[] ResizeImageFromWidth(byte[] imageData, float width);
    }
    public interface IBarCodeScanner
    {
        BarCodeScannerConfiguration Configuration { get; }

        void Read(Action<BarCodeResult> onRead);
        Task<BarCodeResult> ReadAsync();
    }

    public interface IApplyTheme
    {
        void ApplyTheme(StyleConfig config);
    }
}
