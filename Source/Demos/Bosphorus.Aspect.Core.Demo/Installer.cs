using Bosphorus.Aspect.Core.Aspect;
using Bosphorus.Aspect.Default;
using Bosphorus.Aspect.Log;
using Bosphorus.Common.Core.Context;
using Bosphorus.Container.Castle.Registration;
using Bosphorus.Logging.Core;
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
                    .For(typeof(ILogger<ServiceLog>))
                    .ImplementedBy(typeof(MockLogger)),

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
