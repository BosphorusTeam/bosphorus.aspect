using System;
using System.Linq;
using Bosphorus.Aspect.Core.Aspect.Applier;
using Bosphorus.Aspect.Default;
using Bosphorus.Aspect.Exception;
using Bosphorus.Aspect.Log;
using Bosphorus.BootStapper.Runner.Console;
using Castle.Core;

namespace Bosphorus.Aspect.Core.Demo
{
    public class AspectApplier : IAspectApplier
    {
        public bool IsApplicable(ComponentModel model)
        {
            Type[] interceptedServices = {typeof(IService), typeof(IProgram)};
            bool any = model.Services.Intersect(interceptedServices).Any();
            return any;
        }

        public void Apply(ComponentModel model, AspectRegistry aspectRegistry)
        {
            aspectRegistry.Register(typeof(IDefaultAspect<>));
            aspectRegistry.Register(typeof(IExceptionAspect<>));
            aspectRegistry.Register(typeof(ILogAspect<>));
        }
    }
}