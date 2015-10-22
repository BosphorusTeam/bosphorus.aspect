using System;
using Bosphorus.Container.Castle.Registration.Installer;
using Castle.Core;
using Castle.Core.Internal;
using Castle.DynamicProxy;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Handlers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Aspect.Core.Aspect
{
    public class Installer: AbstractWindsorInstaller, IInfrastructureInstaller
    {
        private class GenericImplementationMatchingStrategy : IGenericImplementationMatchingStrategy
        {
            public Type[] GetGenericArguments(ComponentModel model, CreationContext context)
            {
                return new[] { context.RequestedType };
            }
        }

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
                    .BasedOn(typeof(IAspect<>))
                    .WithService
                    .FromInterface()
                    .Configure(ConfigureAspect)
            );
        }

        private void ConfigureAspect(ComponentRegistration componentRegistration)
        {
            componentRegistration.Forward<IInterceptor>();
            componentRegistration.ExtendedProperties(genericImplementationMatchingStrategyProperty);
        }
    }

}
