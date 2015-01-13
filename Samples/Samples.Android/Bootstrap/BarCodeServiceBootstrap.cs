// HACK: this is to deal with the linker nuking the assembly
using Acr.XamForms.BarCodeScanner;

namespace Samples.Droid.Bootstrap
{
    public class BarCodeServiceBootstrap 
    {
        public BarCodeServiceBootstrap() 
        {
            new BarCodeService();
        }
    }
}