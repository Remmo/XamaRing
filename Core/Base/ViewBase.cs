using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarRing.Base
{
    public class ViewLogin : View
    {
        
        public delegate void LoginFailedEventHandler(String message, EventArgs e);
        public event LoginFailedEventHandler OnLoginFailed;

        public delegate void LoginOKEventHandler(Object sender, EventArgs e);
        public event LoginOKEventHandler OnLoginOK;
        public void LoginOK(Object argument = null)
        {
            if (this.OnLoginOK != null)
                this.OnLoginOK(argument == null ? this : argument, EventArgs.Empty);
        }
        public void LoginFailed(String message = null)
        {
            if (this.OnLoginFailed != null)
                this.OnLoginFailed(String.IsNullOrWhiteSpace(message) ? "Errore durante l'autenticazione, si prega di riprovare" : message, EventArgs.Empty);
        }
    }
}
