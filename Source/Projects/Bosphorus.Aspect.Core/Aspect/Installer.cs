using System;
using Bosphorus.Common.Api.Container;
using Bosphorus.Common.Api.Symbol;
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
    public class Installer: IBosphorusInstaller
    {
        private readonly ITypeProvider typeProvider;

        private class GenericImplementationMatchingStrategy : IGenericImplementationMatchingStrategy
        {
            public Type[] GetGenericArguments(ComponentModel model, CreationContext context)
            {
                return new[] { context.RequestedType };
            }
        }

        private readonly Property genericImplementationMatchingStrategyProperty;

        public Installer(ITypeProvider typeProvider)
        {
            this.typeProvider = typeProvider;
            IGenericImplementationMatchingStrategy genericImplementationMatchingStrategy = new GenericImplementationMatchingStrategy();
            genericImplementationMatchingStrategyProperty = Property.ForKey(Constants.GenericImplementationMatchingStrategy).Eq(genericImplementationMatchingStrategy);
        }

        private void ConfigureAspect(ComponentRegistration componentRegistration)
        {
            componentRegistration.Forward<IInterceptor>();
            componentRegistration.ExtendedProperties(genericImplementationMatchingStrategyProperty);
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.From(typeProvider.LoadedTypes)
                    .BasedOn(typeof(IAspect<>))
                    .WithService
                    .FromInterface()
                    .Configure(ConfigureAspect)
            );
        }
    }

}
