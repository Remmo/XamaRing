using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
