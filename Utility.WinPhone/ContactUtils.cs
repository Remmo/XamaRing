using Microsoft.Phone.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;


[assembly:  Xamarin.Forms.Dependency(typeof(XamaRing.Utility.WinPhone.ContactAdder))]
namespace XamaRing.Utility.WinPhone
{
    
    public class ContactAdder : DependencyServices.IAddContact
    {
        SaveContactTask saveContactTask;
        public ContactAdder()
        {
            saveContactTask = new SaveContactTask();
            saveContactTask.Completed += new EventHandler<SaveContactResult>(saveContactTask_Completed);
        }


        public void AddContact(string FirstName, string LastName, string MobilePhone)
        {
            saveContactTask.FirstName = FirstName;
            saveContactTask.LastName = LastName;
            saveContactTask.MobilePhone = MobilePhone;            
            saveContactTask.Show();
        }

        public void AddContact(string FirstName, string LastName, string MobilePhone, string WorkPhone, string HomePhone, string Fax, string Mail)
        {
            saveContactTask.FirstName = FirstName;
            saveContactTask.LastName = LastName;

            if(!string.IsNullOrEmpty(MobilePhone))
                saveContactTask.MobilePhone = MobilePhone;

            if (!string.IsNullOrEmpty(WorkPhone))
                saveContactTask.WorkPhone = WorkPhone;

            if (!string.IsNullOrEmpty(HomePhone))
                saveContactTask.HomePhone = HomePhone;

            if (!string.IsNullOrEmpty(Mail))
                saveContactTask.WorkEmail = Mail;

            saveContactTask.Show();
        }

        void saveContactTask_Completed(object sender, SaveContactResult e)
        {
            switch (e.TaskResult)
            {
                //Logic for when the contact was saved successfully
                case TaskResult.OK:
                    MessageBox.Show("Contatto sincronizzato.");
                    break;

                //Logic for when the task was cancelled by the user
                case TaskResult.Cancel:
                    MessageBox.Show("Sincronizzazione annullata.");
                    break;

                //Logic for when the contact could not be saved
                case TaskResult.None:
                    MessageBox.Show("Non è stato possibile sincronizzare il contatto.");
                    break;
            }
        }
    }
}
