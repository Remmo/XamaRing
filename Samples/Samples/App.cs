using Samples.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.EIDOS.Base;
using XamaRing;
using XamaRing.Core.Base;
using XamaRing.DS.Configs;

namespace Samples
{
    public class App : Xamarin.Forms.Application
    {

        ContentPage ct = new ContentPage
        {
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                                    new Label {
                                        XAlign = TextAlignment.Center,
                                        Text = "Welcome to Xamarin Forms!"
                                    }
                                }
            }
        };

        #region Portrait Example
        //public App()
        //{
        //    XamaRing.Core.Base.AppBase.Init();
        //    manageTheme();
        //    AppBase.AppNavigator = new NavigationPage(this.creaPaginaLogin());
        //    if (Device.OS == TargetPlatform.Android || Device.OS == TargetPlatform.iOS)
        //    {
        //        var navigation = ((NavigationPage)(AppBase.AppNavigator));
        //        navigation.BarBackgroundColor = Color.FromHex("#dd3f18");
        //        navigation.BarTextColor = Color.White;
        //    }
        //    this.MainPage = AppBase.AppNavigator;
        //}

        //private LoginItalferr creaPaginaLogin()
        //{
        //    LoginItalferr login = new LoginItalferr(ct, 2) { IsLandscape = false, BackgroundColor = Color.FromHex("#dd3f18"), TitoloApp = "Rubrica" };
        //    if (Device.OS == TargetPlatform.WinPhone)
        //    {
        //        login.LogoAppImageSource = ImageSource.FromFile("Images\\LoginLogoApp.png");
        //    }
        //    else if (Device.OS == TargetPlatform.Android)
        //    {
        //        login.LogoAppImageSource = ImageSource.FromFile("LogoLogin.png");
        //        login.ButtonsBgColor = Color.FromHex("#dbdbdb");
        //        login.ButtonsFgColor = Color.FromHex("#dd3f18");
        //        login.SwitchBgColor = Color.White;
        //        //Titolo, txtBox, lblMemorizza FgColor
        //        login.AllTextFGColor = Color.White;
        //    }
        //    else if (Device.OS == TargetPlatform.iOS)
        //    {
        //        login.LogoAppImageSource = ImageSource.FromFile("LogoLogin.png");
        //        //this.login.ButtonsBgColor = Color.FromHex("#dbdbdb");
        //        login.ButtonsFgColor = Color.White;
        //        //Titolo, txtBox, lblMemorizza FgColor
        //        login.AllTextFGColor = Color.White;
        //    }
        //    login.CustomPageStyle.BgColor = Color.FromHex("#dd3f18");
        //    login.CustomPageStyle.EntryBackgroundColor = Color.White;
        //    login.CustomPageStyle.WPLightTheme = false;
        //    return login;
        //}



        //private static void manageTheme()
        //{
        //    StyleConfig cfg = new StyleConfig();
        //    if (Device.OS == TargetPlatform.WinPhone)
        //    {
        //        cfg.BgColor = Color.White;
        //        cfg.WPPhoneChromeColor = Color.FromHex("#dd3f18");
        //        cfg.WPPhoneForegroundColor = Color.White;
        //        cfg.EntryBackgroundColor = Color.Silver;
        //        cfg.WPLightTheme = true;
        //        //cfg.AccentColor = Color.FromHex("#dd3f18");
        //    }
        //    else if (Device.OS == TargetPlatform.Android)
        //    {
        //        cfg.BgColor = Color.White;
        //    }
        //    AppBase.SetCrossStyle(cfg);
        //}
        #endregion

        #region Landscape Example
        public App()
        {
            XamaRing.Core.Base.AppBase.Init();
            manageTheme();
            AppBase.AppNavigator = new NavigationPage(this.creaPaginaLogin());
            if (Device.OS == TargetPlatform.Android || Device.OS == TargetPlatform.iOS)
            {
                AppBase.AppNavigator.BarBackgroundColor = Color.FromHex("#a1b400");
                AppBase.AppNavigator.BarTextColor = Color.White;
            }
            this.MainPage = AppBase.AppNavigator;
        }
        private LoginItalferr creaPaginaLogin()
        {
            LoginItalferr login = new LoginItalferr(ct, 3) { IsLandscape = false, BackgroundColor = Color.FromHex("#a1b400"), TitoloApp = "ROI Giustificativi" };
            login.CustomPageStyle.BgColor = Color.FromHex("#a1b400");
            login.CustomPageStyle.EntryBackgroundColor = Color.White;
            login.CustomPageStyle.WPPhoneChromeColor = Color.FromHex("#a1b400");
            login.CustomPageStyle.WPLightTheme = false;
            login.WPButtonsBorderColor = Color.White;
            login.LblMemorizzaCredenzialiFGColor = Color.White;
            if (Device.OS == TargetPlatform.WinPhone)
            {
                login.TitoloAppTextColor = Color.White;
                login.LogoAppImageSource = ImageSource.FromFile("Images\\LoginLogoApp.png");
                login.ButtonsFgColor = Color.White;
            }
            else if (Device.OS == TargetPlatform.Android)
            {
                login.LogoAppImageSource = ImageSource.FromFile("LogoLogin.png");
                login.ButtonsBgColor = Color.FromHex("#dbdbdb");
                login.ButtonsFgColor = Color.White;
                login.SwitchBgColor = Color.White;
                //Titolo, txtBox, lblMemorizza FgColor
                login.AllTextFGColor = Color.White;
            }
            else if (Device.OS == TargetPlatform.iOS)
            {

            }
            return login;
        }

        private static void manageTheme()
        {
            StyleConfig cfg = new StyleConfig();
            if (Device.OS == TargetPlatform.WinPhone)
            {
                //cfg.BgColor = Color.FromHex("#a1b400");
                cfg.BgColor = Color.White;
                cfg.WPPhoneChromeColor = Color.FromHex("#a1b400");
                cfg.WPPhoneForegroundColor = Color.White;
                cfg.EntryBackgroundColor = Color.Silver;
                cfg.WPLightTheme = true;
                //cfg.AccentColor = Color.FromHex("#dd3f18");
            }
            else if (Device.OS == TargetPlatform.Android)
            {
                cfg.BgColor = Color.FromHex("#a1b400");
            }
            AppBase.SetCrossStyle(cfg);
        }
        #endregion






        //public App()
        //{
        //    XamaRing.Core.Base.AppBase.Init();
        //    manageTheme();
        //    AppBase.AppNavigator = new NavigationPage(new MainView());
        //    MainPage = AppBase.AppNavigator;
        //    if (CrossTools.NetworkSvc.IsConnected)
        //    {
        //        MainPage = AppBase.AppNavigator;
        //    }
        //}

        //private static void manageTheme()
        //{
        //    StyleConfig cfg = new StyleConfig();
        //    //if (Device.OS == TargetPlatform.WinPhone)
        //    //{
        //    //    cfg.BgColor = Color.White;
        //    //    cfg.WPPhoneChromeColor = Color.FromHex("#2faeb5");
        //    //    cfg.WPPhoneForegroundColor = Color.White;
        //    //    cfg.EntryBackgroundColor = Color.Silver;
        //    //    cfg.WPLightTheme = true;
        //    //    //cfg.AccentColor = Color.FromHex("#dd3f18");
        //    //}
        //    //else if (Device.OS == TargetPlatform.Android)
        //    //{
        //    //    cfg.BgColor = Color.White;
        //    //}
        //    AppBase.SetCrossStyle(cfg);
        //}
    }
}
