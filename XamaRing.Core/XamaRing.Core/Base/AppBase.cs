﻿using Acr.XamForms.Mobile;
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
using XamaRing.DS;
using XamaRing;
using XamaRing.DS.Configs;


//using Acr.XamForms.Infrastructure;
//using Acr.XamForms.ViewModels;


namespace XamaRing.Core.Base
{

    public static class AppBase
    {
        public static Boolean IsLoginRemoved = false;

        public static Boolean IsThemeChanged = false;
        public static bool IsLoggedIn = false;
        public static bool IsInitialized = false;

        private static StyleConfig baseCrossStyle;
        private static StyleConfig pageCrossStyle;

        public static String Token;
        internal static IContainer AppContainer;
        public static NavigationPage AppNavigator;

        public static void SetCrossStyle(StyleConfig cfg)
        {
            baseCrossStyle = cfg;
            pageCrossStyle = cfg;
            CrossTools.ApplyCrossTheme(cfg);
        }

        public static StyleConfig GetCrossStyle()
        {
            pageCrossStyle = baseCrossStyle;
            return pageCrossStyle;
        }
        public static void InitHelpers()
        {
            CrossTools.InitializeUtility(Resolve<INetworkService>(), Resolve<Acr.XamForms.Mobile.Media.IMediaPicker>());
            XamaRing.Core.Helpers.DeviceInfos.Initialize(Resolve<IDeviceInfo>());
        }

        //static SimpleContainer ResContainer;

        public static void Init()
        {
            if (IsInitialized)
                return;

            IsInitialized = true;
            //ResContainer = new SimpleContainer();
            //Resolver.SetResolver(ResContainer.GetResolver());
            //if (InterfacesToRegister == null)
            //{
            ContainerBuilder cont = new ContainerBuilder();
            try
            {
                cont.RegisterXamDependency<INetworkService>();
            }
            catch { }
            try
            {
                cont.RegisterXamDependency<IDeviceInfo>();
            }
            catch (Exception)
            {


            }
            try
            {
                cont.RegisterXamDependency<IUserDialogService>();
            }
            catch (Exception)
            {


            }
            try
            {
                cont.RegisterXamDependency<IMailSender>();
            }
            catch (Exception)
            {


            }
            try
            {
                cont.RegisterXamDependency<IAddContact>();
            }
            catch (Exception)
            {


            }
            try
            {
                cont.RegisterXamDependency<ICallNumber>();
            }
            catch (Exception)
            {


            }
            try
            {
                cont.RegisterXamDependency<IApplyTheme>();
            }
            catch (Exception)
            {


            }
            try
            {
                cont.RegisterXamDependency<Acr.XamForms.Mobile.Media.IMediaPicker>();
            }
            catch (Exception)
            {


            }



            AppContainer = cont
                //.RegisterViewModels()
                //.RegisterXamDependency<IBarCodeScanner>()                
                
                
                
                
                
                
                
                //.RegisterXamDependency<Xamarin.Forms.Labs.Services.ISimpleCache>()
                .Build();




            //}
            //else
            //{
            //    var p = new ContainerBuilder();
            //    foreach (var itf in InterfacesToRegister)
            //    {
            //        Type t = p.RegisterXamDependency<t>(p);

            //    }
            //}

            ////.RegisterXamDependency<ISignatureService>();

            //builder
            //    .Register(x => new ViewModelResolver(vt => AppContainer.Resolve(vt) as IViewModel))
            //    .As<IViewModelResolver>()
            //    .SingleInstance();
            ////XamarRing.Base.Helpers.DeviceInfos.Initialize(Resolve<IDeviceInfo>());

            InitHelpers();
            IsInitialized = true;
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
