// HACK: this is to deal with the linker nuking the assembly


namespace XamaRing.Utility.iOS.Bootstrap
{
    public class XamaRingCallBootstrap 
    {
        public XamaRingCallBootstrap() 
        {
            new NumberCaller();
        }
    }
    public class XamaRingMailBootstrap
    {
        public XamaRingMailBootstrap()
        {
            new MailSender();
        }
    }
    public class XamaRingContactBootstrap
    {
        public XamaRingContactBootstrap()
        {
            new ContactAdder();
        }
    }   
}