using Microsoft.Phone.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using XamaRing.DependencyServices;
using XamaRing.DependencyServices.Configs;


[assembly: Xamarin.Forms.Dependency(typeof(XamaRing.Utility.WinPhone.ThemeUtils))]
namespace XamaRing.Utility.WinPhone
{
    public static class WPExt
    {
        public static System.Windows.Media.Color ToWPColor(this Xamarin.Forms.Color xamColor)
        {
            return System.Windows.Media.Color.FromArgb(Convert.ToByte(xamColor.A * 255), Convert.ToByte(xamColor.R * 255), Convert.ToByte(xamColor.G * 255), Convert.ToByte(xamColor.B * 255));
        }
    }
    public static class wpStyleKey
    {
        public static readonly String PhoneContrastBackgroundColor = "PhoneContrastBackgroundColor";
        public static readonly String PhoneChromeColor = "PhoneChromeColor";
        public static readonly String PhoneBackgroundColor = "PhoneBackgroundColor";
        public static readonly String PhoneTextBoxColor = "PhoneTextBoxColor";
        public static readonly String PhoneAccentColor = "PhoneAccentColor";
        public static readonly String PhoneForegroundColor = "PhoneForegroundColor";


    }
    public class ThemeUtils : IApplyTheme
    {
        public ThemeUtils() { }

        PhoneApplicationPage frame;



        private void addOrChangeStyle(System.Windows.Media.Color st, String Key)
        {
            //if (this.dictionary.Any(q => q.Key.ToString() == Key))
            //{
            //    return;
            //    this.dictionary.Remove(Key);
            //}
            this.dictionary.Add(Key, st);
        }


        System.Windows.ResourceDictionary dictionary;

        public void ApplyTheme(StyleConfig config)
        {
            try
            {
                dictionary = new System.Windows.ResourceDictionary();
                #region Background
                if (config.BgColor.HasValue)
                    this.addOrChangeStyle(config.BgColor.Value.ToWPColor(), wpStyleKey.PhoneBackgroundColor);
                #endregion
                #region ApplicationBar and SystemTray
                if (config.WPPhoneChromeColor.HasValue)
                    this.addOrChangeStyle(config.WPPhoneChromeColor.Value.ToWPColor(), wpStyleKey.PhoneChromeColor);
                #endregion
                #region ContrastBackground
                if (config.WPPhoneContrastBackgroundColor.HasValue)
                    this.addOrChangeStyle(config.WPPhoneContrastBackgroundColor.Value.ToWPColor(), wpStyleKey.PhoneContrastBackgroundColor);
                #endregion
                #region ForegroundColor
                if (config.WPPhoneForegroundColor.HasValue)
                    this.addOrChangeStyle(config.WPPhoneForegroundColor.Value.ToWPColor(), wpStyleKey.PhoneForegroundColor);
                #endregion
                //#region Button
                //if (config.ButtonColor.HasValue)
                //    this.addOrChangeStyle(config.ButtonColor.Value.ToWPColor(), wpStyleKey.PhoneContrastBackgroundColor);
                //#endregion


                //#region DefaultFont
                //if (config.TextColor.HasValue)
                //{
                //    this.addOrChangeStyle(new Style(typeof(ContentControl))
                //    {
                //        Setters = 
                //        {
                //            new Setter(System.Windows.Controls.ContentControl.ForegroundProperty, config.TextColor.Value.ToWPColor())
                //        }
                //    },wpStyleKey.Border);
                //}
                //#endregion

                #region EntryBackgroundColor
                if (config.EntryBackgroundColor.HasValue)
                    this.addOrChangeStyle(config.EntryBackgroundColor.Value.ToWPColor(), wpStyleKey.PhoneTextBoxColor);
                #endregion

                //#region EntryForegroundColor
                //if (config.EntryForegroundColor.HasValue)
                //{
                //    stEntry.Setters.Add(new Setter(System.Windows.Controls.TextBox.ForegroundProperty, new SolidColorBrush(config.EntryForegroundColor.Value.ToWPColor())));
                //    add = true;
                //}
                //if (add)
                //    this.addOrChangeStyle(stEntry);
                //#endregion


            }
            catch (Exception)
            {

                throw;
            }

            ThemeManager.SetCustomTheme(dictionary, config.WPLightTheme ? Theme.Light : Theme.Dark);
            #region AccentColor
            if (config.AccentColor.HasValue)
                ThemeManager.SetAccentColor(config.AccentColor.Value.ToWPColor());
            #endregion
        }
    }
}
