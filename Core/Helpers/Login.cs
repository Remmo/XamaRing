//using Acr.XamForms.Mobile;
//using Acr.XamForms.Mobile.Net;
//using Acr.XamForms.UserDialogs;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xamarin.Forms;


//namespace XamaRing.Core.Helpers
//{
//    public class Login : View
//    {
//        public Login()
//        {

//        }
//        public delegate void LoginFailedEventHandler(String message, EventArgs e);
//        public event LoginFailedEventHandler OnLoginFailed;

//        public delegate void LoginOKEventHandler(Object sender, EventArgs e);
//        public event LoginOKEventHandler OnLoginOK;
//        public void LoginOK(Object argument = null)
//        {

//            if (this.OnLoginOK != null)
//                this.OnLoginOK(argument == null ? this : argument, EventArgs.Empty);
//        }
//        public void LoginFailed(String message = null)
//        {
//            if (this.OnLoginFailed != null)
//                this.OnLoginFailed(String.IsNullOrWhiteSpace(message) ? "Errore durante l'autenticazione, si prega di riprovare" : message, EventArgs.Empty);
//        }
//        public View GetLoginContent(String applicationName, IUserDialogService dialogService, INetworkService networkService, String mailAssistenza = null, Boolean isLandscape = false)
//        {

//            this.dialogService = dialogService;
//            this.networkService = networkService;
//            //if (!XamaRing.Base.Helpers.DeviceInfos.IsInitialized)
//            //    XamaRing.Base.Helpers.DeviceInfos.Initialize(Xamarin.Forms.Labs.Services.Resolver.Resolve<Xamarin.Forms.Labs.IDevice>());

//            this.AppName = applicationName;
//            //this.Title = "Autenticazione alla rete ITALFERR";
//            Image img = new Image();
//            img.Opacity = 0.2;
//            //Device.OnPlatform(iOS: () => { img.Source = ImageSource.FromFile("Images/effe.png"); });
//            img.Source = ImageSource.FromResource("XamaRing.Base.Images.effe.png");
//            //img.HeightRequest = 500;

//            img.HorizontalOptions = LayoutOptions.FillAndExpand;
//            img.VerticalOptions = LayoutOptions.CenterAndExpand;

//            //ViewModels.Login.LoginVM VM = new ViewModels.Login.LoginVM();

//            StackLayout stackMain = new StackLayout();
//            if (Device.OS == TargetPlatform.WinPhone)
//            {
//                stackMain.Spacing = 0;
//            }
//            Image imgLogoItalferr = new Image
//            {
//                //TODO
//                HeightRequest = 80,
//                HorizontalOptions = LayoutOptions.CenterAndExpand,
//            };
//            imgLogoItalferr.Source = ImageSource.FromResource("XamaRing.Base.Images.LogoItalferr.png");
//            Label lblProblemiAccesso = new Label
//            {
//                Text = "Problemi di accesso?",
//                Font = Font.SystemFontOfSize(NamedSize.Medium),
//                HorizontalOptions = LayoutOptions.CenterAndExpand,
//                VerticalOptions = LayoutOptions.Center,
//                TextColor = Color.Accent,

//            };

           
//            stackMain.HorizontalOptions = LayoutOptions.FillAndExpand;
//            stackMain.VerticalOptions = LayoutOptions.CenterAndExpand;
//            StackLayout stCredenziali = new StackLayout { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.Center };
//            Label lblCredenziali = new Label { Text = "Memorizza credenziali?", VerticalOptions = LayoutOptions.Center, Font = Font.SystemFontOfSize(NamedSize.Medium), TextColor = Color.Accent };
//            stCredenziali.Children.Add(lblCredenziali);
//            stCredenziali.Children.Add(switchMemorizzaPassword);
//            btLogin.Clicked += async (sender, args) =>
//            {
//                //if (Device.OS == TargetPlatform.WinPhone)
//                //{
//                //    //bisogna richiamarlo per farlo aggiornare -- agghiacciante!
//                //    this.networkService = AppBase.Resolve<INetworkService>();
//                //}


//                //Boolean isReachable = await this.networkService.IsHostReachable("https://www.google.it");
//                if (this.networkService.IsConnected)
//                {

//                    if (String.IsNullOrWhiteSpace(this.txtPassword.Text) || String.IsNullOrWhiteSpace(this.txtUsername.Text))
//                    {

//                        this.LoginFailed("Nome utente e password obbligatori");
//                        //await this.DisplayAlert("Attenzione", "Nome utente e password obbligatori", "Ok", null);
//                    }
//                    else
//                    {
//                        this.noSave = false;
//                        autenticate();
//                    }
//                }
//                else
//                {
//                    this.LoginFailed("Nessuna connessione ad Internet, connettersi e riprovare");
//                }

//            };
//            #region Assegnazione alla griglia principale
//            stackMain.Children.Add(imgLogoItalferr);
//            //stackMain.Children.Add(lblAccesso);
//            stackMain.Children.Add(txtUsername);
//            stackMain.Children.Add(txtPassword);
//            stackMain.Children.Add(btLogin);
//            stackMain.Children.Add(stCredenziali);
//            if (isLandscape)
//            {
//                this.btAssistenza.HorizontalOptions = LayoutOptions.Start;
//                lblProblemiAccesso.HorizontalOptions = LayoutOptions.End;
//                StackLayout stackAss = new StackLayout() { Orientation = StackOrientation.Horizontal, HorizontalOptions=LayoutOptions.Center };
//                if (Device.OS == TargetPlatform.WinPhone)
//                {
//                    stackAss.Padding = 0;
//                }
//                stackAss.Children.Add(lblProblemiAccesso);
//                stackAss.Children.Add(btAssistenza);
//                stackMain.Children.Add(stackAss);
//            }
//            else
//            {
//                stackMain.Children.Add(lblProblemiAccesso);
//                stackMain.Children.Add(btAssistenza);
//            }
//            //stackMain.Children.Add(loader);

