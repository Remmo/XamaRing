using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace XamaRing.DependencyServices.Configs
{
    public class StyleConfig
    {


        private Color? bgColor;

        public Color? BgColor
        {
            get { return bgColor; }
            set { bgColor = value; }
        }

        private string fontFamily;

        public string FontFamily
        {
            get { return fontFamily; }
            set { fontFamily = value; }
        }

        //private Color? buttonColor;

        //public Color? ButtonColor
        //{
        //    get { return buttonColor; }
        //    set { buttonColor = value; }
        //}
        private Boolean wpLightTheme;
        public Boolean WPLightTheme
        {
            get { return wpLightTheme; }
            set { wpLightTheme = value; }
        }

        private Color? accentColor;

        public Color? AccentColor
        {
            get { return accentColor; }
            set { accentColor = value; }
        }

        //private Color? textColor;

        //public Color? TextColor
        //{
        //    get { return textColor; }
        //    set { textColor = value; }
        //}

        private Color? wpPhoneChromeColor;

        public Color? WPPhoneChromeColor
        {
            get { return wpPhoneChromeColor; }
            set { wpPhoneChromeColor = value; }
        }

        private Color? wpPhoneContrastBackgroundColor;

        public Color? WPPhoneContrastBackgroundColor
        {
            get { return wpPhoneContrastBackgroundColor; }
            set { wpPhoneContrastBackgroundColor = value; }
        }

        private Color? wpPhoneForegroundColor;

        public Color? WPPhoneForegroundColor
        {
            get { return wpPhoneForegroundColor; }
            set { wpPhoneForegroundColor = value; }
        }

        

        private Color? entryBackgroundColor;

        public Color? EntryBackgroundColor
        {
            get { return entryBackgroundColor; }
            set { entryBackgroundColor = value; }
        }

        private Color? entryForegroundColor;

        public Color? EntryForegroundColor
        {
            get { return entryForegroundColor; }
            set { entryForegroundColor = value; }
        }






    }
}
