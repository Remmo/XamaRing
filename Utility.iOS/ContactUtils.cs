
using MonoTouch.AddressBook;
using MonoTouch.AddressBookUI;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Xamarin.Forms;
using XamaRing.Utility.iOS;


[assembly: Dependency(typeof(ContactAdder))]


namespace XamaRing.Utility.iOS
{
    [Preserve]
    public  class ContactAdder : DependencyServices.IAddContact
    {
        ABNewPersonViewController _newPersonController;
        public ContactAdder()
        {
            _newPersonController = new ABNewPersonViewController();
        }

        //Codice trovato su http://developer.xamarin.com/recipes/ios/shared_resources/contacts/create_a_new_contact/
        public void AddContact(string FirstName, string LastName, string MobilePhone)
        {

            var contact = new ABPerson();
            contact.FirstName = FirstName;
            contact.LastName = LastName;
            ABMutableMultiValue<string> cel = new ABMutableStringMultiValue();
            cel.Add(new NSString(MobilePhone), new NSString("Work"));
            contact.SetPhones(cel);
            _newPersonController.DisplayedPerson = contact;

            AppDelegateBaseIOS.FindNavigationController().PushViewController(_newPersonController, true);
             
       //    _newPersonController.NewPersonComplete += (object sender,
       //       ABNewPersonCompleteEventArgs e) => {

       //       if (e.Completed) {
       //             
       //       }  else {
       //               
       //       }       
       //} ;
        }

        public void AddContact(string FirstName, string LastName, string MobilePhone, string WorkPhone, string HomePhone, string Fax, string Mail)
        {
            var contact = new ABPerson();
            contact.FirstName = FirstName;
            contact.LastName = LastName;

            if (!string.IsNullOrEmpty(Mail))
            {
                ABMutableMultiValue<string> mail = new ABMutableStringMultiValue();
                mail.Add(Mail, new NSString("WorkEMail"));
                contact.SetEmails(mail);
            }

            ABMutableMultiValue<string> cel = new ABMutableStringMultiValue();

            if (!string.IsNullOrEmpty(MobilePhone))
                cel.Add(new NSString(MobilePhone), new NSString("Mobile"));

            if (!string.IsNullOrEmpty(WorkPhone))
            cel.Add(new NSString(WorkPhone), new NSString("Work"));

            if (!string.IsNullOrEmpty(HomePhone))
            cel.Add(new NSString(HomePhone), new NSString("Home"));

            if (!string.IsNullOrEmpty(Fax))
            cel.Add(new NSString(Fax), new NSString("Fax"));

            if(cel.Count>0)
                contact.SetPhones(cel);


            _newPersonController.DisplayedPerson = contact;

            AppDelegateBaseIOS.FindNavigationController().PushViewController(_newPersonController, true);
        }
    }
}
