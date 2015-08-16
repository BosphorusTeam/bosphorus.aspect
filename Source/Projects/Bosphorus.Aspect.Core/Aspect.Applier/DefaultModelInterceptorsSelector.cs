using System.Linq;
using Castle.Core;
using Castle.MicroKernel.Proxy;

namespace Bosphorus.Aspect.Core.Aspect.Applier
{
    internal class DefaultModelInterceptorsSelector : IModelInterceptorsSelector
    {
        private readonly IAspectApplier aspectApplier;

        public DefaultModelInterceptorsSelector(IAspectApplier aspectApplier)
        {
            this.aspectApplier = aspectApplier;
        }

        public bool HasInterceptors(ComponentModel model)
        {
            bool componentIsAspect = typeof (IAspect).IsAssignableFrom(model.Implementation);
            if (componentIsAspect)
            {
                return false;
            }

            bool isApplicable = aspectApplier.IsApplicable(model);
            return isApplicable;
        }

        public InterceptorReference[] SelectInterceptors(ComponentModel model, InterceptorReference[] interceptors)
        {
            AspectRegistry aspectRegistry = new AspectRegistry();
            aspectApplier.Apply(model, aspectRegistry);

            InterceptorReference[] interceptorReferences = aspectRegistry.Aspects
                .Select(serviceAspect => InterceptorReference.ForType(serviceAspect))
                .ToArray();

            return interceptorReferences;
        }
    }
}
