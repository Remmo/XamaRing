
using XamaRing.WinPhone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamaRing.DS;
using System.Windows;

[assembly: Xamarin.Forms.Dependency(typeof(CloseApp_WP))]



namespace XamaRing.WinPhone
{
    public class CloseApp_WP : ICloseApp
    {
        public void CloseApp()
        {
            Application.Current.Terminate();
        }
    }
}
