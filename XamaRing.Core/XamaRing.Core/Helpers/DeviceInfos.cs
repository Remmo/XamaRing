using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XLabs.Ioc;
using XLabs.Platform.Device;



namespace XamaRing.Core.Helpers
{
    public static class DeviceInfos
    {

        public static Boolean IsInitialized = false;
        public static String DeviceID;
        public static String Manufacturer;
        public static String Model;
        public static String OperatingSystem;
        public static Double ScreenHeight;
        public static Double ScreenWidth;
        public static void Initialize(IDevice p)
        {
            Manufacturer = p.Manufacturer;
            DeviceID = p.Id;
            Model = p.Manufacturer;
            OperatingSystem = p.FirmwareVersion;
            ScreenHeight = p.ScreenHeightInches();
            ScreenWidth = p.ScreenWidthInches();
            IsInitialized = true;
        }
    }
}
