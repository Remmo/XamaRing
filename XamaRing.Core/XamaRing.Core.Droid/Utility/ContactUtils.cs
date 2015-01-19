using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Contacts;
using System.Threading.Tasks;
using Android.Provider;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(XamaRing.Utility.Droid.ContactAdder))]
namespace XamaRing.Utility.Droid
{
    public class ContactAdder : DS.IAddContact
    {
        AddressBook book;
        public ContactAdder()
        {
            book = new AddressBook(Android.App.Application.Context);
        }


        public void AddContact(string FirstName, string LastName, string MobilePhone)
        {

            Intent intent = new Intent(Intent.ActionInsert);
            intent.SetType(ContactsContract.Contacts.ContentType);
            intent.PutExtra(ContactsContract.Intents.Insert.Name, LastName +" "+ FirstName);
            intent.PutExtra(ContactsContract.Intents.Insert.Phone, MobilePhone);

            // Send with it a unique request code, so when you get called back, you can
            // check to make sure it is from the intent you launched (ideally should be
            // some public static final so receiver can check against it)
            int PICK_CONTACT = 100;
            Forms.Context.StartActivity(intent);
        }

        public void AddContact(string FirstName, string LastName, string MobilePhone, string WorkPhone, string HomePhone, string Fax, string Mail)
        {
            Intent intent = new Intent(Intent.ActionInsert);
            intent.SetType(ContactsContract.Contacts.ContentType);
            intent.PutExtra(ContactsContract.Intents.Insert.Name, LastName + " " + FirstName);

            if(!string.IsNullOrEmpty(MobilePhone))
                intent.PutExtra(ContactsContract.Intents.Insert.Phone, MobilePhone);

             if(!string.IsNullOrEmpty(WorkPhone))
                 intent.PutExtra(ContactsContract.Intents.Insert.SecondaryPhone, WorkPhone);

            if(!string.IsNullOrEmpty(HomePhone))
                intent.PutExtra(ContactsContract.Intents.Insert.TertiaryPhone, HomePhone);

            //if(!string.IsNullOrEmpty(Fax))
            //    intent.PutExtra(ContactsContract.Intents.Insert.Phone, Fax);

            if (!string.IsNullOrEmpty(Mail))
                intent.PutExtra(ContactsContract.Intents.Insert.Email, Mail);

            // Send with it a unique request code, so when you get called back, you can
            // check to make sure it is from the intent you launched (ideally should be
            // some public static final so receiver can check against it)
            int PICK_CONTACT = 100;
            Forms.Context.StartActivity(intent);
        }
    }

   
}