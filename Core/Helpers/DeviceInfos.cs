using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace XamarRing.Core.Helpers
{
    public static class DeviceInfos
    {

        public static Boolean IsInitialized = false;
        public static String DeviceID;
        public static String Manufacturer;
        public static String Model;
        public static String OperatingSystem;
        public static Int32 ScreenHeight;
        public static Int32 ScreenWidth;
        public static void Initialize(Acr.XamForms.Mobile.IDeviceInfo p)
        {
            DeviceID = p.DeviceId;
            Manufacturer = p.Manufacturer;
            DeviceID = p.DeviceId;
            Model = p.Model;
            OperatingSystem = p.OperatingSystem;
            ScreenHeight = p.ScreenHeight;
            ScreenWidth = p.ScreenWidth;
            IsInitialized = true;
        }
    }
}
