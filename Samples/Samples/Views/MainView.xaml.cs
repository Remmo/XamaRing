
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.EIDOS.Base;
using Xamarin.Forms.EIDOS.Base.Helpers;
using XamaRing.Core.Base;
using Acr.XamForms.UserDialogs;

namespace Project.Views
{
    public partial class MainView : ContentPageBase
    {
        Boolean alternate = false;
        public MainView()
        {
            InitializeComponent();
            this.login.OnLoginFailed += vv_OnLoginFailed;
         
            this.login.OnShowLoading += login_OnShowLoading;
            this.login.OnHideLoading += login_OnHideLoading;
            this.grdMain.IsVisible = false;



            this.prjList.ItemTemplate = new DataTemplate(() =>
            {

                StackLayout stk = new StackLayout();
                Device.OnPlatform(Android: () => { stk.HeightRequest = 58; });


                Label lblPrjName = new Label() { LineBreakMode = LineBreakMode.TailTruncation, HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.CenterAndExpand, TextColor = Color.Black };
                lblPrjName.SetBinding(Label.TextProperty,
                    new Binding("PriojectName", BindingMode.OneWay,
                                null, null));
                Device.OnPlatform(iOS: () => { lblPrjName.Font = Font.SystemFontOfSize(NamedSize.Small); });


                Label lblPerc = new Label() { Font = Font.SystemFontOfSize(NamedSize.Large), WidthRequest = Device.OnPlatform<Int32>(70, 70, 100), HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.Center, TextColor = Color.FromHex("#ffa200") };
                lblPerc.SetBinding(Label.TextProperty,
                    new Binding("PercCompletamento", BindingMode.OneWay,
                                null, null, "{0}%"));

                Label lblStato = new Label() { Font = Font.SystemFontOfSize(NamedSize.Medium), LineBreakMode = LineBreakMode.NoWrap, HorizontalOptions = LayoutOptions.StartAndExpand, VerticalOptions = LayoutOptions.Center, TextColor = Color.Black };
                lblStato.SetBinding(Label.TextProperty,
                    new Binding("StatoGara", BindingMode.OneWay,
                                null, null));

                Label lblGara = new Label() { WidthRequest = Device.OnPlatform<Int32>(110, 110, 160), Font = Font.SystemFontOfSize(NamedSize.Large, FontAttributes.Bold), LineBreakMode = LineBreakMode.NoWrap, HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.CenterAndExpand, TextColor = Color.Black };
                lblGara.SetBinding(Label.TextProperty,
                    new Binding("CodiceGara", BindingMode.OneWay,
                                null, null));
                if (Device.OS == TargetPlatform.iOS)
                {

                }
                //grd.Padding = new Thickness(5);

                StackLayout stackMain = new StackLayout();

                stackMain.Padding = new Thickness(5, 5, 0, 0);
                stackMain.Orientation = StackOrientation.Vertical;
                StackLayout stackUp = new StackLayout();
                stackUp.Orientation = StackOrientation.Horizontal;
                stackUp.Children.Add(lblGara);
                stackUp.Children.Add(lblPerc);
                stackUp.Children.Add(lblStato);

                stackMain.Children.Add(stackUp);
                stackMain.Children.Add(lblPrjName);
                stk.Children.Add(stackMain);
                stk.VerticalOptions = LayoutOptions.FillAndExpand;

                var p = new ViewCell
                {
                    View = new Grid { Children = { new Grid { BackgroundColor = Color.Gray, Opacity = 0.5, HeightRequest = 1, IsVisible = Device.OS != TargetPlatform.iOS, VerticalOptions = LayoutOptions.EndAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, WidthRequest = 500 }, stk }, HorizontalOptions = LayoutOptions.FillAndExpand },
                    //Height = 60,
                };
                if (Device.OS != TargetPlatform.iOS)
                    p.Height = 60;
                alternate = !alternate;
                return p;
            });
            Device.OnPlatform(iOS: () => { prjList.RowHeight = 70; }, Android: () => { prjList.RowHeight = 60; }, WinPhone: () => { ;});
            inizializzaLogin();


            if (Device.OS == TargetPlatform.WinPhone)
            {
                var titoloPagina = Xamarin.Forms.EIDOS.Base.Helpers.General.GetTitoloWP("Elenco gare", Font.SystemFontOfSize(24).WithAttributes(FontAttributes.Bold), Color.FromHex("#2faeb5"), Color.White);
                titoloPagina.HorizontalOptions = LayoutOptions.FillAndExpand;
                this.stackMain.Children.Insert(0, titoloPagina);
            }


        }

        private void inizializzaLogin()
        {
            this.login.TitoloApp = "Cruscotto Gare";
            this.login.HorizontalOptions = LayoutOptions.FillAndExpand;
            this.login.VerticalOptions = LayoutOptions.FillAndExpand;

            if (Device.OS == TargetPlatform.iOS)
            {

            }
            else if (Device.OS == TargetPlatform.WinPhone)
            {
                this.login.LogoAppImageSource = ImageSource.FromFile("Images\\LoginLogoApp.png");

            }
            else if (Device.OS == TargetPlatform.Android)
            {
                this.login.LogoAppImageSource = ImageSource.FromFile("AppIcon2.png");
                //this.login.BackgroundColor = Color.FromHex("#2faeb5");
                this.login.ButtonsBgColor = Color.White;
                this.login.TitoloAppFont = Font.OfSize("sans-serif-light", 40);
                this.login.SwitchBgColor = Color.White;
                this.login.ButtonsFgColor = Color.FromHex("#2faeb5");
                //this.login.SwitchBgColor = Color.White;

                ////Titolo, txtBox, lblMemorizza FgColor
                this.login.AllTextFGColor = Color.White;
            }
        }

        void login_OnHideLoading(object sender, EventArgs e)
        {
            //this.vm.DialogService.HideLoading();
        }

        void login_OnShowLoading(string message, EventArgs e)
        {
            //this.vm.DialogService.ShowLoading(message);
        }


    

        private Boolean isFirstTime = true;
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (isFirstTime)
            {
                this.Title = "Autenticazione";

                this.CustomPageStyle.BgColor = Color.FromHex("#2faeb5");
                this.CustomPageStyle.EntryBackgroundColor = Color.White;
                this.CustomPageStyle.WPLightTheme = false;
                this.CustomPageStyle.AccentColor = Color.Accent;
                this.CustomPageStyle.WPPhoneForegroundColor = Color.White;
             
                base.ApplyCrossTheme(this.CustomPageStyle);
            }
            else
            {
                this.ApplyCrossTheme(AppBase.GetCrossStyle());
                this.grdMain.IsVisible = true;
                this.grdMain.HeightRequest = this.Height;
                this.grdMain.WidthRequest = this.Width;
                this.grdLogin.IsVisible = false;

                this.prjList.SelectedItem = null;


            }
        }
        private void vv_OnLoginFailed(string message, EventArgs e)
        {
           
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            this.CustomPageStyle.BgColor = Color.White;
            //this.CustomPageStyle.EntryBackgroundColor = Color.White;
            //this.CustomPageStyle.WPLightTheme = false;
            //this.CustomPageStyle.AccentColor = Color.Accent;
            this.CustomPageStyle.WPPhoneForegroundColor = Color.Black;
            base.ApplyCrossTheme(this.CustomPageStyle);
        }
    }
}
