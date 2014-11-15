using Bosphorus.Aspect.Core.Aspect;
using Bosphorus.Aspect.Default;
using Bosphorus.Common.Core.Context;
using Bosphorus.Container.Castle.Registration;
using Bosphorus.Library.Logging.Core;
using Bosphorus.Logging.Database;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Aspect.Core.Demo
{
    public class Installer: AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                Component
                    .For(typeof(ILogger<>))
                    .ImplementedBy(typeof(DatabaseLogger<>)),

                Component
                    .For<IService>()
                    .ImplementedBy<DefaultService>(),

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
