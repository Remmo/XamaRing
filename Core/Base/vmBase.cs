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
    public class vmBase : INotifyPropertyChanged
    {
        private IUserDialogService dialogService;
        public event PropertyChangedEventHandler PropertyChanged;

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
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);
                this.PropertyChanged(this, args);
            }
        }
        protected void OnPropertyChanged(Object propertyInstance)
        {
            if (PropertyChanged != null)
            {
                PropertyChangedEventArgs args = new PropertyChangedEventArgs(General.GetPropertyName(() => propertyInstance));
                this.PropertyChanged(this, args);
            }
        }

    }
}
