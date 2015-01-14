using Microsoft.Phone;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

[assembly: Xamarin.Forms.Dependency(typeof(XamaRing.Utility.WinPhone.ImageResizer))]
namespace XamaRing.Utility.WinPhone
{

    public class ImageResizer : DS.IImageResizer
    {
        public ImageResizer()
        {

        }
        public byte[] ResizeImage(byte[] imageData, float width, float height)
        {
            byte[] resizedData;

            using (MemoryStream streamIn = new MemoryStream(imageData))
            {
                WriteableBitmap bitmap = PictureDecoder.DecodeJpeg(streamIn, (int)width, (int)height);

                using (MemoryStream streamOut = new MemoryStream())
                {
                    bitmap.SaveJpeg(streamOut, (int)width, (int)height, 0, 100);
                    resizedData = streamOut.ToArray();
                }
            }
            return resizedData;
        }

        public byte[] ResizeImageFromHeight(byte[] imageData, float height)
        {
            byte[] resizedData;
            using (MemoryStream streamIn = new MemoryStream(imageData))
            {

                WriteableBitmap bitmap = PictureDecoder.DecodeJpeg(streamIn);//, (int)width, (int)height);
                Int32 width = (Int32)((bitmap.PixelWidth * height) / bitmap.PixelHeight);

                using (MemoryStream streamOut = new MemoryStream())
                {
                    bitmap.SaveJpeg(streamOut, width, (Int32)height, 0, 100);
                    resizedData = streamOut.ToArray();
                }
            }
            return resizedData;
        }
        public byte[] ResizeImageFromWidth(byte[] imageData, float width)
        {
            byte[] resizedData;
            using (MemoryStream streamIn = new MemoryStream(imageData))
            {

                WriteableBitmap bitmap = PictureDecoder.DecodeJpeg(streamIn);//, (int)width, (int)height);
                Int32 height = (Int32)((bitmap.PixelHeight * width) / bitmap.PixelHeight);
                using (MemoryStream streamOut = new MemoryStream())
                {
                    bitmap.SaveJpeg(streamOut, (Int32)width, height, 0, 100);
                    resizedData = streamOut.ToArray();
                }
            }
            return resizedData;
        }

        public byte[] ResizeImage(byte[] imageData, Int32 frazione)
        {
            byte[] resizedData;
            using (MemoryStream streamIn = new MemoryStream(imageData))
            {

                WriteableBitmap bitmap = PictureDecoder.DecodeJpeg(streamIn);//, (int)width, (int)height);
                Int32 widthFr = (Int32)(bitmap.PixelWidth / frazione);
                Int32 heightFr = (Int32)(bitmap.PixelHeight / frazione);
                using (MemoryStream streamOut = new MemoryStream())
                {
                    bitmap.SaveJpeg(streamOut, widthFr, heightFr, 0, 100);
                    resizedData = streamOut.ToArray();
                }
            }
            return resizedData;
        }
    }
}
