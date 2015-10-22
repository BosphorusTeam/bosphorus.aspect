using System;
using System.Linq;
using Bosphorus.Aspect.Core.Aspect.Applier.CoC;
using Bosphorus.Common.Core.CoC.Convention;
using Castle.Core;
using Castle.MicroKernel.Proxy;

namespace Bosphorus.Aspect.Core.Aspect.Applier
{
    internal class DefaultModelInterceptorsSelector : IModelInterceptorsSelector
    {
        private readonly IConventionApplier<AspectAcceptance> conventionApplier;

        public DefaultModelInterceptorsSelector(IConventionApplier<AspectAcceptance> conventionApplier)
        {
            this.conventionApplier = conventionApplier;
        }

        public bool HasInterceptors(ComponentModel model)
        {
            bool componentIsAspect = typeof (IAspect).IsAssignableFrom(model.Implementation);
            if (componentIsAspect)
            {
                return false;
            }

            AspectAcceptance aspectAcceptance = new AspectAcceptance(model);
            bool applicable = conventionApplier.IsApplicable<AspectConvention>(aspectAcceptance);
            return applicable;
        }

        public InterceptorReference[] SelectInterceptors(ComponentModel model, InterceptorReference[] interceptors)
        {
            AspectAcceptance aspectAcceptance = new AspectAcceptance(model);
            AspectConvention aspectConvention = new AspectConvention();
            conventionApplier.Apply(aspectAcceptance, aspectConvention);

            InterceptorReference[] interceptorReferences = aspectConvention.Aspects
                .Select(serviceAspect => InterceptorReference.ForType(serviceAspect))
                .ToArray();

            return interceptorReferences;
        }
    }
}
