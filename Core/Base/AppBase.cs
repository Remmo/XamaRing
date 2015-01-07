using Acr.XamForms.Mobile;
using Acr.XamForms.Mobile.Net;
using Acr.XamForms.UserDialogs;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Labs.Services;
using XamaRing.DependencyServices;
using XamaRing;
using XamaRing.DependencyServices.Configs;


namespace XamaRing.Core.Base
{

    public static class AppBase
    {
        public static Boolean IsThemeChanged = false;
        public static bool IsLoggedIn = false;
        public static bool IsInitialized = false;

        private static StyleConfig baseCrossStyle;
        private static StyleConfig pageCrossStyle;

        public static String Token;
        public static IContainer AppContainer;

        public static void SetCrossStyle(StyleConfig cfg)
        {
            baseCrossStyle = cfg;
            pageCrossStyle = cfg;
            CrossTools.ApplyCrossTheme(cfg);
        }

        public static StyleConfig GetCrossStryle()
        {
            pageCrossStyle = baseCrossStyle;
            return pageCrossStyle;
        }

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
            IsInitialized = true;
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
