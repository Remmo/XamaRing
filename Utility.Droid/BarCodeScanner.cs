using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing;
using ZXing.Mobile;

using XamaRing.DS.BarCodeScanner;
using XamaRing.DS;

[assembly: Dependency(typeof(XamaRing.Utility.Droid.BarCodeScanner))]
namespace XamaRing.Utility.Droid
{


    public class BarCodeScanner : Java.Lang.Object, IBarCodeScanner
    {

        public BarCodeScannerConfiguration Configuration { get; private set; }


        public BarCodeScanner()
        {
            var def = ZXing.Mobile.MobileBarcodeScanningOptions.Default;

            this.Configuration = new BarCodeScannerConfiguration
            {
                AutoRotate = def.AutoRotate,
                CharacterSet = def.CharacterSet,
                DelayBetweenAnalyzingFrames = def.DelayBetweenAnalyzingFrames,
                InitialDelayBeforeAnalyzingFrames = def.InitialDelayBeforeAnalyzingFrames,
                PureBarcode = def.PureBarcode,
                TryHarder = def.TryHarder,
                TryInverted = def.TryInverted,
                UseFrontCameraIfAvailable = def.UseFrontCameraIfAvailable
            };
        }


        public void Read(Action<BarCodeResult> onRead)
        {
            this.ReadAsync().ContinueWith(x => onRead(x.Result));
        }


        public async Task<BarCodeResult> ReadAsync()
        {

            var scanner = new MobileBarcodeScanner(Forms.Context) { UseCustomOverlay = false };

            var result = await scanner.Scan(this.GetXingConfig());
            return (result == null || String.IsNullOrWhiteSpace(result.Text)
                ? BarCodeResult.Fail
                : new BarCodeResult(result.Text, FromXingFormat(result.BarcodeFormat))
            );
        }


        private static BarCodeFormat FromXingFormat(ZXing.BarcodeFormat format)
        {
            return (BarCodeFormat)Enum.Parse(typeof(BarCodeFormat), format.ToString());
        }


        private MobileBarcodeScanningOptions GetXingConfig()
        {
            var opts = new MobileBarcodeScanningOptions
            {
                AutoRotate = this.Configuration.AutoRotate,
                CharacterSet = this.Configuration.CharacterSet,
                DelayBetweenAnalyzingFrames = this.Configuration.DelayBetweenAnalyzingFrames,
                InitialDelayBeforeAnalyzingFrames = this.Configuration.InitialDelayBeforeAnalyzingFrames,
                PureBarcode = this.Configuration.PureBarcode,
                TryHarder = this.Configuration.TryHarder,
                TryInverted = this.Configuration.TryInverted,
                UseFrontCameraIfAvailable = this.Configuration.UseFrontCameraIfAvailable
            };

            if (this.Configuration.Formats != null && this.Configuration.Formats.Count > 0)
            {
                opts.PossibleFormats = this.Configuration.Formats
                    .Select(x => (BarcodeFormat)(int)x)
                    .ToList();
            }
            return opts;
        }
    }

}
