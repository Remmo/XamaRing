using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using System.Drawing;

using System.Text;
using UIKit;
using Xamarin.Forms;
using XamaRing.Utility.iOS;

[assembly: Dependency(typeof(ImageResizer))]
namespace XamaRing.Utility.iOS
{
    [Preserve]
    public class ImageResizer : DS.IImageResizer
    {

        public ImageResizer()
        {
        }

        public byte[] ResizeImageFromWidth(byte[] imageData, float width)
        { 
            UIImage originalImage = ImageFromByteArray(imageData);
            Int32 height = (Int32)((originalImage.Size.Height * width) / originalImage.Size.Width);

            //create a 24bit RGB image
            using (CGBitmapContext context = new CGBitmapContext(IntPtr.Zero,
                (int)width, (int)height, 8,
                (int)(4 * width), CGColorSpace.CreateDeviceRGB(),
                CGImageAlphaInfo.PremultipliedFirst))
            {

                RectangleF imageRect = new RectangleF(0, 0, width, height);

                // draw the image
                context.DrawImage(imageRect, originalImage.CGImage);

                UIImage resizedImage = UIImage.FromImage(context.ToImage());

                // save the image as a jpeg
                return resizedImage.AsJPEG().ToArray();
            }
        }

        public byte[] ResizeImageFromHeight(byte[] imageData, float height)
        {
            UIImage originalImage = ImageFromByteArray(imageData);
            Int32 width = (Int32)((originalImage.Size.Width * height) / originalImage.Size.Height);

            //create a 24bit RGB image
            using (CGBitmapContext context = new CGBitmapContext(IntPtr.Zero,
                (int)width, (int)height, 8,
                (int)(4 * width), CGColorSpace.CreateDeviceRGB(),
                CGImageAlphaInfo.PremultipliedFirst))
            {

                RectangleF imageRect = new RectangleF(0, 0, width, height);

                // draw the image
                context.DrawImage(imageRect, originalImage.CGImage);

               UIImage resizedImage = UIImage.FromImage(context.ToImage());

                // save the image as a jpeg
                return resizedImage.AsJPEG().ToArray();
            }
        }



        public byte[] ResizeImage(byte[] imageData, float width, float height)
        {
            UIImage originalImage = ImageFromByteArray(imageData);

            //create a 24bit RGB image
            using (CGBitmapContext context = new CGBitmapContext(IntPtr.Zero,
                (int)width, (int)height, 8,
                (int)(4 * width), CGColorSpace.CreateDeviceRGB(),
                CGImageAlphaInfo.PremultipliedFirst))
            {

                RectangleF imageRect = new RectangleF(0, 0, width, height);

                // draw the image
                context.DrawImage(imageRect, originalImage.CGImage);

                UIImage resizedImage = UIImage.FromImage(context.ToImage());

                // save the image as a jpeg
                return resizedImage.AsJPEG().ToArray();
            }
        }

        public byte[] ResizeImage(byte[] imageData, Int32 frazione)
        {
            UIImage originalImage = ImageFromByteArray(imageData);
            Int32 widthFr = (Int32)(originalImage.Size.Width / frazione);
            Int32 heightFr = (Int32)(originalImage.Size.Height / frazione);
            //create a 24bit RGB image
            using (CGBitmapContext context = new CGBitmapContext(IntPtr.Zero,
                widthFr, heightFr, 8,
                (int)(4 * widthFr), CGColorSpace.CreateDeviceRGB(),
                CGImageAlphaInfo.PremultipliedFirst))
            {

                RectangleF imageRect = new RectangleF(0, 0, widthFr, widthFr);

                // draw the image
                context.DrawImage(imageRect, originalImage.CGImage);

               UIImage resizedImage =UIImage.FromImage(context.ToImage());

                // save the image as a jpeg
                return resizedImage.AsJPEG().ToArray();
            }
        }

        public static  UIImage ImageFromByteArray(byte[] data)
        {
            if (data == null)
            {
                return null;
            }

            UIImage image;
            try
            {
                image = new UIImage(Foundation.NSData.FromArray(data));
            }
            catch (Exception e)
            {
                Console.WriteLine("Image load failed: " + e.Message);
                return null;
            }
            return image;
        }


    }
}
