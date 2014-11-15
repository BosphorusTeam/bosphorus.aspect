using System.Linq;
using Bosphorus.Aspect.Core.Aspect;
using Bosphorus.Aspect.Core.Aspect.Applier;
using Castle.Core;
using Castle.MicroKernel.Proxy;

namespace Bosphorus.Aspect.Core
{
    public class DefaultModelInterceptorsSelector : IModelInterceptorsSelector
    {
        private readonly IServiceAspectApplier serviceAspectApplier;

        public DefaultModelInterceptorsSelector(IServiceAspectApplier serviceAspectApplier)
        {
            this.serviceAspectApplier = serviceAspectApplier;
        }

        public bool HasInterceptors(ComponentModel model)
        {
            if (typeof (IServiceAspect).IsAssignableFrom(model.Implementation))
            {
                return false;
            }

            bool isApplicable = serviceAspectApplier.IsApplicable(model);
            return isApplicable;
        }

        public InterceptorReference[] SelectInterceptors(ComponentModel model, InterceptorReference[] interceptors)
        {
            ServiceAspectRegistry serviceAspectRegistry = new ServiceAspectRegistry();
            serviceAspectApplier.Apply(model, serviceAspectRegistry);

            InterceptorReference[] interceptorReferences = serviceAspectRegistry.Aspects
                .Select(serviceAspect => InterceptorReference.ForType(serviceAspect))
                .ToArray();

            return interceptorReferences;
        }
    }
}
