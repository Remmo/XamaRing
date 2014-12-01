using Microsoft.Phone.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(XamaRing.Utility.WinPhone.NumberCaller))]
namespace XamaRing.Utility.WinPhone
{

    public class NumberCaller : DependencyServices.ICallNumber
    {
        public NumberCaller()
        {

        }
        public void CallNumber(string number)
        {
            PhoneCallTask task = new PhoneCallTask();
            task.DisplayName = string.Empty;
            task.PhoneNumber = number;

            task.Show();
        }
    }
}
