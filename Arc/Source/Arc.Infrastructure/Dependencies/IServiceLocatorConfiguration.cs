using System;

namespace Arc.Infrastructure.Dependencies
{
    /// <summary>
    /// Configuration for service locator.
    /// </summary>
    public interface IServiceLocatorConfiguration
    {
        /// <summary>
        /// Loads the specified module by name.
        /// It should load module for concrete implementation of service locator.
        /// </summary>
        /// <param name="moduleName">Name of the module.</param>
        void Load(string moduleName);

        /// <summary>
        /// Loads the specified service locator modules by name.
        /// It should load module for concrete implementation of service locator.
        /// </summary>
        /// <param name="moduleNames">The module names.</param>
        void Load(params string[] moduleNames);

        /// <summary>
        /// Loads the specified configuration.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        void Load(IServiceLocatorModule<IServiceLocator> configuration);

        /// <summary>
        /// Registers service to implementation.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        void Register<TService, TImplementation>(); //where TImplementation : TService; NOTE: It can't be mocked because of System.Reflection.Emit bug

        /// <summary>
        /// Registers service to implementation in specified scope.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="scope">The scope.</param>
        void Register<TService, TImplementation>(IScope scope); //where TImplementation : TService; NOTE: It can't be mocked because of System.Reflection.Emit bug

        /// <summary>
        /// Registers service to implementation.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="implementation">The implementation.</param>
        void Register(Type service, Type implementation);

        /// <summary>
        /// Registers service to implementation in specified scope.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="implementation">The implementation.</param>
        /// <param name="scope">The scope.</param>
        void Register(Type service, Type implementation, IScope scope);
    }
}