using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamaRing;
using XamaRing.Core.Base;
using XamaRing.DS.Configs;

namespace XamaRing.Core.Base
{
    public class ContentPageBase : ContentPage
    {
        public StyleConfig CustomPageStyle = new StyleConfig();
        public ContentPageBase()
        {
            var app = AppBase.GetCrossStyle();
            CustomPageStyle.BgColor = app.BgColor;
            CustomPageStyle.WPLightTheme = app.WPLightTheme;
            CustomPageStyle.FontFamily = app.FontFamily;
            CustomPageStyle.WPPhoneChromeColor = app.WPPhoneChromeColor;
            CustomPageStyle.EntryBackgroundColor = app.EntryBackgroundColor;
            CustomPageStyle.EntryForegroundColor = app.EntryForegroundColor;
            CustomPageStyle.EntryForegroundColor = app.EntryForegroundColor;
            CustomPageStyle.WPPhoneContrastBackgroundColor = app.WPPhoneContrastBackgroundColor;
            CustomPageStyle.AccentColor = app.AccentColor;
            CustomPageStyle.WPPhoneForegroundColor = app.WPPhoneForegroundColor;
            CustomPageStyle.TableViewDetailColor = app.TableViewDetailColor;
            if (Device.OS == TargetPlatform.Android)
            {
                if (app.WPPhoneChromeColor.HasValue)
                    AppBase.AppNavigator.BarBackgroundColor = app.WPPhoneChromeColor.Value;
                if (app.BgColor.HasValue)
                    Device.BeginInvokeOnMainThread(() => { this.BackgroundColor = app.BgColor.Value; });

            }

        }
        protected override void OnAppearing()
        {
            if (!this.isCustomThemeApplied && AppBase.IsThemeChanged)
            {
                AppBase.IsThemeChanged = false;
                CrossTools.ApplyCrossTheme(AppBase.GetCrossStyle());
            }
            base.OnAppearing();
        }
        private Boolean isCustomThemeApplied = false;
        public void ApplyCrossTheme(StyleConfig cfgTheme)
        {
#warning 1.3.1 aggiungere lo style da codice
            this.isCustomThemeApplied = true;
            AppBase.IsThemeChanged = true;
            if (cfgTheme.BgColor.HasValue)
            {
                if (Device.OS == TargetPlatform.Android)
                {
                    Device.BeginInvokeOnMainThread(() => { this.BackgroundColor = cfgTheme.BgColor.Value; });
                }
                else
                    this.BackgroundColor = cfgTheme.BgColor.Value;
            }
            if (Device.OS == TargetPlatform.Android)
            {
                if (cfgTheme.WPPhoneChromeColor.HasValue)
                    AppBase.AppNavigator.BarBackgroundColor = cfgTheme.WPPhoneChromeColor.Value;
            }
            CrossTools.ApplyCrossTheme(cfgTheme);
        }
        public StackLayout GetTitoloWP(string Titolo, Font TitoloFont, Color ColoreRiempimento, Color ColoreFont)
        {
            Label lbl = new Label();
            lbl.Text = Titolo;
            lbl.Font = TitoloFont;
            lbl.HorizontalOptions = LayoutOptions.CenterAndExpand;
            lbl.VerticalOptions = LayoutOptions.Start;
            lbl.XAlign = TextAlignment.Center;
            lbl.YAlign = TextAlignment.Center;
            lbl.TextColor = ColoreFont;
            StackLayout frame = new StackLayout();
            frame.HeightRequest = 50;
            frame.BackgroundColor = ColoreRiempimento;
            frame.HorizontalOptions = LayoutOptions.FillAndExpand;
            frame.VerticalOptions = LayoutOptions.Start;
            frame.Children.Add(lbl);
            return frame;
        }


    }
}
