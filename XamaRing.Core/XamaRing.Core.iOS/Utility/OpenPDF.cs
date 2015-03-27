using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using XamaRing.Core.iOS.Utility;
using System.IO;
using QuickLook;

[assembly: Dependency(typeof(PdfUtils))]
namespace XamaRing.Core.iOS.Utility
{
    [Preserve]
    public class PdfUtils : DS.IOpenPdf
    {
        public void OpenPdf(string filePath)
        {
            FileInfo fi = new FileInfo(filePath);

            QLPreviewController previewController = new QLPreviewController();
            previewController.DataSource = new PDFPreviewControllerDataSource(fi.FullName, fi.Name);

            UINavigationController controller = FindNavigationController();
            if (controller != null)
                controller.PresentViewController(previewController, true, null);
        }

        private UINavigationController FindNavigationController()
        {
            foreach (var window in UIApplication.SharedApplication.Windows)
            {
                if (window.RootViewController.NavigationController != null)
                    return window.RootViewController.NavigationController;
                else
                {
                    UINavigationController val = CheckSubs(window.RootViewController.ChildViewControllers);
                    if (val != null)
                        return val;
                }
            }

            return null;
        }

        private UINavigationController CheckSubs(UIViewController[] controllers)
        {
            foreach (var controller in controllers)
            {
                if (controller.NavigationController != null)
                    return controller.NavigationController;
                else
                {
                    UINavigationController val = CheckSubs(controller.ChildViewControllers);
                    if (val != null)
                        return val;
                }
            }
            return null;
        }




    }
    public class PDFItem : QLPreviewItem
    {
        string title;
        string uri;

        public PDFItem(string title, string uri)
        {
            this.title = title;
            this.uri = uri;
        }

        public override string ItemTitle
        {
            get { return title; }
        }

        public override NSUrl ItemUrl
        {
            get { return NSUrl.FromFilename(uri); }
        }
    }
    public class PDFPreviewControllerDataSource : QLPreviewControllerDataSource
    {
        string url = "";
        string filename = "";

        public PDFPreviewControllerDataSource(string url, string filename)
        {
            this.url = url;
            this.filename = filename;
        }

        public override IQLPreviewItem GetPreviewItem(QLPreviewController controller, nint index)
        {
            return new PDFItem(filename, url);
        }

        public override nint PreviewItemCount(QLPreviewController controller)
        {
            return 1;
        }

        //public override IQLPreviewItem GetPreviewItem(QLPreviewController controller, nint index)
        //{
        //    throw new NotImplementedException();
        //}
    }
}