// HACK: this is to deal with the linker nuking the assembly
using Acr.XamForms.Mobile.iOS;

namespace XamaRing.Core.iOS.Bootstrap
{
    public class MediaBootstrap 
    {
        public MediaBootstrap() 
        {
            new Acr.XamForms.Mobile.Media.MediaPicker();
        }
    }
}