//            #endregion
//            if (XamaRing.Base.Helpers.Settings.CheckLoginDataKey())
//            {
//                AuthData auth = XamaRing.Base.Helpers.Settings.GetLoginData();
//                txtUsername.Text = auth.Username;
//                txtPassword.Text = auth.Password;
//                this.noSave = true;
//                //this.autenticate();
//            }
//            View retView = new Grid
//            {
//                Children = 
//                {
//                    img,
//                    stackMain
//                },

//                HorizontalOptions = LayoutOptions.CenterAndExpand,
//                VerticalOptions = LayoutOptions.CenterAndExpand,
//                Padding = new Thickness(10)
//            };
//            return retView;
//        }



//        Boolean noSave = true;

//        private INetworkService networkService;
//        private IUserDialogService dialogService;
//        Button btLogin = new Button() { Text = "Accedi", HorizontalOptions = LayoutOptions.CenterAndExpand };
//        Entry txtUsername = new Entry() { Placeholder = "CID", HorizontalOptions = LayoutOptions.Center, WidthRequest = Device.OnPlatform(300, 300, 400) };
//        Entry txtPassword = new Entry() { Placeholder = "Password", IsPassword = true, HorizontalOptions = LayoutOptions.Center, WidthRequest = Device.OnPlatform(300, 300, 400) };
//        Button btAssistenza = new Button { Text = "Contatta l'assistenza", HorizontalOptions = LayoutOptions.Center };

//        Switch switchMemorizzaPassword = new Switch() { IsToggled = true };
//        String AppName = String.Empty;
//        //public delegate void LoginFailedEventHandler(String message, EventArgs e);
//        //public event LoginFailedEventHandler OnLoginFailed;

//        //public delegate void LoginOKEventHandler(Object sender, EventArgs e);
//        //public event LoginOKEventHandler OnLoginOK;



//        //ActivityIndicator loader = new ActivityIndicator
//        //{
//        //    Color = Color.Green,
//        //    IsEnabled = false,
//        //    IsVisible = false,
//        //    IsRunning = false,
//        //};

//        AuthServiceITALFERR.AuthenticationServiceClient authSvc = new AuthServiceITALFERR.AuthenticationServiceClient();
//        private void autenticate()
//        {
//            if (Device.OS == TargetPlatform.iOS)
//            {
//                Device.BeginInvokeOnMainThread(() =>
//                {
//                    dialogService.ShowLoading("Login in corso");
//                });
//            }
//            else
//            {
//                dialogService.ShowLoading("Login in corso");
//            }
//            //loader.IsEnabled = true;
//            //loader.IsVisible = true;
//            //loader.IsRunning = true;
//            authSvc.LogOnCompleted += authSvc_LogOnCompleted;

//            authSvc.LogOnAsync("ITALFERR", this.txtUsername.Text, this.txtPassword.Text, Helpers.DeviceInfos.DeviceID, Helpers.DeviceInfos.Manufacturer, Helpers.DeviceInfos.OperatingSystem, Helpers.DeviceInfos.Model);
//        }

//        async void authSvc_LogOnCompleted(object sender, AuthServiceITALFERR.LogOnCompletedEventArgs e)
//        {
//            if (Device.OS == TargetPlatform.Android)
//            {
//                Device.BeginInvokeOnMainThread(() =>
//                {
//                    dialogService.HideLoading();
//                });
//            }
//            else
//            {
//                dialogService.HideLoading();
//            }
//            //Task.Delay(1000);
//            //loader.IsEnabled = false;
//            //loader.IsVisible = false;
//            //loader.IsRunning = false;
//            if (e.Error != null)
//            {
//                this.LoginFailed("L'autenticazione non è avvenuta a causa del seguente errore :" + e.Error.Message);
//                //if (Device.OS == TargetPlatform.Android)
//                //{
//                //    Device.BeginInvokeOnMainThread(async () =>
//                //    {
//                //      await  dialogService.AlertAsync("L'autenticazione non è avvenuta a causa del seguente errore :" + e.Error.Message);
//                //        //dialogService.Alert("L'autenticazione non è avvenuta a causa del seguente errore :" + e.Error.Message);
//                //    });
//                //}
//                //else
//                //{
//                //   await dialogService.AlertAsync("L'autenticazione non è avvenuta a causa del seguente errore :" + e.Error.Message);

//                //    //dialogService.Alert("L'autenticazione non è avvenuta a causa del seguente errore :" + e.Error.Message);
//                //}
//            }
//            else if (e.Cancelled)
//            {
//                return;
//            }
//            else if (e.Result != null)
//            {
//                if (e.Result.ExitCode == 0)//AuthOK
//                {
//                    AppBase.Token = e.Result.Resulted.ToString();
//                    // dialogService.Alert("Login avvenuto con successo", null, "Ok", () =>
//                    //{
//                    AppBase.IsLoggedIn = true;
//                    this.LoginOK();
//                    if (!noSave && this.switchMemorizzaPassword.IsToggled)
//                    {
//                        XamaRing.Base.Helpers.Settings.SaveLoginData(new Helpers.AuthData() { Domain = "ITALFERR", Username = this.txtUsername.Text, Password = this.txtPassword.Text });
//                    }
//                    else
//                    {
//                        XamaRing.Base.Helpers.Settings.DeleteLoginData();
//                    }
//                    //});
//                }
//                else
//                {
//                    this.LoginFailed(e.Result.Message);
//                }
//            }
//        }
//    }
//}
