using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace XamaRing.Utility.WinPhone
{
    public partial class AppBaseWP : Application
    {
         private static bool _initialized;
         public AppBaseWP()
        {
            //SetIoc();
        }
        private void SetIoc()
        {
            //var resolverContainer = new SimpleContainer();

            ////var app = new XFormsAppDroid();

            ////app.Init(this);

            ////var documents = app.AppDataDirectory;
            ////var pathToDatabase = Path.Combine(documents, "xforms.db");

            //resolverContainer.Register<IDevice>(t => WindowsPhoneDevice.CurrentDevice)
            //    .Register<IDisplay>(t => t.Resolve<IDevice>().Display)
            //    .Register<IDependencyContainer>(resolverContainer);



            //Resolver.SetResolver(resolverContainer.GetResolver());

            //_initialized = true;
        }
    }
}
