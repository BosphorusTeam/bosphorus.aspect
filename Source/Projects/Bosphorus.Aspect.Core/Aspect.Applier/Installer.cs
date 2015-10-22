using Bosphorus.Container.Castle.Registration;
using Bosphorus.Container.Castle.Registration.Installer;
using Castle.MicroKernel.Proxy;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Aspect.Core.Aspect.Applier
{
    public class Installer: AbstractWindsorInstaller, IInfrastructureInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                Component
                    .For<IModelInterceptorsSelector>()
                    .ImplementedBy<DefaultModelInterceptorsSelector>()
            );

            IModelInterceptorsSelector modelInterceptorsSelector = container.Resolve<IModelInterceptorsSelector>();
            container.Kernel.ProxyFactory.AddInterceptorSelector(modelInterceptorsSelector);
        }
    }

}
