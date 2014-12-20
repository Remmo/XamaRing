using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace XamaRing.Base.Converters
{
    public class StringToEnumConverter : IValueConverter
    {
        public Type DefaultEnumType { get; set; }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (value == null)
            {
                return null;
            }
            return value.ToString();

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                return Enum.Parse(DefaultEnumType, value.ToString(), true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
