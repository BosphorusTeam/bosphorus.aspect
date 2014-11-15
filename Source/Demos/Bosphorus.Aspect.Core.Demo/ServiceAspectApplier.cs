using System;
using System.Linq;
using Bosphorus.Aspect.Core.Aspect.Applier;
using Bosphorus.Aspect.Default;
using Bosphorus.Aspect.Exception;
using Bosphorus.Aspect.Log;
using Bosphorus.BootStapper.Program;
using Castle.Core;

namespace Bosphorus.Aspect.Core.Demo
{
    public class ServiceAspectApplier : IServiceAspectApplier
    {
        public bool IsApplicable(ComponentModel model)
        {
            Type[] interceptedServices = new Type[] {typeof(IService), typeof(IProgram)};
            bool any = model.Services.Intersect(interceptedServices).Any();
            return any;
        }

        public void Apply(ComponentModel model, ServiceAspectRegistry serviceAspectRegistry)
        {
            serviceAspectRegistry.Register(typeof(IDefaultAspect<>));
            serviceAspectRegistry.Register(typeof(IExceptionAspect<>));
            serviceAspectRegistry.Register(typeof(ILogAspect<>));
        }
    }
}