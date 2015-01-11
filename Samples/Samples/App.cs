using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Samples
{
    public class App
    {
        public static Page GetMainPage()
        {
            Init();
            return new ContentPage
            {
                Content = new Label
                {
                    Text = "Hello, Forms !",
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                },
            };
        }
        public static void Init()
        {
         
            XamaRing.Core.Base.AppBase.Init();
            //var app = AppBase.Resolve<IXFormsApp>();

            //if (app == null)
            //{
            //    return;
            //}

            //app.Closing += (o, e) => Debug.WriteLine("Application Closing");
            //app.Error += (o, e) => Debug.WriteLine("Application Error");
            //app.Initialize += (o, e) => Debug.WriteLine("Application Initialized");
            //app.Resumed += (o, e) => Debug.WriteLine("Application Resumed");
            //app.Rotation += (o, e) => Debug.WriteLine("Application Rotated");
            //app.Startup += (o, e) => Debug.WriteLine("Application Startup");
            //app.Suspended += (o, e) => Debug.WriteLine("Application Suspended");
        }
    }
}
