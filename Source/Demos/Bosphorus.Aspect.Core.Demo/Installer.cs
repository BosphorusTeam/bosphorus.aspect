using Bosphorus.Aspect.Log;
using Bosphorus.Common.Api.CoC.Convention;
using Bosphorus.Logging.Core.Logger;
using Bosphorus.Serialization.Core.Serializer.Json;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Aspect.Core.Demo
{
    public class Installer: IDemoInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<IService>()
                    .ImplementedBy<DefaultService>(),

                Component
                    .For<ILogger<ServiceLog>>()
                    .ImplementedBy<DemoLogger>(),

                Component
                    .For(typeof(IJsonSerializer<>))
                    .ImplementedBy(typeof(DemoJsonSerializer<>))
            );
        }
    }
}
