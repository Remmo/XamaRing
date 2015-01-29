using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamaRing.Core.Base;
using System.Windows.Input;
using Xamarin.Forms;
using Acr.XamForms.UserDialogs;

namespace Samples.ViewModels
{
    public class vmMain : vmBase
    {
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set
            {
                this.SetProperty(ref this.myVar, value);
            }
        }


        public ICommand OnOpenControls { get; private set; }
        public ICommand OnOpenServices { get; private set; }
        public ICommand PopupCommand { get; private set; }
        public ICommand PaginaCommand { get; private set; }
        public ICommand AlertCommand { get; private set; }

        private IUserDialogService dialogService = AppBase.Resolve<IUserDialogService>();

        public vmMain()
        {

            this.OnOpenControls = new Command(async () =>
            {
                await base.Navigation.PushAsync(new Samples.Views.XControlExamples());
            });
            this.OnOpenServices = new Command(async () =>
            {
                await base.Navigation.PushAsync(new Samples.Views.ServicesView());
            });
            this.PaginaCommand = new Command(async () =>
            {
                await base.Navigation.PushAsync(new Samples.Views.SecondView());
            });
            this.PopupCommand = new Command(async () =>
            {
                await base.Navigation.PushModalAsync(new Samples.Views.SecondView());
            });
            this.AlertCommand = new Command(async () =>
            {
                await dialogService.AlertAsync("Alert Async");
            });
        }
    }
}
