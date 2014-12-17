// Helpers/Settings.cs
using Refractored.Xam.Settings;
using Refractored.Xam.Settings.Abstractions;
using System;

namespace XamarRing.Core.Helpers
{

    public sealed class AuthData
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public String Domain { get; set; }
    }


    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        public static String Username { get; set; }
        public static String Password { get; set; }
        public static String Domain { get; set; }

        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants
        private const string UsernameKey = "Username_key";
        private const string PasswordKey = "Password_key";
        private const string DomainKey = "Domain_key";

        #endregion
        public static Boolean CheckLoginDataKey()
        {
            return AppSettings.GetValueOrDefault<String>(UsernameKey) != default(String);
        }
        //public static AuthData LoginData
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault<AuthData>(LoginDataKey);
        //    }
        //    set
        //    {
        //        //if value has changed then save it!
        //        //if (AppSettings.AddOrUpdateValue(LoginDataKey, value))
        //        AppSettings.AddOrUpdateValue(LoginDataKey, value);
        //        AppSettings.Save();
        //    }
        //}
        public static AuthData GetLoginData()
        {
            return new AuthData
            {
                Username = AppSettings.GetValueOrDefault<String>(UsernameKey),
                Password = AppSettings.GetValueOrDefault<String>(PasswordKey),
                Domain = AppSettings.GetValueOrDefault<String>(DomainKey),
            }; ;
        }
        public static void SaveLoginData(AuthData login)
        {

            AppSettings.AddOrUpdateValue(UsernameKey, login.Username);
            AppSettings.AddOrUpdateValue(PasswordKey, login.Password);
            AppSettings.AddOrUpdateValue(DomainKey, login.Domain);
            AppSettings.Save();
        }


        public static void DeleteLoginData()
        {
            if (CheckLoginDataKey())
            {
                AppSettings.AddOrUpdateValue(UsernameKey, String.Empty);
                AppSettings.AddOrUpdateValue(PasswordKey, String.Empty);
                AppSettings.AddOrUpdateValue(DomainKey, String.Empty);
                AppSettings.Save();
            }
        }
    }
}