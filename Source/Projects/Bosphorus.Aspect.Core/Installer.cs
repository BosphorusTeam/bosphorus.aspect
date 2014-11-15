using System;
using System.CodeDom.Compiler;
using Bosphorus.Aspect.Core.Aspect;
using Bosphorus.Aspect.Core.Aspect.Applier;
using Bosphorus.Container.Castle.Registration;
using Castle.Core;
using Castle.Core.Internal;
using Castle.DynamicProxy;
using Castle.MicroKernel.Handlers;
using Castle.MicroKernel.Proxy;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Aspect.Core
{
    public class Installer: AbstractWindsorInstaller
    {
        private readonly Property genericImplementationMatchingStrategyProperty;

        public Installer()
        {
            IGenericImplementationMatchingStrategy genericImplementationMatchingStrategy = new GenericImplementationMatchingStrategy();
            genericImplementationMatchingStrategyProperty = Property.ForKey(Constants.GenericImplementationMatchingStrategy).Eq(genericImplementationMatchingStrategy);
        }

        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                allLoadedTypes
                    .BasedOn(typeof(IServiceAspect<>))
                    .WithService
                    .FromInterface()
                    .Configure(ConfigureAspect),

                allLoadedTypes
                    .BasedOn<IServiceAspectApplier>()
                    .WithService
                    .FromInterface(),

                Component
                    .For<IServiceAspectApplier>()
                    .ImplementedBy<CompositeServiceAspectApplier>()
                    .IsDefault(),

                Component
                    .For<IModelInterceptorsSelector>()
                    .ImplementedBy<DefaultModelInterceptorsSelector>()
            );

            IModelInterceptorsSelector modelInterceptorsSelector = container.Resolve<IModelInterceptorsSelector>();
            container.Kernel.ProxyFactory.AddInterceptorSelector(modelInterceptorsSelector);
        }

        private void ConfigureAspect(ComponentRegistration componentRegistration)
        {
            componentRegistration.Forward<IInterceptor>();
            componentRegistration.ExtendedProperties(genericImplementationMatchingStrategyProperty);
        }
    }

}
