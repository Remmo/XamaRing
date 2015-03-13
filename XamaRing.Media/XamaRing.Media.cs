
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamaRing
{
    public static class CrossToolsMedia
    {
        private static Acr.BarCodes.IBarCodes barcodeScanner;
        //public static IMediaPicker MediaSvc;

        //public static void InitializeMedia(IMediaPicker pick)
        //{    
        //    MediaSvc = pick;          
        //}


        public static async Task<String> ReadBarcode()
        {
            //if (barcodeScanner == null)
            //{
            //    barcodeScanner = DependencyService.Get<Acr.BarCodes.IBarCodes>();
            //}
            if (barcodeScanner == null)
                barcodeScanner = Acr.BarCodes.BarCodes.Instance;
            var p = await barcodeScanner.Read();
            if (p.Success)
            {
                return p.Code;
            }
            else
                return String.Empty;
        }
    }
}
