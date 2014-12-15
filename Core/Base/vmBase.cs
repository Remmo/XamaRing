using Acr.XamForms.Mobile.Net;
using Acr.XamForms.UserDialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XamarRing.Core.Helpers;

namespace XamarRing.Core.Base
{

    public partial class vmBase : Xamarin.Forms.Labs.Mvvm.ViewModel
    {
        
        private IUserDialogService dialogService;

        public vmBase()
        {
            this.dialogService = AppBase.Resolve<IUserDialogService>();
        }
        public async Task ShowAlert(String message, String title = null, String okText = "OK")
        {
            //await AppBase.AppNavigator.DisplayAlert(title,message,okText);
            await this.dialogService.AlertAsync(message, title, okText);
        }
        public void ShowLoading(String title = "Caricamento")
        {
            this.dialogService.ShowLoading(title);
        }

        public void HideLoading()
        {
            this.dialogService.HideLoading();
        } 
    }
}
