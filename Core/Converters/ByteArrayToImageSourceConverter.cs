using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace XamarRing.Base.Converters
{
    public class ByteArrayToImageSourceConverter : IValueConverter
    {        
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                var fromRes = ImageSource.FromResource("ITALFERR.Rubrica.Images.EmptyFace.jpg");
                return null;
            }
            var bArray = (byte[])value;

            var imgsrc = ImageSource.FromStream(() =>
            {                
                var ms = new MemoryStream(bArray);
                ms.Position = 0;
                return ms;
            });
            
            return imgsrc;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
