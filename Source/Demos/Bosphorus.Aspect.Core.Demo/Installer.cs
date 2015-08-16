using Bosphorus.Aspect.Core.Aspect;
using Bosphorus.Aspect.Default;
using Bosphorus.Common.Core.Context;
using Bosphorus.Configuration.Core.Parameter;
using Bosphorus.Container.Castle.Registration;
using Bosphorus.Container.Castle.Registration.Installer;
using Bosphorus.Logging.Console.Logger;
using Bosphorus.Logging.Core.Logger;
using Bosphorus.Serialization.Core.Serializer.Json;
using Bosphorus.Serialization.Default.Serializer.Json;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Aspect.Core.Demo
{
    public class Installer: AbstractWindsorInstaller, IInfrastructureInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                Component
                    .For<IService>()
                    .ImplementedBy<DefaultService>(),

                Component
                    .For<IParameterProvider>()
                    .ImplementedBy<ParameterProvider>(),

                Component
                    .For(typeof(ILogger<>))
                    .ImplementedBy(typeof(ConsoleLogger<>)),

                Component
                    .For(typeof(IJsonSerializer<>))
                    .ImplementedBy(typeof(DefaultJsonSerializer<>)),

                Component
                    .For<IContextProvider<InvocationContext>>()
                    .Forward<InvocationContextProvider>()
                    .ImplementedBy<InvocationContextProvider>()
                    .LifeStyle
                    .PerThread
            );
        }
    }
}
