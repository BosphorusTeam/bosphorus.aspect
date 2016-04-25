using System;
using Bosphorus.Common.Api.CoC.Convention;
using Bosphorus.Common.Api.Container;
using Castle.Facilities.Startable;
using Castle.MicroKernel;
using Castle.MicroKernel.Proxy;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Aspect.Core.Aspect.Applier
{
    public class Installer: IBosphorusInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<IModelInterceptorsSelector>()
                    .ImplementedBy<DefaultModelInterceptorsSelector>()
                    .LifeStyle
                    .Singleton
                    .Start()
                    .OnCreate(OnInterceptorSelectorCreated)
            );
        }

        private void OnInterceptorSelectorCreated(IKernel kernel, IModelInterceptorsSelector item)
        {
            kernel.ProxyFactory.AddInterceptorSelector(item);
        }
    }

}
