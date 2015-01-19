using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamaRing.DS.BarCodeScanner;
using XamaRing.DS.Configs;

namespace XamaRing.DS
{
    public interface IMailSender
    {
        void SendMail(List<String> recipients, List<String> recipientsCC, String subject, String body);
    }

    public interface IAddContact
    {
        void AddContact(string FirstName, string LastName, string MobilePhone);

        void AddContact(string FirstName, string LastName, string MobilePhone, string WorkPhone, string HomePhone, string Fax, string Mail);
    }

    public interface ICallNumber
    {
        void CallNumber(string number);
    }
    public interface IImageResizer
    {
        byte[] ResizeImage(byte[] imageData, float width, float height);
        byte[] ResizeImage(byte[] imageData, Int32 frazione);
        byte[] ResizeImageFromHeight(byte[] imageData, float height);
        byte[] ResizeImageFromWidth(byte[] imageData, float width);
    }
    //public interface IBarCodeScanner
    //{
    //    BarCodeScannerConfiguration Configuration { get; }

    //    void Read(Action<BarCodeResult> onRead);
    //    Task<BarCodeResult> ReadAsync();
    //}

    public interface IApplyTheme
    {
        void ApplyTheme(StyleConfig config);
    }

    /// <summary>
    /// Interface for dependency container. Extends on <see cref="IResolver"/> by providing the 
    /// ability to register services.
    /// </summary>
    public interface IDependencyContainer
    {
        /// <summary>
        /// Gets the resolver from the container
        /// </summary>
        /// <returns>An instance of <see cref="IResolver"/></returns>
        IResolver GetResolver();

        /// <summary>
        /// Registers an instance of T to be stored in the container.
        /// </summary>
        /// <typeparam name="T">Type of instance</typeparam>
        /// <param name="instance">Instance of type T.</param>
        /// <returns>An instance of <see cref="IDependencyContainer"/></returns>
        IDependencyContainer Register<T>(T instance) where T : class;

        /// <summary>
        /// Registers a type to instantiate for type T.
        /// </summary>
        /// <typeparam name="T">Type of instance</typeparam>
        /// <typeparam name="TImpl">Type to register for instantiation.</typeparam>
        /// <returns>An instance of <see cref="IDependencyContainer"/></returns>
        IDependencyContainer Register<T, TImpl>()
            where T : class
            where TImpl : class, T;

        /// <summary>
        /// Registers a type to instantiate for type T as singleton.
        /// </summary>
        /// <typeparam name="T">Type of instance</typeparam>
        /// <typeparam name="TImpl">Type to register for instantiation.</typeparam>
        /// <returns>An instance of <see cref="IDependencyContainer"/></returns>
        IDependencyContainer RegisterSingle<T, TImpl>()
            where T : class
            where TImpl : class, T;


        /// <summary>
        /// Tries to register a type
        /// </summary>
        /// <typeparam name="T">Type of instance</typeparam>
        /// <param name="type">Type of implementation</param>
        /// <returns>An instance of <see cref="IDependencyContainer"/></returns>
        IDependencyContainer Register<T>(Type type) where T : class;

        /// <summary>
        /// Tries to register a type
        /// </summary>
        /// <param name="type">Type to register.</param>
        /// <param name="impl">Type that implements registered type.</param>
        /// <returns>An instance of <see cref="IDependencyContainer"/></returns>
        IDependencyContainer Register(Type type, Type impl);

        /// <summary>
        /// Registers a function which returns an instance of type T.
        /// </summary>
        /// <typeparam name="T">Type of instance.</typeparam>
        /// <param name="func">Function which returns an instance of T.</param>
        /// <returns>An instance of <see cref="IDependencyContainer"/></returns>
        IDependencyContainer Register<T>(Func<IResolver, T> func) where T : class;
    }
    /// <summary>
    /// Interface definition for dependency resolver.
    /// </summary>
    public interface IResolver
    {
        /// <summary>
        /// Resolve a dependency.
        /// </summary>
        /// <typeparam name="T">Type of instance to get.</typeparam>
        /// <returns>An instance of {T} if successful, otherwise null.</returns>
        T Resolve<T>() where T : class;

        /// <summary>
        /// Resolve a dependency by type.
        /// </summary>
        /// <param name="type">Type of object.</param>
        /// <returns>An instance to type if found as <see cref="object"/>, otherwise null.</returns>
        object Resolve(Type type);

        /// <summary>
        /// Resolve a dependency.
        /// </summary>
        /// <typeparam name="T">Type of instance to get.</typeparam>
        /// <returns>All instances of {T} if successful, otherwise null.</returns>
        IEnumerable<T> ResolveAll<T>() where T : class;

        /// <summary>
        /// Resolve a dependency by type.
        /// </summary>
        /// <param name="type">Type of object.</param>
        /// <returns>All instances of type if found as <see cref="object"/>, otherwise null.</returns>
        IEnumerable<object> ResolveAll(Type type);

        /// <summary>
        /// Determines whether the specified type is registered.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if the specified type is registered; otherwise, <c>false</c>.</returns>
        bool IsRegistered(Type type);

        /// <summary>
        /// Determines whether this instance is registered.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns><c>true</c> if this instance is registered; otherwise, <c>false</c>.</returns>
        bool IsRegistered<T>() where T : class;
    }
}
