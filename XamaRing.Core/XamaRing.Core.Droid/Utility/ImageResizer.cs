using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(XamaRing.Utility.Droid.ImageResizer))]
namespace XamaRing.Utility.Droid
{
    public class ImageResizer : Java.Lang.Object, DS.IImageResizer
    {

        //    x: y = z : q 

        //x
        //1024

        //1024 per 5000 / 4000
        Bitmap originalImage ;
        public byte[] ResizeImageFromWidth(byte[] imageData, float width)
        {
            // Load the bitmap
            originalImage = BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length);
            Int32 height = (Int32)((originalImage.Height * width) / originalImage.Width);
            Bitmap resizedImage = Bitmap.CreateScaledBitmap(originalImage, (int)width, (int)height, false);

            using (MemoryStream ms = new MemoryStream())
            {
                resizedImage.Compress(Bitmap.CompressFormat.Jpeg, 100, ms);
                return ms.ToArray();
            }
        }

        public byte[] ResizeImageFromHeight(byte[] imageData, float height)
        {
            // Load the bitmap
            originalImage = BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length);
            Int32 width = (Int32)((originalImage.Width * height) / originalImage.Height);
            Bitmap resizedImage = Bitmap.CreateScaledBitmap(originalImage, (int)width, (int)height, false);

            using (MemoryStream ms = new MemoryStream())
            {
                resizedImage.Compress(Bitmap.CompressFormat.Jpeg, 100, ms);
                return ms.ToArray();
            }
        }
        public byte[] ResizeImage(byte[] imageData, float width, float height)
        {
            // Load the bitmap
            originalImage = BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length);
            Bitmap resizedImage = Bitmap.CreateScaledBitmap(originalImage, (int)width, (int)height, false);

            using (MemoryStream ms = new MemoryStream())
            {
                resizedImage.Compress(Bitmap.CompressFormat.Jpeg, 100, ms);
                return ms.ToArray();
            }
        }

        public byte[] ResizeImage(byte[] imageData, Int32 frazione)
        {
            // Load the bitmap
            originalImage = BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length);
            Bitmap resizedImage = Bitmap.CreateScaledBitmap(originalImage, (int)(originalImage.Width / frazione), (int)(originalImage.Height / frazione), false);

            using (MemoryStream ms = new MemoryStream())
            {
                resizedImage.Compress(Bitmap.CompressFormat.Jpeg, 100, ms);
                return ms.ToArray();
            }
        }
    }
}