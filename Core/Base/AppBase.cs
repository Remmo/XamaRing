using Acr.XamForms.Infrastructure;
using Acr.XamForms.Mobile;
using Acr.XamForms.Mobile.Net;
using Acr.XamForms.UserDialogs;
using Acr.XamForms.ViewModels;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamaRing.DependencyServices;
using XamaRing.Utility;


namespace XamarRing.Core.Base
{

    public static class AppBase
    {
        public static bool IsLoggedIn = false;
        public static bool IsInitialized = false;



        public static String Token;
        public static IContainer AppContainer;
        //public static NavigationPage AppNavigator;
        public static Page AppMainPage;

        public static void InitHelpers()
        {
            CrossTools.InitializeUtility();
            Helpers.DeviceInfos.Initialize(AppContainer.Resolve<IDeviceInfo>());
        }



        public static void Init()
        {
            if (IsInitialized)
                return;

            //if (!XamarRing.Base.Helpers.DeviceInfos.IsInitialized)
            //    XamarRing.Base.Helpers.DeviceInfos.Initialize(Xamarin.Forms.Labs.Services.Resolver.Resolve<Xamarin.Forms.Labs.IDevice>());



            IsInitialized = true;
            var builder = new ContainerBuilder()
                //.RegisterViewModels()
                //.RegisterXamDependency<IBarCodeScanner>()
                .RegisterXamDependency<IDeviceInfo>()
                //.RegisterXamDependency<IFileViewer>()
                //.RegisterXamDependency<ILocationService>()
                //.RegisterXamDependency<ILogger>()
                //.RegisterXamDependency<IFileSystem>()
                ////.RegisterXamDependency<IMailService>()
                //.RegisterXamDependency<INetworkService>()
                //.RegisterXamDependency<IPhoneService>()
                //.RegisterXamDependency<IPhotoService>()
                //.RegisterXamDependency<ISettings>()
                //.RegisterXamDependency<ITextToSpeechService>()
                .RegisterXamDependency<IUserDialogService>()
                 .RegisterXamDependency<IMailSender>()
                .RegisterXamDependency<IAddContact>()
                .RegisterXamDependency<ICallNumber>();

            //.RegisterXamDependency<ISignatureService>();

            builder
                .Register(x => new ViewModelResolver(vt => AppContainer.Resolve(vt) as IViewModel))
                .As<IViewModelResolver>()
                .SingleInstance();
            //XamarRing.Base.Helpers.DeviceInfos.Initialize(Resolve<IDeviceInfo>());
            AppContainer = builder.Build();
            InitHelpers();
        }

        public static ContainerBuilder RegisterXamDependency<T>(this ContainerBuilder builder) where T : class
        {
            builder.Register(x => DependencyService.Get<T>()).SingleInstance();
            return builder;
        }
        public static T Resolve<T>() where T : class
        {
            return AppContainer.Resolve<T>();
        }
    }
}
