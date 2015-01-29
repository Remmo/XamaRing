// HACK: this is to deal with the linker nuking the assembly
using Xamarin.Forms.EIDOS.iOS.Utils;
using XamaRing.Utility.iOS;

namespace ITALFERR.Rubrica.iOS.Bootstrap
{
    public class EIDOSCallBootstrap 
    {
        public EIDOSCallBootstrap() 
        {
            new NumberCaller();
        }
    }
    public class EIDOSMailBootstrap
    {
        public EIDOSMailBootstrap()
        {
            new MailSender();
        }
    }
    public class EIDOSContactBootstrap
    {
        public EIDOSContactBootstrap()
        {
            new ContactAdder();
        }
    }   
}