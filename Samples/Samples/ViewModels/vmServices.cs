using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamaRing;
using XamaRing.Core.Base;

namespace Samples.ViewModels
{
    public class vmServices : vmBase
    {
        public ICommand OnReadBarcode { get; private set; }
        public vmServices()
        {
            this.OnReadBarcode = new Command(() =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var dt = await CrossTools.ReadBarcode();
                    if (!String.IsNullOrWhiteSpace(dt))
                    {
                        await DialogService.AlertAsync(dt);
                    }
                });
            });
        }

    }
}
